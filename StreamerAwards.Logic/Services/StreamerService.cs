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
    public class StreamerService
    {

        private readonly IRepository<Streamer> _repository;
        private readonly IRepository<Vote> _voteRepository;

        public StreamerService(IRepository<Streamer> repository, IRepository<Vote> voteRepository)
        {
            _repository = repository;
            _voteRepository = voteRepository;
        }

        // Összes streamer lekérdezése
        public IEnumerable<StreamerShortViewDto> GetAllStreamers()
        {
            var streamers = _repository.GetAll();
            return streamers.Select(s => new StreamerShortViewDto
            {
                Id = s.Id,
                Name = s.Name,
                VotesCount = s.VotesCount
            }).ToList();
        }

        // Streamer lekérdezése ID alapján
        public StreamerViewDto? GetStreamerById(string id)
        {
            var streamer = _repository.GetById(id);
            if (streamer == null)
                return null;

            return new StreamerViewDto
            {
                Id = streamer.Id,
                Name = streamer.Name,
                Description = streamer.Description,
                VotesCount = streamer.VotesCount,
                Category = streamer.Category?.Name
            };
        }

        // Új streamer hozzáadása
        public void AddStreamer(StreamerCreateUpdateDto dto)
        {
            var streamer = new Streamer
            {
                Name = dto.Name,
                Description = dto.Description,
                CategoryId = dto.CategoryId
            };

            _repository.Add(streamer);
            _repository.SaveChanges();
        }

        // Streamer frissítése
        public void UpdateStreamer(string id, StreamerCreateUpdateDto dto)
        {
            var existingStreamer = _repository.GetById(id);
            if (existingStreamer == null)
                throw new Exception($"Streamer with ID {id} not found.");

            existingStreamer.Name = dto.Name;
            existingStreamer.Description = dto.Description;
            existingStreamer.CategoryId = dto.CategoryId;

            _repository.Update(existingStreamer);
            _repository.SaveChanges();
        }

        // Streamer törlése
        public void DeleteStreamer(string id)
        {
            var existingStreamer = _repository.GetById(id);
            if (existingStreamer == null)
                throw new Exception($"Streamer with ID {id} not found.");

            // Kapcsolódó szavazatok törlése
            var votes = _voteRepository.GetAll().Where(v => v.StreamerId == id).ToList();
            foreach (var vote in votes)
            {
                _voteRepository.Delete(vote.Id);
            }
            _voteRepository.SaveChanges();

            // Streamer törlése
            _repository.Delete(id);
            _repository.SaveChanges();
        }   
    }
}
