using System.Collections.Generic;

namespace Lab6.Data.DB
{
    interface IUserSourceModel
    {

        List<UserDataModel> GetUsers();

        int AddUser(UserDataModel user);

        void DeleteUser(int userId);

        void EditUser(UserDataModel user);

    }
}
