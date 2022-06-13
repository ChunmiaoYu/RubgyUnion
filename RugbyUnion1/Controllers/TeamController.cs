using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RugbyClub1.Models;
using RugbyUnion1.Data;
using RugbyUnion1.DataTransferObjects;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RugbyUnion1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private ITeamRepository _teamRepository;
        private IMapper _mapper;
        private readonly ILogger<TeamController> _logger;
        public TeamController(ITeamRepository teamRepository,IMapper mapper, ILogger<TeamController> logger)
        {//Dependency Injection
            _teamRepository = teamRepository;
            _mapper = mapper;
            _logger = logger;
        }
        // GET: api/<TeamController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("Entering GetAll in TeamController");
            try
            {
                var teams = await _teamRepository.FindAll().ToListAsync();
                return Ok(teams);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAll action: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<TeamController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            _logger.LogInformation("Entering GetById in TeamController");
            try
            {
                var team = await _teamRepository.FindByCondition(x => x.Id.Equals(id)).FirstOrDefaultAsync();
                if (team is null)
                {
                    _logger.LogError($"Team with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                return Ok(team);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetById action: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<TeamController>/Aiden   show team with all players
        [HttpGet("Name/{teamName}")]
        public async Task<IActionResult> ShowTeamWithAllPlayers(string teamName)
        {
            _logger.LogInformation("Entering ShowTeamWithAllPlayers in TeamController");
            try
            {
                var team = await _teamRepository.FindByCondition(x => x.Name.Equals(teamName)).Include(team => team.Players).FirstOrDefaultAsync();
                if (team is null)
                {
                    _logger.LogError($"Team with name: {teamName}, hasn't been found in db.");
                    return NotFound();
                }
                return Ok(team);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside ShowTeamWithAllPlayers action: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<TeamController>
        [HttpPost]
        public IActionResult CreateTeam([FromBody] TeamDto teamDto)
        {
            _logger.LogInformation("Entering CreateTeam in teamController");
            try
            {
                if (teamDto is null)
                {
                   _logger.LogError("team object sent from client is null.");
                    return BadRequest("team object is null");
                }
                if (!ModelState.IsValid)
                {
                   _logger.LogError("Invalid team object sent from client.");
                    return BadRequest("Invalid model object");
                }

                //team map database; dto map user request.
                Team team= _mapper.Map<Team>(teamDto);
                _teamRepository.Create(team);
                _teamRepository.Save();
                //TeamDto createdteamDto = _mapper.Map<TeamDto>(team);
                return CreatedAtRoute( new { id = team.Id }, team);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateTeam action: {ex.Message}");
                return StatusCode(500, ex.Message);
            }

        }

        // PUT api/<TeamController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] string value)
        {
            return NoContent();
        }

        // DELETE api/<TeamController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            return NoContent();
        }
    }
}
