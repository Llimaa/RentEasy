using System.Security.Cryptography;
using System.Text;

namespace RentEasy.Domain.ValueObjects
{
    public class Password
    {
        public Password()
        {

        }
        public Password(string value)
        {
            Value = value;
            if (value.Length > 4)
                Encrypt();
            else
                Value = "";
        }

        public string Value { get; private set; }

        protected void Encrypt()
        {
            byte[] temp;

            SHA1 sha = new SHA1CryptoServiceProvider();
            temp = sha.ComputeHash(Encoding.UTF8.GetBytes(Value));

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < temp.Length; i++)
                sb.Append(temp[i].ToString("x2"));

            Value = sb.ToString();
        }

        public void update(string password)
        {
            Value = password;
            Encrypt();
        }
    }
}
