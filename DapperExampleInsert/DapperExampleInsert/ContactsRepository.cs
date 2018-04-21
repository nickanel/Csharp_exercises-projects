using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace DapperExampleInsert
{
    class ContactsRepository : IContactsRepository
    {
        //private IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);
        private IDbConnection db = new SqlConnection(cn);
        private const string cn = @"Data Source=KANELLOV-PC\SQLEXPRESS;Initial Catalog=Project_Database;Integrated Security=True;Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //Get Contacts Record By Id
        public Contacts GetById(int id)
        {
            return this.db.Query<Contacts>("Select * From Contacts Where Id=@Id", new { Id = id }).FirstOrDefault();
        }

        //Retreive the data from the table.
        public List<Contacts> GetAll()
        {
            return this.db.Query<Contacts>("Select * From Contacts").ToList();
        }
        //Add Employee Data
        public bool Add(Contacts contacts)
        {
            try
            {
                string sql = "INSERT INTO Contacts(FirstName,LastName,Company,Title) values(@FirstName,@LastName,@Company,@Title); SELECT CAST(SCOPE_IDENTITY() as int)";
                var returnId = this.db.Query<int>(sql, contacts).SingleOrDefault();
                contacts.Id = returnId;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }
            return true;
        }
        //Update The Contacts Record
        public bool Update(Contacts contacts, String ColumnName)
        {
            string query = "update Contacts set " + ColumnName + "=@" + ColumnName + " Where Id=@Id";
            var count = this.db.Execute(query, contacts);
            return count > 0;
        }
        public bool Delete(int id)
        {
            var affectedrows = this.db.Execute("Delete from Contacts where Id=@Id", new { Id = id });
            return affectedrows > 0;
        }
    }
}