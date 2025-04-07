using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Abstract
{
    public interface IWriterService
    {
        List<Writer> GetList();
        void WriterAdd(Writer writer);
        void WriterDelete(Writer writer);
        void WriterUpdate(Writer writer);
        Writer GetById(int id);

        Writer GetWriterByMail(string mail);
        void HashExistingPassword();
        string HashNewPassword(string password);
        bool VerifyPassword(string hashedPassword, string enteredPassword);
    }
}
