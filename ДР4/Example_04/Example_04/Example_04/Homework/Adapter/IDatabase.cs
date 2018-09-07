using Example_04.Homework.Models;

namespace Example_04.Homework.Adapter
{
    public interface IDatabase
    {
        void AddUser(DbUserEntity user);
        void RemoveUser(int userId);
        void UpdateUser(DbUserEntity user);
        void UpdateUserInfo(int userId, DbUserInfoEntity userInfo);
        DbUserEntity GetUser(int userId);
        DbUserInfoEntity GetUserInfo(int userId);
        DbUserEntity[] GetAllUsers();
        DbUserInfoEntity[] GetAllUserInfos();
    }
}
