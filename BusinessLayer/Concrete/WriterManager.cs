using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class WriterManager : IWriterService
    {
        private readonly IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public Writer GetById(int id)
        {
            return _writerDal.Get(x=>x.WriterId==id);
        }

        public List<Writer> GetList()
        {
            return _writerDal.List();
        }

        public Writer GetWriterByMail(string mail)
        {
            return _writerDal.GetWriterByMail(mail);
        }

        public void HashExistingPassword()
        {
            _writerDal.HashExistingPassword();
        }

        public string HashNewPassword(string password)
        {
            return _writerDal.HashNewPassword(password);
        }

        public bool VerifyPassword(string hashedPassword, string enteredPassword)
        {
            return _writerDal.VerifyPassword(hashedPassword, enteredPassword);
        }

        public void WriterAdd(Writer writer)
        {
            _writerDal.Insert(writer);
        }

        public void WriterDelete(Writer writer)
        {
            _writerDal.Delete(writer);
        }

        public void WriterUpdate(Writer writer)
        {
            _writerDal.Update(writer);
        }
    }
}
