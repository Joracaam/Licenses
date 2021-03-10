using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Licenses.Interfaces
{
    public interface IVerifyHash
    {
        string GetMd5Hash(string input, int Counter);
        bool VerifyMd5Hash(string input, string hash, int verCounter);
    }
}
