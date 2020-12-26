using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Camper.Web.CampFinder.Repositories;

namespace Camper.Services.CampFinder.Controllers
{
    [Route("api/camps")]
    [ApiController]
    public class CampSiteController : ControllerBase
    {
        private readonly ICampSiteRepository campSiteRepository;
        private readonly IMapper mapper;
        private readonly ILogger<CampSiteController> logger;

        public CampSiteController(
            ICampSiteRepository campSiteRepository,
            IMapper mapper,
            ILogger<CampSiteController> logger
            )
        {
            this.campSiteRepository = campSiteRepository;
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.CampSiteDto>>> Get([FromQuery] Guid categoryId)
        {
            var result = await campSiteRepository.GetCampSites(categoryId);
            return Ok(mapper.Map<List<Models.CampSiteDto>>(result));
        }

        [HttpGet("{campSiteId}")]
        public async Task<ActionResult<Models.CampSiteDto>> GetById(Guid campSiteId)
        {
            using var scope = logger.BeginScope("Handling request for {CampSiteId}", campSiteId);

            var result = await campSiteRepository.GetCampSiteById(campSiteId);

            if (result is null) return NotFound();

            return Ok(mapper.Map<Models.CampSiteDto>(result));
        }
    }
}