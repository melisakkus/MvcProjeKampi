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
        public int DraftsCount(string sessionMail)
        {
            return _object.Count(x => x.SenderMail == sessionMail && x.IsDeleted == false && x.IsDraft == true);
        }

        public int DeletedCount(string sessionMail)
        {
            return _object.Count(x =>x.ReceiverMail == sessionMail || x.SenderMail == sessionMail && x.IsDeleted == true && x.IsDraft == false);
        }

        public int ReceivedMessageCount(string sessionMail)
        {
            return _object.Count(x => x.ReceiverMail == sessionMail && x.IsDeleted == false);
        }

        public int SendMessageCount(string sessionMail)
        {
            return _object.Count(x => x.SenderMail == sessionMail && x.IsDeleted == false && x.IsDraft == false);
        }

        public int ReadCount(string sessionMail)
        {
            return _object.Count(x => x.ReceiverMail == sessionMail && x.IsRead == true && x.IsDraft == false && x.IsDeleted == false );
        }

        public int NotReadCount(string sessionMail)
        {
            return _object.Count(x => x.ReceiverMail == sessionMail && x.IsRead == false && x.IsDraft == false && x.IsDeleted == false);
        }
    }
}
