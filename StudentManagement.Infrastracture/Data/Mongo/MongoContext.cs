using StudentManagement.Abstraction.Models;
using StudentManagement.Core.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Infrastruture.Data.Mongo
{
   public class MongoContext
    {
        MongoClient client;
        IMongoDatabase database;
        public MongoContext()
        {
            client = new MongoClient("mongodb://localhost");
            database = client.GetDatabase("StudentPortalDatabase");
        }
        public IMongoCollection<StudentEntity> Studentss => database.GetCollection<StudentEntity>("Students");

     
        public IMongoCollection<DepartmentEntity> Departments => database.GetCollection<DepartmentEntity>("Departments");
        public IMongoCollection<LecturerEntity> Lecturers => database.GetCollection<LecturerEntity>("Lecturers");
        public IMongoCollection<CourseEntity> Courses => database.GetCollection<CourseEntity>("Courses");

        public IMongoCollection<DegreeProgramEntity> DegreePrograms => database.GetCollection<DegreeProgramEntity>("Courses");
    }
}
