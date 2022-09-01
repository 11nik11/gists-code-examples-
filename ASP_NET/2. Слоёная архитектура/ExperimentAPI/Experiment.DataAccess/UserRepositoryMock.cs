using System.Collections.Generic;
using Experiment.DataBase;
using Experiment.Domain.Interfaces.DataAccess;
using Experiment.Domain.Models.DataAccess;

namespace Experiment.DataAccess
{
    public class UserRepositoryMock : IUsersRepository
    {
        private DataBaseMock _db;
        public UserRepositoryMock(DataBaseMock dataBaseMock)
        {
            _db = dataBaseMock;
        }
        public UserDataLayer[] GetAllUsers()
        {
            List<UserDataLayer> result = new List<UserDataLayer>();
            foreach (var user in _db.Users)
            {
                result.Add(new UserDataLayer()
                {
                    Id = user.Id,
                    Name = user.Name,
                    Age = user.Age
                });
            }
            return result.ToArray();
        }

        public UserDataLayer GetUserById(int id)
        {
            return _db.Users.Find(x => x.Id == id);
        }

        public bool CreateNewUser(UserDataLayer user)
        {
            if (user != null)
            {
                _db.AddUser(user);
                return true;
            }
            return false;
        }
    }
}