using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

using IMI.Turf.DataModels;

namespace IMI.Turf.Repository
{
    public class ServiceRepository: IServiceRepository
    {
        private IMIEntities _entities=null;

        public ServiceRepository()
        {
            this._entities = new IMIEntities();
        }
        public ServiceRepository(IMIEntities entities)
        {
            this._entities = entities;
        }
        public IEnumerable<ServiceCategory> GetServiceCategories()
        {
            return _entities.ServiceCategories.ToList().Select(c => new ServiceCategory { CategoryName = c.CategoryName, ServiceCategoryId = c.ServiceCategoryId });

        }
        public void Create(ServiceRequest request)
        {
            _entities.ServiceRequests.Add(request);
            _entities.SaveChanges();
        }
        public IEnumerable<ServiceRequest> Get()
        {
            return _entities.ServiceRequests.ToList();
        }
        public ServiceRequest GetById(int id)
        {
            return _entities.ServiceRequests.Where(s => s.ServiceRequestId == id).Single();
        }
        public IEnumerable<ServiceRequest> GetRequestsForUser(int userId)
        {
            return _entities.ServiceRequests.Where(s => s.CreatedBy == userId).ToList().Select(r => new ServiceRequest
            {
                ServiceRequestId = r.ServiceRequestId,
                CreatedBy = r.CreatedBy,
                MaxBudget = r.MaxBudget,
                MinBudget = r.MinBudget,
                RequestName = r.RequestName,
                ServiceDate = r.ServiceDate,
                CreatedDate = r.CreatedDate
            });
        }
    }
}