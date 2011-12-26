/***************************************************************************/
/*                                                                         */
/*          Copyright (C) BEIJING NEXTSKY NETWORK TECHNOLOGY CO., LTD.           */
/*                                                                         */
/***************************************************************************/

#ifndef MAP_H
#define MAP_H

void map_clear ();  /* Clear all the bits in a map		*/
int  map_test ();   /* Test if a particular bit is on or off	*/
void map_set ();    /* Set a particular bit			*/
void map_reset ();  /* Reset a particular bit			*/
void map_man ();    /* Map manager to build complete maps	*/

/* This define should reflect the maximum field number supported.	*/
#define MAX_FIELD 64

/* This define should indicate the number of bytes in a map segment.	*/
#define BIT_MAP_SIZE 8

/* This define converts a maximum field number to the number	*/
/* of map bytes required. Basically (((fn-1)/64)+1)*8		*/
#define map_bytes(fn)	(((((fn)-1)/(BIT_MAP_SIZE*8))+1)*BIT_MAP_SIZE)

/* Use this define to declare a map variable			*/
#define bit_map(name,fn) unsigned char name[map_bytes(fn)]

#define STOP       0x8000   /* Indicates end of param list to map_man      */
#define OFF        0x4000   /* Use to tell map_man to reset a bit          */
#define SKIP       0x4000   /* Use to indicate skip in field table         */
#define FIELD_MASK 0x0fff   /* Bit number in bottom 12 bits                */

#define legal_field(fn)		( ((fn)>=1) && ((fn)<=MAX_FIELD) )

#define LS_MAP_BIT   0x80   /* Least significant bit within a map byte     */

#endif
