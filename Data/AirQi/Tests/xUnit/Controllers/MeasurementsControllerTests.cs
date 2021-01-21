using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AirQi.Controllers;
using AirQi.Dtos.Core;
using AirQi.Models.Core;
using AirQi.Profiles;
using AirQi.Repository.Core;
using AirQi.Repository.Test;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Moq;
using Xunit;

namespace Qi.Tests.xUnit.Controllers
***REMOVED***
    public class MeasurementsControllerTests
    ***REMOVED***
        private readonly IMapper _mapper;
        private readonly MockDataRepository _mock;

        public MeasurementsControllerTests()
        ***REMOVED***
            this._mock = new MockDataRepository();

            if (this._mapper == null)
            ***REMOVED***
                var mappingConfig = new MapperConfiguration(mc =>
                ***REMOVED***
                    mc.AddProfile(new StationsProfile());
                    mc.AddProfile(new MeasurementsProfile());
               ***REMOVED***);
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
           ***REMOVED***
       ***REMOVED***

        public IMapper Mapper => _mapper;
        public MockDataRepository Mock => _mock;

        [Fact]
        public void Test_GetAllMeasurements_ReturnsOkResult()
        ***REMOVED***
            // Arrange
            var mockRepo = new Mock<IMongoDataRepository<Station>>();
            var controller = new MeasurementsController(mockRepo.Object, Mapper);
            
            // Act
            var okResult = controller.GetAllMeasurements();

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
            Assert.IsType<List<StationMeasurementReadDto>>((okResult.Result as OkObjectResult).Value); 
       ***REMOVED***

        [Fact]
        public void Test_GetAllMeasurements_ReturnsNotFoundResult()
        ***REMOVED***
            // Arrange
            var mockRepo = new Mock<IMongoDataRepository<Station>>();

            mockRepo.Setup(repo => repo.GetAllAsync())
            .Returns(Task.FromResult((IEnumerable<Station>)default(Station)));

            var controller = new MeasurementsController(mockRepo.Object, Mapper);
            
            // Act
            var notFoundResult = controller.GetAllMeasurements();

            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
       ***REMOVED***

        [Fact]
        public void Test_GetMeasurementByStationId_ReturnsRightItem()
        ***REMOVED***
            // Arrange
            var mockRepo = new Mock<IMongoDataRepository<Station>>();

            double[] position = new double[] ***REMOVED*** 30.2, 50.3***REMOVED***;
            Station station = this.Mock.MockStation(position);
            station.Id = ObjectId.GenerateNewId();
            station.CreatedAt = station.UpdatedAt = DateTime.UtcNow;

            mockRepo.Setup(repo => repo.GetObjectByIdAsync(station.Id.ToString()))
            .Returns(Task.FromResult(station));

            var controller = new MeasurementsController(mockRepo.Object, Mapper);
            
            // Act       
            var okResult = controller.GetMeasurementsByStationId(station.Id.ToString()).Result as OkObjectResult;

            // Assert
            Assert.IsType<StationMeasurementReadDto>(okResult.Value);
            Assert.Equal(station.Id.ToString(), (okResult.Value as StationMeasurementReadDto).Id);           
       ***REMOVED***

        [Fact]
        public void Test_GetMeasurementsByStationId_ReturnsNotFoundResult()
        ***REMOVED***
            // Arrange
            var mockRepo = new Mock<IMongoDataRepository<Station>>();
            var controller = new MeasurementsController(mockRepo.Object, Mapper);
            this.Mock.GenerateMockStations();

            // Act
            var notFoundResult = controller.GetMeasurementsByStationId(ObjectId.GenerateNewId().ToString());
        
            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
       ***REMOVED***

        [Fact]
        public void Test_UpdateMeasurements_ReturnsOkResult()
        ***REMOVED***
            // Arrange
            var mockRepo = new Mock<IMongoDataRepository<Station>>();

            double[] position = new double[] ***REMOVED*** 30.2, 50.3***REMOVED***;
            Station station = this.Mock.MockStation(position);
            station.Id = ObjectId.GenerateNewId();
            station.CreatedAt = station.UpdatedAt = DateTime.UtcNow;

            mockRepo.Setup(repo => repo.GetObjectByIdAsync(station.Id.ToString()))
            .Returns(Task.FromResult(station));

            var controller = new MeasurementsController(mockRepo.Object, Mapper);
            
            // Act       
            var okResult = controller.UpdateMeasurements(station.Id.ToString(), this.Mapper.Map<StationMeasurementCreateDto>(station));

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result); 
            Assert.IsType<StationReadDto>((okResult.Result as OkObjectResult).Value);           
       ***REMOVED***

        [Fact]
        public void Test_UpdateMeasurements_ReturnsNotFoundResult()
        ***REMOVED***
            // Arrange
            var mockRepo = new Mock<IMongoDataRepository<Station>>();
            var controller = new MeasurementsController(mockRepo.Object, Mapper);

            // Act
            var notFoundResult = controller.UpdateMeasurements(ObjectId.GenerateNewId().ToString(), (StationMeasurementCreateDto) null);
        
            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
       ***REMOVED***

        [Fact]
        public void Test_DeleteMeasurement_ReturnsOkResult()
        ***REMOVED***
            // Arrange
            var mockRepo = new Mock<IMongoDataRepository<Station>>();

            double[] position = new double[] ***REMOVED*** 30.2, 50.3***REMOVED***;
            Station station = this.Mock.MockStation(position);
            station.Id = ObjectId.GenerateNewId();
            station.CreatedAt = station.UpdatedAt = DateTime.UtcNow;

            mockRepo.Setup(repo => repo.GetObjectByIdAsync(station.Id.ToString()))
            .Returns(Task.FromResult(station));

            var controller = new MeasurementsController(mockRepo.Object, Mapper);
            
            // Act       
            var okResult = controller.DeleteStation(station.Id.ToString());

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);           
       ***REMOVED***

        [Fact]
        public void Test_DeleteStation_ReturnsNotFoundResult()
        ***REMOVED***
            // Arrange
            var mockRepo = new Mock<IMongoDataRepository<Station>>();
            var controller = new MeasurementsController(mockRepo.Object, Mapper);

            // Act
            var notFoundResult = controller.DeleteStation(ObjectId.GenerateNewId().ToString());
        
            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
       ***REMOVED***
        
   ***REMOVED***
***REMOVED***
