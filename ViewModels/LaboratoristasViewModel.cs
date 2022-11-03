using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using PrestamosWPF.Models;
using PrestamosWPF.Repositories;

namespace PrestamosWPF.ViewModels;

public class LaboratoristasViewModel : ViewModelBase

{
    private ObservableCollection<UserModel> _CollectionUserModel;
    private string? _area;
    private string? _carrera;
    private string? _firstName;
    private string? _id;
    private string? _idSelector;
    private string? _lastName;
    private string? _password;
    private string? _tipoEmpleado; 
    //fields
    private UserModel _userModel;
    private string? _username;
    private readonly IUserRepository userRepository;

    private UserModel _usersModelRow;
    private int _selectIndex;

    //constructor
    public LaboratoristasViewModel()
    {
        userRepository = new UserRepository();
        UpdateCommand = new ViewModelCommand(ExecuteUpdateCommand, CanUpdateCommand);
        AddCommand = new ViewModelCommand(ExecuteAddCommand);
        ExecuteGetAllCommand(null);
    }


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

    public ObservableCollection<UserModel> CollectionUserModel
    {
        get => _CollectionUserModel;
        set
        {
            _CollectionUserModel = value;
            OnPropertyChanged(nameof(CollectionUserModel));
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

    public int SelectIndex
    {
        get => _selectIndex;
        set
        {
            _selectIndex = value;
            OnPropertyChanged(nameof(SelectIndex));
        }
    }
    public UserModel UsersModelRow
    {
        get => _usersModelRow;
        set
        {
            _usersModelRow = value;
            OnPropertyChanged(nameof(_usersModelRow));
        }
    }


    //commands
    public ICommand AddCommand { get; }
    public ICommand UpdateCommand { get; }
    public ICommand GetByAllCommand { get; }
    public ICommand RemoveCommand { get; }


    private void ExecuteGetAllCommand(object obj)
    {
        CollectionUserModel = new ObservableCollection<UserModel>(userRepository.GetByAll());
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
        _userModel = new UserModel
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