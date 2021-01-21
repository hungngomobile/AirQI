using AutoMapper;
using AirQi.Dtos.Core;
using AirQi.Models.Core;

namespace AirQi.Profiles
***REMOVED***
    public class MeasurementsProfile : Profile
    ***REMOVED***
        public MeasurementsProfile()
        ***REMOVED***
            CreateMap<Station, MeasurementStationReadDto>();
            CreateMap<MeasurementStationReadDto, StationReadDto>().ForMember(dest => dest.Measurements, opt => opt.MapFrom(src => src));

            CreateMap<Measurement, MeasurementStationReadDto>();
            // https://stackoverflow.com/questions/10660623/automapper-map-from-source-nested-collection-to-another-collection

            CreateMap<Station, StationMeasurementReadDto>();
            CreateMap<StationMeasurementReadDto, StationReadDto>().ForMember(dest => dest.Measurements, opt => opt.MapFrom(src => src));

            CreateMap<Measurement, MeasurementReadDto>();

            CreateMap<StationMeasurementCreateDto, Station>();
            CreateMap<Station, StationMeasurementCreateDto>();
       ***REMOVED***
   ***REMOVED***
***REMOVED***