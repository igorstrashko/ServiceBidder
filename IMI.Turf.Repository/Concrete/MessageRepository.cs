using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

using IMI.Turf.DataModels;

namespace IMI.Turf.Repository
{
    public class MessageRepository: IMessageRepository
    {
        private IMIEntities _entities=null;

        public MessageRepository()
        {
            this._entities = new IMIEntities();
        }
        public MessageRepository(IMIEntities entities)
        {
            this._entities = entities;
        }
        public IEnumerable<Message> GetMessages(int serviceRequestId)
        {
            return _entities.Messages.Where(r=>r.ServiceRequestId == serviceRequestId).ToList();
        }
        public void Create(Message message)
        {
            _entities.Messages.Add(message);
            _entities.SaveChanges();
        }
    }
}