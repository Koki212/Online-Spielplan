﻿using Microsoft.AspNetCore.Mvc;
using OnlineSpielplan.Models;
using OnlineSpielplan.Services;


namespace OnlineSpielplan.Controllers
{
    [ApiController]
    [Route("api/competition")]
    public class CompetitionController : ControllerBase
    {
        private readonly CompetitionService _competitionService;

        public CompetitionController(CompetitionService competitionService)
        {
            _competitionService = competitionService;
        }

        // CREATE-COMPETITION
        [HttpPost("CreateCompetition")]
        public async Task<IActionResult> Post(string name)
        {
            var competition = await _competitionService.CreateCompetition(name);
            return Ok(competition);
        }

        // GET-ALL-COMPETITIONS
        [HttpGet("GetAllCompetitions")]
        public async Task<List<Competition>> GetAllCompetitions()
        {
            var competitions = await _competitionService.GetAllCompetitionsAsync();
            return competitions;
        }

        // GET-COMPETITION-BY-NAME
        [HttpGet("GetCompetitionByName")]
        public async Task<IActionResult> GetCompetitionByName(string name)
        {
            var competition = await _competitionService.GetCompetitionByNameAsync(name);

            if (competition == null)
            {
                return NotFound();
            }
            return Ok(competition);
        }

        // GET-COMPETITION-BY-ID
        [HttpGet("GetCompetitionById")]
        public async Task<IActionResult> GetCompetitionById(string id)
        {
            var competition = await _competitionService.GetCompetitionByIdAsync(id);

            if (competition == null)
            {
                return NotFound();
            }
            return Ok(competition);
        }
    }
}
