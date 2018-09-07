﻿using Example_04.Homework.Models.Interfaces;

namespace Example_04.Homework.Models
{
    public struct DbUserEntity : IDbEntity
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public int UserInfoId { get; set; }
    }
}
