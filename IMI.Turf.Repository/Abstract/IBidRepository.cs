using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMI.Turf.DataModels;

namespace IMI.Turf.Repository
{
    public interface IBidRepository
    {
        IEnumerable<Bid> GetBids(int serviceRequestId);
        void Create(Bid request);
    }
}
