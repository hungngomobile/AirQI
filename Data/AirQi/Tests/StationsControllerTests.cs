using AirQi.Controllers;
using AirQi.Models.Core;
using AirQi.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Qi.Tests
***REMOVED***
    public class StationsControllerTests
    ***REMOVED***
        private readonly Mock<IMongoDataRepository<Station>> _repository;
        private readonly Mock<IMapper> _mapper;

        private readonly StationsController _controller;

        public StationsControllerTests()
        ***REMOVED***
            this._repository = new Mock<IMongoDataRepository<Station>>();
            this._mapper = new Mock<IMapper>();
            this._controller = new StationsController(Repository.Object, Mapper.Object);
       ***REMOVED***

        public Mock<IMongoDataRepository<Station>> Repository => _repository;

        public Mock<IMapper> Mapper => _mapper;

        [Fact]
        public void Test_GetAllStations_OkResult()
        ***REMOVED***
            // Act
            var okResult = _controller.GetAllStations();

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
       ***REMOVED***
   ***REMOVED***
***REMOVED***
