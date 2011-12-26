/***************************************************************************/
/*                                                                         */
/*           Copyright (C) BEIJING NEXTSKY NETWORK TECHNOLOGY CO., LTD.          */
/*                                                                         */
/***************************************************************************/

#ifndef CONVERT_H
#define CONVERT_H

#ifndef ISO8583_H 
#include "iso8583.h"
#endif

/***************************************************************************
 Abbreviations:
 asc = ASCII fixed size string
 bcd = Binary Coded Decimal (packet numeric digits as 4 bit items)
 str = Null terminated strings (C style)
 av2 = ASCII string preceeded by 2 digit length
 bv2 = BCD string preceeded by 2 digit length
 av3 = ASCII string preceeded by 3 digit length
 xbc = "Signed" ("C" or "D") followed by BCD string
 bit = Bit string
***************************************************************************/ 

/*************************************************************************** 
 Straight movers 
***************************************************************************/ 
void asc_to_asc();	/* Straight transfer of N bytes			*/
void av3_to_av3();	/* Straight transfer of 2 byte counted string	*/
void bit_to_bit();	/* Straight transfer of bits. Whole bytes.	*/
void bcd_to_bcd();	/* Straight transfer of N nibbles. Whole bytes.	*/

/***************************************************************************
 Convert ASCII bytes to/from BCD nibbles
***************************************************************************/
void asc_to_bcd();	/* N bytes of ASCII to N nibbles of BCD	*/
void bcd_to_asc();	/* N nibbles of BCD to N bytes of ASCII	*/

/***************************************************************************
 Convert ASCII bytes to/from c-cstring
***************************************************************************/
void asc_to_str();	/* N bytes of ASCII to C-string			*/
void str_to_asc();	/* C-string to N bytes, pad on right with space	*/

/***************************************************************************
 Convert BCD to/from C-string
***************************************************************************/
void bcd_to_str();	/* N nibbles of BCD to C-string, preserve lead 0*/
void str_to_bcd();	/* C-string to N nibbles, pad on left with 0	*/
void bcd_to_snz();	/* N nibbles of BCD to C-string, drop lead 0	*/

/***************************************************************************
 Convert short counted ASCII string to/from C-string
***************************************************************************/
void av2_to_str();	/* 1 byte counted string of ASCII to C-string	*/
void str_to_av2();	/* C-string to 1 byte counted string of ASCII	*/

/***************************************************************************
 Convert short counted BCD string to/from null terminated string
***************************************************************************/
void bv2_to_str();	/* 1 byte counted string of BCD to C-string	*/
void str_to_bv2();	/* C-string to 1 byte counted string of BCD	*/

/***************************************************************************
 Convert long counted ASCII string to/from null terminated string
***************************************************************************/
void av3_to_str();	/* 2 byte counted string of ASCII to C-string	*/
void str_to_av3();	/* C-string to 2 byte counted string of ASCII	*/

/***************************************************************************
 Convert "signed" ("C" or "D") followed by BCD string
***************************************************************************/
void xbc_to_str();	/* Signed BCD to C-string	*/
void str_to_xbc();	/* C-string to 2 signed BCD	*/

void bv3_to_str();
void str_to_bv3();

/***************************************************************************/
/* This table must contain all the pairs which are use by the application  */
/* to transform the data. The embedded defines establish the convert table */
/* indicies which are used in field_table (see tables.h).                  */
/***************************************************************************/

extern converters convert_table[];

#define ASC_ASC	0
#define AV3_AV3	1
#define BIT_BIT	2
#define BCD_BCD	3
#define BCD_ASC	4
#define ASC_STR	5
#define BCD_STR	6
#define BCD_SNZ	7
#define AV2_STR	8
#define BV2_STR	9
#define AV3_STR	10
#define XBC_STR	11
#define BV3_STR 12

/*
converters convert_table [] = {

#define ASC_ASC	0
			{ asc_to_asc, asc_to_asc },
#define AV3_AV3	1
			{ av3_to_av3, av3_to_av3 },
#define BIT_BIT	2
			{ bit_to_bit, bit_to_bit },
#define BCD_BCD	3
			{ bcd_to_bcd, bcd_to_bcd },
#define BCD_ASC	4
			{ asc_to_bcd, bcd_to_asc },
#define ASC_STR	5
			{ str_to_asc, asc_to_str },
#define BCD_STR	6
			{ str_to_bcd, bcd_to_str },
#define BCD_SNZ	7
			{ str_to_bcd, bcd_to_snz },
#define AV2_STR	8
			{ str_to_av2, av2_to_str },
#define BV2_STR	9
			{ str_to_bv2, bv2_to_str },
#define AV3_STR	10
			{ str_to_av3, av3_to_str },
#define XBC_STR	11
			{ str_to_xbc, xbc_to_str }
};
*/

#define VARIANT	13		/* This must be last +1 */
#define COMPUTE	(VARIANT+1)

#endif
