using Lab2.Model;
using Lab2.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Lab2.Controllers
{
    [RoutePrefix("api/students")]
    public class StudentController : ApiController
    {
        StudentRepository studentRepository = new StudentRepository();
        public StudentController() { }
        [HttpGet]
        [Route]
        public HttpResponseMessage GetStudents(string limit = null, string offset = null, string sort = null, string minid = null, string maxid = null, string like = null, string columns = null, string globalike=null)
        {
            try
            {
                string acceptHeader = Request.Headers.Accept.ToString();
                string[] myArray = acceptHeader.Split(';');
                bool okay = myArray[0].Contains("application/json") || myArray[0].Contains("application/xml") || myArray[0].Contains("text/xml") || myArray[0].Contains("text/json");
                if (!(myArray[0].Contains("application/json")|| myArray[0].Contains("application/xml") || myArray[0].Contains("text/xml")|| myArray[0].Contains("text/json")))
                {
                    Error httpError = new Error(5);
                    LinkHelper<Error> errorHelper = new LinkHelper<Error>(httpError);
                    var errorResponse = Request.CreateResponse(HttpStatusCode.BadRequest, errorHelper);
                    return errorResponse;
                }

                if (minid != null)
                {
                    int min_id = Int32.Parse(minid);
                    if (min_id < 0)
                    {
                        throw new ArgumentException();
                    }
                }
                if (maxid != null)
                {
                    int max_id = Int32.Parse(maxid);
                    if (max_id < 0)
                    {
                        throw new ArgumentException();
                    }
                }

                IEnumerable<Student> students = studentRepository.GetAll(limit, offset, sort, minid, maxid, like, globalike);
                List<LinkHelper<Student>> studentsHelper = new List<LinkHelper<Student>>();
                IEnumerable<Student> allStudents = studentRepository.GetAll(null, null, sort,minid, maxid,like,globalike);
                int count = allStudents.Count();
                int viewedCount = students.Count();

                List<Link> paginationLinks = new List<Link>();
                if (count != viewedCount)
                {
                    if (Convert.ToInt32(offset) > 0)
                    {
                        int prevOffset = Math.Max(0, Convert.ToInt32(offset) - Convert.ToInt32(limit));
                        Link prevLink = new Link();
                        prevLink.Rel = "prev";
                        prevLink.Href = $"localhost/api/students?limit={limit}&offset={prevOffset}&sort={sort}&minid={minid}&maxid={maxid}&like={like}&globalike={globalike}";
                        prevLink.Method = "GET";
                        paginationLinks.Add(prevLink);
                    }
                    if (Convert.ToInt32(offset) + Convert.ToInt32(limit) < count)
                    {
                        int nextOffset = Convert.ToInt32(offset) + Convert.ToInt32(limit);
                        Link nextLink = new Link();
                        nextLink.Rel = "next";
                        nextLink.Href = $"localhost/api/students?limit={limit}&offset={nextOffset}&sort={sort}&minid={minid}&maxid={maxid}&like={like}&globalike={globalike}";
                        nextLink.Method = "GET";
                        paginationLinks.Add(nextLink);
                    }
                }
                foreach (var student in students)
                {
                    if (columns != null)
                    {
                        Student studentObj = new Student();
                        string[] words = columns.ToLower().Split(',');
                        if (words.Contains("name"))
                        {
                            studentObj.Name = student.Name;
                        }
                        if (words.Contains("phone"))
                        {
                            studentObj.Phone = student.Phone;
                        }
                        studentObj.Id = student.Id;
                        LinkHelper<Student> studentLinkHelper = new LinkHelper<Student>(studentObj);
                        if (!words.Contains("id"))
                        {
                            studentLinkHelper.Value.Id = null;
                        }
                        studentsHelper.Add(studentLinkHelper);
                    }
                    else
                    {
                        studentsHelper.Add(new LinkHelper<Student>(student));
                    }
                }
                LinkListWrapper studentListWrapper = new LinkListWrapper();
                studentListWrapper.Students = studentsHelper;
                studentListWrapper.PaginationLinks = paginationLinks;
                var response = Request.CreateResponse(HttpStatusCode.OK, studentListWrapper);
                return response;
            }
            catch (ArgumentException e)
            {
                Error httpError = new Error(4);
                LinkHelper<Error> errorHelper = new LinkHelper<Error>(httpError);
                var errorResponse = Request.CreateResponse(HttpStatusCode.BadRequest, errorHelper);
                return errorResponse;
            }
            catch
            {
                Error httpError = new Error(1);
                LinkHelper<Error> errorHelper = new LinkHelper<Error>(httpError);
                var errorResponse = Request.CreateResponse(HttpStatusCode.BadRequest, errorHelper);
                return errorResponse;
            }
        }
        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage GetStudent(int id)
        {
            try
            {
                string acceptHeader = Request.Headers.Accept.ToString();
                string[] myArray = acceptHeader.Split(';');
                if (myArray[0].Contains("application/json") || myArray[0].Contains("application/xml") || myArray[0].Contains("text/xml") || myArray[0].Contains("text/json"))
                {

                }
                Student student = studentRepository.GetStudent(id);
                if (student == null)
                {
                    throw new ObjectNotFoundException();
                }
                LinkHelper<Student> studentHelper = new LinkHelper<Student>(student);
                var studentResponse = Request.CreateResponse(HttpStatusCode.OK, studentHelper);
                return studentResponse;
            }
            catch (ObjectNotFoundException e)
            {
                Error httpError = new Error(2);
                LinkHelper<Error> errorHelper = new LinkHelper<Error>(httpError);
                var errorResponse = Request.CreateResponse(HttpStatusCode.BadRequest, errorHelper);
                return errorResponse;
            }
            catch
            {
                Error httpError = new Error(1);
                LinkHelper<Error> errorHelper = new LinkHelper<Error>(httpError);
                var errorResponse = Request.CreateResponse(HttpStatusCode.BadRequest, errorHelper);
                return errorResponse;
            }
        }
        [HttpPost]
        [Route]
        public HttpResponseMessage CreateStudent([FromBody] Student student)
        {
            try
            {
                string acceptHeader = Request.Headers.Accept.ToString();
                string[] myArray = acceptHeader.Split(';');
                if (myArray[0].Contains("application/json") || myArray[0].Contains("application/xml") || myArray[0].Contains("text/xml") || myArray[0].Contains("text/json"))
                {

                }
                studentRepository.Create(student);
                studentRepository.Save();
                return new HttpResponseMessage(HttpStatusCode.Created);
            }
            catch
            {
                Error httpError = new Error(1);
                LinkHelper<Error> errorHelper = new LinkHelper<Error>(httpError);
                var errorResponse = Request.CreateResponse(HttpStatusCode.BadRequest, errorHelper);
                return errorResponse;
            }
        }

        [HttpPut]
        [Route("{id}")]
        public HttpResponseMessage UpdateStudent(int id,[FromBody] Student student)
        {
            try
            {
                string acceptHeader = Request.Headers.Accept.ToString();
                string[] myArray = acceptHeader.Split(';');
                if (myArray[0].Contains("application/json") || myArray[0].Contains("application/xml") || myArray[0].Contains("text/xml") || myArray[0].Contains("text/json"))
                {

                }
                Student foundStudent = studentRepository.GetStudent(id);
                if(foundStudent == null)
                {
                    throw new ObjectNotFoundException($"Student with id {id} not found");
                
                }
                foundStudent.Phone = student.Phone;
                foundStudent.Name = student.Name;
                studentRepository.Update(foundStudent);
                studentRepository.Save();
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch(ObjectNotFoundException e)
            {
                Error httpError = new Error(2);
                LinkHelper<Error> errorHelper = new LinkHelper<Error>(httpError);
                var errorResponse = Request.CreateResponse(HttpStatusCode.BadRequest, errorHelper);
                return errorResponse;
            }
            catch
            {
                Error httpError = new Error(1);
                LinkHelper<Error> errorHelper = new LinkHelper<Error>(httpError);
                var errorResponse = Request.CreateResponse(HttpStatusCode.BadRequest, errorHelper);
                return errorResponse;
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public HttpResponseMessage DeleteStudent(int id)
        {
            try
            {
                string acceptHeader = Request.Headers.Accept.ToString();
                string[] myArray = acceptHeader.Split(';');
                if (myArray[0].Contains("application/json") || myArray[0].Contains("application/xml") || myArray[0].Contains("text/xml") || myArray[0].Contains("text/json"))
                {

                }
                Student foundStudent = studentRepository.GetStudent(id);
                if (foundStudent == null)
                {
                    throw new ObjectNotFoundException($"Student with id {id} not found");
                }
                studentRepository.Delete(foundStudent);
                studentRepository.Save();
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (ObjectNotFoundException e)
            {
                Error httpError = new Error(2);
                LinkHelper<Error> errorHelper = new LinkHelper<Error>(httpError);
                var errorResponse = Request.CreateResponse(HttpStatusCode.BadRequest, errorHelper);
                return errorResponse;
            }
            catch
            {
                Error httpError = new Error(1);
                LinkHelper<Error> errorHelper = new LinkHelper<Error>(httpError);
                var errorResponse = Request.CreateResponse(HttpStatusCode.BadRequest, errorHelper);
                return errorResponse;
            }
        }
    }
}
