﻿using AnimeWebSite.Domain.Common;
using AnimeWebSite.Domain.Entities;
using AnimeWebSite.Identity.Domain.Entities.Users;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;
using static AnimeWebSite.Domain.Entities.Anime;

namespace AnimeWebSite.Infrastructure
{
    public static class SeedDb
    {
        public static void Init(this IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<AnimeWebSiteDbContext>();
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetService<RoleManager<ApplicationRole>>();
            var _mapper = serviceProvider.GetService<IMapper>();

            #region Add anime in DB
            var anime = new Anime
            {
                Name = "Throne of Seal",
                OriginalName = "Shen Yin Wangzuo",
                Description = "While the demons were rising, mankind was about to become extinct. Six temples rose, and protected the last of mankind. A young boy joins the temple as a knight to save his mother. During his journey of wonders and mischief in the world of temples and demons, will he be able to ascend to become the strongest knight and inherit the throne?",
                Episodes = 25,
                CurrentEpisodes = 13,
                Genres = Genre.Action,
                ReleaseDate = new DateOnly(2022, 05, 28),
                PostedOn = DateTime.Now,
                ImagePath = "/Files/AnimeImages/Test1.jpg"

            };
            context.Animes.AddRange(anime
                ,
                new Anime
                {
                    Name = "Swallowed Star",
                    OriginalName = "Tunshi Xingkong",
                    Description = "One day, the RR virus of unknown origin appears on earth and disaster strikes the world. The infected animals mutate into terrifying monsters and attack on a large scale. When humans faced destruction, they built walls and founded cities as humanity’s last strongholds. The trials that mankind experiences during this period are called the “Nirvana Period”.In such an extreme living environment,human physical strength also gradually evolved and developed,martial arts sprang up,and human physical strength was qualitatively increasing compared to before.And the best of them is called “Warriors”. 18 - year - old Luo Feng also dreams of becoming one of them.Right now,he was about to take the college entrance exam and face a choice at a crossroads in his life,but suddenly a monster attack affects the trajectory of his life.",
                    Episodes = 26,
                    CurrentEpisodes = 9,
                    Genres =Genre.Action,
                    ReleaseDate = new DateOnly(2020, 09, 29),
                    PostedOn = DateTime.Now,
                    ImagePath = "/Files/AnimeImages/Test2.jpg"
                });
            #endregion

            #region Add roles
            roleManager.CreateAsync(new ApplicationRole { Name = "User" });
            roleManager.CreateAsync(new ApplicationRole { Name = "Administrator" });
            #endregion

            #region Add users
            var user = new ApplicationUser
            {
                UserName = "Admin",
                Email = "hello.world@mail.ru",
                RegistrationDate = DateTime.Today,
            };

            var result = userManager.CreateAsync(user, "123qwe").GetAwaiter().GetResult();
            if (result.Succeeded)
            {
                  result = userManager.AddToRoleAsync(user, "Administrator").GetAwaiter().GetResult();
            }

            if (!result.Succeeded)
            {
                foreach(var a in result.Errors)
                {
                    Console.WriteLine(a);
                }
                
            }
            #endregion

            context.Comments.Add(new AnimeComment
            {
                AnimeId = 1,
                Content = "Test",
                PostedOn = DateTime.Now,
                User = user

            });

            context.SaveChanges();
        }

    }
}
