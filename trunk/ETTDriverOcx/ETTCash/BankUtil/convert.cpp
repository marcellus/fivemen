#include "stdafx.h"
#include "convert.h"


/*
Macros
*/
#ifndef TRUE
#define TRUE	1
#define FALSE	0
#endif

#define YES 1 
#define NO 0  

/*
Local types
*/


/*
Exported variables
*/


/*
Local variables
*/

static unsigned char AscToEbcdTable[]=
{
	'\x40', '\x40', '\x40', '\x40', '\x40', '\x40', '\x40', '\x40', '\x40', '\x40', 
	'\x40', '\x40', '\x40', '\x40', '\x40', '\x40', '\x40', '\x40', '\x40', '\x40',
	'\x40', '\x40', '\x40', '\x40', '\x40', '\x40', '\x40', '\x40', '\x40', '\x40',
	'\x40', '\x40', '\x40', '\x5A', '\x7F', '\x7B', '\x5B', '\x6C', '\x50', '\x7D',
	'\x4D', '\x5D', '\x5C', '\x4E', '\x6B', '\x60', '\x4B', '\x61', '\xF0', '\xF1',
	'\xF2', '\xF3', '\xF4', '\xF5', '\xF6', '\xF7', '\xF8', '\xF9', '\x7A', '\x5E',
	'\x4C', '\x7E', '\x6E', '\x6F', '\x7C', '\xC1', '\xC2', '\xC3', '\xC4', '\xC5',
	'\xC6', '\xC7', '\xC8', '\xC9', '\xD1', '\xD2', '\xD3', '\xD4', '\xD5', '\xD6',
	'\xD7', '\xD8', '\xD9', '\xE2', '\xE3', '\xE4', '\xE5', '\xE6', '\xE7', '\xE8',
	'\xE9', '\x40', '\x40', '\x40', '\x40', '\x6D', '\x40', '\x81', '\x82', '\x83',
	'\x84', '\x85', '\x86', '\x87', '\x88', '\x89', '\x91', '\x92', '\x93', '\x94',
	'\x95', '\x96', '\x97', '\x98', '\x99', '\xA2', '\xA3', '\xA4', '\xA5', '\xA6',
	'\xA7', '\xA8', '\xA9', '\x40', '\x4F', '\x40', '\x40', '\x40', '\x40', '\x40',
	'\x40', '\x40', '\x40', '\x40', '\x40', '\x40', '\x40', '\x40', '\x40', '\x40',
	'\x40', '\x40', '\x40', '\x40', '\x40', '\x40', '\x40', '\x40', '\x40', '\x40',
	'\x40', '\x40', '\x40', '\x40', '\x40', '\x40', '\x40', '\x40', '\x40', '\x40',
	'\x40', '\x40', '\x40', '\x40', '\x40', '\x40', '\x40', '\x40', '\x40', '\x40',
	'\x40', '\x40', '\x40', '\x40', '\x40', '\x40', '\x40', '\x40', '\x40', '\x40',
	'\x40', '\x40', '\x40', '\x40', '\x40', '\x40', '\x40', '\x40', '\x40', '\x40',
	'\x40', '\x40', '\x40', '\x40', '\x40', '\x40', '\x40', '\x40', '\x40', '\x40',
	'\x40', '\x40', '\x40', '\x40', '\x40', '\x40', '\x40', '\x40', '\x40', '\x40',
	'\x40', '\x40', '\x40', '\x40', '\x40', '\x40', '\x40', '\x40', '\x40', '\x40',
	'\x40', '\x40', '\x40', '\x40', '\x40', '\x40', '\x40', '\x40', '\x40', '\x40',
	'\x40', '\x40', '\x40', '\x40', '\x40', '\x40', '\x40', '\x40', '\x40', '\x40',
	'\x40', '\x40', '\x40', '\x40', '\x40', '\x40', '\x40', '\x40', '\x40', '\x40',
	'\x40', '\x40', '\x40', '\x40', '\x40', '\x40'
};

static unsigned char EbcdToAscTable[]=
{
	'\x20', '\x20', '\x20', '\x20', '\x20', '\x20', '\x20', '\x20', '\x20', '\x20',
	'\x20', '\x20', '\x20', '\x20', '\x20', '\x20', '\x20', '\x20', '\x20', '\x20',
	'\x20', '\x20', '\x20', '\x20', '\x20', '\x20', '\x20', '\x20', '\x20', '\x20',
	'\x20', '\x20', '\x20', '\x20', '\x20', '\x20', '\x20', '\x20', '\x20', '\x20',
	'\x20', '\x20', '\x20', '\x20', '\x20', '\x20', '\x20', '\x20', '\x20', '\x20',
	'\x20', '\x20', '\x20', '\x20', '\x20', '\x20', '\x20', '\x20', '\x20', '\x20',
	'\x20', '\x20', '\x20', '\x20', '\x20', '\x20', '\x20', '\x20', '\x20', '\x20',
	'\x20', '\x20', '\x20', '\x20', '\x20', '\x2E', '\x3C', '\x28', '\x2B', '\x7C',
	'\x26', '\x20', '\x20', '\x20', '\x20', '\x20', '\x20', '\x20', '\x20', '\x20',
	'\x21', '\x24', '\x2A', '\x29', '\x3B', '\x20', '\x2D', '\x2F', '\x20', '\x20',
	'\x20', '\x20', '\x20', '\x20', '\x20', '\x20', '\x20', '\x2C', '\x25', '\x5F',
	'\x3E', '\x3F', '\x20', '\x20', '\x20', '\x20', '\x20', '\x20', '\x20', '\x20',
	'\x20', '\x20', '\x3A', '\x23', '\x40', '\x27', '\x3D', '\x22', '\x20', '\x61', 
	'\x62', '\x63', '\x64', '\x65', '\x66', '\x67', '\x68', '\x69', '\x20', '\x20', 
	'\x20', '\x20', '\x20', '\x20', '\x20', '\x6A', '\x6B', '\x6C', '\x6D', '\x6E', 
	'\x6F', '\x70', '\x71', '\x72', '\x20', '\x20', '\x20', '\x20', '\x20', '\x20', 
	'\x20', '\x20', '\x73', '\x74', '\x75', '\x76', '\x77', '\x78', '\x79', '\x7A', 
	'\x20', '\x20', '\x20', '\x20', '\x20', '\x20', '\x20', '\x20', '\x20', '\x20', 
	'\x20', '\x20', '\x20', '\x20', '\x20', '\x20', '\x20', '\x20', '\x20', '\x20', 
	'\x20', '\x20', '\x20', '\x41', '\x42', '\x43', '\x44', '\x45', '\x46', '\x47', 
	'\x48', '\x49', '\x20', '\x20', '\x20', '\x20', '\x20', '\x20', '\x20', '\x4A', 
	'\x4B', '\x4C', '\x4D', '\x4E', '\x4F', '\x50', '\x51', '\x52', '\x20', '\x20', 
	'\x20', '\x20', '\x20', '\x20', '\x20', '\x20', '\x53', '\x54', '\x55', '\x56', 
	'\x57', '\x58', '\x59', '\x5A', '\x20', '\x20', '\x20', '\x20', '\x20', '\x20', 
	'\x30', '\x31', '\x32', '\x33', '\x34', '\x35', '\x36', '\x37', '\x38', '\x39', 
	'\x20', '\x20', '\x20', '\x20', '\x20', '\x20' 
};
/*
Macro functions
*/
#define hex(x)		((x)<=9 ? ((x)+'0') : ((x)+('A'-0x0a)) )
#define odd(x)			((x) & 0x01)
#define even(x)			(!odd(x))


/*
Functions
*/
static unsigned char	char_ascii_to_hex(unsigned char ascii)
{
	unsigned char	val;

	val = ascii;
	if( (val>='0') && (val<='9'))
	{
		val = val & 0x0f;
	}
	else
		if( (val>='a') && (val<='f'))
		{
			val = val - 'a' + 0x0a;
		}
		else
			if( (val>='A') && (val<='F'))
			{
				val = val - 'A' + 0x0a;
			}
			else
			{
				val = 0;
			}
			return( val);
}

/*----------------------------------------------------------------------------*
* 功能: 转换前导零为空格.
* 参数:
*       unsigned char *buf - 数据.
*       int len - 数据长度.
* 返回: 
*       无.
* 说明:
*----------------------------------------------------------------------------*/
void ConvertToLeadingSpaces(unsigned char *buf,int len)
{
	int	i;

	i = 0;
	while( (i<len) && (*buf == '0'))
	{
		*buf = ' ';				/* change leading zeroes to spaces. */
		buf++;
		i++;
	}
	buf--;				/* got to last byte */

	if( (i==len) && (*buf==' '))		/* if all spaces */
	{
		*buf = '0';				/* change last space back to zero */
	}
}

/*----------------------------------------------------------------------------*
* 功能: 转换前导空格为零.
* 参数:
*       unsigned char *buf - 数据.
*       int len - 数据长度.
* 返回: 
*       无.
* 说明:
*----------------------------------------------------------------------------*/
void ConvertToLeadingZeroes(unsigned char *buf,int len)
{
	int	i;

	i = 0;
	while( (i<len) && (*buf == ' '))
	{
		*buf = '0';				/* change leading spaces to zeroes. */
		buf++;
		i++;
	}
	buf--;				/* got to last byte */
}

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
void HexToAsc(unsigned char *ascii_buf,unsigned char *hex_buf,int ascii_len)
{
	int	i;
	unsigned char val;

	for( i=0; i<ascii_len; i++)
	{
		if( even(i) )
		{
			val = *hex_buf;
			*ascii_buf = hex( val >> 4);
			ascii_buf++;
		}
		else
		{
			*ascii_buf = hex( val & 0x0f);
			ascii_buf++;
			hex_buf++;
		}
	}
}

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
void BcdToAsc(unsigned char *ascii_buf,unsigned char *bcd_buf,int ascii_len)
{
	HexToAsc(ascii_buf,bcd_buf,ascii_len);
}

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
void AscToHex(unsigned char *hex_buf,unsigned char *ascii_buf,int ascii_len)
{
	int	i, len;

	len = (ascii_len+1) / 2;
	for( i=0; i<len; i++)
	{
		*hex_buf  = char_ascii_to_hex( *ascii_buf) << 4;	/* high nibble */
		ascii_buf++;
		*hex_buf |= char_ascii_to_hex( *ascii_buf);		/* low  nibble */
		ascii_buf++;
		hex_buf++;
	}
	if( odd(ascii_len) )
	{
		hex_buf--;
		*hex_buf &= 0xf0;	/* odd lengths have the extra digit set to 0 */
	}
}

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
void AscToBcd(unsigned char *bcd_buf,unsigned char *ascii_buf,int ascii_len)
{
	AscToHex(bcd_buf,ascii_buf,ascii_len);
}

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
unsigned long BcdToBin(unsigned char *bcd_buf,int bcd_len)
{
	int	i;
	unsigned long rc;
	unsigned char val;

	rc = 0;
	for( i=0; i<bcd_len; i++)
	{
		val = *bcd_buf;
		rc = rc*10 + (val >> 4);
		rc = rc*10 + (val & 0x0f);
		bcd_buf++;
	}
	return( rc);
}

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
void BinToBcd(unsigned char *bcd_buf,long bin,int bcd_len)
{
	int	i;
	int	multiple, remainder;

	bcd_buf += bcd_len - 1;
	for( i=bcd_len; i>0; i--)
	{
		multiple  = bin / 10;
		remainder = bin - (multiple * 10);
		bin = multiple;
		*bcd_buf  = remainder;

		multiple  = bin / 10;
		remainder = bin - (multiple * 10);
		bin = multiple;
		*bcd_buf |= remainder << 4;

		bcd_buf--;
	}
}

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
unsigned long AscToBin(unsigned char *ascii_buf,int ascii_len)
{
	unsigned char bcd_buf[64];

	AscToBcd(bcd_buf,ascii_buf,ascii_len);
	return(BcdToBin(bcd_buf,(ascii_len+1)/2));
}

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
void BinToAsc(unsigned char *ascii_buf,unsigned long bin,int ascii_len)
{
	int	i;
	unsigned long multiple, remainder;

	ascii_buf += ascii_len - 1;
	for( i=ascii_len; i>0; i--)
	{
		multiple  = bin / 10;
		remainder = bin - (multiple * 10);
		bin = multiple;
		*ascii_buf  = hex( remainder);
		ascii_buf--;
	}

	ascii_buf++;		/* go to first byte */
}

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
void AscToEBcd(unsigned char *ebcd_buf,unsigned char *asc_buf,int asc_len)
{
	int i;

	for(i=0;i<asc_len;i++)  
	{
		ebcd_buf[i]=AscToEbcdTable[asc_buf[i]];
	}
}

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
void EBcdToAsc(unsigned char *asc_buf,unsigned char *ebcd_buf,int ebcd_len)
{
	int i;

	for(i=0;i<ebcd_len;i++)  
	{
		asc_buf[i]=EbcdToAscTable[ebcd_buf[i]];
	}
}

CString Convert2Hex(LPCTSTR p,int nLen)
{
	TCHAR sz[4]={0};
	CString str(_T(""));
	for(int i=0;i<nLen;i++)
	{
		_stprintf(sz,_T("%02X"),p[i]&0xFF);
		str += sz;
	}
	return str;
}

char* str2hex(const char* str) 
{
	char* out = (char*)malloc(strlen(str) * 2 + 1);
	memset(out, 0, strlen(str) * 2 + 1);
	char *p = out;
	while (*str != '\0') 
	{
		sprintf(p, "%02x", *str);
		str++;
		p = p + 2;
	}
	*p = '\0';
	return out;
}

char* hex2str(const char* hex) 
{
	char* out = (char*) malloc(strlen(hex) / 2 + 1);
	memset(out, 0, strlen(hex) / 2 + 1);
	char tmp[3] = {0};
	char* p;
	p = out;
	while (*hex != '\0') 
	{
		tmp[0] = *hex;
		hex++;
		tmp[1] = *hex;
		hex++;
		tmp[2] = '\0';
		*p = (char) strtol(tmp, NULL, 10);
		p++;
	}
	*p = '\0';
	return out;
}

char * itoa_hex(unsigned int data,char * hbuff,int len) 
{ 
	unsigned char * p=(unsigned char *)(&data); 
	//int len=sizeof(data); 

	static const char hex_map[]="0123456789ABCDEF"; 
	static const bool lit_end=*(char*)(&len)==len; 

	int counter=0; 
	if(lit_end) 
	{ 
		for(counter=len;counter>0;--counter) 
		{ 
			hbuff[(len-counter)<<1] = hex_map[*(p+counter-1)>>4]; 
			hbuff[((len-counter)<<1)|1]=hex_map[(*(p+counter-1))&0xF]; 
		} 
	} 
	else 
	{ 
		for(;counter<len;++counter) 
		{ 
			hbuff[counter<<1]=hex_map[*(p+counter-1)>>4]; 
			hbuff[(counter<<1)|1]=hex_map[*(p+counter-1)|0x0F]; 
		} 
	} 
	return hbuff; 
}

//hex to int
int htoi(char s[]) 
{ 
	int i,n;
	int inhex,digital; 
	i=0;
	if (s[i]=='0')
	{
		i++;
		if (s[i]=='x'||s[i]=='X') 
		{
			i++;   
		}
	}
	n=0;
	inhex=YES;
	for(;inhex==YES;i++)
	{
		if (s[i]>='0'&&s[i]<='9')
			digital=s[i]-'0';
		else if (s[i]>='a'&&s[i]<='f')    
			digital=s[i]-'a'+10; 
		else if (s[i]>='A'&&s[i]<='F') 
			digital=s[i]-'A'+10;  
		else    
		{
			inhex=NO;   
			break;  
		}
		n=16*n+digital; 
	}
	return n; 
} 
/* End of conv.c */
