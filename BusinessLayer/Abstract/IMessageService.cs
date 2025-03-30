﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> GetListInbox();
        List<Message> GetListSendbox();
        Message GetById(int id);
        void Add(Message message);
        void Delete(Message message);
        void Update(Message message);
        int TSendMessageCount();
        int TReceivedMessageCount();

    }
}
