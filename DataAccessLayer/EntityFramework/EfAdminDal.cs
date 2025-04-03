using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;

namespace DataAccessLayer.EntityFramework
{
    public class EfAdminDal : GenericRepository<Admin>, IAdminDal
    {
        PasswordHasher<Admin> _passwordHasher = new PasswordHasher<Admin>();
        public bool VerifyPassword(string hashedPassword, string enteredPassword)
        {
            var result = _passwordHasher.VerifyHashedPassword(null, hashedPassword, enteredPassword);
            return result == PasswordVerificationResult.Success;
        }

        public void HashExistingPassword()
        {           
            var admins = _object.ToList();
            foreach (var admin in admins)
            {
                admin.AdminPassword = _passwordHasher.HashPassword(admin, admin.AdminPassword);
            }
            context.SaveChanges();
        }

        public string HashNewPassword(string password)
        {
            return _passwordHasher.HashPassword(null, password);
        }

        public Admin GetAdminByUserName(string username)
        {
            var admin = _object.FirstOrDefault(x => x.AdminUserName == username);
            return admin;
        }
    }
}
