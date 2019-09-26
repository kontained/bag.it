using System;
using System.Text;

namespace Bag.It.Models
{
    public class AuthSettings
    {
        public string Secret { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }

        public byte[] GetSecretBytes()
        {
            if (string.IsNullOrWhiteSpace(Secret)) throw new Exception("Secret is null!");

            return Encoding.ASCII.GetBytes(Secret);
        }
    }
}