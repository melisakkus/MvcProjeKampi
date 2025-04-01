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
        int SendMessageCount();
        int ReceivedMessageCount();
        int DraftsCount();
        int DeletedCount();
        int ReadCount();
        int NotReadCount();
    }
}
