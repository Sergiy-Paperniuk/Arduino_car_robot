// The source code is from here: http://www.hackersdelight.org/hdcodetxt/crc.c.txt

unsigned long GetCRC32( unsigned char* Buffer, unsigned long size )
{
   unsigned long Single_byte;
   unsigned long CRC32; 
   unsigned long Mask;
  
   CRC32 = 0xFFFFFFFF;
   
   for( int i = 0; i < size; i++ )
   {
      Single_byte = Buffer[i];  // Get the next byte
      CRC32 = CRC32 ^ Single_byte;
      
      for( int j = 7; j >= 0; j-- )  // Do eight times
      {
         Mask = -(CRC32 & 1);
         CRC32 = (CRC32 >> 1) ^ (0xEDB88320 & Mask);
      }
   }
   
   return ~CRC32;
}


