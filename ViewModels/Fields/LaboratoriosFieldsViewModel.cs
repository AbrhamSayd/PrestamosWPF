using System.Windows.Input;
using PrestamosWPF.Models;
using PrestamosWPF.Repositories;

namespace PrestamosWPF.ViewModels.Fields
{
    public class LaboratoriosFieldsViewModel : ViewModelBase
    {
        private LabsModel _labsModel;
        private readonly ILabsRepository labsRepository;
        private string _id_lab;
        private string _lab_name;
        private string _ubicacion;
        private string _id_user;

        public string id_lab
        {
            get => _id_lab;
            set
            {
                _id_lab = value;
                OnPropertyChanged(nameof(id_lab));
            }
        }
        public string lab_name
        {
            get => _lab_name;
            set
            {
                _lab_name = value;
                OnPropertyChanged(nameof(lab_name));
            }
        }
        public string ubicacion
        {
            get => _ubicacion;
            set
            {
                _ubicacion = value;
                OnPropertyChanged(nameof(ubicacion));
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

        public ICommand AddCommand { get; }
        public LaboratoriosFieldsViewModel()
        {
            labsRepository = new LabsRepository();
            AddCommand = new ViewModelCommand(ExecuteAddCommand);
        }

        

        private void ExecuteAddCommand(object obj)
        {
            _labsModel = new LabsModel()
            {
                id_lab = 1.ToString(),
                lab_name = _lab_name,
                ubicacion = _ubicacion,
                id_user = _id_user
            };
            labsRepository.Add(_labsModel);
        }
    }
}
