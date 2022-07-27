using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeWebSite.Domain.Exceptions
{
    public sealed class AnimeNotFoundException : NotFoundException
    {
        public AnimeNotFoundException(int id)
            :base($"The anime with the Id {id} was not found")
        {

        }
    }
}
