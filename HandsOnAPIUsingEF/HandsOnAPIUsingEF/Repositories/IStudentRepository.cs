using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HandsOnAPIUsingEF.Entities;

namespace HandsOnAPIUsingEF.Repositories
{
   public interface IStudentRepository
    {
        void AddStudent(StudentMaster student);
        StudentMaster GetStudentById(decimal studentcode);
        List<StudentMaster> GetStudentsByDept(decimal deptcode);
        void DeleteStudent(decimal studentcode);
        void UpdateStudent(StudentMaster student);
    }
}
