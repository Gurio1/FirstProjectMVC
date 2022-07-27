using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeWebSite.Services.Abstractions
{
    public interface IServiceManager
    {
        IAnimeService AnimeService { get; }
    }
}
