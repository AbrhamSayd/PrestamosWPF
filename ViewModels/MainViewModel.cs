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
        private string? _id;
        private string? _firstName;
        private string? _lastName;
        private string? _username;
        private string? _password;
        private string? _carrera;
        private string? _tipoEmpleado;
        private string? _area;
        private string? _idSelector;

        public string? IdSelector
        {
            get => _idSelector;
            set
            {
                _idSelector = value;
                OnPropertyChanged(nameof(IdSelector));

            }
        }

        public string Id
        {
            get => _id;
            set
            {
                
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        public string FirstName
        {
            get => _firstName;
            set
            {
                
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        public string Username
        {
            get => _username;
            set
            {
                if (value == _username) return;
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                if (value == _password) return;
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public string Carrera
        {
            get => _carrera;
            set
            {
                if (value == _carrera) return;
                _carrera = value;
                OnPropertyChanged(nameof(Carrera));
            }
        }

        public string TipoEmpleado
        {
            get => _tipoEmpleado;
            set
            {
                if (value == _tipoEmpleado) return;
                _tipoEmpleado = value;
                OnPropertyChanged(nameof(TipoEmpleado));
            }
        }

        public string Area
        {
            get => _area;
            set
            {
                if (value == _area) return;
                _area = value;
                OnPropertyChanged(nameof(Area));
            }
        }

        public UserAccountModel CurrentUserAccount
        {
            get => _currentAccount;
            set
            {
                _currentAccount = value;
                OnPropertyChanged(nameof(CurrentUserAccount));
            }
        }

       

        public ICommand AddCommand { get; }
        public ICommand updateCommand { get; }
        public ICommand GetUsersByUsernameCommand { get; }

        public MainViewModel()
        {
            userRepository = new UserRepository();
            updateCommand = new ViewModelCommand(ExecuteUpdateCommand);
            AddCommand = new ViewModelCommand(ExecuteAddCommand);
            CurrentUserAccount = new UserAccountModel();
            GetUsersByUsernameCommand = new ViewModelCommand(ExecuteGetUsersByUsername);
            LoadCurrentUserdata();
        }

        private void ExecuteGetUsersByUsername(object obj)
        {
            var user = userRepository.GetByUsername(_idSelector);
            
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Username = user.Username;
            Password = user.Password;
            Carrera = user.Carrera;
            TipoEmpleado = user.TipoEmpleado;
            Area = user.Area;
        }

        private void ExecuteUpdateCommand(object obj)
        {
            var a = new UserModel
            {
                Id = Id,
                FirstName = FirstName,
                LastName = LastName,
                Username = Username,
                Password = Password,
                Carrera = Carrera,
                TipoEmpleado = TipoEmpleado,
                Area = Area
            };
            userRepository.Edit(a);
        }

        

        private void ExecuteAddCommand(object obj)
        {
            
            var a = new UserModel
            {
                FirstName = FirstName,
                LastName = LastName,
                Username = Username,
                Password = Password,
                Carrera = Carrera,
                TipoEmpleado = TipoEmpleado,
                Area = Area
            };
            userRepository.Add(a);
            
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