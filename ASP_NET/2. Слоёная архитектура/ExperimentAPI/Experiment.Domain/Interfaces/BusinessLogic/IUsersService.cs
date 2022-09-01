using Experiment.Domain.Models.BusinessLogic;

namespace Experiment.Domain.Interfaces.BisinessLogic
{
    public interface IUsersService
    {
        public UserBusinessLayer[] GetAllUsers();
        public UserBusinessLayer GetUserById(int id);
        public bool CreateNewUser(UserBusinessLayer user);
    }
}