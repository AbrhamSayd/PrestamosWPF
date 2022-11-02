using System.Data;
using System.Windows.Input;
using PrestamosWPF.Models;
using PrestamosWPF.Repositories;

namespace PrestamosWPF.ViewModels
{
    public class LaboratoriosViewModel : ViewModelBase
    {
        
        private LabsModel _labsModel;
        private ILabsRepository labsRepository;
        private DataTable _labsTable;


        //fields
        public LabsModel LabsModel
        {
           get { return _labsModel; }

            set
            {
                _labsModel = value;
                OnPropertyChanged(nameof(LabsModel));
            }
        }
        public DataTable LabsTable
        {
            get { return _labsTable; }

            set
            {
                _labsTable = value;
                OnPropertyChanged(nameof(LabsTable));
            }
        }

        //commands
        public ICommand AddCommand { get; }
        public ICommand RemoveCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand GetByIdCommand { get; }
        public ICommand GetByAllCommand { get; }
        //constructor
        public LaboratoriosViewModel()
        {
            labsRepository = new LabsRepository();
            AddCommand = new ViewModelCommand(ExecuteAddCommand);
            RemoveCommand = new ViewModelCommand(ExecuteRemoveCommand);
            EditCommand = new ViewModelCommand(ExecuteEditCommand);
            GetByIdCommand = new ViewModelCommand(ExecuteGetByIdCommand);
            GetByAllCommand = new ViewModelCommand(ExecuteGetByAllCommand);
        }

        //commands constructor
        private void ExecuteGetByAllCommand(object obj)
        {
            LabsTable = labsRepository.GetByAll();
        }

        private void ExecuteEditCommand(object obj)
        {
            throw new System.NotImplementedException();
        }

        private void ExecuteRemoveCommand(object obj)
        {
            throw new System.NotImplementedException();
        }

        private void ExecuteAddCommand(object obj)
        {
            throw new System.NotImplementedException();
        }

        private void ExecuteGetByIdCommand(object obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
