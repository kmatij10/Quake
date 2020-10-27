using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Quake.Core.Repositories.Buildings;
using Quake.Data.Entities;


namespace Quake.Api.Controllers
{
    [Route("api/buildings")]
    public class BuildingController : BaseController
    {
        private readonly IBuildingRepository buildingRepository;
        private readonly IMapper mapper;

        public BuildingController(
            IBuildingRepository buildingRepository,
            IMapper mapper
        )
        {
            this.buildingRepository = buildingRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Building>> GetAll([FromQuery] string search)
        {
            var building = this.buildingRepository.GetAll(search);
            return Ok(building);
        }

        [HttpGet("{id}")]
        public ActionResult<Building> GetOne(long id)
        {
            var entity = this.buildingRepository.GetOne(id);
            var building = this.mapper.Map<Building>(entity);
            return Ok(building);
        }

        [HttpPost]
        public ActionResult<Building> Create(Building c)
        {
            var building = this.mapper.Map<Building>(c);
            building = this.buildingRepository.Create(building);
            return this.mapper.Map<Building>(building);
        }

        [HttpPut("{id}")]
        public ActionResult<Building> Put(long id, Building c)
        {
            var building = this.buildingRepository.Update(id, c);
            return Ok(building);
        }

        [HttpDelete("{id}")]
        public ActionResult<Building> Delete(long id)
        {
            this.buildingRepository.Delete(id);
            return Ok();
        }
    }
}