/***************************************************************************/
/*                                                                         */
/*           Copyright (C) BEIJING NEXTSKY NETWORK TECHNOLOGY CO., LTD.    */
/*                                                                         */
/***************************************************************************/

#ifndef ISO8583_H
#define ISO8583_H
#define APPLN

#include "map.h"

typedef struct 
{
    int  field_num;            /* 1st col - field number		*/
    int  packet_sz;            /* 2nd col - packet size			*/
    int  convert_idx;          /* 3rd col - index into covert table	*/
    void *reference;           /* 4th col - pointer to var or table	*/
    int  var_sz;               /* 5th col - var size			*/
} field_struct;

typedef struct 
{
    unsigned int  variant1;    /* 1st col - target			*/
    unsigned int  variant2;    /* 2nd col - target			*/
    int           packet_sz;   /* 3nd col - packet size			*/
    int           convert_idx; /* 4rd col - index into covert table	*/
    void          *reference;  /* 5th col - pointer to var or table	*/
    int           var_sz;      /* 6th col - var size			*/
} variant_struct;

typedef void (*(converters[2])) ();  /* a pair or pointers to functions */

extern int fn_8583;				/* Field number		*/
extern unsigned char *src_8583;			/* Source pointer	*/
extern unsigned char *dst_8583;			/* Destination pointer	*/
extern unsigned char map_8583[BIT_MAP_SIZE];	/* Map			*/

/***************************************************************************
 The least significant 4 bits of the following byte will be used to pad
 an odd length packed item in the final nibble. The default is zero.
***************************************************************************/
extern unsigned char pad_nibble_8583;

#endif
