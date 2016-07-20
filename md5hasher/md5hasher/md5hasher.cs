using System;
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
            // secondStep(sourcePhrase);
            // thirdStep(sourcePhrase);
            // fourhStep(sourcePhrase);
            return sourcePhrase;
        }
        #region firstStep
        private void firstStep(string sourcePhrase)
        {
            byte[] intermediate = toByteArray(sourcePhrase);
            sourceBytes = new byte[getSourceBytesLength(sourcePhrase)];
            copyIntermediateInSource(intermediate,sourceBytes);
            insertSolitaryByte(sourceBytes,intermediate.Length);
        }
        private byte[] toByteArray(string phrase)
        {
            byte[] bytes = new byte[phrase.Length * sizeof(char)];
            System.Buffer.BlockCopy(phrase.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }
        private int getSourceBytesLength(string phrase)
        {
            int result = 512 + 448;
            while(result<=phrase.Length*sizeof(char)+1)
            {
                result += 512;
            }
            return result;
        }
        private void copyIntermediateInSource(byte[] intermediate,byte[] source)
        {
            System.Buffer.BlockCopy(intermediate, 0, source, 0, intermediate.Length);
        }
        private void insertSolitaryByte(byte[] sourceBytes,int position)
        {
            sourceBytes[position] = 0x80;
        }
        #endregion 
    }
}
