using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

using IMI.Turf.DataModels;

namespace IMI.Turf.Repository
{
    public class UserRepository: IUserRepository
    {
        private IMIEntities _entities=null;

        public UserRepository()
        {
            this._entities = new IMIEntities();
        }
        public UserRepository(IMIEntities entities)
        {
            this._entities = entities;
        }
        public UserProfile GetByEmail(string email)
        {
            return _entities.UserProfiles.Where(x => x.UserName == email).FirstOrDefault();
        }
    }
}