using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeWebSite.Domain.Common
{
    public class UserViewForComment
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string ImagePath { get; set; }

        public DateTime RegistrationDate { get; set; }
    }
}
