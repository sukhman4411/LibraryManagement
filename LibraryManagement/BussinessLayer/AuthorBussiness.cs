using LibraryManagement.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagement.BussinessLayer
{
    public class AuthorBussiness
    {
        LibraryManagementEntities db = new LibraryManagementEntities();
        public List<AuthorTable> GetAuthorData()
        {
            try
            {
                List<AuthorTable> obj_Author = null;
                obj_Author = (from u in db.AuthorTables select u).ToList();
                return obj_Author;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void InsertAuthor(AuthorTable Obj_Author_Insert)
        {
            try
            {
                using (LibraryManagementEntities db = new LibraryManagementEntities())
                {
                    db.AuthorTables.Add(Obj_Author_Insert);
                    db.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static List<AuthorTable> GetAuthorDetails(string selectedValue)
        {
            try
            {
                List<AuthorTable> Obj_Author_Detail = null;
                using (LibraryManagementEntities db = new LibraryManagementEntities())
                {
                    Obj_Author_Detail = (from u in db.AuthorTables where u.ID.ToString() == selectedValue select u).ToList();
                }
                return Obj_Author_Detail;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int UpdateAuthor(AuthorTable Obj_Author_Update)
        {
            try
            {
                using (LibraryManagementEntities db = new LibraryManagementEntities())
                {
                    //Lembda expression

                    AuthorTable c = db.AuthorTables.SingleOrDefault(x => x.ID == Obj_Author_Update.ID);
                    c.AuthorName = Obj_Author_Update.AuthorName;
                    db.SaveChanges();
                    return Obj_Author_Update.ID;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void DeleteAuthor(string Obj_Author_Delete)
        {
            try
            {
                using(LibraryManagementEntities db = new LibraryManagementEntities())
                {
                    //Lembda expression
                    AuthorTable c = db.AuthorTables.SingleOrDefault(x => x.ID.ToString().Trim() == Obj_Author_Delete.Trim());
                    if (c != null)
                    {
                        db.AuthorTables.Remove(c);
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