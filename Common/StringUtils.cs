﻿using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Common
{
    public class StringUtils
    {
        private const string PwdKey = "z619815x";
        private static readonly byte[] Keys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };

        public static string Encrypt(string encryptString)
        {
            try
            {
                var rgbKey = Encoding.UTF8.GetBytes(PwdKey.Substring(0, 8));
                var rgbIv = Keys;
                var inputByteArray = Encoding.UTF8.GetBytes(encryptString);
                var dCsp = new DESCryptoServiceProvider();
                var mStream = new MemoryStream();
                var cStream = new CryptoStream(mStream, dCsp.CreateEncryptor(rgbKey, rgbIv), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Convert.ToBase64String(mStream.ToArray());
            }
            catch
            {
                return encryptString;
            }
        }

        public static string Decrypt(string decryptString)
        {
            try
            {
                var rgbKey = Encoding.UTF8.GetBytes(PwdKey);
                var rgbIv = Keys;
                var inputByteArray = Convert.FromBase64String(decryptString);
                var dcsp = new DESCryptoServiceProvider();
                var mStream = new MemoryStream();
                var cStream = new CryptoStream(mStream, dcsp.CreateDecryptor(rgbKey, rgbIv), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Encoding.UTF8.GetString(mStream.ToArray());
            }
            catch
            {
                return decryptString;
            }
        }

        public static string GetMd5(string value)
        {
            var md5 = new MD5CryptoServiceProvider();
            var bytValue = Encoding.UTF8.GetBytes(value);
            var bytHash = md5.ComputeHash(bytValue);
            md5.Clear();
            var sTemp = bytHash.Aggregate("", (current, t) => current + t.ToString("X").PadLeft(2, '0'));
            return sTemp.ToUpper();
        }
    }
}