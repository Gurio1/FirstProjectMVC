using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeWebSite.Contracts.AnimeCommsAndReviews
{
    public sealed class AnimeReviewViewModel
    {
        public int UserId { get; set; }

        public string Content { get; set; }

        public DateTime PostedOn { get; set; }
    }
}
