using Experiment.Domain.Models.DataAccess;

namespace Experiment.Domain.Interfaces.DataAccess
{
    public interface IUsersRepository
    {
        public UserDataLayer[] GetAllUsers();
        public UserDataLayer GetUserById(int id);
        public bool CreateNewUser(UserDataLayer user);
    }
}