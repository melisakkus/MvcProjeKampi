using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> GetListInbox(string receiverMail);
        List<Message> GetListSendbox(string senderMail);
        List<Message> GetListDrafts(string sessionMail);
        List<Message> GetListDeleteds(string sessionMail);

        Message GetById(int id);
        void Add(Message message);
        void Delete(Message message);
        void Update(Message message);
        int TSendMessageCount(string sessionMail);
        int TReceivedMessageCount(string sessionMail);
        int TDraftsCount(string sessionMail);
        int TDeletedCount(string sessionMail);
        int TReadCount(string sessionMail);
        int TNotReadCount(string sessionMail);

    }
}
