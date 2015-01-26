using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMI.Turf.DataModels;

namespace IMI.Turf.Repository
{
    public interface IServiceRepository
    {
        IEnumerable<ServiceCategory> GetServiceCategories();
        void Create(ServiceRequest request);
        IEnumerable<ServiceRequest> Get();
        ServiceRequest GetById(int id);
        IEnumerable<ServiceRequest> GetRequestsForUser(int userId);
    }
}
