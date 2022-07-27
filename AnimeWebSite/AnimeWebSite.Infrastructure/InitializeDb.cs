using AnimeWebSite.Domain.Entities;
using static AnimeWebSite.Domain.Entities.Anime;

namespace AnimeWebSite.Infrastructure
{
    public class InitializeDb
    {
        private AnimeWebSiteDbContext _context;

        public InitializeDb(AnimeWebSiteDbContext context)
        {
            _context = context;
        }

        public static void Init(AnimeWebSiteDbContext _context)
        {
            _context.Animes.AddRange(
                new Anime
                {
                    Name = "Throne of Seal",
                    OriginalName = "Shen Yin Wangzuo",
                    Description = "While the demons were rising, mankind was about to become extinct. Six temples rose, and protected the last of mankind. A young boy joins the temple as a knight to save his mother. During his journey of wonders and mischief in the world of temples and demons, will he be able to ascend to become the strongest knight and inherit the throne?",
                    Episodes = 25,
                    CurrentEpisodes = 13,
                   // Genres =Genre.Action,
                    ReleaseDate = new DateOnly(2022, 05, 28),
                    PostedOn = DateTime.Now,
                    ImagePath = "/Files/Test1.jpg"

                },
                new Anime
                {
                    Name = "Swallowed Star",
                    OriginalName = "Tunshi Xingkong",
                    Description = "One day, the RR virus of unknown origin appears on earth and disaster strikes the world. The infected animals mutate into terrifying monsters and attack on a large scale. When humans faced destruction, they built walls and founded cities as humanity’s last strongholds. The trials that mankind experiences during this period are called the “Nirvana Period”.In such an extreme living environment,human physical strength also gradually evolved and developed,martial arts sprang up,and human physical strength was qualitatively increasing compared to before.And the best of them is called “Warriors”. 18 - year - old Luo Feng also dreams of becoming one of them.Right now,he was about to take the college entrance exam and face a choice at a crossroads in his life,but suddenly a monster attack affects the trajectory of his life.",
                    Episodes = 26,
                    CurrentEpisodes = 9,
                    //Genres =Genre.Action,
                    ReleaseDate = new DateOnly(2020, 09, 29),
                    PostedOn = DateTime.Now,
                    ImagePath = "/Files/Test2.jpg"
                });
            _context.SaveChanges();
        }

    }
}
