using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.VisualBasic.ApplicationServices;
using PrestamosWPF.Models;
using PrestamosWPF.Repositories;

namespace PrestamosWPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private UserAccountModel _currentAccount;
        private UserModel _userModel;
        private IUserRepository userRepository;
        


        public UserAccountModel CurrentUserAccount
        {
            get => _currentAccount;
            set
            {
                _currentAccount = value;
                OnPropertyChanged(nameof(CurrentUserAccount));
            }
        }

        public UserModel UserModel
        {
            get => _userModel;
            set
            {
                _userModel = value;
                OnPropertyChanged(nameof(UserModel));
            }
        }

        
        


        public ICommand AddCommand { get; }
        public ICommand updateCommand { get; }

        public MainViewModel()
        {
            userRepository = new UserRepository();
            updateCommand = new ViewModelCommand(UpdateCommand);
            AddCommand = new ViewModelCommand(ExecuteAddCommand);
            CurrentUserAccount = new UserAccountModel();
            LoadCurrentUserdata();
        }

        private void UpdateCommand(object obj)
        {
            
        }

        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData;
            if (string.IsNullOrWhiteSpace(_userModel.Username) || _userModel.Username.Length < 3 || _userModel.Password == null || _userModel.Password.Length < 3 || string.IsNullOrWhiteSpace(_userModel.FirstName) || string.IsNullOrWhiteSpace(_userModel.LastName) || string.IsNullOrWhiteSpace(_userModel.Area))
            {
                validData = false;
            }
            else
            {
                validData = true;
            }
            return validData;
        }

        private void ExecuteAddCommand(object obj)
        {
            userRepository.Add(UserModel);
        }

        private void LoadCurrentUserdata()
        {
            var user = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
            if (user != null)
            {
                CurrentUserAccount.Username = user.Username;
                CurrentUserAccount.DisplayName = $"Bienvenido {user.FirstName} {user.LastName} ;)";
                CurrentUserAccount.ProfilePicture = null;
            }
            else
            {
                CurrentUserAccount.DisplayName = "Usuario invalido, not logged";
            }
        }
    }
}