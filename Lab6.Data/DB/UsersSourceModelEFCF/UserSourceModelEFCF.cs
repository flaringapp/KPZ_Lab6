using Lab6.Data.DB.UsersSourceModelEFCF.DAO;
using System.Collections.Generic;
using System.Linq;

namespace Lab6.Data.DB
{
    class UserSourceModelEFCF : IUserSourceModel
    {

        private readonly UsersCFDAO dao;

        public UserSourceModelEFCF(UsersCFDAO dao)
        {
            this.dao = dao;
        }

        public List<UserDataModel> GetUsers()
        {
            return dao.Users.ToList().Select(entity=> UserFromEntity(entity)).ToList();
        }

        public int AddUser(UserDataModel user)
        {
            var result = dao.Users.Add(UserToEntity(user));
            dao.SaveChanges();

            return result.Id;
        }

        public void DeleteUser(int userId)
        {
            dao.Users.Remove(dao.Users.First(e => e.Id == userId));
            dao.SaveChanges();
        }

        public void EditUser(UserDataModel user)
        {
            var entity = dao.Users.SingleOrDefault(e => e.Id == user.Id);
            SetEntityFromUser(entity, user);
            dao.SaveChanges();
        }

        private UserDataModel UserFromEntity(User entity)
        {
            return new UserDataModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Surname = entity.Surname,
                Email = entity.Email,
                Type = entity.Type
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

            entity.Id = user.Id;
            entity.Name = user.Name;
            entity.Surname = user.Surname;
            entity.Email = user.Email;
            entity.ype = user.Type;
        }
    }
}
