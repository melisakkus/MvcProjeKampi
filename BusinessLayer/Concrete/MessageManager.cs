using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        private readonly IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void Add(Message message)
        {
            _messageDal.Insert(message);
        }

        public void Delete(Message message)
        {
            _messageDal.Delete(message);
        }

        public Message GetById(int id)
        {
            return _messageDal.Get(x=>x.MessageId == id);
        }

        public List<Message> GetListDeleteds(string sessionMail)
        {
            return _messageDal.List(x=>(x.SenderMail == sessionMail || x.ReceiverMail==sessionMail) && x.IsDeleted==true);
        }

        public List<Message> GetListDrafts(string sessionMail)
        {
            return _messageDal.List(x => x.IsDraft == true && x.SenderMail == sessionMail);
        }

        public List<Message> GetListInbox(string receiverMail)
        {
            return _messageDal.List(x=>x.ReceiverMail== receiverMail && x.IsDeleted == false && x.IsDraft == false);
        }

        public List<Message> GetListSendbox(string senderMail)
        {
            return _messageDal.List(x => x.SenderMail == senderMail && x.IsDraft == false && x.IsDeleted==false);
        }

        public int TDraftsCount(string sessionMail)
        {
            return _messageDal.DraftsCount( sessionMail);
        }

        public int TReceivedMessageCount(string sessionMail)
        {
            return _messageDal.ReceivedMessageCount(sessionMail);
        }

        public int TSendMessageCount(string sessionMail)
        {
            return _messageDal.SendMessageCount(sessionMail);
        }

        public void Update(Message message)
        {
            _messageDal.Update(message);    
        }

        public int TDeletedCount(string sessionMail)
        {
            return _messageDal.DeletedCount(sessionMail);
        }

        public int TReadCount(string sessionMail)
        {
            return _messageDal.ReadCount(sessionMail);
        }

        public int TNotReadCount(string sessionMail)
        {
            return _messageDal.NotReadCount(sessionMail);
        }
    }
}
