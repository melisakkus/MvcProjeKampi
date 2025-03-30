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
        public int ReceivedMessageCount()
        {
            return _object.Count(x => x.ReceiverMail == "admin@gmail.com");
        }

        public int SendMessageCount()
        {
            return _object.Count(x => x.SenderMail == "admin@gmail.com");
        }
    }
}
