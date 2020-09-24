using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace AnnoncesAspNet.Interface
{
    public interface IHash
    {
        string GetHash(HashAlgorithm algo, string chaine);
        bool VerifyHash(HashAlgorithm algo, string chaine, string hash);
    }
}
