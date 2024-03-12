using System;
using System.Collections.Generic;

namespace KYC360API.Models
{
    public interface IEntity
    {
        public List<Address>? Addresses { get; set; }
        public List<Date> Dates { get; set; }
        public bool Deceased { get; set; }
        public string? Gender { get; set; }
        public string Id { get; set; }
        public List<Name> Names { get; set; }
    }

    public class Entity : IEntity
    {
        public List<Address>? Addresses { get; set; }
        public List<Date> Dates { get; set; } = new List<Date>(); // Initialize Dates list
        public bool Deceased { get; set; }
        public string? Gender { get; set; }
        public string Id { get; set; } = string.Empty; // Initialize Id
        public List<Name> Names { get; set; } = new List<Name>(); // Initialize Names list
    }
}
