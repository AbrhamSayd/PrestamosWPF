using PrestamosWPF.Models;
using System.Collections.ObjectModel;
using PrestamosWPF.Repositories;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Windows.Media.Media3D;
using static PrestamosWPF.ViewModels.MainViewModel;

namespace PrestamosWPF.ViewModels;

public class HerramientasViewModel : ViewModelBase
{
    private ObservableCollection<ToolsModel> _collectionToolsModels;
    private readonly IToolsRepository toolsRepository;
    private ToolsModel _toolsModelRow;
    private int _selectIndex;

    //Fields
    public ObservableCollection<ToolsModel> CollectionToolsModels
    {
        get => _collectionToolsModels;
        set
        {
            _collectionToolsModels = value;
            OnPropertyChanged(nameof(CollectionToolsModels));
        }
    }

    public HerramientasViewModel()
    {
        toolsRepository = new ToolsRepository();
        RemoveCommand = new ViewModelCommand(ExecuteRemoveCommand);
        ExecuteGetAllCommand(null);
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
    public ToolsModel ToolsModelRow
    {
        get => _toolsModelRow;
        set
        {
            _toolsModelRow = value;
            OnPropertyChanged(nameof(ToolsModelRow));
        }
    }

    private void ExecuteRemoveCommand(object obj)
    {
        toolsRepository.Remove(int.Parse(ToolsModelRow.id_tool));
        CollectionToolsModels = new ObservableCollection<ToolsModel>(toolsRepository.GetByAll());
    }

    
    private void ExecuteGetAllCommand(object obj)
    {
        CollectionToolsModels = new ObservableCollection<ToolsModel>(toolsRepository.GetByAll());
    }

    //commands
    public ICommand RemoveCommand { get; }
}