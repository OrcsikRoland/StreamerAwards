using StreamerAwards.Data.Repositories;
using StreamerAwards.Entities.DTOs;
using StreamerAwards.Entities.Entity_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamerAwards.Logic.Services
{
    public class VoteService
    {
        private readonly IRepository<Vote> _voteRepository;
        private readonly IRepository<Streamer> _streamerRepository;

        public VoteService(IRepository<Vote> voteRepository, IRepository<Streamer> streamerRepository)
        {
            _voteRepository = voteRepository;
            _streamerRepository = streamerRepository;
        }

        public void CastVote(string streamerId, string categoryId)
        {
            try
            {
                var streamer = _streamerRepository.GetById(streamerId);
                if (streamer == null || streamer.CategoryId != categoryId)
                    throw new Exception("Invalid streamer or category.");

                var vote = new Vote
                {
                    StreamerId = streamerId,
                    CategoryId = categoryId
                };

                _voteRepository.Add(vote);
                _voteRepository.SaveChanges();

                streamer.VotesCount++;
                _streamerRepository.Update(streamer);
                _streamerRepository.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in CastVote: {ex.Message}", ex);
            }
        }
        //public void CastVote(string streamerId, string categoryId)
        //{
        //    try
        //    {
        //        var streamer = _streamerRepository.GetById(streamerId);
        //        if (streamer == null || streamer.CategoryId != categoryId)
        //            throw new Exception("Invalid streamer or category.");

        //        // Új szavazat hozzáadása
        //        var vote = new Vote
        //        {
        //            StreamerId = streamerId,
        //            CategoryId = categoryId
        //        };
        //        _voteRepository.Add(vote);
        //        _voteRepository.SaveChanges();

        //        // Szavazatok számának frissítése
        //        streamer.VotesCount++;
        //        _streamerRepository.Update(streamer);
        //        _streamerRepository.SaveChanges();

        //        Console.WriteLine($"VotesCount for streamer {streamer.Name}: {streamer.VotesCount}");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error in CastVote: {ex.Message}");
        //        throw;
        //    }
        //}

            public Streamer? GetCategoryWinner(string categoryId)
        {
            return _streamerRepository
                .Find(s => s.CategoryId == categoryId)
                .OrderByDescending(s => s.VotesCount)
                .FirstOrDefault();
        }
    }
}
