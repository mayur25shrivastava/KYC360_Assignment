using System;
using System.Collections.Generic;
using System.Linq;
using KYC360API.Models;

namespace KYC360API.Services
{
    public class MockDatabaseService
    {
        private List<Entity> _entities;

        public MockDatabaseService()
        {
            // Initialize mock data
            _entities = new List<Entity>
            {
                new Entity
                {
                    Id = "1",
                    Names = new List<Name> { new Name { FirstName = "John", Surname = "Doe" } },
                    Addresses = new List<Address> { new Address { AddressLine = "123 Main St", City = "City", Country = "Country" } },
                    Dates = new List<Date> { new Date { DateType = "Birth", DateValue = new DateTime(1980, 1, 1) } },
                    Gender = "Male",
                    Deceased = false
                },
                new Entity
                {
                    Id = "2",
                    Names = new List<Name> { new Name { FirstName = "Jane", Surname = "Smith" } },
                    Addresses = new List<Address> { new Address { AddressLine = "456 Elm St", City = "City", Country = "Country" } },
                    Dates = new List<Date> { new Date { DateType = "Birth", DateValue = new DateTime(1990, 5, 5) } },
                    Gender = "Female",
                    Deceased = true
                }
            };
        }

        public List<Entity> GetEntities()
        {
            return _entities;
        }

        public Entity GetEntityById(string id)
        {
            return _entities.FirstOrDefault(e => e.Id == id);
        }

        public void AddEntity(Entity entity)
        {
            entity.Id = Guid.NewGuid().ToString(); // Generate unique ID
            _entities.Add(entity);
        }

        public void UpdateEntity(Entity entity)
        {
            var existingEntity = _entities.FirstOrDefault(e => e.Id == entity.Id);
            if (existingEntity != null)
            {
                // Update entity properties
                existingEntity.Names = entity.Names;
                existingEntity.Addresses = entity.Addresses;
                existingEntity.Dates = entity.Dates;
                existingEntity.Gender = entity.Gender;
                existingEntity.Deceased = entity.Deceased;
            }
        }

        public void DeleteEntity(string id)
        {
            var entityToRemove = _entities.FirstOrDefault(e => e.Id == id);
            if (entityToRemove != null)
            {
                _entities.Remove(entityToRemove);
            }
        }

        public bool EntityExists(string id)
        {
            return _entities.Any(e => e.Id == id);
        }
    }
}
