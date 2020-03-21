using GolfClub_CA2Idea_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GolfClub_CA2Idea_API.Controllers
{
    [RoutePrefix("api/Comp")]
    public class CompetitionController : ApiController
    {
        private static List<Competition> CompList = new List<Competition>
        {
            new Competition(){ID = 1, Name="Marty Reilly", Club = new GolfClub(){ ID = 1}, Date = new DateTime(2020, 01,01), Type = CompType.Stableford /*GUI = new Golfer(){GUI = 1111}*/ },
            new Competition(){ID = 2, Name="William Smith", Club = new GolfClub(){ ID = 1}, Date = new DateTime(2020, 02,01), Type = CompType.Stableford },
            new Competition(){ID = 3, Name="March Medal", Club = new GolfClub(){ ID = 1}, Date = new DateTime(2020, 03,01), Type = CompType.Strokeplay }
        };

        [HttpGet]
        [Route("all")]
        public IEnumerable<Competition> Get()
        {
            return CompList;
        }


        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var foundcomp = CompList.FirstOrDefault(i => i.ID == id);
            if (foundcomp != null)
            {
                return Ok(foundcomp);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        [Route("AddComp")]
        public IHttpActionResult AddClub(Competition newComp)
        {
            var foundClub = CompList.FirstOrDefault(i => i.Name == newComp.Name);
            if (foundClub == null)
            {
                CompList.Add(newComp);
                return Ok();
            }
            else
            {
                return BadRequest("Comp Already exists");
            }
        }

        [HttpPut]
        [Route("UpdateComp")]
        public IHttpActionResult UpdateComp(Competition newComp)
        {
            var foundComp = CompList.FirstOrDefault(i => i.ID == newComp.ID);
            if (foundComp == null)
            {
                return BadRequest("Comp Name Doesn't Exist");

            }
            else
            {
                foundComp.Name = newComp.Name;
                return Ok();
            }
        }

        [HttpDelete]
        [Route("DeleteComp/{id}")]
        public IHttpActionResult DeleteComp(int id)
        {
            var foundComp = CompList.FirstOrDefault(i => i.ID == id);
            if (foundComp == null)
            {
                return BadRequest("Comp ID Doesn't Exist");
            }
            else
            {
                CompList.Remove(foundComp);
                return Ok();
            }
        }
    }
}