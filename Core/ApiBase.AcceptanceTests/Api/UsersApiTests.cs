﻿using System.Threading.Tasks;
using ApiBase.AcceptanceTests.Brokers;
using ApiBase.AcceptanceTests.Models;
using FluentAssertions;
using Tynamix.ObjectFiller;
using Xunit;

namespace ApiBase.AcceptanceTests.Api
***REMOVED***
    [Collection(nameof(ApiTestCollection))]
    public class UsersApiTests
    ***REMOVED***
        private readonly ApiBaseBroker broker;

        public UsersApiTests(ApiBaseBroker apiBaseBroker)
        ***REMOVED***
            this.broker = apiBaseBroker;
       ***REMOVED***

        private UserDto CreateRandomUser() => new Filler<UserDto>().Create();


        [Fact]
        public async Task ShouldCreateUserAsync()
        ***REMOVED***
            // Arrange
            var testUser = CreateRandomUser();


            // Act
            UserDto actualUser = await this.broker.CreateUserAsync(testUser);

            var users = await this.broker.GetUsers();

            await this.broker.DeleteUserByIdAsync(users[users.Count - 1].Id);


            // Assert
            actualUser.Should().BeEquivalentTo(testUser);
       ***REMOVED***
   ***REMOVED***
***REMOVED***
