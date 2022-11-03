using PrestamosWPF.Models;
using System.Collections.ObjectModel;
using PrestamosWPF.Repositories;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Windows.Media.Media3D;

namespace PrestamosWPF.ViewModels;

public class HerramientasViewModel : ViewModelBase
{
    private ObservableCollection<ToolsModel> _collectionToolsModels;
    private readonly IToolsRepository toolsRepository;
    private ToolsModel _toolsModel;

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

    private void ExecuteRemoveCommand(object obj)
    {
        toolsRepository.Remove(int.Parse(_toolsModel.id_tool));
    }

    
    private void ExecuteGetAllCommand(object o)
    {
        CollectionToolsModels = new ObservableCollection<ToolsModel>(toolsRepository.GetByAll());
    }


    //commands
    public ICommand RemoveCommand;
}