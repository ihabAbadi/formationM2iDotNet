using Ecommerce.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Services
{
    public class HashService : IHash
    {
        public string GetHash(HashAlgorithm algo, string chaine)
        {
            byte[] hashData = algo.ComputeHash(Encoding.UTF8.GetBytes(chaine));
            StringBuilder sBuilder = new StringBuilder();
            for(int i=0; i< hashData.Length; i++)
            {
                sBuilder.Append(hashData[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        public bool VerifyHash(HashAlgorithm algo, string chaine, string hash)
        {
            string chaineHash = GetHash(algo, chaine);
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            return comparer.Compare(chaineHash, hash) == 0;
        }
        
    }
}
