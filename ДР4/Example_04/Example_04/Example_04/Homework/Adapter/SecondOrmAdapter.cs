using System.Linq;
using Example_04.Homework.Models;
using Example_04.Homework.SecondOrmLibrary;

namespace Example_04.Homework.Adapter
{
    public class SecondOrmAdapter : SecondOrm, IDatabase
    {
        public void AddUser(DbUserEntity user)
        {
            Context.Users.Add(user);
            Context.UserInfos.Add(new DbUserInfoEntity {Id = user.UserInfoId});
        }

        public void RemoveUser(int userId)
        {
            var user = GetUser(userId);
            Context.Users.Remove(user);
            Context.UserInfos.RemoveWhere(ui => ui.Id == user.UserInfoId);
        }

        public void UpdateUser(DbUserEntity user)
        {
            Context.Users.RemoveWhere(u => u.Id == user.Id);
            Context.Users.Add(user);
        }

        public void UpdateUserInfo(int userId, DbUserInfoEntity userInfo)
        {
            userInfo.Id = GetUser(userId).UserInfoId;
            Context.UserInfos.RemoveWhere(u => u.Id == userInfo.Id);
            Context.UserInfos.Add(userInfo);
        }

        public DbUserEntity GetUser(int userId)
        {
            return Context.Users.First(u => u.Id == userId);
        }

        public DbUserInfoEntity GetUserInfo(int userId)
        {
            var user = GetUser(userId);
            return Context.UserInfos.First(ui => ui.Id == user.UserInfoId);
        }

        public DbUserEntity[] GetAllUsers()
        {
            return Context.Users.ToArray();
        }

        public DbUserInfoEntity[] GetAllUserInfos()
        {
            return Context.UserInfos.ToArray();
        }
    }
}
