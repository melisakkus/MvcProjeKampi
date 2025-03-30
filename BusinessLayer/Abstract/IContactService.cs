using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContactService
    {
        List<Contact> GetList();
        Contact GetContactById(int id);
        void AddContact(Contact contact);
        void UpdateContact(Contact contact);
        void DeleteContact(Contact contact);
        int TContactCount();

    }
}
