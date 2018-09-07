using System;
using NUnit.Framework;
using Example_04.Homework.Models;
using Example_04.Homework.Adapter;

namespace Example_04.Homework.Tests
{
    [TestFixture]
    public class AdapterTests
    {
        private static IDatabase fo_Database = PopulateDatabase(new FirstOrmAdapter());
        private static IDatabase so_Database = PopulateDatabase(new SecondOrmAdapter());

        public static IDatabase PopulateDatabase(IDatabase database)
        {
            database.AddUser(new DbUserEntity { Id = 1, Login = "alex123", PasswordHash = "qwer", UserInfoId = 11 });
            database.AddUser(new DbUserEntity { Id = 2, Login = "greg001", PasswordHash = "password", UserInfoId = 12 });
            database.AddUser(new DbUserEntity { Id = 3, Login = "petr1997", PasswordHash = "guess", UserInfoId = 13 });
            database.AddUser(new DbUserEntity { Id = 4, Login = "nick2000", PasswordHash = "mypass", UserInfoId = 14 });

            database.UpdateUserInfo(1, new DbUserInfoEntity { Name = "Алексей", Id = 11, Birthday = new DateTime(1980, 05, 24)});
            database.UpdateUserInfo(2, new DbUserInfoEntity { Name = "Григорий", Id = 12, Birthday = new DateTime(1975, 11, 01) });
            database.UpdateUserInfo(3, new DbUserInfoEntity { Name = "Петр", Id = 13, Birthday = new DateTime(1997, 12, 30) });
            database.UpdateUserInfo(4, new DbUserInfoEntity { Name = "Никита", Id = 14, Birthday = new DateTime(2000, 03, 27) });

            return database;
        }

        public void UpdatingInfo(IDatabase database) // infoId зависит только от infoId у юзера
        {
            database.UpdateUserInfo(1, new DbUserInfoEntity { Name = "Александр", Id = 21, Birthday = new DateTime(1997, 11, 07) });
            var info = database.GetUserInfo(database.GetUser(1).Id);
            Assert.AreEqual(info.Name, "Александр");
            Assert.AreEqual(info.Id, 11);
            Assert.AreEqual(info.Birthday, new DateTime(1997, 11, 07));
        }
        
        public void DeletingUser(IDatabase database)
        {
            database.RemoveUser(1);
            Assert.AreEqual(3, database.GetAllUsers().Length);
            Assert.AreEqual(3, database.GetAllUserInfos().Length);
        }

        [Test]
        public void TestUpdatingInfo_FirstOrm()
        {
            UpdatingInfo(PopulateDatabase(new FirstOrmAdapter()));
        }

        [Test]
        public void TestUpdatingInfo_SecondOrm()
        {
            UpdatingInfo(PopulateDatabase(new SecondOrmAdapter()));
        }

        [Test]
        public void TestDeletingInfo_FirstOrm()
        {
            DeletingUser(PopulateDatabase(new FirstOrmAdapter()));
        }

        [Test]
        public void TestDeletingInfo_SecondOrm()
        {
            DeletingUser(PopulateDatabase(new SecondOrmAdapter()));
        }
    }
}
