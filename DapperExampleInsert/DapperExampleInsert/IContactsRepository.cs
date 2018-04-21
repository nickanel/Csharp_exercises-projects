using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DapperExampleInsert
{
    interface IContactsRepository
    {
        List<Contacts> GetAll();
        bool Add(Contacts contacts);
        Contacts GetById(int id);
        bool Update(Contacts contacts, String ColumnWidth);
        bool Delete(int id);
    }
}