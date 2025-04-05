using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace DataAccessLayer.EntityFramework
{
    public class EfWriterDal : GenericRepository<Writer>, IWriterDal
    {
        PasswordHasher<Writer> _passwordHasher = new PasswordHasher<Writer>();

        public Writer GetWriterByMail(string mail)
        {
            return _object.Where(x => x.WriterMail == mail).FirstOrDefault();
        }

        public void HashExistingPassword()
        {
            var writers = _object.ToList();
            foreach(var writer in writers)
            {
                writer.WriterPassword = _passwordHasher.HashPassword(writer, writer.WriterPassword);
            }
            context.SaveChanges();
        }

        public string HashNewPassword(string password)
        {
            return _passwordHasher.HashPassword(null, password);
        }

        public bool VerifyPassword(string hashedPassword, string enteredPassword)
        {
            var result = _passwordHasher.VerifyHashedPassword(null,hashedPassword,enteredPassword);
            return result == PasswordVerificationResult.Success;
        }
    }
}
