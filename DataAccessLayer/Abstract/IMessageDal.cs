using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IMessageDal : IRepository<Message>
    {
        int SendMessageCount(string sessionMail);
        int ReceivedMessageCount(string sessionMail);
        int DraftsCount(string sessionMail);
        int DeletedCount(string sessionMail);
        int ReadCount(string sessionMail);
        int NotReadCount(string sessionMail);
    }
}
