using Proyecto.Data;
using Proyecto.Entities;
using System.Text;

namespace Proyecto.Services
{
    public class URLHelpers
    {

        public string GenerateShortURL()
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var shortUrl = new StringBuilder();

            for (int i = 0; i < 6; i++)
            {
                shortUrl.Append(chars[random.Next(chars.Length)]);
            }

            return shortUrl.ToString();
        }

    }
}
