using System;
using Example_04.Homework.Models.Interfaces;

namespace Example_04.Homework.Models
{
    public struct DbUserInfoEntity : IDbEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
    }
}
