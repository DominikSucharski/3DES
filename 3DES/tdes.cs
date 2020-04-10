using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DES
{
    class tdes
    {
        private des _des;
        public tdes()
        {
            _des = new des();
        }

        public UInt64 EncryptBlock(UInt64 block, UInt64 key1, UInt64 key2, UInt64 key3)
        {
            // input, key1
            UInt64 result = _des.Encrypt(block, key1);
            // key 2
            result = _des.Decrypt(result, key2);
            // key 3
            result = _des.Encrypt(result, key3);
            return result;
        }

        public UInt64 DecryptBlock(UInt64 block, UInt64 key1, UInt64 key2, UInt64 key3)
        {
            // input, key1
            UInt64 result = _des.Decrypt(block, key3);
            // key 2
            result = _des.Encrypt(result, key2);
            // key 3
            result = _des.Decrypt(result, key1);
            return result;
        }
    }
}
