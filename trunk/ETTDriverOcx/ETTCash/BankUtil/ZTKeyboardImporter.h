#pragma once
#ifndef _ZTKEYBOARDIMPORTER_H
#define _ZTKEYBOARDIMPORTER_H

//---------------------------------------------------------------------------
//’˛Õ®Ω Ù√‹¬Îº¸≈Ã
//---------------------------------------------------------------------------
extern	short (__stdcall* ZT_EPP_OpenCom)(short,long);
extern	short (__stdcall* ZT_EPP_CloseCom)();
extern	short (__stdcall* ZT_EPP_PinReadVersion)(char *,char *,char *);
extern	short (__stdcall* ZT_EPP_PinLoadMasterKey)(int , short ,unsigned char *, char *);
extern	short (__stdcall* ZT_EPP_SetDesPara)(short, short);
extern	short (__stdcall* ZT_EPP_PinLoadWorkKey)(int , short ,short,unsigned char *, char * );
extern	short (__stdcall* ZT_EPP_Des)(char *, char *, char *);
extern	short (__stdcall* ZT_EPP_ActivWorkPin)(short ,short );
extern	short (__stdcall* ZT_EPP_PinStartAdd)( short, short, short, short, short);
extern	short (__stdcall* ZT_EPP_PinLoadCardNo)(char *);
extern	short (__stdcall* ZT_EPP_OpenKeyVoic)( short );
extern	short (__stdcall* ZT_EPP_PinReportPressed)(char *, int );
extern	short (__stdcall* ZT_EPP_PinReadPin)(int,unsigned char *);
extern	short (__stdcall* ZT_EPP_Undes)(char *,char *,char *);
extern	void  (__stdcall* ZT_EPP_DllSplitBcd)(unsigned char *,unsigned char *,int);
extern	short (__stdcall* ZT_EPP_PinCalMAC)( int, int ,char *,char *);
extern	short (__stdcall* PinGenerateMAC)(char *,char *);
extern	short (__stdcall* ZT_EPP_PinAdd)(int,int ,char *, char *);
extern  short (__stdcall* ZT_EPP_PinUnAdd)(int,int,char *, char *);
extern	short (__stdcall* ZT_EPP_PinInitialization)( int );
extern	short (__stdcall* ZT_EPP_TerminalNum)( char *, char * );
extern	short (__stdcall* ZT_EPP_ICOnPower)( char * );
extern	short (__stdcall* ZT_EPP_ICDownPower)( );
extern	short (__stdcall* ZT_EPP_ICControl)( char *,char * );
extern	short (__stdcall* ZT_EPP_SetICType)( int, int );
extern	short (__stdcall* ZT_EPP_ReadICType)( int, char * );
//  
#endif