using System.Threading;
using System.Windows.Input;
using PrestamosWPF.Models;
using PrestamosWPF.Repositories;
using PrestamosWPF.ViewModels.Fields;

namespace PrestamosWPF.ViewModels;

public class MainViewModel : ViewModelBase
{
    private UserAccountModel _currentAccountView;
    private ViewModelBase _currentChidlView;
    private UserModel _userModel;
    private readonly IUserRepository userRepository;


    public MainViewModel()
    {
        userRepository = new UserRepository();
        CurrentUserAccountView = new UserAccountModel();


        //Command for childrends
        ShowFieldsCommand = new ViewModelCommand(ExecuteShowFieldsCommand);
        ShowPrestamosCommand = new ViewModelCommand(ExecuteShowPrestamosCommand);
        ShowHerramientasCommand = new ViewModelCommand(ExecuteShowHerramientasCommand);
        ShowLaboratoriosCommand = new ViewModelCommand(ExecuteShowLaboratoriosCommand);
        ShowLaboratoristasCommand = new ViewModelCommand(ExecuteShowLaboratistasCommand);
        

        LoadCurrentUserdata();
    }


    public UserAccountModel CurrentUserAccountView
    {
        get => _currentAccountView;
        set
        {
            _currentAccountView = value;
            OnPropertyChanged(nameof(CurrentUserAccountView));
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

    public ViewModelBase CurrentChidlView
    {
        get => _currentChidlView;
        set
        {
            _currentChidlView = value;
            OnPropertyChanged(nameof(CurrentChidlView));
        }
    }

    public ICommand ShowFieldsCommand { get; }
    public ICommand ShowPrestamosCommand { get; }
    public ICommand ShowHerramientasCommand { get; }
    public ICommand ShowLaboratoriosCommand { get; }
    public ICommand ShowLaboratoristasCommand { get; }





    private void ExecuteShowFieldsCommand(object obj)
    {
        CurrentChidlView = new HerramientasFieldsViewModel();
    }
    private void ExecuteShowLaboratistasCommand(object obj)
    {
        CurrentChidlView = new LaboratoristasViewModel();
    }

    private void ExecuteShowLaboratoriosCommand(object obj)
    {
        CurrentChidlView = new LaboratoriosViewModel();
    }

    private void ExecuteShowHerramientasCommand(object obj)
    {
        CurrentChidlView = new HerramientasViewModel();
    }
    private void ExecuteShowPrestamosCommand(object obj)
    {
        CurrentChidlView = new PrestamosViewModel();
    }
    

    private void LoadCurrentUserdata()
    {
        var user = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
        if (user != null)
        {
            CurrentUserAccountView.Username = user.Username;
            CurrentUserAccountView.DisplayName = $"Bienvenido {user.FirstName} {user.LastName} ;)";
            CurrentUserAccountView.ProfilePicture = null;
        }
        else
        {
            CurrentUserAccountView.DisplayName = "Usuario invalido, not logged";
        }
    }
}