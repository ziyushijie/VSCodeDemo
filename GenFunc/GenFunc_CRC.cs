﻿using System;

namespace GenFuncLib
{
	public partial class GenFunc
	{
		#region CRC32

		/// <summary>
		/// CRC32表
		/// </summary>
		private static UInt32[] crc32Tab = new UInt32[256]
		{
			0x00000000,0x04C11DB7,0x09823B6E,0x0D4326D9,0x130476DC,0x17C56B6B,0x1A864DB2,0x1E475005,
			0x2608EDB8,0x22C9F00F,0x2F8AD6D6,0x2B4BCB61,0x350C9B64,0x31CD86D3,0x3C8EA00A,0x384FBDBD,
			0x4C11DB70,0x48D0C6C7,0x4593E01E,0x4152FDA9,0x5F15ADAC,0x5BD4B01B,0x569796C2,0x52568B75,
			0x6A1936C8,0x6ED82B7F,0x639B0DA6,0x675A1011,0x791D4014,0x7DDC5DA3,0x709F7B7A,0x745E66CD,
			0x9823B6E0,0x9CE2AB57,0x91A18D8E,0x95609039,0x8B27C03C,0x8FE6DD8B,0x82A5FB52,0x8664E6E5,
			0xBE2B5B58,0xBAEA46EF,0xB7A96036,0xB3687D81,0xAD2F2D84,0xA9EE3033,0xA4AD16EA,0xA06C0B5D,
			0xD4326D90,0xD0F37027,0xDDB056FE,0xD9714B49,0xC7361B4C,0xC3F706FB,0xCEB42022,0xCA753D95,
			0xF23A8028,0xF6FB9D9F,0xFBB8BB46,0xFF79A6F1,0xE13EF6F4,0xE5FFEB43,0xE8BCCD9A,0xEC7DD02D,
			0x34867077,0x30476DC0,0x3D044B19,0x39C556AE,0x278206AB,0x23431B1C,0x2E003DC5,0x2AC12072,
			0x128E9DCF,0x164F8078,0x1B0CA6A1,0x1FCDBB16,0x018AEB13,0x054BF6A4,0x0808D07D,0x0CC9CDCA,
			0x7897AB07,0x7C56B6B0,0x71159069,0x75D48DDE,0x6B93DDDB,0x6F52C06C,0x6211E6B5,0x66D0FB02,
			0x5E9F46BF,0x5A5E5B08,0x571D7DD1,0x53DC6066,0x4D9B3063,0x495A2DD4,0x44190B0D,0x40D816BA,
			0xACA5C697,0xA864DB20,0xA527FDF9,0xA1E6E04E,0xBFA1B04B,0xBB60ADFC,0xB6238B25,0xB2E29692,
			0x8AAD2B2F,0x8E6C3698,0x832F1041,0x87EE0DF6,0x99A95DF3,0x9D684044,0x902B669D,0x94EA7B2A,
			0xE0B41DE7,0xE4750050,0xE9362689,0xEDF73B3E,0xF3B06B3B,0xF771768C,0xFA325055,0xFEF34DE2,
			0xC6BCF05F,0xC27DEDE8,0xCF3ECB31,0xCBFFD686,0xD5B88683,0xD1799B34,0xDC3ABDED,0xD8FBA05A,
			0x690CE0EE,0x6DCDFD59,0x608EDB80,0x644FC637,0x7A089632,0x7EC98B85,0x738AAD5C,0x774BB0EB,
			0x4F040D56,0x4BC510E1,0x46863638,0x42472B8F,0x5C007B8A,0x58C1663D,0x558240E4,0x51435D53,
			0x251D3B9E,0x21DC2629,0x2C9F00F0,0x285E1D47,0x36194D42,0x32D850F5,0x3F9B762C,0x3B5A6B9B,
			0x0315D626,0x07D4CB91,0x0A97ED48,0x0E56F0FF,0x1011A0FA,0x14D0BD4D,0x19939B94,0x1D528623,
			0xF12F560E,0xF5EE4BB9,0xF8AD6D60,0xFC6C70D7,0xE22B20D2,0xE6EA3D65,0xEBA91BBC,0xEF68060B,
			0xD727BBB6,0xD3E6A601,0xDEA580D8,0xDA649D6F,0xC423CD6A,0xC0E2D0DD,0xCDA1F604,0xC960EBB3,
			0xBD3E8D7E,0xB9FF90C9,0xB4BCB610,0xB07DABA7,0xAE3AFBA2,0xAAFBE615,0xA7B8C0CC,0xA379DD7B,
			0x9B3660C6,0x9FF77D71,0x92B45BA8,0x9675461F,0x8832161A,0x8CF30BAD,0x81B02D74,0x857130C3,
			0x5D8A9099,0x594B8D2E,0x5408ABF7,0x50C9B640,0x4E8EE645,0x4A4FFBF2,0x470CDD2B,0x43CDC09C,
			0x7B827D21,0x7F436096,0x7200464F,0x76C15BF8,0x68860BFD,0x6C47164A,0x61043093,0x65C52D24,
			0x119B4BE9,0x155A565E,0x18197087,0x1CD86D30,0x029F3D35,0x065E2082,0x0B1D065B,0x0FDC1BEC,
			0x3793A651,0x3352BBE6,0x3E119D3F,0x3AD08088,0x2497D08D,0x2056CD3A,0x2D15EBE3,0x29D4F654,
			0xC5A92679,0xC1683BCE,0xCC2B1D17,0xC8EA00A0,0xD6AD50A5,0xD26C4D12,0xDF2F6BCB,0xDBEE767C,
			0xE3A1CBC1,0xE760D676,0xEA23F0AF,0xEEE2ED18,0xF0A5BD1D,0xF464A0AA,0xF9278673,0xFDE69BC4,
			0x89B8FD09,0x8D79E0BE,0x803AC667,0x84FBDBD0,0x9ABC8BD5,0x9E7D9662,0x933EB0BB,0x97FFAD0C,
			0xAFB010B1,0xAB710D06,0xA6322BDF,0xA2F33668,0xBCB4666D,0xB8757BDA,0xB5365D03,0xB1F740B4
		};

		/// <summary>
		///
		/// </summary>
		/// <param name="cmd"></param>
		/// <param name="length"></param>
		/// <returns></returns>
		public static UInt32 GenFuncCRC32Table(byte[] cmd, int length)
		{
			UInt32 nReg = 0xFFFFFFFF;//CRC寄存器
			UInt32 nTemp = 0;
			UInt32 byteIndex = 0, uIndex = 0;
			//---开始计算CRC32的值
			for (uIndex = 0; uIndex < length; uIndex++)
			{
				//---强制转换为4字节数据
				nReg ^= (UInt32)cmd[uIndex];
				//---4字节数据计算
				for (byteIndex = 0; byteIndex < 4; byteIndex++)
				{
					//---取一个字节，查表
					nTemp = GenFunc.crc32Tab[((nReg >> 24) & 0xFF)];
					//---丢掉计算过的头一个BYTE
					nReg <<= 8;
					//---与前一个BYTE的计算结果异或
					nReg ^= nTemp;
				}
			}
			return nReg;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="cmd"></param>
		/// <param name="length"></param>
		/// <returns></returns>
		public static UInt32 GenFuncCRC32Table(UInt32[] cmd, int length)
		{
			UInt32 nReg = 0xFFFFFFFF;//CRC寄存器
			UInt32 nTemp = 0;
			UInt32 byteIndex = 0, uIndex = 0;
			//---开始计算CRC32的值
			for (uIndex = 0; uIndex < length; uIndex++)
			{
				//---强制转换为4字节数据
				nReg ^= cmd[uIndex];
				//---4字节数据计算
				for (byteIndex = 0; byteIndex < 4; byteIndex++)
				{
					//---取一个字节，查表
					nTemp = GenFunc.crc32Tab[((nReg >> 24) & 0xFF)];
					//---丢掉计算过的头一个BYTE
					nReg <<= 8;
					//---与前一个BYTE的计算结果异或
					nReg ^= nTemp;
				}
			}
			return nReg;
		}

		#endregion CRC32

		#region CRC16

		/// <summary>
		/// CRC16表
		/// </summary>
		private static UInt16[] crc16Table = new UInt16[256]
		{
			0x0000, 0x1021, 0x2042, 0x3063, 0x4084, 0x50a5, 0x60c6, 0x70e7,
			0x8108, 0x9129, 0xa14a, 0xb16b, 0xc18c, 0xd1ad, 0xe1ce, 0xf1ef,
			0x1231, 0x0210, 0x3273, 0x2252, 0x52b5, 0x4294, 0x72f7, 0x62d6,
			0x9339, 0x8318, 0xb37b, 0xa35a, 0xd3bd, 0xc39c, 0xf3ff, 0xe3de,
			0x2462, 0x3443, 0x0420, 0x1401, 0x64e6, 0x74c7, 0x44a4, 0x5485,
			0xa56a, 0xb54b, 0x8528, 0x9509, 0xe5ee, 0xf5cf, 0xc5ac, 0xd58d,
			0x3653, 0x2672, 0x1611, 0x0630, 0x76d7, 0x66f6, 0x5695, 0x46b4,
			0xb75b, 0xa77a, 0x9719, 0x8738, 0xf7df, 0xe7fe, 0xd79d, 0xc7bc,
			0x48c4, 0x58e5, 0x6886, 0x78a7, 0x0840, 0x1861, 0x2802, 0x3823,
			0xc9cc, 0xd9ed, 0xe98e, 0xf9af, 0x8948, 0x9969, 0xa90a, 0xb92b,
			0x5af5, 0x4ad4, 0x7ab7, 0x6a96, 0x1a71, 0x0a50, 0x3a33, 0x2a12,
			0xdbfd, 0xcbdc, 0xfbbf, 0xeb9e, 0x9b79, 0x8b58, 0xbb3b, 0xab1a,
			0x6ca6, 0x7c87, 0x4ce4, 0x5cc5, 0x2c22, 0x3c03, 0x0c60, 0x1c41,
			0xedae, 0xfd8f, 0xcdec, 0xddcd, 0xad2a, 0xbd0b, 0x8d68, 0x9d49,
			0x7e97, 0x6eb6, 0x5ed5, 0x4ef4, 0x3e13, 0x2e32, 0x1e51, 0x0e70,
			0xff9f, 0xefbe, 0xdfdd, 0xcffc, 0xbf1b, 0xaf3a, 0x9f59, 0x8f78,
			0x9188, 0x81a9, 0xb1ca, 0xa1eb, 0xd10c, 0xc12d, 0xf14e, 0xe16f,
			0x1080, 0x00a1, 0x30c2, 0x20e3, 0x5004, 0x4025, 0x7046, 0x6067,
			0x83b9, 0x9398, 0xa3fb, 0xb3da, 0xc33d, 0xd31c, 0xe37f, 0xf35e,
			0x02b1, 0x1290, 0x22f3, 0x32d2, 0x4235, 0x5214, 0x6277, 0x7256,
			0xb5ea, 0xa5cb, 0x95a8, 0x8589, 0xf56e, 0xe54f, 0xd52c, 0xc50d,
			0x34e2, 0x24c3, 0x14a0, 0x0481, 0x7466, 0x6447, 0x5424, 0x4405,
			0xa7db, 0xb7fa, 0x8799, 0x97b8, 0xe75f, 0xf77e, 0xc71d, 0xd73c,
			0x26d3, 0x36f2, 0x0691, 0x16b0, 0x6657, 0x7676, 0x4615, 0x5634,
			0xd94c, 0xc96d, 0xf90e, 0xe92f, 0x99c8, 0x89e9, 0xb98a, 0xa9ab,
			0x5844, 0x4865, 0x7806, 0x6827, 0x18c0, 0x08e1, 0x3882, 0x28a3,
			0xcb7d, 0xdb5c, 0xeb3f, 0xfb1e, 0x8bf9, 0x9bd8, 0xabbb, 0xbb9a,
			0x4a75, 0x5a54, 0x6a37, 0x7a16, 0x0af1, 0x1ad0, 0x2ab3, 0x3a92,
			0xfd2e, 0xed0f, 0xdd6c, 0xcd4d, 0xbdaa, 0xad8b, 0x9de8, 0x8dc9,
			0x7c26, 0x6c07, 0x5c64, 0x4c45, 0x3ca2, 0x2c83, 0x1ce0, 0x0cc1,
			0xef1f, 0xff3e, 0xcf5d, 0xdf7c, 0xaf9b, 0xbfba, 0x8fd9, 0x9ff8,
			0x6e17, 0x7e36, 0x4e55, 0x5e74, 0x2e93, 0x3eb2, 0x0ed1, 0x1ef0
		};

		/// <summary>
		///
		/// </summary>
		/// <param name="cmd"></param>
		/// <param name="length"></param>
		/// <returns></returns>
		public static UInt16 GenFuncCRC16Table(byte[] cmd, int length)
		{
			byte nTemp;
			UInt32 nReg = 0;
			UInt32 index = 0;
			for (index = 0; index < length; index++)
			{
				nTemp = (byte)((nReg >> 8) ^ cmd[index]);
				nReg = (nReg << 8) ^ GenFunc.crc16Table[nTemp];
			}
			return (UInt16)nReg;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="cmd"></param>
		/// <param name="length"></param>
		/// <returns></returns>
		public static UInt16 GenFuncCRC16Table(UInt16[] cmd, int length)
		{
			byte nTemp;
			UInt32 nReg = 0;
			UInt32 index = 0;
			for (index = 0; index < length; index++)
			{
				nTemp = (byte)((nReg >> 8) ^ cmd[index]);
				nReg = (nReg << 8) ^ GenFunc.crc16Table[nTemp];
			}
			return (UInt16)nReg;
		}

		#endregion CRC16

		#region CRC8

		/// <summary>
		/// CRC8表
		/// </summary>
		public static byte[] crc8Table = new byte[256]
		{
			0x00,0x07,0x0E,0x09,0x1C,0x1B,0x12,0x15,0x38,0x3F,0x36,0x31,0x24,0x23,0x2A,0x2D,
			0x70,0x77,0x7E,0x79,0x6C,0x6B,0x62,0x65,0x48,0x4F,0x46,0x41,0x54,0x53,0x5A,0x5D,
			0xE0,0xE7,0xEE,0xE9,0xFC,0xFB,0xF2,0xF5,0xD8,0xDF,0xD6,0xD1,0xC4,0xC3,0xCA,0xCD,
			0x90,0x97,0x9E,0x99,0x8C,0x8B,0x82,0x85,0xA8,0xAF,0xA6,0xA1,0xB4,0xB3,0xBA,0xBD,
			0xC7,0xC0,0xC9,0xCE,0xDB,0xDC,0xD5,0xD2,0xFF,0xF8,0xF1,0xF6,0xE3,0xE4,0xED,0xEA,
			0xB7,0xB0,0xB9,0xBE,0xAB,0xAC,0xA5,0xA2,0x8F,0x88,0x81,0x86,0x93,0x94,0x9D,0x9A,
			0x27,0x20,0x29,0x2E,0x3B,0x3C,0x35,0x32,0x1F,0x18,0x11,0x16,0x03,0x04,0x0D,0x0A,
			0x57,0x50,0x59,0x5E,0x4B,0x4C,0x45,0x42,0x6F,0x68,0x61,0x66,0x73,0x74,0x7D,0x7A,
			0x89,0x8E,0x87,0x80,0x95,0x92,0x9B,0x9C,0xB1,0xB6,0xBF,0xB8,0xAD,0xAA,0xA3,0xA4,
			0xF9,0xFE,0xF7,0xF0,0xE5,0xE2,0xEB,0xEC,0xC1,0xC6,0xCF,0xC8,0xDD,0xDA,0xD3,0xD4,
			0x69,0x6E,0x67,0x60,0x75,0x72,0x7B,0x7C,0x51,0x56,0x5F,0x58,0x4D,0x4A,0x43,0x44,
			0x19,0x1E,0x17,0x10,0x05,0x02,0x0B,0x0C,0x21,0x26,0x2F,0x28,0x3D,0x3A,0x33,0x34,
			0x4E,0x49,0x40,0x47,0x52,0x55,0x5C,0x5B,0x76,0x71,0x78,0x7F,0x6A,0x6D,0x64,0x63,
			0x3E,0x39,0x30,0x37,0x22,0x25,0x2C,0x2B,0x06,0x01,0x08,0x0F,0x1A,0x1D,0x14,0x13,
			0xAE,0xA9,0xA0,0xA7,0xB2,0xB5,0xBC,0xBB,0x96,0x91,0x98,0x9F,0x8A,0x8D,0x84,0x83,
			0xDE,0xD9,0xD0,0xD7,0xC2,0xC5,0xCC,0xCB,0xE6,0xE1,0xE8,0xEF,0xFA,0xFD,0xF4,0xF3
		};

		/// <summary>
		///
		/// </summary>
		/// <param name="cmd"></param>
		/// <param name="length"></param>
		/// <returns></returns>
		public static byte GenFuncCRC8Table(byte[] cmd, int length)
		{
			byte nTemp;
			byte nReg = 0;
			UInt32 index = 0;
			for (index = 0; index < length; index++)
			{
				nTemp = (byte)(nReg ^ cmd[index]);
				nReg = GenFunc.crc8Table[nTemp];
			}
			return (byte)nReg;
		}

		#endregion CRC8

		#region 校验和

		/// <summary>
		///
		/// </summary>
		/// <param name="cmd"></param>
		/// <param name="length"></param>
		/// <returns></returns>
		public static byte GenFuncCheckSum(byte[] cmd, int length)
		{
			UInt32 i = 0;
			byte _return = 0;
			for (i = 0; i < length; i++)
			{
				_return += cmd[i];
			}
			//---计算的校验和
			_return = (byte)(0x100 - _return);
			return _return;
		}

		#endregion 校验和
	}
}