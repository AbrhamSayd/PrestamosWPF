using PrestamosWPF.Models;
using PrestamosWPF.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PrestamosWPF.ViewModels
{
    public class LaboratoristasViewModel : ViewModelBase

    { //fields
        private UserModel _userModel;
        private IUserRepository userRepository;
        private DataTable _dtUsers;
        private string? _id;
        private string? _firstName;
        private string? _lastName;
        private string? _username;
        private string? _password;
        private string? _carrera;
        private string? _tipoEmpleado;
        private string? _area;
        private string? _idSelector;


        //props
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



        public UserModel User
        {
            get => _userModel;
            set
            {
                _userModel = value;
                OnPropertyChanged(nameof(User));
            }
        }

        public DataTable dtUsers
        {
            get => _dtUsers;

            set
            {
                _dtUsers = value;
                OnPropertyChanged(nameof(dtUsers));
            }
        }

        //commands
        public ICommand AddCommand { get; }
        public ICommand updateCommand { get; }
        public ICommand GetUsersByUsernameCommand { get; }
        public ICommand GetUsersCommand { get; }

        //constructor
        public LaboratoristasViewModel()
        {
            userRepository = new UserRepository();
            updateCommand = new ViewModelCommand(ExecuteUpdateCommand, CanUpdateCommand);
            AddCommand = new ViewModelCommand(ExecuteAddCommand);
            GetUsersByUsernameCommand = new ViewModelCommand(ExecuteGetUsersByUsername);
            GetUsersCommand = new ViewModelCommand(ExecuteGetUsersCommand);
        }

        private void ExecuteGetUsersCommand(object obj)
        {
            _dtUsers = userRepository.GetByAllDataTable();
        }

        private void ExecuteGetUsersByUsername(object obj)
        {

            User = userRepository.GetByUsername(_idSelector);

            Id = User.Id;
            FirstName = User.FirstName;
            LastName = User.LastName;
            Username = User.Username;
            Password = User.Password;
            Carrera = User.Carrera;
            TipoEmpleado = User.TipoEmpleado;
            Area = User.Area;
        }

        private void ExecuteUpdateCommand(object obj)
        {
            _userModel = new UserModel()
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
            userRepository.Edit(_userModel);
        }

        private bool CanUpdateCommand(object obj)
        {
            throw new NotImplementedException();
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
    }
}
