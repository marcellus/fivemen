#if !defined( CONVERT_H)
#define CONVERT_H

#include <stdlib.h>

/*----------------------------------------------------------------------------*
 * ����: ת��ǰ����Ϊ�ո�.
 * ����:
 *       unsigned char *buf - ����.
 *       int len - ���ݳ���.
 * ����: 
 *       ��.
 * ˵��:
 *----------------------------------------------------------------------------*/
void ConvertToLeadingSpaces(unsigned char *buf,int len);

/*----------------------------------------------------------------------------*
 * ����: ת��ǰ���ո�Ϊ��.
 * ����:
 *       unsigned char *buf - ����.
 *       int len - ���ݳ���.
 * ����: 
 *       ��.
 * ˵��:
 *----------------------------------------------------------------------------*/
void ConvertToLeadingZeroes(unsigned char *buf,int len);

/*----------------------------------------------------------------------------*
 * ����: ��ѹ����ת��Ϊascii��(ͬ BcdToAsc() һ��).
 * ����:
 *       unsigned char *ascii_buf - ת�����ascii��.
 *       unsigned char *hex_buf - Ҫת����bcd��.
 *       int ascii_len - ascii���ݳ���(ת���󳤶�).
 * ����: 
 *       ��.
 * ˵��:
 *      ��"\x23\x45"ת��Ϊ"2345","\xAB\x1d"Ϊ"AB1D".
 *----------------------------------------------------------------------------*/
void HexToAsc(unsigned char *ascii_buf,unsigned char *hex_buf,int ascii_len);

/*----------------------------------------------------------------------------*
 * ����: ��bcd��ת��Ϊascii��(ͬ BcdToAsc() һ��).
 * ����:
 *       unsigned char *ascii_buf - ת�����ascii��.
 *       unsigned char *bcd_buf - Ҫת����bcd��.
 *       int ascii_len - ascii���ݳ���(ת���󳤶�).
 * ����: 
 *       ��.
 * ˵��:
 *      ��"\x23\x45"ת��Ϊ"2345","\xAB\x1d"Ϊ"AB1D".
 *----------------------------------------------------------------------------*/
void BcdToAsc(unsigned char *ascii_buf,unsigned char *bcd_buf,int ascii_len);

/*----------------------------------------------------------------------------*
 * ����: ��ascii��ת��Ϊѹ����(ͬ AscToBcd() һ��).
 * ����:
 *       unsigned char *hex_buf - ת�����bcd��.
 *       unsigned char *ascii_buf - Ҫת����ascii��.
 *       int ascii_len - ascii���ݳ���(ת��ǰ����).
 * ����: 
 *       ��.
 * ˵��:
 *      �������������,���ں������0.
 *      ��"2345"ת��Ϊ"\x23\x45","B1D"Ϊ"\xB1\xD0".
 *----------------------------------------------------------------------------*/
void AscToHex(unsigned char *hex_buf,unsigned char *ascii_buf,int ascii_len);

/*----------------------------------------------------------------------------*
 * ����: ��ascii��ת��Ϊѹ����(ͬ AscToHex() һ��).
 * ����:
 *       unsigned char *hex_buf - ת�����bcd��.
 *       unsigned char *ascii_buf - Ҫת����ascii��.
 *       int ascii_len - ascii���ݳ���(ת��ǰ����).
 * ����: 
 *       ��.
 * ˵��:
 *      �������������,���ں������0.
 *      ��"2345"ת��Ϊ"\x23\x45","B1D"Ϊ"\xB1\xd0".
 *----------------------------------------------------------------------------*/
void AscToBcd(unsigned char *bcd_buf,unsigned char *ascii_buf,int ascii_len);

/*----------------------------------------------------------------------------*
 * ����: ��bcd��ת��Ϊ32λ�ĳ�����.
 * ����:
 *       unsigned char *bcd_buf - Ҫת����bcd��.
 *       int bcd_len - bcd���ݳ���.
 * ����: 
 *       unsigned long - ת����Ľ��.
 * ˵��:
 *      �� bcd_len=2, \x01 \x23 -> 123
 *         bcd_len=2, \x12 \x30 -> 1230
 *----------------------------------------------------------------------------*/
unsigned long BcdToBin(unsigned char *bcd_buf,int bcd_len);

/*----------------------------------------------------------------------------*
 * ����: ��32λ�ĳ�����ת��Ϊbcd��.
 * ����:
 *       unsigned char *bcd_buf - ת�����bcd��.
 *       long *bin - Ҫת��������.
 *       int bcd_len - ת�����bcd���ݳ���.
 * ����: 
 *       unsigned long - ת����Ľ��.
 * ˵��:
 *      �� bcd_len=2, 123  -> \x01 \x23
 *         bcd_len=2, 1230 -> \x12 \x30
 *----------------------------------------------------------------------------*/
void BinToBcd(unsigned char *bcd_buf,long bin,int bcd_len);

/*----------------------------------------------------------------------------*
 * ����: ��ascii��ת��Ϊ32λ�ĳ�����.
 * ����:
 *       unsigned char *ascii_buf - Ҫת����ascii��.
 *       int ascii_len - ת�����ascii���ݳ���.
 * ����: 
 *       unsigned long - ת����Ľ��.
 * ˵��:
 *      �� "0123"  -> 123
 *----------------------------------------------------------------------------*/
unsigned long AscToBin(unsigned char *ascii_buf,int ascii_len);

/*----------------------------------------------------------------------------*
 * ����: ��32λ�ĳ�����ת��Ϊascii��.
 * ����:
 *       unsigned char *ascii_buf - ת�����ascii��.
 *       unsigned long - Ҫת���ĳ�����.
 *       int ascii_len - ת�����ascii���ݳ���.
 * ����: 
 *       ��.
 * ˵��:
 *      �� 123  -> "0123"
 *----------------------------------------------------------------------------*/
void BinToAsc(unsigned char *ascii_buf,unsigned long bin,int ascii_len);

/*----------------------------------------------------------------------------*
 * ����: ��ascii��ת��Ϊebcd��.
 * ����:
 *       unsigned char *ebcd_buf - ת�����ebcd��.
 *       unsigned char *asc_buf - Ҫת�����ascii��.
 *       int asc_len - Ҫת����ascii���ݳ���.
 * ����: 
 *       ��.
 * ˵��:
 *----------------------------------------------------------------------------*/
void AscToEBcd(unsigned char *ebcd_buf,unsigned char *asc_buf,int asc_len);

/*----------------------------------------------------------------------------*
 * ����: ��ebcd��ת��Ϊascii��.
 * ����:
 *       unsigned char *asc_buf - ת�����ascii��.
 *       unsigned char *ebcd_buf - Ҫת����ebcd��.
 *       int ebcd_len - Ҫת����ebc���ݳ���.
 * ����: 
 *       ��.
 * ˵��:
 *----------------------------------------------------------------------------*/
void EBcdToAsc(unsigned char *asc_buf,unsigned char *ebcd_buf,int ebcd_len);

CString Convert2Hex(LPCTSTR p,int nLen);
char* str2hex(const char* str);
char* hex2str(const char* hex);
char *itoa_hex(unsigned int data,char * hbuff,int len);

int htoi(char s[]);

#endif
