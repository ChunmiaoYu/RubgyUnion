using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RugbyUnion1.Controllers;
using RugbyUnion1.Data;
using RugbyUnion1.Models;
using RugbyUnion1.XUnitTest.MockData;
using System.Configuration;
using System.Threading.Tasks;
using Xunit;

namespace RugbyUnion1.XUnitTest
{
    public class TestPlayerController
    {
        [Fact]
        public async Task GetAll_ShouldReturn200Status()
        {
            /// Arrange
            var playerService = new Mock<IPlayerRepository>();

            playerService.Setup(_ => _.FindAll()).Returns(PlayerMockData.GetAllPlayers().FindAll);
            //var config = new MapperConfiguration();
            //IMapper mapper = (new MappingProfile()).CreateMap();  
            //IMapper mapper = Configuration.CreateMapper();
            var sut = new PlayerController(playerService.Object,null,null);
            /// Act
            var result = (OkObjectResult)await sut.GetAll();
            // /// Assert
            result.StatusCode.Should().Be(200);
        }
    }
}