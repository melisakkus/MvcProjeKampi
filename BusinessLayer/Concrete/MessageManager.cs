﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public List<Message> GetListInbox()
        {
            return _messageDal.List(x=>x.ReceiverMail=="admin@gmail.com");
        }

        public List<Message> GetListSendbox()
        {
            return _messageDal.List(x => x.SenderMail == "admin@gmail.com");
        }

        public int TReceivedMessageCount()
        {
            return _messageDal.ReceivedMessageCount();
        }

        public int TSendMessageCount()
        {
            return _messageDal.SendMessageCount();
        }

        public void Update(Message message)
        {
            _messageDal.Update(message);    
        }
    }
}
