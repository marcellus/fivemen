

#if !defined(AFX_VMR_CAPTURE_H__186091F3_30FA_4FAA_AC8B_EF25E8463B9A__INCLUDED_)
#define AFX_VMR_CAPTURE_H__186091F3_30FA_4FAA_AC8B_EF25E8463B9A__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#include <atlbase.h>
#include <dshow.h>
#include <d3d9.h>
#include <vmr9.h>

//#define WM_GRAPHNOTIFY  WM_USER+13
enum PLAYSTATE {Stopped, Paused, Running, Init};


class CVMR_Capture  
{
public:

	CVMR_Capture();
	int EnumDevices(HWND hList);
	HRESULT Init(int iDeviceID,HWND hWnd,int iWidth,int iHeight);
	DWORD GetFrame(BYTE ** pFrame);
	BOOL Pause();
	DWORD ImageCapture(LPCTSTR szFile);
	DWORD ImageCaptureEx(int xdpi,int ydpi,LPCTSTR szFile);
	DWORD GrabFrame();

	virtual ~CVMR_Capture();


protected:

	IGraphBuilder *m_pGB ;
	IMediaControl *m_pMC;
	IMediaEventEx *m_pME ;
	//IMediaEvent *pME ;


	IVMRWindowlessControl9 *m_pWC;
	IPin * m_pCamOutPin;
	IBaseFilter *m_pDF;

	PLAYSTATE m_psCurrent;

	int m_nWidth;
	int m_nHeight;

	BYTE *m_pFrame;
	long m_nFramelen;


	bool BindFilter(int deviceId, IBaseFilter **pFilter);
	HRESULT InitializeWindowlessVMR(HWND hWnd);
	HRESULT InitVideoWindow(HWND hWnd,int width, int height);
	void StopCapture();
	void CloseInterfaces(void);

	void DeleteMediaType(AM_MEDIA_TYPE *pmt);
	bool Convert24Image(BYTE *p32Img,BYTE *p24Img,DWORD dwSize32);



private:

};

#endif // !defined(AFX_VMR_CAPTURE_H__186091F3_30FA_4FAA_AC8B_EF25E8463B9A__INCLUDED_)
