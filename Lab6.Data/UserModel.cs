using System.Runtime.Serialization;

namespace Lab6.Data
{
    [DataContract]
    public class UserModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Surname { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public UserType Type { get; set; }

        public UserModel() {

        }

        public UserModel(int id, string name, string surname, string email, UserType type)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Email = email;
            Type = type;
        }

        public override string ToString()
        {
            return $"User {Id} - {Name} {Surname} - {Email}";
        }

        [DataContract]
        public enum UserType
        {
            [EnumMember]
            User,
            [EnumMember]
            Manager
        }
    }
}
