using GolfClub_CA2Idea_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GolfClub_CA2Idea_API.Controllers
{
    [RoutePrefix("api/Course")]
    public class CourseController : ApiController
    {
        private static List<Course> CourseList = new List<Course>
        {
            new Course(){HoleNumber = 1, ClubID = 1, Distance = 360, Index = 5, Par = 4, Name = "White Course", ID = 1, Holes = 18},
            new Course(){HoleNumber = 2, ClubID = 1, Distance = 182, Index = 17, Par = 3, Name = "White Course", ID = 1, Holes = 18},
            new Course(){HoleNumber = 3, ClubID = 1, Distance = 363, Index = 7, Par = 4, Name = "White Course", ID = 1, Holes = 18},
            new Course(){HoleNumber = 4, ClubID = 1, Distance = 334, Index = 15, Par = 4, Name = "White Course", ID = 1, Holes = 18},
            new Course(){HoleNumber = 5, ClubID = 1, Distance = 527, Index = 1, Par = 5, Name = "White Course", ID = 1, Holes = 18},
            new Course(){HoleNumber = 6, ClubID = 1, Distance = 200, Index = 9, Par = 3, Name = "White Course", ID = 1, Holes = 18},
            new Course(){HoleNumber = 7, ClubID = 1, Distance = 497, Index = 11, Par = 5, Name = "White Course", ID = 1, Holes = 18},
            new Course(){HoleNumber = 8, ClubID = 1, Distance = 318, Index = 13, Par = 4, Name = "White Course", ID = 1, Holes = 18},
            new Course(){HoleNumber = 9, ClubID = 1, Distance = 404, Index = 3, Par = 4, Name = "White Course", ID = 1, Holes = 18},
            new Course(){HoleNumber = 10, ClubID = 1, Distance = 174, Index = 8, Par = 3, Name = "White Course", ID = 1, Holes = 18},
            new Course(){HoleNumber = 11, ClubID = 1, Distance = 293, Index = 10, Par = 4, Name = "White Course", ID = 1, Holes = 18},
            new Course(){HoleNumber = 12, ClubID = 1, Distance = 143, Index = 16, Par = 3, Name = "White Course", ID = 1, Holes = 18},
            new Course(){HoleNumber = 13, ClubID = 1, Distance = 398, Index = 4, Par = 4, Name = "White Course", ID = 1, Holes = 18},
            new Course(){HoleNumber = 14, ClubID = 1, Distance = 288, Index = 12, Par = 4, Name = "White Course", ID = 1, Holes = 18},
            new Course(){HoleNumber = 15, ClubID = 1, Distance = 339, Index = 18, Par = 4, Name = "White Course", ID = 1, Holes = 18},
            new Course(){HoleNumber = 16, ClubID = 1, Distance = 520, Index = 2, Par = 5, Name = "White Course", ID = 1, Holes = 18},
            new Course(){HoleNumber = 17, ClubID = 1, Distance = 185, Index = 6, Par = 3, Name = "White Course", ID = 1, Holes = 18},
            new Course(){HoleNumber = 18, ClubID = 1, Distance = 486, Index = 14, Par = 5, Name = "White Course", ID = 1, Holes = 18},
        };


        [HttpGet]
        [Route("all")]
        public IEnumerable<Course> Get()
        {
            var distinctCourse = CourseList.GroupBy(i => i.ID).Select(g => g.First());
            return distinctCourse;
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var foundCourse = CourseList.FirstOrDefault(i => i.ID == id);
            if (foundCourse != null)
            {
                return Ok(foundCourse);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpGet]
        [Route("{id}/{holenumber}")]
        public IHttpActionResult Get(int id, int holenumber)
        {
            var foundCourse = CourseList.FirstOrDefault(i => i.ID == id);
            var foundhole = CourseList.FirstOrDefault(i => i.HoleNumber == holenumber);
            if (foundCourse != null & foundhole != null)
            {
                return Ok(foundhole);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        [Route("AddCourse")]
        public IHttpActionResult AddCourse(Course newCourse)
        {
            var foundCourse = CourseList.FirstOrDefault(i => i.Name == newCourse.Name);
            if (foundCourse == null)
            {
                CourseList.Add(newCourse);
                return Ok();
            }
            else
            {
                return BadRequest("Course Already exists");
            }
        }

        [HttpPut]
        [Route("UpdateCourse")]
        public IHttpActionResult UpdateCourse(Course newCourse)
        {
            var foundCourse = CourseList.FirstOrDefault(i => i.ID == newCourse.ID);
            if (foundCourse == null)
            {
                return BadRequest("Course ID Doesn't Exist");

            }
            else
            {
                foundCourse.Name = newCourse.Name;
                return Ok();
            }
        }

        [HttpDelete]
        [Route("DeleteCourse/{id}")]
        public IHttpActionResult DeleteCourse(int id)
        {
            var foundCourse = CourseList.FirstOrDefault(i => i.ID == id);
            if (foundCourse == null)
            {
                return BadRequest("Course ID Doesn't Exist");
            }
            else
            {
                CourseList.Remove(foundCourse);
                return Ok();
            }
        }
    }
}
