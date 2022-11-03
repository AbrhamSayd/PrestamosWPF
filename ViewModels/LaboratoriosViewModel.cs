using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Media3D;
using PrestamosWPF.Models;
using PrestamosWPF.Repositories;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PrestamosWPF.ViewModels;

public class LaboratoriosViewModel : ViewModelBase
{
    private readonly ILabsRepository _labsRepository;
    private ObservableCollection<LabsModel> _labsModel;
    private LabsModel _labsModelRow;
    private bool _isChecked;


    //constructor

    public LaboratoriosViewModel()
    {
        _labsRepository = new LabsRepository();

        RemoveCommand = new ViewModelCommand(ExecuteRemoveCommand, CanExecuteRemoveCommand
            );
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

    public bool isChecked
    {
        get => _isChecked;
        set
        {
            _isChecked = value;
            OnPropertyChanged(nameof(_isChecked));
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
    
    private void ExecuteRemoveCommand(object obj)
    {
        _labsRepository.Remove(int.Parse(_labChecked.id_user));
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