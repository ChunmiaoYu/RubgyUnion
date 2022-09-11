using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RugbyUnion1.Models;
using RugbyUnion1.Data;
using RugbyUnion1.DataTransferObjects;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RugbyUnion1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        //private ILogger _logger;
        private IPlayerRepository _playerRepository;
        private IMapper? _mapper;
        private readonly ILogger<PlayerController>? _logger;
        public PlayerController(IPlayerRepository playerRepository,IMapper mapper, ILogger<PlayerController> logger)
        {
            _playerRepository = playerRepository;
            _mapper = mapper;
            _logger = logger;
        }

        // GET: api/<PlayerController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("Entering GetAll in PlayerController");
            try
            {
                var players = await _playerRepository.FindAll().ToListAsync();
                return Ok(players);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAll action: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<PlayerController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            _logger.LogInformation("Entering GetById in PlayerController");
            try
            {
                var player = await _playerRepository.FindByCondition(x => x.Id.Equals(id)).Include(player => player.Team).FirstOrDefaultAsync();
                if (player is null)
                {
                    _logger.LogError($"Player with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                return Ok(player);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetById action: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<PlayerController>/Age/11
        [HttpGet("Age/{age}")]
        public async Task<IActionResult> GetByAge(int age)
        {
            _logger.LogInformation("Entering GetByAge in PlayerController");
            try
            {
                var player = await _playerRepository.FindByCondition(x => x.BirthDay.AddYears(age)>DateTime.Now.AddYears(-1) && x.BirthDay.AddYears(age)<DateTime.Now).ToListAsync();
                if (!player.Any())
                {
                    _logger.LogError($"Player with age: {age}, hasn't been found in db.");
                    return NotFound();
                }
                return Ok(player);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetByAge action: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<PlayerController>/Coach/Coach1
        [HttpGet("Coach/{coach}")]
        public async Task<IActionResult> GetByCoach(string coach)
        {
            _logger.LogInformation("Entering GetByCoach in PlayerController");
            try
            {
                var players = await _playerRepository.FindByCondition(x=>x.Team.Coach== coach).ToListAsync();
                if (!players.Any())
                {
                    _logger.LogError($"Players with coach: {coach}, hasn't been found in db.");
                    return NotFound();
                }
                return Ok(players);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetByCoach action: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }


        // POST api/<PlayerController>
        [HttpPost]
        public IActionResult CreatePlayer([FromBody] PlayerDto playerDto)
        {
            _logger.LogInformation("Entering CreatePlayer in PlayerController");
            try
            {
                if (playerDto is null)
                {
                   _logger.LogError("Player object sent from client is null.");
                    return BadRequest("Player object is null");
                }
                if (!ModelState.IsValid)
                {
                   _logger.LogError("Invalid Player object sent from client.");
                    return BadRequest("Invalid model object");
                }
               
                //player map database; dto map user request.
                Player player= _mapper.Map<Player>(playerDto);
                _playerRepository.Create(player);
                _playerRepository.Save();
                //PlayerDto createdPlayerDto = _mapper.Map<PlayerDto>(player);
                return CreatedAtRoute( new { id = player.Id }, player);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreatePlayer action: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<PlayerController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> SignPlayer(Guid id, [FromBody] SignPlayerDto signPlayerDto)
        {
            _logger.LogInformation("Entering SignPlayer in PlayerController");
            try
            {
                var player = await _playerRepository.FindByCondition(x => x.Id.Equals(id)).FirstOrDefaultAsync();
                if (player is null)
                {
                    _logger.LogError($"Player with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                
                player.TeamId = signPlayerDto.TeamId;
                _playerRepository.Update(player);
                _playerRepository.Save();
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside SignPlayer action: {ex.Message}");
                return StatusCode(500, ex.Message);
            }

        }

        // DELETE api/<PlayerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            return NoContent();
        }
    }
}
