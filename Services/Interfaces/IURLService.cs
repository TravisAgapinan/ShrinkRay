using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URLShortener.Models;
using URLShortener.Models.Domain;

namespace URLShortener.Services.Interfaces
{
    public interface IURLService
    {
        int Insert(URLRequestModel model);
        URL GetBySlug(string slug);
        URL GetByUrl(string url);
    }
}
