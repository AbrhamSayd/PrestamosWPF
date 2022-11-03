using System.Collections.ObjectModel;
using System.Windows.Input;
using PrestamosWPF.Models;
using PrestamosWPF.Repositories;

namespace PrestamosWPF.ViewModels;

public class PrestamosViewModel : ViewModelBase
{
    private readonly ILendingRepository _lendingRepository;
    private ObservableCollection<LendingModel> _colectionLendingModels;
    private LendingModel _lendingModelRow;

    public PrestamosViewModel()
    {
        RemoveCommand = new ViewModelCommand(ExecuteRemoveCommand);
        _colectionLendingModels = new ObservableCollection<LendingModel>();
        _lendingRepository = new LendingRepository();
        ExecuteGetAllCommand(null);
    }

    //fields
    public ObservableCollection<LendingModel> CollectionLendingModels
    {
        get => _colectionLendingModels;
        set
        {
            _colectionLendingModels = value;
            OnPropertyChanged(nameof(CollectionLendingModels));
        }
    }

    public LendingModel LendingModelRow
    {
        get => _lendingModelRow;
        set
        {
            _lendingModelRow = value;
            OnPropertyChanged(nameof(LendingModelRow));

        }
    }

    private void ExecuteRemoveCommand(object obj)
    {
        _lendingRepository.Remove(int.Parse(_lendingModelRow.id_lending));
        ExecuteGetAllCommand(null);
    }
    private void ExecuteGetAllCommand(object obj)
    {
        //LabsTable = labsRepository.GetByAll();
        _colectionLendingModels = new ObservableCollection<LendingModel>(_lendingRepository.GetByAll());
    }
    //commands

    public ICommand RemoveCommand { get; }
}