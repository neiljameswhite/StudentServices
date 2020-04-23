using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudentDataAccess;

namespace StudentServices.Controllers
{
    public class StudentsController : ApiController
    {
        public IEnumerable<Student> Get()
        {
            using (StudentDetailsEntities entities = new StudentDetailsEntities())
            {
                return entities.Student.ToList();
                
            }
        }

        public Student Get(int id)
        {
            using(StudentDetailsEntities entities = new StudentDetailsEntities())
            {
                return entities.Student.FirstOrDefault(e => e.ID == id);                
            }
        }

        public IHttpActionResult Post(Student student)
        {
            using(StudentDetailsEntities entities = new StudentDetailsEntities())
            {
                entities.Student.Add(new Student()
                {                   
                    FIRSTNAME = student.FIRSTNAME,
                    LASTNAME = student.LASTNAME,
                    AGE = student.AGE,
                    GENDER = student.GENDER
                });

                entities.SaveChanges();
            }

            return Ok();
        }

        public IHttpActionResult Put(Student student)
        {
            using(StudentDetailsEntities entities = new StudentDetailsEntities())
            {
                var exisingStudent = entities.Student.Where(s => s.ID == student.ID)
                                             .FirstOrDefault();               

                if (exisingStudent != null)
                {                    
                    exisingStudent.FIRSTNAME = student.FIRSTNAME;
                    exisingStudent.LASTNAME = student.LASTNAME;
                    exisingStudent.GENDER = student.GENDER;
                    exisingStudent.AGE = student.AGE;                 

                    entities.SaveChanges();
                }
                else
                {
                    return NotFound();
                }

                return Ok();
            }
        }
    }
}

    
