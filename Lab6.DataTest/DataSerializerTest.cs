using Lab6.Data;
using Lab6.Data.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Lab6.DataTest
{
    [TestClass]
    public class DataSerializerTest
    {
        private readonly string dir = AppDomain.CurrentDomain.BaseDirectory;
        private string FilePath => dir + "/test.txt";

        [TestMethod]
        public void TestSerialize()
        {
            var model = new DataModel
            {
                Users = new List<UserModel>
            {
                new UserModel(1, "Name1", "Surname1", "email1@gmail.com", UserModel.UserType.User),
                new UserModel(2, "Name2", "Surname2", "email2@gmail.com", UserModel.UserType.Manager)
            }
            };
            DataSerializer.Serialize(FilePath, model);
        }

        [TestMethod]
        public void TestDeserialize()
        {
            DataSerializer.Deserialize(FilePath);
        }
    }
}
