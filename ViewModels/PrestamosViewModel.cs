using System.Collections.ObjectModel;
using PrestamosWPF.Models;
using PrestamosWPF.Repositories;

namespace PrestamosWPF.ViewModels;

public class PrestamosViewModel : ViewModelBase
{
    private readonly ILendingRepository _lendingRepository;
    private ObservableCollection<LendingModel> _lendingModels;
    private LendingModel _lendingModelRow;

    public PrestamosViewModel()
    {
        _lendingModels = new ObservableCollection<LendingModel>();
        _lendingRepository = new repo
    }
}