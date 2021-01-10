using Lab6.Base;
using Lab6.Data;
using Lab6.Data.Repository;
using Lab6.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Lab6.ViewModels
{
    class UsersViewModel: BaseViewModel
    {

        private readonly IUsersRepository _repository = UsersRepository.Instance;

        public UsersViewModel()
        {
            _repository.OnUsersUpdated += HandleUsersUpdated;

            var loadedUsers = _repository.GetUsers();
            _users = new ObservableCollection<UserModel>(loadedUsers);
        }

        private ObservableCollection<UserModel> _users;
        public ObservableCollection<UserModel> Users
        {
            get => _users;
            set
            {
                _users = value;
                OnPropertyChanged("Users");
            }
        }

        public UserModel SelectedUser { get; set; }

        private RelayCommand _onAddClicked;
        public RelayCommand OnAddClicked
        {
            get => _onAddClicked ?? (_onAddClicked = new RelayCommand(
                o => HandleAddClicked(),
                o => true
                ));
        }

        private RelayCommand _onEditClicked;
        public RelayCommand OnEditClicked
        {
            get => _onEditClicked ?? (_onEditClicked = new RelayCommand(
                o => HandleEditClicked(),
                o => SelectedUser != null
                ));
        }

        private RelayCommand _onDeleteClicked;
        public RelayCommand OnDeleteClicked
        {
            get => _onDeleteClicked ?? (_onDeleteClicked = new RelayCommand(
                o => HandleDeleteClicked(),
                o => SelectedUser != null
                ));
        }

        protected override void Release()
        {
            _repository.OnUsersUpdated -= HandleUsersUpdated;
        }

        private void HandleUsersUpdated(List<UserModel> users)
        {
            Users = new ObservableCollection<UserModel>(users);
        }

        private void HandleAddClicked()
        {
            var viewModel = new EditUserViewModel();
            var window = new EditUserWindow { DataContext = viewModel };
            window.Show();
        }

        private void HandleEditClicked()
        {
            var viewModel = new EditUserViewModel(SelectedUser);
            var window = new EditUserWindow { DataContext = viewModel };
            window.Show();
        }

        private void HandleDeleteClicked()
        {
            _repository.DeleteUser(SelectedUser.Id);
        }
    }
}
