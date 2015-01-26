using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMI.Turf.DataModels;

namespace IMI.Turf.Repository
{
    public interface IMessageRepository
    {
        void Create(Message message);
        IEnumerable<Message> GetMessages(int serviceRequestId);
    }
}
