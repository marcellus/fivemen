#if !defined( CONVERT_H)
#define CONVERT_H

#include <stdlib.h>

/*----------------------------------------------------------------------------*
 * 功能: 转换前导零为空格.
 * 参数:
 *       unsigned char *buf - 数据.
 *       int len - 数据长度.
 * 返回: 
 *       无.
 * 说明:
 *----------------------------------------------------------------------------*/
void ConvertToLeadingSpaces(unsigned char *buf,int len);

/*----------------------------------------------------------------------------*
 * 功能: 转换前导空格为零.
 * 参数:
 *       unsigned char *buf - 数据.
 *       int len - 数据长度.
 * 返回: 
 *       无.
 * 说明:
 *----------------------------------------------------------------------------*/
void ConvertToLeadingZeroes(unsigned char *buf,int len);

/*----------------------------------------------------------------------------*
 * 功能: 把压缩码转换为ascii码(同 BcdToAsc() 一样).
 * 参数:
 *       unsigned char *ascii_buf - 转换后的ascii码.
 *       unsigned char *hex_buf - 要转换的bcd码.
 *       int ascii_len - ascii数据长度(转换后长度).
 * 返回: 
 *       无.
 * 说明:
 *      如"\x23\x45"转换为"2345","\xAB\x1d"为"AB1D".
 *----------------------------------------------------------------------------*/
void HexToAsc(unsigned char *ascii_buf,unsigned char *hex_buf,int ascii_len);

/*----------------------------------------------------------------------------*
 * 功能: 把bcd码转换为ascii码(同 BcdToAsc() 一样).
 * 参数:
 *       unsigned char *ascii_buf - 转换后的ascii码.
 *       unsigned char *bcd_buf - 要转换的bcd码.
 *       int ascii_len - ascii数据长度(转换后长度).
 * 返回: 
 *       无.
 * 说明:
 *      如"\x23\x45"转换为"2345","\xAB\x1d"为"AB1D".
 *----------------------------------------------------------------------------*/
void BcdToAsc(unsigned char *ascii_buf,unsigned char *bcd_buf,int ascii_len);

/*----------------------------------------------------------------------------*
 * 功能: 把ascii码转换为压缩码(同 AscToBcd() 一样).
 * 参数:
 *       unsigned char *hex_buf - 转换后的bcd码.
 *       unsigned char *ascii_buf - 要转换的ascii码.
 *       int ascii_len - ascii数据长度(转换前长度).
 * 返回: 
 *       无.
 * 说明:
 *      如果长度是奇数,则在后面填充0.
 *      如"2345"转换为"\x23\x45","B1D"为"\xB1\xD0".
 *----------------------------------------------------------------------------*/
void AscToHex(unsigned char *hex_buf,unsigned char *ascii_buf,int ascii_len);

/*----------------------------------------------------------------------------*
 * 功能: 把ascii码转换为压缩码(同 AscToHex() 一样).
 * 参数:
 *       unsigned char *hex_buf - 转换后的bcd码.
 *       unsigned char *ascii_buf - 要转换的ascii码.
 *       int ascii_len - ascii数据长度(转换前长度).
 * 返回: 
 *       无.
 * 说明:
 *      如果长度是奇数,则在后面填充0.
 *      如"2345"转换为"\x23\x45","B1D"为"\xB1\xd0".
 *----------------------------------------------------------------------------*/
void AscToBcd(unsigned char *bcd_buf,unsigned char *ascii_buf,int ascii_len);

/*----------------------------------------------------------------------------*
 * 功能: 把bcd码转换为32位的长整数.
 * 参数:
 *       unsigned char *bcd_buf - 要转换的bcd码.
 *       int bcd_len - bcd数据长度.
 * 返回: 
 *       unsigned long - 转换后的结果.
 * 说明:
 *      如 bcd_len=2, \x01 \x23 -> 123
 *         bcd_len=2, \x12 \x30 -> 1230
 *----------------------------------------------------------------------------*/
unsigned long BcdToBin(unsigned char *bcd_buf,int bcd_len);

/*----------------------------------------------------------------------------*
 * 功能: 把32位的长整数转换为bcd码.
 * 参数:
 *       unsigned char *bcd_buf - 转换后的bcd码.
 *       long *bin - 要转换长整数.
 *       int bcd_len - 转换后的bcd数据长度.
 * 返回: 
 *       unsigned long - 转换后的结果.
 * 说明:
 *      如 bcd_len=2, 123  -> \x01 \x23
 *         bcd_len=2, 1230 -> \x12 \x30
 *----------------------------------------------------------------------------*/
void BinToBcd(unsigned char *bcd_buf,long bin,int bcd_len);

/*----------------------------------------------------------------------------*
 * 功能: 把ascii码转换为32位的长整数.
 * 参数:
 *       unsigned char *ascii_buf - 要转换的ascii码.
 *       int ascii_len - 转换后的ascii数据长度.
 * 返回: 
 *       unsigned long - 转换后的结果.
 * 说明:
 *      如 "0123"  -> 123
 *----------------------------------------------------------------------------*/
unsigned long AscToBin(unsigned char *ascii_buf,int ascii_len);

/*----------------------------------------------------------------------------*
 * 功能: 把32位的长整数转换为ascii码.
 * 参数:
 *       unsigned char *ascii_buf - 转换后的ascii码.
 *       unsigned long - 要转换的长整数.
 *       int ascii_len - 转换后的ascii数据长度.
 * 返回: 
 *       无.
 * 说明:
 *      如 123  -> "0123"
 *----------------------------------------------------------------------------*/
void BinToAsc(unsigned char *ascii_buf,unsigned long bin,int ascii_len);

/*----------------------------------------------------------------------------*
 * 功能: 把ascii码转换为ebcd码.
 * 参数:
 *       unsigned char *ebcd_buf - 转换后的ebcd码.
 *       unsigned char *asc_buf - 要转换后的ascii码.
 *       int asc_len - 要转换的ascii数据长度.
 * 返回: 
 *       无.
 * 说明:
 *----------------------------------------------------------------------------*/
void AscToEBcd(unsigned char *ebcd_buf,unsigned char *asc_buf,int asc_len);

/*----------------------------------------------------------------------------*
 * 功能: 把ebcd码转换为ascii码.
 * 参数:
 *       unsigned char *asc_buf - 转换后的ascii码.
 *       unsigned char *ebcd_buf - 要转换的ebcd码.
 *       int ebcd_len - 要转换的ebc数据长度.
 * 返回: 
 *       无.
 * 说明:
 *----------------------------------------------------------------------------*/
void EBcdToAsc(unsigned char *asc_buf,unsigned char *ebcd_buf,int ebcd_len);

CString Convert2Hex(LPCTSTR p,int nLen);
char* str2hex(const char* str);
char* hex2str(const char* hex);
char *itoa_hex(unsigned int data,char * hbuff,int len);

int htoi(char s[]);

#endif
