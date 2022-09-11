using RugbyUnion1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RugbyUnion1.XUnitTest.MockData
{
    public class PlayerMockData
    {
        public static List<Player> GetAllPlayers()
        {
            return new List<Player>()
            {
                new Player
                {
                    Name = "Name1",
                    BirthDay=new DateTime(2000,01,01),
                    Height_cm=175.2,
                    Weight_kg=67.2,
                    BirthPlace="Place1"
                }
            };
        }
    }
}
