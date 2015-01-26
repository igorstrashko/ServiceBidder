using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMI.Turf.DataModels;

namespace IMI.Turf.Repository
{
    public interface IUserRepository
    {
        UserProfile GetByEmail(string email);
    }
}
