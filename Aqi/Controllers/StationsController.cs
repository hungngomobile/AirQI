using Aqi.Dtos;
using AutoMapper;
using System.Collections.Generic;
using Aqi.Models.Data;
using Aqi.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Aqi.Controllers
{
    // api/stations
    [ApiController]
    [Route("[controller]")]
    public class StationsController : ControllerBase
    {
        private readonly IMongoRepo<Station> _repository;
        private readonly IMapper _mapper;
        public StationsController(IMongoRepo<Station> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task CreateStation(StationCreateDto stationCreateDto)
        {
            var stationModel = _mapper.Map<Station>(stationCreateDto);
            await _repository.InsertOneAsync(stationModel);
        }

        [HttpGet]
        public ActionResult <IEnumerable<StationReadDto>> GetAllStations()
        {
            var stationModelItems =  _repository.GetAll();
            
            if(stationModelItems != null){
                return Ok(_mapper.Map<IEnumerable<StationReadDto>>(stationModelItems));
            }

            return NotFound();
        }
    }
}