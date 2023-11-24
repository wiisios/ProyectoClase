using Proyecto.Data;
using Proyecto.Entities;

namespace Proyecto.Services
{
    public class URLService
    {
        private readonly URLContext _context;
        private readonly URLHelpers _urlhelpers;

        public URLService(URLContext context, URLHelpers urlhelpers)
        {
            _context = context;
            _urlhelpers = urlhelpers;
        }

        public string GetURL(string url)
        {
            if (url.Length <= 6)
            {
                URL? theshorturl = _context.Urls.SingleOrDefault(u => u.ShortUrl == url);
                if (theshorturl != null)
                {
                    theshorturl.VisitCounter += 1;
                }
                return theshorturl.Url;
            }
            
            URL? theurl = _context.Urls.SingleOrDefault(u => u.Url == url);
            if (theurl != null)
            {
                theurl.VisitCounter += 1;
            }
            return theurl.ShortUrl;
        }

        public URL Create(string fullurl, string category)
        {
            string shortenedurl = _urlhelpers.GenerateShortURL();

            URL url  = new URL()
            {
                Url = fullurl,
                ShortUrl = shortenedurl,
                VisitCounter = 1,
                Catergory = category,
              
            };
            _context.Urls.Add(url);
            _context.SaveChanges();

            return (url);
        }
    }
}
