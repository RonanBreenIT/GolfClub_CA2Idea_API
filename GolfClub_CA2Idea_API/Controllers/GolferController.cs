using GolfClub_CA2Idea_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GolfClub_CA2Idea_API.Controllers
{
    [RoutePrefix("api/Golfer")]
    public class GolferController : ApiController
    {
        private static List<Golfer> GolferList = new List<Golfer>
        {
            new Golfer(){GUI = 1111, FirstName = "Ronan", Surname = "Breen", Handicap = 16, ClubID = 1},
            new Golfer(){GUI = 2222, FirstName = "Andrew", Surname = "Breen", Handicap = 60, ClubID = 2 },
            new Golfer(){GUI = 3333, FirstName = "Kevin", Surname = "Hearns", Handicap = 15, ClubID = 1}
        };

        [HttpGet]
        [Route("all")]
        public IEnumerable<Golfer> Get()
        {
            return GolferList;
        }


        [HttpGet]
        [Route("{gui}")]
        public IHttpActionResult Get(int gui)
        {
            var foundGolfer = GolferList.FirstOrDefault(i => i.GUI == gui);
            if (foundGolfer != null)
            {
                return Ok(foundGolfer);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("AddGolfer")]
        public IHttpActionResult AddGolfer(Golfer newGolfer)
        {
            var foundClub = GolferList.FirstOrDefault(i => i.GUI == newGolfer.GUI);
            if (foundClub == null)
            {
                GolferList.Add(newGolfer);
                return Ok();
            }
            else
            {
                return BadRequest("Golfer with that GUI Already exists");
            }
        }

        [HttpPut]
        [Route("UpdateGolfer")]
        public IHttpActionResult UpdateClub(Golfer newGolfer)
        {
            var foundGolfer = GolferList.FirstOrDefault(i => i.GUI == newGolfer.GUI);
            if (foundGolfer == null)
            {
                return BadRequest("Golfer with GUI doens't exist");
            }
            else
            {
                foundGolfer.FirstName = newGolfer.FirstName;
                foundGolfer.Surname = newGolfer.Surname;
                foundGolfer.GUI = newGolfer.GUI;
                foundGolfer.ClubID = newGolfer.ClubID;
                foundGolfer.Handicap = newGolfer.Handicap;
                return Ok();
            }
        }

        [HttpDelete]
        [Route("DeleteGolfer/{gui}")]
        public IHttpActionResult DeleteGolfer(int gui)
        {
            var foundGolfer = GolferList.FirstOrDefault(i => i.GUI == gui);
            if (foundGolfer == null)
            {
                return BadRequest("Golfer with GUI doesn't exist");
            }
            else
            {
                GolferList.Remove(foundGolfer);
                return Ok();
            }
        }
    }
}
