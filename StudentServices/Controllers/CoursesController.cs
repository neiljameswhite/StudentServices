using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudentDataAccess;

namespace StudentServices.Controllers
{
    public class CoursesController : ApiController
    {
        public IEnumerable<Course> Get()
        {
            using (StudentDetailsEntities entities = new StudentDetailsEntities())
            {
                return entities.Course.ToList();
                
            }
        }

        public Course Get(int id)
        {
            using (StudentDetailsEntities entities = new StudentDetailsEntities())
            {
                return entities.Course.FirstOrDefault(e => e.COURSEID == id);
            }
        }
    }
}

    
