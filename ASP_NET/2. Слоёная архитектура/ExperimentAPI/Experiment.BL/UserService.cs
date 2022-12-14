using System;
using System.Collections.Generic;
using Experiment.Domain.Interfaces.BisinessLogic;
using Experiment.Domain.Interfaces.DataAccess;
using Experiment.Domain.Models.BusinessLogic;
using Experiment.Domain.Models.DataAccess;

namespace Experiment.BL
{
    public class UserService : IUsersService
    {
        private IUsersRepository _repository;
        public UserService(IUsersRepository repository)
        {
            _repository = repository;
        }
        
        public UserBusinessLayer[] GetAllUsers()
        {
            List<UserBusinessLayer> result = new List<UserBusinessLayer>();
            foreach (var user in _repository.GetAllUsers())
            {
                result.Add(new UserBusinessLayer()
                {
                    Id = user.Id,
                    Age = user.Age,
                    Name = user.Name
                });
            }
            return result.ToArray();
        }

        public UserBusinessLayer GetUserById(int id)
        {
            var userRepository = _repository.GetUserById(id);
            return new UserBusinessLayer()
            {
                Id = userRepository.Id,
                Age = userRepository.Age,
                Name = userRepository.Name
            };
        }

        public bool CreateNewUser(UserBusinessLayer user)
        {
            try
            {
                _repository.CreateNewUser(new UserDataLayer()
                {
                    Id = new Random().Next(99999999,999999999),
                    Age = user.Age,
                    Name = user.Name
                });
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}