using Lab6.Base;
using Lab6.Data;
using Lab6.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using static Lab6.Data.UserModel;

namespace Lab6.ViewModels
{
    class EditUserViewModel : BaseViewModel
    {

        public EditUserViewModel(UserModel user)
        {
            _isEdit = true;
            _id = user.Id;
            NameModel.Input = user.Name;
            SurnameModel.Input = user.Surname;
            EmailModel.Input = user.Email;
            Type = user.Type;
        }

        public EditUserViewModel()
        {
            _isEdit = false;
            _id = -1;
        }

        private readonly IUsersRepository _repository = UsersRepository.Instance;

        private readonly bool _isEdit;

        private readonly int _id;

        private readonly InputViewModel _nameModel = new InputViewModel();
        public InputViewModel NameModel { get => _nameModel; }

        private readonly InputViewModel _surnameModel = new InputViewModel();
        public InputViewModel SurnameModel { get => _surnameModel; }

        private readonly InputViewModel _emailModel = new InputViewModel();
        public InputViewModel EmailModel { get => _emailModel; }

        private UserType? _type = null;
        public UserType? Type
        {
            get => _type;
            set
            {
                _type = value;
                OnPropertyChanged("Type");
            }
        }

        public IEnumerable<UserType> UserTypeValues
        {
            get
            {
                return Enum.GetValues(typeof(UserType))
                    .Cast<UserType>();
            }
        }

        public string Title
        {
            get
            {
                if (_isEdit) return "Edit user";
                else return "Add new user";
            }
        }

        public string SubmitButton
        {
            get
            {
                if (_isEdit) return "Save";
                else return "Submit";
            }
        }

        private RelayCommand _onSaveClicked;
        public RelayCommand OnSaveClicked
        {
            get => _onSaveClicked ?? (_onSaveClicked = new RelayCommand(
                o =>
                {
                    HandleSaveClicked();
                    CloseWindow(o);
                },
                o => IsAllDataFilled()
                ));
        }

        private bool IsAllDataFilled()
        {
            return NameModel.Input.Length > 0 &&
                SurnameModel.Input.Length > 0 &&
                EmailModel.Input.Length > 0 &&
                Type != null;
        }

        private void HandleSaveClicked()
        {
            var user = CreateUser();
            if (_isEdit) UpdateUser(user);
            else AddUser(user);
        }

        private void AddUser(UserModel user)
        {
            _repository.AddUser(user);
        }

        private void UpdateUser(UserModel user)
        {
            _repository.UpdateUser(user);
        }

        private UserModel CreateUser()
        {
            return new UserModel(_id, NameModel.Input, SurnameModel.Input, EmailModel.Input, Type.Value);
        }
    }
}
