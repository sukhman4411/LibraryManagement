using LibraryManagement.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagement.BussinessLayer
{
    public class StudentBussiness
    {
        LibraryManagementEntities _db = new LibraryManagementEntities();
        public List<StudentTable> GetStudents()//This is Students list method
        {
            try
            {
                List<StudentTable> obj_Student = null;
                obj_Student = (from o in _db.StudentTables select o).ToList();
                return obj_Student;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void SaveStudents(StudentTable Obj_Student_Save)//This is Add method.
        {
            try
            {
                using (LibraryManagementEntities db = new LibraryManagementEntities())
                {
                    db.StudentTables.Add(Obj_Student_Save);
                    db.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static List<StudentTable> GetStudentDetails(string selectedValue)
        {
            try
            {
                List<StudentTable> Obj_Student_Detail = null;
                using (LibraryManagementEntities db = new LibraryManagementEntities())
                {
                    Obj_Student_Detail = (from c in db.StudentTables where c.ID.ToString() == selectedValue select c).ToList();
                }
                return Obj_Student_Detail
;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int UpdateStudent(StudentTable Obj_Student_Update)
        {
            try
            {
                using (LibraryManagementEntities db = new LibraryManagementEntities())
                {
                    //Lambda expression
                    StudentTable s = db.StudentTables.SingleOrDefault(x => x.ID == Obj_Student_Update.ID);
                    s.Name = Obj_Student_Update.Name;
                    s.FatherName = Obj_Student_Update.FatherName;
                    s.Email = Obj_Student_Update.Email;
                    s.Mobile = Obj_Student_Update.Mobile;
                    s.AuthorID = Obj_Student_Update.AuthorID;
                    s.BookID = Obj_Student_Update.BookID;
                    db.SaveChanges();
                    return Obj_Student_Update.ID;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void DeleteStudent(string Obj_Student_Delete)
        {
            try
            {
                using (LibraryManagementEntities db = new LibraryManagementEntities())
                {
                    //Lambda expression
                    StudentTable s = db.StudentTables.SingleOrDefault(x => x.ID.ToString().Trim() == Obj_Student_Delete.Trim());
                    if (s != null)
                    {
                        db.StudentTables.Remove(s);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}