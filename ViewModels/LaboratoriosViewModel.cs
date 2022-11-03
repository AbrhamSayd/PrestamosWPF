using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Windows.Input;
using PrestamosWPF.Models;
using PrestamosWPF.Repositories;
using PrestamosWPF.Utilities;

namespace PrestamosWPF.ViewModels
{
    public class LaboratoriosViewModel : ViewModelBase
    {
        
    
        private readonly ILabsRepository _labsRepository;
        private ObservableCollection<LabsModel> _labsModel;



        //fields
        public ObservableCollection<LabsModel> LabsModel
        {
            get => _labsModel;
            set
            {
                _labsModel = value;
                OnPropertyChanged(nameof(LabsModel));
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
            _labsRepository = new LabsRepository();
            AddCommand = new ViewModelCommand(ExecuteAddCommand);
            RemoveCommand = new ViewModelCommand(ExecuteRemoveCommand);
            EditCommand = new ViewModelCommand(ExecuteEditCommand);
            GetByIdCommand = new ViewModelCommand(ExecuteGetByIdCommand);
            GetByAllCommand = new ViewModelCommand(ExecuteGetByAllCommand);
            
        }

        //commands constructor
        private void ExecuteGetByAllCommand(object obj)
        {
            //LabsTable = labsRepository.GetByAll();
            LabsModel = new ObservableCollection<LabsModel>(_labsRepository.GetByAll());
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
