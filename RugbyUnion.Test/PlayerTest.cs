using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;
using System.Net.Http.Json;
using System.Threading.Tasks;
using RugbyUnion1.Models;
using System.Collections.Generic;

namespace RugbyUnion.Test
{
    public class PlayerTest
    {
        [Test]
        public async Task TestGetAllPlayers()
        {
            using var application = new WebApplicationFactory<Program>();
            var client = application.CreateClient();
            var players = await client.GetFromJsonAsync<List<Player>>("api/Player");
            Assert.IsNotNull(players);
        }
        [Test]
        public async Task TestGetAllTeams()
        {
            using var application = new WebApplicationFactory<Program>();
            var client = application.CreateClient();
            var teams = await client.GetFromJsonAsync<List<Team>>("api/Team");
            Assert.IsNotNull(teams);
        }
    }
}
