﻿using AnimeWebSite.Domain.Entities;
using AnimeWebSite.Services.Abstractions;
using AnimeWebSite.Domain.Repositories;
using AnimeWebSite.Identity.Domain.Entities.Users;
using AutoMapper;

namespace AnimeWebSite.Services
{
    public class CommentsService : GenericService<ICommentsRepository, AnimeComment>, ICommentsService
    {
        private readonly ICommentsRepository _repository;
        private readonly IMapper _mapper;

        public CommentsService(ICommentsRepository repository,
                               IMapper mapper) : base(repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> CreateAsync(int animeId, int userId, string comment)
        {
            var animeComment = new AnimeComment
            {
                AnimeId = animeId,
                UserId = userId,
                Content = comment,
                PostedOn = DateTime.Now,
            };

            var result = await _repository.CreateAsync(animeComment);

            if(result is null)
            {
                return false;
            }

            return true;
        }
    }
}
