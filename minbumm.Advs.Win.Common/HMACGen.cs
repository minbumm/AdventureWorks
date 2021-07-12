using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace minbumm.Advs.Win.Common
{
    public enum HMACType
    {
        MD5 = 0,
        SHA1,
        SHA2,
        SHA256
    }

    class HMACGen
    {
        public static string GenerateHMAC(string key, string message, HMACType hmacType)
        {
            byte[] hashmessage = new byte[1];
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            byte[] keyByte = encoding.GetBytes(key);
            byte[] messageBytes = encoding.GetBytes(message == null ? string.Empty : message);

            if (hmacType == HMACType.MD5)
            {
                HMACMD5 hmacmd5 = new HMACMD5(keyByte);
                hashmessage = hmacmd5.ComputeHash(messageBytes);
            }
            else if (hmacType == HMACType.SHA1)
            {
                HMACSHA1 hmacsha1 = new HMACSHA1(keyByte);
                hashmessage = hmacsha1.ComputeHash(messageBytes);
            }
            else if (hmacType == HMACType.SHA256)
            {
                HMACSHA256 hmacsha256 = new HMACSHA256(keyByte);
                hashmessage = hmacsha256.ComputeHash(messageBytes);
            }

            return ByteToString(hashmessage);
        }
        public static string ByteToString(byte[] buff)
        {
            string sbinary = "";

            for (int i = 0; i < buff.Length; i++)
            {
                sbinary += buff[i].ToString("X2"); // hex format
            }
            return (sbinary);
        }
    }
}
