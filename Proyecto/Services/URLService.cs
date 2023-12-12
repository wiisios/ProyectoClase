using Proyecto.Data;
using Proyecto.Data.Interfaces;
using Proyecto.Entities;

namespace Proyecto.Services
{
    public class URLService : IUrlService
    {
        private readonly URLContext _context;
        private readonly URLHelpers _urlhelpers;


        public URLService(URLContext context, URLHelpers urlhelpers)
        {
            _context = context;
            _urlhelpers = urlhelpers;
        }

        public string GetFullURL(string url)
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

        public URL GetById(int urlId)
        {
            return _context.Urls.SingleOrDefault(x => x.Id == urlId);
        }

        public URL Create(string fullurl, Category category, User user)
        {
            string shortenedurl = _urlhelpers.GenerateShortURL();

            URL url  = new URL()
            {
                Url = fullurl,
                ShortUrl = shortenedurl,
                VisitCounter = 1,
                Category = category,
                User = user
                 
            };
            

            _context.Urls.Add(url);
            _context.SaveChanges();

            return (url);
        }
    }
}
