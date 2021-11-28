using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Assignment1_Server.Models;
using Assignment1_Server.Persistence;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Assignment1_Server.Persistence
{
    public class InMemoryUserService : IUserService
    {
        private readonly FamilyDBContext dbContext;

        public InMemoryUserService()
        {
            dbContext = new FamilyDBContext();
        }

        public async Task<IList<User>> GetUsers()
        {
            return dbContext.Users.ToList();
        }

        public User ValidateUser(string username, string password)
        {
            User first = dbContext.Users.FirstOrDefault(x => x.Username.Equals(username));
            /*if (first == null) throw new Exception("User not found");
            if (!first.Password.Equals(password)) throw new Exception("Invalid password");*/
            if (first != null) throw new Exception("User already exists");
            return first;
        }

        public async Task SaveChanges()
        {
            await dbContext.SaveChangesAsync();
        }

        public async Task<User> Add(User user)
        {
            user.IsRegistered = true;
            EntityEntry<User> added = await dbContext.Users.AddAsync(user);
            await SaveChanges();

            return added.Entity;
        }
    }
}
