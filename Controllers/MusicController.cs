using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MinhaApi.Models;
using MinhaApi.Services;


namespace MinhaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        private readonly MusicService _musicService; 
        // GET api/values

        public MusicController(MusicService musicService)
        {
            this._musicService =  musicService;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Music>> Get()
        {
            return this._musicService.Get();
        }

        // GET api/values/5
        [HttpGet("{id}",Name="GetMusic")]
        public ActionResult<Music> Get(string id)
        {
            return this._musicService.Get(id);
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Music> Post([FromBody] Music music)
        {
            _musicService.Create(music);
            return CreatedAtRoute("GetMusic",new {id = music._id.ToString()},music);

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] Music value)
        {
            var music=  _musicService.Get(id);

            if(music == null){
                return NotFound();
            }

            _musicService.Update(id,value);

            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var music = _musicService.Get(id);

            if(music == null)
            {
                return NotFound();
            }

            _musicService.Remove(id);

            return NoContent();
        }
    }
}
