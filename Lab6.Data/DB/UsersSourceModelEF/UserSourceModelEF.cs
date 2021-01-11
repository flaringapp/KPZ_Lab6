using Lab6.Data.DB.UsersSourceModelEF.DAO;
using System.Collections.Generic;
using System.Linq;

namespace Lab6.Data.DB
{
    class UserSourceModelEF : IUserSourceModel
    {
        private readonly KpzLab6Entities2 dao = new KpzLab6Entities2();

        public List<UserDataModel> GetUsers()
        {
            return dao.Users.ToList().Select(entity=> UserFromEntity(entity)).ToList();
        }

        public int AddUser(UserDataModel user)
        {
            var result = dao.Users.Add(UserToEntity(user));
            dao.SaveChanges();

            return result.id;
        }

        public void DeleteUser(int userId)
        {
            dao.Users.Remove(dao.Users.First(e => e.id == userId));
            dao.SaveChanges();
        }

        public void EditUser(UserDataModel user)
        {
            var entity = dao.Users.SingleOrDefault(e => e.id == user.Id);
            SetEntityFromUser(entity, user);
            dao.SaveChanges();
        }

        private UserDataModel UserFromEntity(User entity)
        {
            return new UserDataModel
            {
                Id = entity.id,
                Name = entity.name,
                Surname = entity.surname,
                Email = entity.email,
                Type = entity.type
            };
        }

        private User UserToEntity(UserDataModel user)
        {
            var entity = new User();
            SetEntityFromUser(entity, user);
            return entity;
        }

        private void SetEntityFromUser(User entity, UserDataModel user)
        {

            entity.id = user.Id;
            entity.name = user.Name;
            entity.surname = user.Surname;
            entity.email = user.Email;
            entity.type = user.Type;
        }
    }
}
