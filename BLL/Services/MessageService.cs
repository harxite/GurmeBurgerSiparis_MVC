using DAL.Repositories.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class MessageService
    {
        
        private readonly IMessageRepository messageRepository;

        public MessageService(IMessageRepository messageRepository)
        {
            
            this.messageRepository = messageRepository;
        }
        public void Save(Message message)
        {
            messageRepository.Add(message);
        }
    }
}
