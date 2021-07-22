using HandsOnAPIUsingEF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HandsOnAPIUsingEF.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private TrainingContext context = null;
        public StudentRepository()
        {
            context = new TrainingContext();
        }
        public void AddStudent(StudentMaster student)
        {
            context.StudentMasters.Add(student);
            context.SaveChanges();
        }

        public void DeleteStudent(decimal studentcode)
        {
            StudentMaster student = context.StudentMasters.SingleOrDefault(s => s.StudCode == studentcode);
            context.StudentMasters.Remove(student);
            context.SaveChanges();
        }

        public StudentMaster GetStudentById(decimal studentcode)
        {
            return context.StudentMasters.SingleOrDefault(s=> s.StudCode == studentcode);
        }

        public List<StudentMaster> GetStudentsByDept(decimal deptcode)
        {
            return context.StudentMasters.Where(s => s.DeptCode == deptcode).ToList();
        }

        public void UpdateStudent(StudentMaster student)
        {
            context.StudentMasters.Update(student);
            context.SaveChanges();
        }
    }
}
