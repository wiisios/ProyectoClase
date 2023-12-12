using Proyecto.Entities;

namespace Proyecto.Data.Interfaces
{
    public interface IUrlService
    {
        string GetFullURL(string url);
        URL GetById(int urlId);
        URL Create(string fullurl, Category category, User user);

    }
}
