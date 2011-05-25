

#include "stdafx.h"
#include "VMR_Capture.h"

#define SAFE_RELEASE(x) { if (x) x->Release(); x = NULL; }

//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////
CVMR_Capture::CVMR_Capture()
{
	CoInitialize(NULL);
	m_pGB = NULL;
	m_pMC = NULL;
	m_pME = NULL;			
	m_pWC = NULL;		
	m_pDF =NULL;
	m_pCamOutPin =NULL;
	m_pFrame=NULL;
	m_nFramelen=0;

	m_psCurrent=Stopped;
}

CVMR_Capture::~CVMR_Capture()
{
	CloseInterfaces();
	CoUninitialize( );
}
HRESULT CVMR_Capture::Init(int iDeviceID,HWND hWnd, int iWidth, int iHeight)
{
	HRESULT hr;
	hr=CoCreateInstance(CLSID_FilterGraph, NULL, CLSCTX_INPROC_SERVER, 
		IID_IGraphBuilder, (void **)&m_pGB);

	if(SUCCEEDED(hr))
	{
		InitializeWindowlessVMR(hWnd);        
		if(!BindFilter(iDeviceID, &m_pDF))
			return S_FALSE;

		hr=m_pGB->AddFilter(m_pDF, L"Video Capture");
		if (FAILED(hr))
			return hr;

		CComPtr<IEnumPins> pEnum;
		m_pDF->EnumPins(&pEnum);

		hr = pEnum->Reset();
		hr = pEnum->Next(1, &m_pCamOutPin, NULL); 



		// QueryInterface for DirectShow interfaces
		hr = m_pGB->QueryInterface(IID_IMediaControl, (void **)&m_pMC);

		hr = m_pGB->QueryInterface(IID_IMediaEventEx, (void **)&m_pME);     

		// Have the graph signal event via window callbacks for performance
		//hr = pME->SetNotifyWindow((OAHWND)hWnd, WM_GRAPHNOTIFY, 0);


		hr = InitVideoWindow(hWnd,iWidth, iHeight);

		m_nFramelen=iWidth*iHeight*3;
		m_pFrame=(BYTE*) new BYTE[m_nFramelen];		



		// Run the graph to play the media file

		m_psCurrent=Stopped;

		hr = m_pGB->Render(m_pCamOutPin);
		hr = m_pMC->Run();
		m_psCurrent=Running;


	}
	return hr;

}


HRESULT CVMR_Capture::InitializeWindowlessVMR(HWND hWnd)
{
	IBaseFilter* pVmr = NULL;

	// Create the VMR and add it to the filter graph.
	HRESULT hr = CoCreateInstance(CLSID_VideoMixingRenderer, NULL,
		CLSCTX_INPROC, IID_IBaseFilter, (void**)&pVmr);
	if (SUCCEEDED(hr)) 
	{
		hr = m_pGB->AddFilter(pVmr, L"Video Mixing Renderer");
		if (SUCCEEDED(hr)) 
		{
			// Set the rendering mode and number of streams.  
			IVMRFilterConfig* pConfig;

			hr = pVmr->QueryInterface(IID_IVMRFilterConfig, (void**)&pConfig);
			if( SUCCEEDED(hr)) 
			{
				pConfig->SetRenderingMode(VMRMode_Windowless);
				pConfig->Release();
			}

			hr = pVmr->QueryInterface(IID_IVMRWindowlessControl, (void**)&m_pWC);
			if( SUCCEEDED(hr)) 
			{
				m_pWC->SetVideoClippingWindow(hWnd);

			}
		}
		pVmr->Release();
	}

	return hr;
}

bool CVMR_Capture::BindFilter(int deviceId, IBaseFilter **pFilter)
{
	if (deviceId < 0)
		return false;

	// enumerate all video capture devices
	CComPtr<ICreateDevEnum> pCreateDevEnum;
	HRESULT hr = CoCreateInstance(CLSID_SystemDeviceEnum, NULL, CLSCTX_INPROC_SERVER,
		IID_ICreateDevEnum, (void**)&pCreateDevEnum);
	if (hr != NOERROR)
	{

		return false;
	}

	CComPtr<IEnumMoniker> pEm;
	hr = pCreateDevEnum->CreateClassEnumerator(CLSID_VideoInputDeviceCategory,
		&pEm, 0);
	if (hr != NOERROR) 
	{
		return false;
	}

	pEm->Reset();
	ULONG cFetched;
	IMoniker *pM;
	int index = 0;
	while(hr = pEm->Next(1, &pM, &cFetched), hr==S_OK, index <= deviceId)
	{
		IPropertyBag *pBag;
		hr = pM->BindToStorage(0, 0, IID_IPropertyBag, (void **)&pBag);
		if(SUCCEEDED(hr)) 
		{
			VARIANT var;
			var.vt = VT_BSTR;
			hr = pBag->Read(L"FriendlyName", &var, NULL);
			if (hr == NOERROR) 
			{
				if (index == deviceId)
				{
					pM->BindToObject(0, 0, IID_IBaseFilter, (void**)pFilter);
				}
				SysFreeString(var.bstrVal);
			}
			pBag->Release();
		}
		pM->Release();
		index++;
	}
	return true;
}

HRESULT CVMR_Capture::InitVideoWindow(HWND hWnd,int width, int height)
{


	HRESULT hr;
	RECT rcDest;

	CComPtr<IAMStreamConfig> pConfig;
	IEnumMediaTypes *pMedia;
	AM_MEDIA_TYPE *pmt = NULL, *pfnt = NULL;

	hr = m_pCamOutPin->EnumMediaTypes( &pMedia );
	if(SUCCEEDED(hr))
	{

		while(pMedia->Next(1, &pmt, 0) == S_OK)
		{
			if( pmt->formattype == FORMAT_VideoInfo )
			{
				VIDEOINFOHEADER *vih = (VIDEOINFOHEADER *)pmt->pbFormat;
				// printf("Size %i  %i\n", vih->bmiHeader.biWidth, vih->bmiHeader.biHeight );
				if( vih->bmiHeader.biWidth == width && vih->bmiHeader.biHeight == height )
				{
					pfnt = pmt;

					// printf("found mediatype with %i %i\n", vih->bmiHeader.biWidth, vih->bmiHeader.biHeight );
					//char test[100];
					//sprintf(test,"Width=%d\nHeight=%d",vih->bmiHeader.biWidth, vih->bmiHeader.biHeight);
					//MessageBox(test);
					break;
				}
				DeleteMediaType( pmt );
			}                        
		}
		pMedia->Release();
	}
	hr = m_pCamOutPin->QueryInterface( IID_IAMStreamConfig, (void **) &pConfig );
	if(SUCCEEDED(hr))
	{
		if( pfnt != NULL )
		{
			hr=pConfig->SetFormat( pfnt );

			//if(SUCCEEDED(hr))        
			//MessageBox("OK");

			DeleteMediaType( pfnt );
		}
		hr = pConfig->GetFormat( &pfnt );
		if(SUCCEEDED(hr))
		{

			m_nWidth = ((VIDEOINFOHEADER *)pfnt->pbFormat)->bmiHeader.biWidth;
			m_nHeight = ((VIDEOINFOHEADER *)pfnt->pbFormat)->bmiHeader.biHeight;

			DeleteMediaType( pfnt );
		}
	}
	::GetClientRect (hWnd,&rcDest);
	hr = m_pWC->SetVideoPosition(NULL, &rcDest);
	return hr;
}

void CVMR_Capture::StopCapture()
{
	HRESULT hr;

	if((m_psCurrent == Paused) || (m_psCurrent == Running))
	{
		LONGLONG pos = 0;
		hr = m_pMC->Stop();
		m_psCurrent = Stopped;		
		// Display the first frame to indicate the reset condition
		hr = m_pMC->Pause();
	}



}

void CVMR_Capture::CloseInterfaces(void)
{
	HRESULT hr;


	// Stop media playback
	if(m_pMC)
		hr = m_pMC->Stop();	    
	m_psCurrent = Stopped;  


	if(m_pCamOutPin)
		m_pCamOutPin->Disconnect ();


	SAFE_RELEASE(m_pCamOutPin);        
	SAFE_RELEASE(m_pMC);    
	SAFE_RELEASE(m_pGB);    
	SAFE_RELEASE(m_pWC);	
	SAFE_RELEASE(m_pDF);





	//delete allocated memory 
	if(m_pFrame!=NULL)
		delete []m_pFrame;

}

//Capture RAW IMAGE BITS 24bits/pixel
DWORD CVMR_Capture::ImageCaptureEx(int xdpi,int ydpi,LPCTSTR szFile)
{
	//AfxMessageBox("ImageCapture��");
	BYTE *pImage;

	DWORD dwSize,dwWritten;
	dwSize=this->GrabFrame ();
	this->GetFrame (&pImage);

	HANDLE hFile = CreateFile(szFile, GENERIC_WRITE, FILE_SHARE_READ, NULL,
		CREATE_ALWAYS, FILE_ATTRIBUTE_NORMAL, 0);

	if (hFile == INVALID_HANDLE_VALUE)

		return FALSE;
	// д�ļ�ͷ 
	BITMAPFILEHEADER bfh;
	memset(&bfh,0,sizeof(bfh));
	bfh.bfType ='MB';
	bfh.bfSize = sizeof( bfh ) +m_nFramelen+ sizeof( BITMAPINFOHEADER );
	bfh.bfOffBits = sizeof( BITMAPINFOHEADER ) + sizeof( BITMAPFILEHEADER );
	WriteFile(hFile,&bfh,sizeof( bfh ),&dwWritten, NULL );

	//д�ļ���ʽ
	BITMAPINFOHEADER bih;
	memset( &bih, 0, sizeof( bih ) );
	bih.biSize = sizeof( bih );
	bih.biWidth =m_nWidth;
	bih.biHeight =m_nHeight;
	bih.biPlanes = 1;
	bih.biBitCount =24;
	bih.biCompression=BI_RGB;
	bih.biXPelsPerMeter=xdpi* 10000 / 254;
	bih.biYPelsPerMeter=ydpi* 10000 / 254;

	//bih.biClrImportant

	//AfxMessageBox("��ʼд���ļ���");
	WriteFile(hFile, &bih, sizeof( bih ), &dwWritten, NULL );
	//AfxMessageBox("д���ļ��ɹ���");
	//��תͼ��
	BYTE*ptr,*pTemp;
	BYTE* ptr1=new BYTE[m_nFramelen];
	pTemp=pImage;
	ptr=ptr1+m_nFramelen-1;
	for (DWORD index = 0; index<m_nFramelen/3; index++)
	{									
		unsigned char r = *(pTemp++);
		unsigned char g = *(pTemp++);
		unsigned char b = *(pTemp++);

		*(ptr--) = b;
		*(ptr--) = g;
		*(ptr--) = r;			

	}

	WriteFile(hFile,(LPCVOID)ptr1,m_nFramelen, &dwWritten, 0);
	// Close the file
	CloseHandle(hFile);

	delete [] ptr1;

	return dwWritten;
}


//Capture RAW IMAGE BITS 24bits/pixel
DWORD CVMR_Capture::ImageCapture(LPCTSTR szFile)
{
	BYTE *pImage;

	DWORD dwSize,dwWritten;
	dwSize=this->GrabFrame ();
	this->GetFrame (&pImage);

	HANDLE hFile = CreateFile(szFile, GENERIC_WRITE, FILE_SHARE_READ, NULL,
		CREATE_ALWAYS, FILE_ATTRIBUTE_NORMAL, 0);

	if (hFile == INVALID_HANDLE_VALUE)

		return FALSE;
	// д�ļ�ͷ 
	BITMAPFILEHEADER bfh;
	memset(&bfh,0,sizeof(bfh));
	bfh.bfType ='MB';
	bfh.bfSize = sizeof( bfh ) +m_nFramelen+ sizeof( BITMAPINFOHEADER );
	bfh.bfOffBits = sizeof( BITMAPINFOHEADER ) + sizeof( BITMAPFILEHEADER );
	WriteFile(hFile,&bfh,sizeof( bfh ),&dwWritten, NULL );

	//д�ļ���ʽ
	BITMAPINFOHEADER bih;
	memset( &bih, 0, sizeof( bih ) );
	bih.biSize = sizeof( bih );
	bih.biWidth =m_nWidth;
	bih.biHeight =m_nHeight;
	bih.biPlanes = 1;
	bih.biBitCount =24;
	bih.biCompression=BI_RGB;
	//bih.biClrImportant

	WriteFile(hFile, &bih, sizeof( bih ), &dwWritten, NULL );
	//��תͼ��
	BYTE*ptr,*pTemp;
	BYTE* ptr1=new BYTE[m_nFramelen];
	pTemp=pImage;
	ptr=ptr1+m_nFramelen-1;
	for (DWORD index = 0; index<m_nFramelen/3; index++)
	{									
		unsigned char r = *(pTemp++);
		unsigned char g = *(pTemp++);
		unsigned char b = *(pTemp++);

		*(ptr--) = b;
		*(ptr--) = g;
		*(ptr--) = r;			

	}

	WriteFile(hFile,(LPCVOID)ptr1,m_nFramelen, &dwWritten, 0);
	// Close the file
	CloseHandle(hFile);

	delete [] ptr1;

	return dwWritten;
}

void CVMR_Capture::DeleteMediaType(AM_MEDIA_TYPE *pmt)
{
	// allow NULL pointers for coding simplicity

	if (pmt == NULL) {
		return;
	}

	if (pmt->cbFormat != 0) {
		CoTaskMemFree((PVOID)pmt->pbFormat);

		// Strictly unnecessary but tidier
		pmt->cbFormat = 0;
		pmt->pbFormat = NULL;
	}
	if (pmt->pUnk != NULL) {
		pmt->pUnk->Release();
		pmt->pUnk = NULL;
	}

	CoTaskMemFree((PVOID)pmt);
}


DWORD CVMR_Capture::GrabFrame()
{
	long lOut=-1;
	if(m_pWC ) 
	{
		BYTE* lpCurrImage = NULL;

		// Read the current video frame into a byte buffer.  The information
		// will be returned in a packed Windows DIB and will be allocated
		// by the VMR.
		if(m_pWC->GetCurrentImage(&lpCurrImage) == S_OK)
		{

			LPBITMAPINFOHEADER  pdib = (LPBITMAPINFOHEADER) lpCurrImage;

			if(m_pFrame==NULL || (pdib->biHeight * pdib->biWidth * 3) !=m_nFramelen )
			{
				if(m_pFrame!=NULL)
					delete []m_pFrame;

				m_nFramelen=pdib->biHeight * pdib->biWidth * 3;
				m_pFrame=(BYTE*)new BYTE [pdib->biHeight * pdib->biWidth * 3] ;


			}			

			if(pdib->biBitCount ==32) 
			{
				DWORD  dwSize=0, dwWritten=0;			

				BYTE *pTemp32;
				pTemp32=lpCurrImage + sizeof(BITMAPINFOHEADER);

				//change from 32 to 24 bit /pixel
				this->Convert24Image(pTemp32, m_pFrame, pdib->biSizeImage);

			}

			CoTaskMemFree(lpCurrImage);	//free the image 
		}
		else
		{
			return lOut;
		}

	}
	else
	{
		return lOut;
	}




	return lOut=m_nFramelen;

}

bool CVMR_Capture::Convert24Image(BYTE *p32Img, BYTE *p24Img,DWORD dwSize32)
{

	if(p32Img != NULL && p24Img != NULL && dwSize32>0)
	{

		DWORD dwSize24;

		dwSize24=(dwSize32 * 3)/4;

		BYTE *pTemp,*ptr;
		//pTemp=p32Img + sizeof(BITMAPINFOHEADER); ;
		pTemp=p32Img;

		ptr=p24Img + dwSize24-1 ;

		int ival=0;

		for (DWORD index = 0; index < dwSize32/4 ; index++)
		{									
			unsigned char r = *(pTemp++);
			unsigned char g = *(pTemp++);
			unsigned char b = *(pTemp++);
			(pTemp++);//skip alpha

			*(ptr--) = b;
			*(ptr--) = g;
			*(ptr--) = r;			

		}


	}
	else
	{
		return false;
	}

	return true;
}

BOOL CVMR_Capture::Pause()
{	
	if (!m_pMC)
		return FALSE;


	if(((m_psCurrent == Paused) || (m_psCurrent == Stopped)) )
	{
		this->StopCapture();
		if (SUCCEEDED(m_pMC->Run()))
			m_psCurrent = Running;

	}
	else
	{
		if (SUCCEEDED(m_pMC->Pause()))
			m_psCurrent = Paused;
	}

	return TRUE;
}



DWORD CVMR_Capture::GetFrame(BYTE **pFrame)
{
	if(m_pFrame && m_nFramelen)
	{
		*pFrame=m_pFrame;
	}


	return m_nFramelen;
}

int  CVMR_Capture::EnumDevices(HWND hList)
{
	if (!hList)
		return  -1;


	int id = 0;

	// enumerate all video capture devices
	CComPtr<ICreateDevEnum> pCreateDevEnum;
	//    ICreateDevEnum *pCreateDevEnum;
	HRESULT hr = CoCreateInstance(CLSID_SystemDeviceEnum, NULL, CLSCTX_INPROC_SERVER,
		IID_ICreateDevEnum, (void**)&pCreateDevEnum);
	if (hr != NOERROR)
	{

		return -1;
	}



	CComPtr<IEnumMoniker> pEm;
	hr = pCreateDevEnum->CreateClassEnumerator(CLSID_VideoInputDeviceCategory,
		&pEm, 0);
	if (hr != NOERROR) 
	{

		return -1 ;
	}

	pEm->Reset();
	ULONG cFetched;
	IMoniker *pM;
	while(hr = pEm->Next(1, &pM, &cFetched), hr==S_OK)
	{
		IPropertyBag *pBag;
		hr = pM->BindToStorage(0, 0, IID_IPropertyBag, (void **)&pBag);
		if(SUCCEEDED(hr)) 
		{
			VARIANT var;
			var.vt = VT_BSTR;
			hr = pBag->Read(L"FriendlyName", &var, NULL);
			if (hr == NOERROR) 
			{
				TCHAR str[2048];		


				id++;
				WideCharToMultiByte(CP_ACP,0,var.bstrVal, -1, str, 2048, NULL, NULL);


				(long)SendMessage(hList, CB_ADDSTRING, 0,(LPARAM)str);

				SysFreeString(var.bstrVal);
			}
			pBag->Release();
		}
		pM->Release();
	}
	return id;
}



