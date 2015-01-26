using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMI.Turf.Repository;
using IMI.Turf.DataModels;

namespace IMI.Turf.Orchestrators
{
    public class ServiceOrchestrator
    {
        ServiceRepository repo = new ServiceRepository();

        public IEnumerable<ServiceCategory> GetServiceCategories()
        {
            return repo.GetServiceCategories();
        }


        //public void CreateService(Service service, ServiceAddress address)
        //{
        //    repo.CreateService(service);
        //}
    }
}
