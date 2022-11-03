using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using PrestamosWPF.Models;
using PrestamosWPF.Repositories;

namespace PrestamosWPF.ViewModels.Fields
{
    public class PrestamosFieldsViewModel : ViewModelBase
    {
        private UserAccountModel _currentAccountView;
        private readonly UserRepository userRepository;
        private UserAccountModel currentUser;
        private ObservableCollection<ToolsModel> _CollectionTools;
        private ToolsModel _toolsModel;
        private LendingModel _lendingModel;
        private readonly ILendingRepository lendingRepository;
        private readonly IToolsRepository _toolsRepositoryl;
        private string _id_lending;
        private string _username;
        private string _id_user;
        private string _id_tool;
        private string _name;
        private DateTime _fecha_prestamo;


        public ToolsModel toolsModel
        {
            get => _toolsModel;
            set
            {
                _toolsModel = value;
                OnPropertyChanged(nameof(toolsModel));
            }
        }
        public ObservableCollection<ToolsModel> collectiontools
        {
            get => _CollectionTools;
            set
            {
                _CollectionTools = value;
                OnPropertyChanged(nameof(collectiontools));
            }
        }
        public string id_lending
        {
            get => _id_lending;
            set
            {
                _id_lending = value;
                OnPropertyChanged(nameof(id_lending));
            }
        }

        public string username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(username));
            }
        }
        public string id_user
        {
            get => _id_user;
            set
            {
                _id_user = value;
                OnPropertyChanged(nameof(id_user));
            }
        }

        public string id_tool
        {
            get => _id_tool;
            set
            {
                _id_tool = value;
                OnPropertyChanged(nameof(id_tool));
            }
        }

        public string name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(name));
            }
        }

        public DateTime fecha_prestamo
        {
            get => _fecha_prestamo;
            set
            {
                _fecha_prestamo = value;
                OnPropertyChanged(nameof(fecha_prestamo));
            }
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

        public ICommand AddCommand { get; }

        public PrestamosFieldsViewModel()
        {
            _toolsRepositoryl = new ToolsRepository();
            ExecuteGettools(null);
            lendingRepository = new LendingRepository();
            AddCommand = new ViewModelCommand(ExecuteAddCommand);
            CurrentUserAccountView = new UserAccountModel();
            userRepository = new UserRepository();
            LoadCurrentUserdata();
        }

        private void ExecuteGettools(object o)
        {
            _CollectionTools = new ObservableCollection<ToolsModel>(_toolsRepositoryl.GetByAll());
        }

        private void ExecuteAddCommand(object obj)
        {
            _lendingModel = new LendingModel()
            {
                id_lending = 1.ToString(),
                username = _username,
                id_user = CurrentUserAccountView.Username,
                id_tool = _id_tool,
                name = _name,
                fecha_prestamo = _fecha_prestamo,
            };
            lendingRepository.Add(_lendingModel);
        }
        private void LoadCurrentUserdata()
        {
            var user = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
            if (user != null)
            {
                CurrentUserAccountView.Username = user.Id;
                CurrentUserAccountView.DisplayName = $"Bienvenido {user.FirstName} {user.LastName} ;)";
                CurrentUserAccountView.ProfilePicture = null;
            }
            else
            {
                CurrentUserAccountView.DisplayName = "Usuario invalido, not logged";
            }
        }
    }
}
