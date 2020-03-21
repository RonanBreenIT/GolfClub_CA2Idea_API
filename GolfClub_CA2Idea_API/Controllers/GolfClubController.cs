using GolfClub_CA2Idea_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GolfClub_CA2Idea_API.Controllers
{
    [RoutePrefix("api/GolfClub")]
    public class GolfClubController : ApiController
    {
        private static List<GolfClub> ClubList = new List<GolfClub>
        {
            
            new GolfClub(){ID = 1, Name="Stackstown G.C.",},
            new GolfClub(){ID = 2, Name="The Grange G.C." },
            new GolfClub(){ID = 3, Name="Ratfarnham G.C." }
        };


        [HttpGet]
        [Route("all")]
        public IEnumerable<GolfClub> Get()
        {
            return ClubList;
        }


        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var foundClub = ClubList.FirstOrDefault(i => i.ID == id);
            if (foundClub != null)
            {
                return Ok(foundClub);
            }
            else
            {
                return NotFound();
            }
              
        }

        [HttpPost]
        [Route("AddClub")]
        public IHttpActionResult AddClub(GolfClub newClub)
        {
            var foundClub = ClubList.FirstOrDefault(i => i.Name == newClub.Name);
            if (foundClub == null)
            {
                ClubList.Add(newClub);
                return Ok();
            }
            else
            {
                return BadRequest("Club Already exists");
            }
        }

        [HttpPut]
        [Route("UpdateClub")]
        public IHttpActionResult UpdateClub(GolfClub newClub)
        {
            var foundClub = ClubList.FirstOrDefault(i => i.ID == newClub.ID);
            if (foundClub == null)
            {
                return BadRequest("Club Name Doesn't Exist");
                
            }
            else
            {
                foundClub.Name = newClub.Name;
                return Ok();
            }
        }

        [HttpDelete]
        [Route("DeleteClub/{id}")]
        public IHttpActionResult DeleteClub(int id)
        {
            var foundClub = ClubList.FirstOrDefault(i => i.ID == id);
            if (foundClub == null)
            {
                return BadRequest("Club ID Doesn't Exist");
            }
            else
            {
                ClubList.Remove(foundClub);
                return Ok();
            }
        }
    }
}
