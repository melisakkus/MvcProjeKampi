using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContactManager : IContactService
    {
        private readonly IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void AddContact(Contact contact)
        {
            _contactDal.Insert(contact);
        }

        public void DeleteContact(Contact contact)
        {
            _contactDal.Delete(contact);
        }

        public Contact GetContactById(int id)
        {
            return _contactDal.Get(x=>x.ContactId == id);
        }

        public List<Contact> GetList()
        {
            return _contactDal.List();
        }

        public int TContactCount()
        {
            return _contactDal.ContactCount();
        }

        public void UpdateContact(Contact contact)
        {
            _contactDal.Update(contact);
        }
    }
}
