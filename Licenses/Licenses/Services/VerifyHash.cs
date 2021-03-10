using Licenses.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace Licenses.Services
{

    public class VerifyHash: IVerifyHash
    {
        readonly MD5 md5Hash;

        public VerifyHash()
        {
            md5Hash = MD5.Create();
        }

        public string GetMd5Hash(string input, int Counter)
        {
            try
            {
                // Create a new Stringbuilder to store the bytes
                // and then form the hash string
                StringBuilder sBuilder = new StringBuilder();

                // Convert input string to byte Array and then compute the hash.
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Convert each byte in array to hexadecimal string

                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }


                // Call the function recursively
                if (Counter > 0)
                {
                    Debug.WriteLine($"Contador No.: {Counter} Actual Hash: {sBuilder}");
                    Counter -= 1;
                    return GetMd5Hash(sBuilder.ToString(), Counter);
                }
                // Return hexadecimal string
                else
                {
                    Debug.WriteLine($"Contador No.: {Counter} Actual Hash: {sBuilder}");
                    return sBuilder.ToString().Substring(0, 20);
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine($"Exception in GetHash method: {exception.Message}");
                return null;
            }
        }

        // Verify the Hash with a string
        public bool VerifyMd5Hash(string input, string hash, int verCounter)
        {
            try
            {

                // Create a StringComparer an compare the hashes.
                StringComparer comparer = StringComparer.OrdinalIgnoreCase;

                if (0 == comparer.Compare(GetMd5Hash(input, verCounter), hash))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception in VerifyMd5Hash: {ex.Message}");
                return false;
            }
        }
    }  
}
