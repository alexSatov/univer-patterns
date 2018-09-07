using System.Linq;
using Example_04.Homework.Models;
using Example_04.Homework.FirstOrmLibrary;

namespace Example_04.Homework.Adapter
{
    public class FirstOrmAdapter : IDatabase
    {
        private readonly FirstOrm users = new FirstOrm();
        private readonly FirstOrm userInfos = new FirstOrm();

        public void AddUser(DbUserEntity user)
        {
            users.Create(user);
            userInfos.Create(new DbUserInfoEntity { Id = user.UserInfoId });
        }

        public void RemoveUser(int userId)
        {
            var userForRemove = (DbUserEntity) users.Read(userId);
            var userInfoForRemove = userInfos.Read(userForRemove.UserInfoId);
            users.Delete(userForRemove);
            userInfos.Delete(userInfoForRemove);
        }

        public void UpdateUser(DbUserEntity user)
        {
            users.Update(user);
        }

        public void UpdateUserInfo(int userId, DbUserInfoEntity userInfo)
        {
            var user = (DbUserEntity) users.Read(userId);
            userInfo.Id = user.UserInfoId;
            userInfos.Update(userInfo);
        }

        public DbUserEntity GetUser(int userId)
        {
            return (DbUserEntity) users.Read(userId);
        }

        public DbUserInfoEntity GetUserInfo(int userId)
        {
            return (DbUserInfoEntity) userInfos.Read(GetUser(userId).UserInfoId);
        }

        public DbUserEntity[] GetAllUsers()
        {
            return users.Entities
                .Select(e => (DbUserEntity) e)
                .ToArray();
        }

        public DbUserInfoEntity[] GetAllUserInfos()
        {
            return userInfos.Entities
                .Select(e => (DbUserInfoEntity)e)
                .ToArray();
        }
    }
}
