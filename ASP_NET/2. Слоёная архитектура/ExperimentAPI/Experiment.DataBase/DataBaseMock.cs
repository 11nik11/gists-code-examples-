using System;
using System.Collections.Generic;
using Experiment.Domain.Models.DataAccess;

namespace Experiment.DataBase
{
    public class DataBaseMock
    {
        public List<UserDataLayer> Users { get; }
        public DataBaseMock()
        {
            Users = new List<UserDataLayer>();
            for (int i = 0; i < 10; i++)
            {
                var rand = new Random();
                Users.Add(new UserDataLayer()
                {
                    Id = i,
                    Age = rand.Next(1,100),
                    Name = "username_" + rand.Next(100,999).ToString()
                });
            }
        }

        public void AddUser(UserDataLayer user)
        {
            Users.Add(user);
        }
    }
}