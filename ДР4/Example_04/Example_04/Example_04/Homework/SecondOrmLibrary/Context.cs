using Example_04.Homework.Models;
using System.Collections.Generic;

namespace Example_04.Homework.SecondOrmLibrary
{
    public class Context : ISecondOrmContext
    {
        public HashSet<DbUserEntity> Users { get; }
        public HashSet<DbUserInfoEntity> UserInfos { get; }

        public Context()
        {
            Users = new HashSet<DbUserEntity>();
            UserInfos = new HashSet<DbUserInfoEntity>();
        }
    }
}
