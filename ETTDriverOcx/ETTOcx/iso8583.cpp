/***************************************************************************/
/*          BEIJING NEXTSKY TECHNOLOGY CO. LTD                             */
/*                    2000.06.18                                           */
/***************************************************************************/

#include "stdafx.h"
#include <stdio.h>
#include "iso8583.h"
#include "convert.h"
#define LS_MAP_BIT 0x80

extern  unsigned char tpdu[];

/***************************************************************************/
/* This table must contain all the pairs which are use by the application  */
/* to transform the data. The embedded defines establish the convert table */
/* indicies which are used in field_table (see tables.h).                  */
/***************************************************************************/
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
			{ str_to_xbc, xbc_to_str },
#define BV3_STR 12
                        { str_to_bv3, bv3_to_str }
};

/***************************************************************************
 The least significant 4 bits of the following byte will be used to pad
 an odd length packed item in the final nibble. The default is zero.
***************************************************************************/
unsigned char pad_nibble_8583 = 0;

int fn_8583;				/* Field number		*/
unsigned char *src_8583;		/* Source pointer	*/
unsigned char *dst_8583;		/* Destination pointer	*/
unsigned char map_8583[BIT_MAP_SIZE];	/* Map			*/

field_struct  *field_ptr;

int Map_Test(map, field_no)
unsigned char *map;
int field_no;
{
    if (field_no >= 1 && field_no <= 64)
    {
	map += (--field_no >> 3);  /* point at proper byte */
	return(*map & (LS_MAP_BIT >> (field_no & 7))); /* form proper mask */
    }
    else
	return( 0 );
}

/* map_reset

   Reset a particular bit.
*/
void Map_Reset(map, field_no)
unsigned char *map;
int field_no;
{
    if (field_no >= 1 && field_no <= 64)
    {
	map += (--field_no >> 3);
	*map &= ~(LS_MAP_BIT >> (field_no & 7));
    }
}

/***************************************************************************
 Determine the size of the bit map and save it in map_8583.
***************************************************************************/
int capture_map( start )
unsigned char *start;
{
    int      n = 0;
    unsigned char *map_ptr;
    unsigned char map_byte;

    map_ptr = start;
    do 
    {
        map_byte = *map_ptr;		/* Fetch first byte of map     */
        map_ptr += BIT_MAP_SIZE;	/* Skip over this map section  */
        n += BIT_MAP_SIZE;
    } 
    while ( map_byte & LS_MAP_BIT );	/* continue if multiple maps   */

    memcpy( map_8583, start, n );	/* save map in map_8583 global */
    return( n );
}

/***************************************************************************
 This is the main 8583 field processing function.
 Return values:
   -1    Field not defined in field table.
   -2    Stored more in buffer than limit.
   -3    Exceeded size of valid data in buffer.
   -4    Stored more than variable limit on an incomming message.
   -5    No matching variant field definition.
   >0    Assembly: number of bytes put into buffer. Use for write.
   Disassembly: Number of bytes in buffer not processed.
                Should be zero.
***************************************************************************/
int process_iso8583( how, field_tbl, map, buffer, limit )
int how;			/* how=0 => pack, how=1 => unpack	  */
field_struct *field_tbl;	/* pointer to field table		  */
unsigned char *map;		/* pointer to map. Ignored on incomming.  */
unsigned char *buffer;		/* pointer to buffer			  */
int limit;			/* limit on assembly. size on disassembly */
{
    int  map_mask;           /* mask for testing map bits */
    int  n,pp;                  /* number of bytes in map */
    int  rst;                /* result of processing a single field */
    unsigned char *map_ptr;

    /* Initialize pointer to field table */
    field_ptr = field_tbl;

    /* Capture either from parameter or buffer */
    /* Copy map to map_8583 return size */
    n = capture_map((how==0)?map:buffer+7);

    /* Initialize source and destination pointers */
    src_8583 = buffer;
    dst_8583 = buffer;
    fn_8583 = 0;

    process_field(how, buffer);   /* TPDU */
    process_field(how, buffer);   /* Message type */

    /* MODIFICATION TO RECOGNISE TPDU BEGINNING WITH 68 - NMS MESSAGE */
    /* if incoming map and NMS then just return as valid response and */
    /* allow higher level routine to take care!			      */

    if ((how == 1) && ((tpdu[1]&0xff) == 0x68))
    {   puts("BACK!");
	return(-6);  /* bytes remaining */
    } 

    if (how==0) 
    {
         memcpy(buffer+7, map_8583, n);  /* store outgoing map     */
         dst_8583 = buffer+7+n;          /* initialize destination */
    }
    else 
    {
         memcpy(map, map_8583, n);       /* return received map */
         src_8583 = buffer+7+n;          /* initialize source   */
    }
    for (fn_8583=1,map_ptr=map_8583; n; n--,map_ptr++) 
    {
	for (map_mask=LS_MAP_BIT; map_mask; map_mask>>=1,fn_8583++) 
        {
            if (*map_ptr & map_mask) 
            {
  	        rst = process_field(how,buffer);
		if (rst != 0)
                    return( rst );
                if (how == 0) 
                {
                    if ((dst_8583-buffer) > limit)
                        return( -2 );
                }
                else if ((src_8583-buffer) > limit)
                {  
                    puts("PUTSA!");
                    return( -3 );
                }
            }
        }
    }

    if (how == 0)
	return( dst_8583-buffer );	/* bytes put into buffer */
    else return( limit-(int)(src_8583-buffer) );  /* bytes remaining */
}

/***************************************************************************
 Process a single field in the field table.
***************************************************************************/
int process_field( how, buffer )
int  how;		/* how=0 => pack, how=1 => unpack */
unsigned char *buffer;	/* pointer to buffer */
{
    int ci;
    int psz;
    int vsz;
    unsigned char *sv_dst;
    int (*func_ptr) ();

    /* advance to corresponding field in table */
    while ((field_ptr->field_num & FIELD_MASK) != fn_8583) 
    {
         /* Received a field  which isnt defined */
         if (field_ptr->field_num & STOP)
         {   
              puts("BACK!");
              return( -1 );
         }
         memset((char *)(field_ptr->reference),0,field_ptr->var_sz);
                                        
         field_ptr++;
    }
    ci = field_ptr->convert_idx;
    if (ci == VARIANT) 
    {
	psz = do_variant(how,return_variant1(),return_variant2(),&ci,&vsz);
	if (psz < 0)
	    return( psz );
    }
    else 
    if (ci == COMPUTE) 
    {
	func_ptr = (int ((*)()))(field_ptr->reference);
	ci = (*func_ptr)(how, buffer, &psz, &vsz);
    }
    else 
    {
	psz = field_ptr->packet_sz;
	vsz = field_ptr->var_sz;
	if (how == 0)
            src_8583 = (unsigned char *)field_ptr->reference;
        else dst_8583 = (unsigned char *)field_ptr->reference;
    }

    sv_dst = dst_8583;			/* save destination before transfer */
    (*convert_table[ci][how])( psz );	/* call the proper convert function */

    if (how == 1)	/* unpacking */ 
    {
	if ((dst_8583 - sv_dst) > vsz)	/* stored more than limit */
             return( -4 );
    }
    field_ptr++;
    return( 0 );
}

/***************************************************************************
 Process a variant field. Returns packet size field or negative on error.
***************************************************************************/
int do_variant( how, v1, v2, ci, vsz )
int how;		/* how=0 => pack, how=1 => unpack */
unsigned int v1, v2;	/* values for first two columns   */
int *ci;		/* return convert table index     */
int *vsz;		/* return size of variable        */
{
    variant_struct *var_ptr;

    var_ptr = (variant_struct *) field_ptr->reference;

    /* Sequentially search the variant field table */
    while (((var_ptr->variant1 & FIELD_MASK) != v1) &&
          (var_ptr->variant2 != v2)) 
    {
        /* Received a field which is not defined */
        if (var_ptr->variant1 & STOP)
            return -5;
        var_ptr++;
    }

    if (how == 0)
	src_8583 = (unsigned char *) var_ptr->reference;
    else dst_8583 = (unsigned char *) var_ptr->reference;

    *ci = var_ptr->convert_idx;
    *vsz = var_ptr->var_sz;
    return( var_ptr->packet_sz );
}

/***************************************************************************
 Store a length in 1 byte. Stores (length div 10) in high order nibble and
 (length mod 10) in low order nibble. Assumes 0<=n<=99
***************************************************************************/
static int put_len_v2(n)
int n;
{
    *dst_8583++ = (n / 10 << 4) | (n % 10);
    return( n );
}

/***************************************************************************
 Stores a lenth in 2 bytes. First byte is (length div 100), second byte
 stored by the routine above.
***************************************************************************/
static int put_len_v3(n)
int n;
{
    *dst_8583++ = n / 100;
    put_len_v2(n % 100);
    return( n );
}

/***************************************************************************
 Fetch a length from a single byte. See put_len_v2 for details.
***************************************************************************/
static int get_len_v2()
{
    unsigned char ch = *src_8583++;

    return( 10 * (ch >> 4) + (ch & 0x0f) );
}

/***************************************************************************
 Fetch a length from two bytes. See lut_len_v3 for details.
***************************************************************************/
static int get_len_v3()
{
    int len;

    len=100 * ((unsigned char)(*src_8583++));
    len+= get_len_v2() ;
    return(len);
}

void str_to_bv3(c)
int c;
{
   max_asc_to_bv(put_len_v3(strlen(src_8583)), c);
}

void bv3_to_str(c)
int c;
{
   copy_bv_to_str(get_len_v3(), c);
}

/***************************************************************************
 Return the binary result of an ASCII digit. Ex: 32h -> 2
***************************************************************************/
static char get_asc_to_bcd()
{
    return( *src_8583++ - '0' );
}

/***************************************************************************
 Convert low order nibble to ASCII. Assumes this value is 0..9.
***************************************************************************/
static char get_bcd_to_asc(bcd)
unsigned char bcd;
{
    return( (bcd & 0xf) + '0' );
}

/***************************************************************************
 Convert ASCII to packet BCD but first place leading zeros.
***************************************************************************/
max_asc_to_bcd(c,max)
int c,max;
{
    while ( c < max ) 
    {
        if ( max-- & 1 ) 
        {
            *dst_8583++ = 0;
        }
    }
    asc_to_bcd( max );
}

/***************************************************************************
 ASCII to packed BCD. ASCII string truncated on right if too long.
***************************************************************************/
max_asc_to_bv(c)
int c;
{
    while ( c-- > 0 ) 
    {
        *dst_8583 = get_asc_to_bcd() << 4;  /* most significant nibble  */
        if ( c > 0 ) 
        {                      /* more to go               */
            *dst_8583 |= get_asc_to_bcd();  /* least significant nibble */
            c--;
        }
        else 
           if (pad_nibble_8583)	    /* non-zero pad             */
               *dst_8583 |= (pad_nibble_8583 & 0x0F);
        dst_8583++;
    }
}

/***************************************************************************
 Simply move c BCD nibbles from source to destination. Since there are two
 nibbles per byte and everything is byte aligned this is done as byte moves.
***************************************************************************/
void bcd_to_bcd(c)
int c;
{
    while ( c > 0 ) 
    {
        *dst_8583++ = *src_8583++;
        c -= 2;
    }
}

/***************************************************************************
 Transfer packed BCD to ASCII. If odd number then advance source ptr.
***************************************************************************/
static void max_bv_to_asc(c)
int c;
{
    int i = 0;

    while ( c-- > 0 ) 
    {
        *dst_8583++ = get_bcd_to_asc(i++ & 1 ? *src_8583++ : *src_8583 >> 4);
    }
    if ( i & 1 )
        src_8583++;
}

/***************************************************************************
 Packed BCD to null terminated ASCII, advance source if odd number.
***************************************************************************/
copy_bv_to_str(c,max)
int c,max;
{
    max_bv_to_asc(c,max);
    *dst_8583++ = 0;
}

/***************************************************************************
 Simply transfer c bytes from source to destination.
***************************************************************************/
void asc_to_asc(c)
int c;
{
/*
    while ( c-- > 0 )
        *dst_8583++ = *src_8583++;
*/
    memcpy( dst_8583, src_8583, c );
    dst_8583 += c;
    src_8583 += c;
}

/***************************************************************************
 Convert c ASCII digits to packed BCD.
***************************************************************************/
void asc_to_bcd(c)
int c;
{
    /* Use this logic if you don't have the SVC function */
    /* ....................................................
    unsigned char bcd = 0;
    while ( c > 0 ) 
    {
        if (c-- & 1)
            *dst_8583++ = bcd | get_asc_to_bcd();
        else
            bcd = get_asc_to_bcd() << 4;
    }
    .................................................... */

    /* Odd length requires leading zero in most sig nibble */
    if ( c & 1 ) 
    {
        *dst_8583++ = *src_8583++ - '0';
        c--;
    }
    SVC_DSP_2_HEX( src_8583, dst_8583, c >> 1 );
    src_8583 += c;
    dst_8583 += c >> 1;
}

/***************************************************************************
 Move c characters from source to destination then place zero into
 destination. Simply makes a null terminated string out of c bytes.
***************************************************************************/
void asc_to_str(c)
int c;
{
    asc_to_asc( c );
    *dst_8583++ = 0;
}

/***************************************************************************
 Transform a counted ASCII string to a null terminated one. The count is
 in the format explained in put_len_v2.
***************************************************************************/
void av2_to_str(c)
int c;
{
    asc_to_asc( get_len_v2() );
    *dst_8583++ = 0;
}

/***************************************************************************
 Simple copy a 2 byte counted string from source to destination.
 The count is in the format explained in put_len_v3.
***************************************************************************/
void av3_to_av3(c)
int c;
{
    asc_to_asc( put_len_v3(get_len_v3()) );
}

/***************************************************************************
 Transform a 2 byte counted string of ASCII to a null terminated one.
 The count is in the format explained in put_len_v3.
***************************************************************************/
void av3_to_str(c)
int c;
{
    asc_to_asc( get_len_v3() );
    *dst_8583++ = 0;
}

/***************************************************************************
 Simply expand a packed BCD sequence into its ASCII equivalent. Assumes
 all the BCD digits are in the range 0..9.
***************************************************************************/
void bcd_to_asc(c)
int c;
{
    /* Use this logic if you don't have the SVC function */
    /* .....................................................................
    while ( c > 0 )
        *dst_8583++ = get_bcd_to_asc( c--&1 ? *src_8583++ : *src_8583>>4 );
    ..................................................................... */

    if ( c & 1 ) 
    {
        *dst_8583++ = *src_8583++ + '0';
        c--;
    }
    /* Count needs to be given in terms of hex pairs */
    SVC_HEX_2_DSP( src_8583, dst_8583, c >> 1 );
    src_8583 += c >> 1;
    dst_8583 += c;
}

/***************************************************************************
 Move fixed length BCD field to string, omitting leading zeros.
***************************************************************************/
void bcd_to_snz(c)
int c;
{
    char ch;
    while ( c > 0 ) 
    {
        ch = ( c--&1 ? *src_8583++ : *src_8583>>4 ) & 0x0f;
        if ( ch ) 
        {	/* first non zero digit */
            if ( ++c & 1 )
                src_8583--;
            break;
        }
    }
    bcd_to_str(c);
}

/***************************************************************************
 Copy fixed length bcd field to null terminated string, preserving
 leading zeros.
***************************************************************************/
void bcd_to_str(c)
int c;
{
    bcd_to_asc(c);
    *dst_8583++ = 0;
}

/***************************************************************************
 Simply move bit field. Will always move whole bytes.
***************************************************************************/
void bit_to_bit(c)
int c;
{
    for ( ; c > 0;  c -= 8 )	/* 8 bits per iteration */
	*dst_8583++ = *src_8583++;
}

/***************************************************************************
 1 byte counted BCD string to null terminated.
***************************************************************************/
void bv2_to_str(c)
int c;
{
    copy_bv_to_str( get_len_v2(), c );
}

/***************************************************************************
 Null terminated string of ASCII to fixed size ASCII with blank padding
 on the right if necessary.
***************************************************************************/
void str_to_asc(c)
int c;
{
    int i = strlen( src_8583 );
    if ( i > c )
        i = c;		/* truncate on right if too long */
    asc_to_asc(i);
    i = c - i;
    if ( i > 0 ) 
    {
        memset( dst_8583, ' ', i );
        dst_8583 += i;
    }
}

/***************************************************************************
 Null terminated ASCII string to 1 byte counted string.
***************************************************************************/
void str_to_av2(c)
int c;
{
    asc_to_asc( put_len_v2(strlen(src_8583)) );
}

/***************************************************************************
 Null terminated ASCII string to 2 byte counted string.
***************************************************************************/
void str_to_av3(c)
int c;
{
    asc_to_asc( put_len_v3(strlen(src_8583)) );
}

/***************************************************************************
 Null terminated to fixed size BCD with zero padding on the left if necessary.
 Move string into fixed length bcd field.
***************************************************************************/
void str_to_bcd(c)
int c;
{
    max_asc_to_bcd( strlen(src_8583), c );
}

/***************************************************************************
 Null terminated BCD string to 1 byte counted string.
***************************************************************************/
void str_to_bv2(c)
int c;
{
    max_asc_to_bv( put_len_v2(strlen(src_8583)), c );
}

/***************************************************************************
 Null terminated to signed BCD. 'C' or 'D' followed by BCD.
***************************************************************************/
void str_to_xbc(c)
int c;
{
    *dst_8583++ = *src_8583++;
    str_to_bcd(c);
}

/***************************************************************************
 Signed BCD to null terminated string.
***************************************************************************/
void xbc_to_str(c)
int c;
{
    *dst_8583++ = *src_8583++;
    bcd_to_str(c);
}

/***************************************************************************
  SUPPOSE dsp CONTAINS THE ASSCII ARRAY "12345F" AND WE EXECUTE THIS FUNCTION
  THEN THE ARRAY  AT hex WILL CONTAIN 12H,34H, 5FH
****************************************************************************/
SVC_DSP_2_HEX(dsp, hex, count)
char *dsp, *hex;
int count;
{
    int i;
    for(i=0;i<count;i++)
    {
        hex[i] = ((dsp[i * 2] <= 0x39) ? dsp[i * 2] - 0x30 
                                       : dsp[i * 2] - 0x41 + 10);
        hex[i] = hex[i] << 4;
        hex[i] += ((dsp[i * 2 + 1] <= 0x39) ? dsp[i * 2 + 1] - 0x30
                                       : dsp[i * 2 + 1] - 0x41 + 10);
    }
}

/***************************************************************************
 SUPPOSE HEX CONTAINS THREE BYTES:12H 34H, 5FH AND WE EXECUTE THIS FUNCTION
 THEN dsp WILL CONTAIN ASCII BYTES "12345F"
**************************************************************************/
SVC_HEX_2_DSP(hex, dsp, count)
char *dsp, *hex;
int count;
{
    int i;
    char ch;
    for(i = 0; i < count; i++)
    {
        ch = (hex[i] & 0xf0) >> 4;
        dsp[i * 2] = (ch > 9) ? ch + 0x41 - 10 : ch + 0x30;
        ch = hex[i] & 0xf;
        dsp[i * 2 + 1] = (ch > 9) ? ch + 0x41 - 10 : ch + 0x30;
    }
}
