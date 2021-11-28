using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment1_Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Assignment1_Server.Persistence
{
    public class AdultData : IAdultData
    {

        private readonly FamilyDBContext dbContext;

        public AdultData()
        {
            dbContext = new FamilyDBContext();
        }

        public async Task<Adult> Add(Adult adult)
        {
            EntityEntry<Adult> added = await dbContext.Adults.AddAsync(adult);
            await dbContext.SaveChangesAsync();
            return added.Entity;
        }

        public async Task<IList<Adult>> GetAdults()
        {
            return await dbContext.Adults.Include(a => a.JobTitle).ToListAsync();
        }

        public async Task RemoveAdult(Adult adult)
        {
            Adult adultToRemove = await dbContext.Adults.Include(a => a.JobTitle).FirstAsync(a => a.Id.Equals(adult.Id));
            if (adultToRemove != null)
            {
                dbContext.Adults.Remove(adultToRemove);
            }
            if (adultToRemove.JobTitle != null)
            {
                Job jobToRemove = await dbContext.Jobs.FirstAsync(j => j.JobId == adultToRemove.JobTitle.JobId);
                if (jobToRemove != null)
                {
                    dbContext.Jobs.Remove(jobToRemove);
                }
            }

            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateAdult(Adult adult)
        {
            Adult toUpdate = await dbContext.Adults.Include(a => a.JobTitle).FirstAsync(a => a.Id == adult.Id);
            if (toUpdate.JobTitle != null)
            {
                Job jobToUpdate = await dbContext.Jobs.FirstAsync(j => j.JobId == toUpdate.JobTitle.JobId);
                jobToUpdate.JobTitle = toUpdate.JobTitle.JobTitle;
                jobToUpdate.Salary = toUpdate.JobTitle.Salary;
                dbContext.Update(jobToUpdate);
            }
            toUpdate.FirstName = adult.FirstName;
            toUpdate.LastName = adult.LastName;
            toUpdate.HairColor = adult.HairColor;
            toUpdate.EyeColor = adult.EyeColor;
            toUpdate.Age = adult.Age;
            toUpdate.Height = adult.Height;
            toUpdate.Weight = adult.Weight;
            toUpdate.Sex = adult.Sex;
            toUpdate.JobTitle = adult.JobTitle;
            dbContext.Update(toUpdate);
            await dbContext.SaveChangesAsync();
        }

        public Adult Get(int id)
        {
            return dbContext.Adults.Include(a => a.JobTitle).FirstOrDefault(a => a.Id == id);
        }
    }
}
