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

        public URL? GetURL(string url)
        {
            URL? theurl = _context.Urls.SingleOrDefault(u => u.Url == url);
            theurl.VisitCounter += 1;
            return theurl;
        }

        public URL Create(string fullurl)
        {
            string shortenedurl = _urlhelpers.GenerateShortURL();

            URL url  = new URL()
            {
                Url = fullurl,
                ShortUrl = shortenedurl,
                VisitCounter = 1,
                Catergory = string.Empty,
              
            };
            _context.Urls.Add(url);
            _context.SaveChanges();

            return (url);
        }
    }
}
