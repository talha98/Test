using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HandsOnAPIUsingEF.Entities;
using HandsOnAPIUsingEF.Controllers;
using HandsOnAPIUsingEF.Repositories;

namespace HandsOnAPIUsingEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private StudentRepository _repository;
        public StudentController()
        {
            _repository = new StudentRepository();
        }

        [HttpGet]
        [Route("GetStudentByDept/{deptcode}")]
        public  List<StudentMaster> GetStudentsByDept(decimal deptcode)
        {
            return _repository.GetStudentsByDept(deptcode);
        }


        [HttpGet]
        [Route("GetStudentById/{studentcode}")]
        public IActionResult GetStudentById(decimal studentcode)
        {
            StudentMaster student=  _repository.GetStudentById(studentcode);
            if(student != null)
            {
                return Ok(student); //200
            }
            else
            {
                return NotFound("Invalid Student"); //404
            }
        }

        [HttpPost]
        [Route("AddStudent")]
        public IActionResult AddStudent(StudentMaster student)
        {
            try
            {
                _repository.AddStudent(student);
                return Ok("Student Added");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteStudent/{studentcode}")]
        public IActionResult DeleteStudent(decimal studentcode)
        {
            try
            {
                _repository.DeleteStudent(studentcode);
                return Ok("Student Deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateStudent")]
        public IActionResult UpdateStudent(StudentMaster student)
        {
            try
            {
                _repository.UpdateStudent(student);
                return Ok("Student Updated");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
