using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StreamerAwards.Entities.DTOs;
using StreamerAwards.Entities.Entity_Models;
using StreamerAwards.Logic.Services;

namespace StreamerAwards.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StreamerController : ControllerBase
    {
        private readonly StreamerService _service;

        public StreamerController(StreamerService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAllStreamers()
        {
            var streamers = _service.GetAllStreamers();
            return Ok(streamers);
        }

        [HttpGet("{id}")]
        public IActionResult GetStreamerById(string id)
        {
            var streamer = _service.GetStreamerById(id);
            if (streamer == null)
                return NotFound($"Streamer with ID {id} not found.");

            return Ok(streamer);
        }

        [HttpPost]
        public IActionResult AddStreamer([FromBody] StreamerCreateUpdateDto dto)
        {
            _service.AddStreamer(dto);
            return Ok("Streamer successfully added.");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStreamer(string id, [FromBody] StreamerCreateUpdateDto dto)
        {
            try
            {
                _service.UpdateStreamer(id, dto);
                return Ok("Streamer successfully updated.");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStreamer(string id)
        {
            try
            {
                _service.DeleteStreamer(id);
                return Ok("Streamer successfully deleted.");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
