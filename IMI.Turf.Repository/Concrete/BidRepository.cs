using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

using IMI.Turf.DataModels;

namespace IMI.Turf.Repository
{
    public class BidRepository: IBidRepository
    {
        private IMIEntities _entities=null;

        public BidRepository()
        {
            this._entities = new IMIEntities();
        }
        public BidRepository(IMIEntities entities)
        {
            this._entities = entities;
        }

        public IEnumerable<Bid> GetBids(int serviceRequestId)
        {
            return _entities.Bids.Where(b => b.ServiceRequestId == serviceRequestId).ToList();
        }

        public void Create(Bid bid)
        {
            _entities.Bids.Add(bid);
            _entities.SaveChanges();
        }
    }
}