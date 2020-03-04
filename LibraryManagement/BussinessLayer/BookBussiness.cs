using LibraryManagement.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagement.BussinessLayer
{
    public class BookBussiness
    {
        LibraryManagementEntities _db = new LibraryManagementEntities();
        public List<BookTable> GetBooks()//This is courses list method
        {
            try
            {
                List<BookTable> obj_BookTable = null;
                obj_BookTable = (from b in _db.BookTables select b).ToList();
                return obj_BookTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void SaveBooks(BookTable Obj_BookTable_Save)//This is Add method.
        {
            try
            {
                using (LibraryManagementEntities db = new LibraryManagementEntities())
                {
                    db.BookTables.Add(Obj_BookTable_Save);
                    db.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static List<BookTable> GetBookDetails(string selectedValue)
        {
            try
            {
                List<BookTable> Obj_BookTable_Detail = null;
                using (LibraryManagementEntities db = new LibraryManagementEntities())
                {
                    Obj_BookTable_Detail = (from b in db.BookTables where b.ID.ToString() == selectedValue select b).ToList();
                }
                return Obj_BookTable_Detail
;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int UpdateBook(BookTable Obj_BookTable_Update)
        {
            try
            {
                using (LibraryManagementEntities db = new LibraryManagementEntities())
                {
                    //Lambda expression

                    BookTable b = db.BookTables.SingleOrDefault(x => x.ID == Obj_BookTable_Update.ID);
                    b.BookName = Obj_BookTable_Update.BookName;
                    db.SaveChanges();
                    return Obj_BookTable_Update.ID;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void DeleteBook(string Obj_BookTable_Delete)
        {
            try
            {
                using (LibraryManagementEntities db = new LibraryManagementEntities())
                {
                    //Lambda expression
                    BookTable b = db.BookTables.SingleOrDefault(x => x.ID.ToString().Trim() == Obj_BookTable_Delete.Trim());
                    if (b != null)
                    {
                        db.BookTables.Remove(b);
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