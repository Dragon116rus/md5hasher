﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace md5hasher
{
    class Md5hasher
    {
        byte[] sourceBytes;
        public string hash(string sourcePhrase)
        {
            firstStep(sourcePhrase);
            secondStep(sourcePhrase);
            // fourthStep();

            return sourcePhrase;
        }
        #region firstStep
        private void firstStep(string sourcePhrase)
        {
            byte[] intermediate = toByteArray(sourcePhrase);
            sourceBytes = new byte[getSourceBytesLength(sourcePhrase)];
            copyIntermediateInSource(intermediate, sourceBytes);
            insertSolitaryByte(sourceBytes, intermediate.Length);
        }
        private byte[] toByteArray(string phrase)
        {
            byte[] bytes = new byte[phrase.Length * sizeof(char)];
            System.Buffer.BlockCopy(phrase.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }
        private uint getSourceBytesLength(string phrase)
        {
            uint result = 512 + 448;
            while (result <= phrase.Length * sizeof(char) + 1)
            {
                result += 512;
            }
            return result;
        }
        private void copyIntermediateInSource(byte[] intermediate, byte[] source)
        {
            System.Buffer.BlockCopy(intermediate, 0, source, 0, intermediate.Length);
        }
        private void insertSolitaryByte(byte[] sourceBytes, int position)
        {
            sourceBytes[position] = 0x80;
        }
        #endregion
        #region secondStep
        private void secondStep(string sourcePhrase)
        {
            uint lengthOfPhraseInBits =(uint) sourcePhrase.Length*sizeof(char)*8;
            int startedPositionToInsert = sourceBytes.Length - 8;
            byte[] lengthInBytes = getLengthInBytes(lengthOfPhraseInBits);
            System.Buffer.BlockCopy(lengthInBytes, 0, sourceBytes, startedPositionToInsert, lengthInBytes.Length);
        }
        private byte[] getLengthInBytes(uint lengthOfPhrase)
        {
            byte[] lengthInBytes = BitConverter.GetBytes(lengthOfPhrase);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(lengthInBytes);
            }
            return lengthInBytes;
        }
        #endregion
        #region thirdStep
        uint wordA = 0x67452301,
              wordB = 0xefcdab89,
              wordC = 0x98badcfe,
              wordD = 0x10325476;
        uint[] s = {
            7, 12, 17, 22, 7, 12, 17, 22, 7, 12, 17, 22, 7, 12, 17, 22 ,
            5,  9, 14, 20,  5,  9, 14, 20,  5,  9, 14, 20,  5,  9, 14, 20,
            4, 11, 16, 23,  4, 11, 16, 23,  4, 11, 16, 23,  4, 11, 16, 23,
            6, 10, 15, 21,  6, 10, 15, 21,  6, 10, 15, 21,  6, 10, 15, 21
        };
        uint[] K =
        {
            0xd76aa478, 0xe8c7b756, 0x242070db, 0xc1bdceee,
            0xf57c0faf, 0x4787c62a, 0xa8304613, 0xfd469501,
            0x698098d8, 0x8b44f7af, 0xffff5bb1, 0x895cd7be,
            0x6b901122, 0xfd987193, 0xa679438e, 0x49b40821,
            0xf61e2562, 0xc040b340, 0x265e5a51, 0xe9b6c7aa,
            0xd62f105d, 0x02441453, 0xd8a1e681, 0xe7d3fbc8,
            0x21e1cde6, 0xc33707d6, 0xf4d50d87, 0x455a14ed,
            0xa9e3e905, 0xfcefa3f8, 0x676f02d9, 0x8d2a4c8a,
            0xfffa3942, 0x8771f681, 0x6d9d6122, 0xfde5380c,
            0xa4beea44, 0x4bdecfa9, 0xf6bb4b60, 0xbebfbc70,
            0x289b7ec6, 0xeaa127fa, 0xd4ef3085, 0x04881d05,
            0xd9d4d039, 0xe6db99e5, 0x1fa27cf8, 0xc4ac5665,
            0xf4292244, 0x432aff97, 0xab9423a7, 0xfc93a039,
            0x655b59c3, 0x8f0ccc92, 0xffeff47d, 0x85845dd1,
            0x6fa87e4f, 0xfe2ce6e0, 0xa3014314, 0x4e0811a1,
            0xf7537e82, 0xbd3af235, 0x2ad7d2bb, 0xeb86d391
        };
        uint funF(uint x, uint y, uint z)
        {
            return (x | y) & (~x | z);
        }
        uint funG(uint x, uint y, uint z)
        {
            return (x | z) & (~z | y);
        }
        uint funH(uint x, uint y, uint z)
        {
            return x ^ y ^ z;
        }
        uint funI(uint x, uint y, uint z)
        {
            return y ^ ((~z) & x);
        }
        #endregion
        #region fourthStep
        private void fourthStep()
        {
            for (int iteration = 0; iteration < getCountOfIteration(); iteration++ )
            {
                uint wordAA = wordA;
                uint wordBB = wordB;
                uint wordCC = wordC;
                uint wordDD = wordD;
                
            }
            
        }
        private int getCountOfIteration()
        {
            return (sourceBytes.Length * 8) / 512;
        }
        private void stage1(ref uint wordAA, ref uint wordBB,ref uint wordCC, ref uint wordDD)
        {
            for (int i = 0; i < 16; i++)
            {

            }
        }
        private uint functionForStage1(uint a, uint b , uint c , uint d,)
        {
            return b + ((a + funF(b, c, d) + X[k] + T[i]) <<< s);
        }
        #endregion
    }
}
