using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataAccessLayer.EntityFramework
{
    public class EfMessageDal : GenericRepository<Message>, IMessageDal
    {
        public int DraftsCount()
        {
            return _object.Count(x => x.SenderMail == "admin@gmail.com" && x.IsDeleted == false && x.IsDraft == true);
        }

        public int DeletedCount()
        {
            return _object.Count(x => (x.ReceiverMail == "admin@gmail.com" || x.SenderMail == "admin@gmail.com") && x.IsDeleted == true && x.IsDraft == false);
        }

        public int ReceivedMessageCount()
        {
            return _object.Count(x => x.ReceiverMail == "admin@gmail.com" && x.IsDeleted == false);
        }

        public int SendMessageCount()
        {
            return _object.Count(x => x.SenderMail == "admin@gmail.com" && x.IsDeleted == false && x.IsDraft == false);
        }

        public int ReadCount()
        {
            return _object.Count(x => x.ReceiverMail == "admin@gmail.com" && x.IsRead == true && x.IsDraft == false && x.IsDeleted == false );
        }

        public int NotReadCount()
        {
            return _object.Count(x => x.ReceiverMail == "admin@gmail.com" && x.IsRead == false && x.IsDraft == false && x.IsDeleted == false);
        }
    }
}
