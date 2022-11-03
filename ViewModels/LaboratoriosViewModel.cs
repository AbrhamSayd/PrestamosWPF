using PrestamosWPF.Models;
using PrestamosWPF.Repositories;
using PrestamosWPF.ViewModels.Fields;
using PrestamosWPF.Views;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace PrestamosWPF.ViewModels;

public class LaboratoriosViewModel : ViewModelBase
{
    private readonly ILabsRepository _labsRepository;
    private ObservableCollection<LabsModel> _labsModel;
    private LabsModel _labsModelRow;
    private int _selectIndex;


    //constructor

    public LaboratoriosViewModel()
    {
        _labsRepository = new LabsRepository();
        RemoveCommand = new ViewModelCommand(ExecuteRemoveCommand, CanExecuteRemoveCommand);
        GetByIdCommand = new ViewModelCommand(ExecuteGetByIdCommand);
        ExecuteGetAllCommand(null);


    }




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

    public int SelectIndex
    {
        get => _selectIndex;
        set
        {
            _selectIndex = value;
            OnPropertyChanged(nameof(SelectIndex));
        }
    }

    public LabsModel LabsModelRow
    {
        get => _labsModelRow;
        set
        {
            _labsModelRow = value;
            OnPropertyChanged(nameof(LabsModelRow));
        }
    }

    //commands
    public ICommand RemoveCommand { get; }
    public ICommand GetByIdCommand { get; }
    //public ICommand ShowAddLaboratoriosCommand { get; }

    //Out of use
    public ICommand GetAllCommand { get; }
    public ICommand EditCommand { get; }
    public ICommand AddCommand { get; }

    //commands constructor
    private void ExecuteGetAllCommand(object obj)
    {
        //LabsTable = labsRepository.GetByAll();
        LabsModel = new ObservableCollection<LabsModel>(_labsRepository.GetByAll());
    }

    //REVISAR
    private void ExecuteRemoveCommand(object obj)
    {
        _labsRepository.Remove(int.Parse(_labsModelRow.id_lab));
        LabsModel = new ObservableCollection<LabsModel>(_labsRepository.GetByAll());
    }

    private bool CanExecuteRemoveCommand(object obj)
    {
        return true;

    }

    private void ExecuteGetByIdCommand(object obj)
    {
        throw new NotImplementedException();
    }

}
