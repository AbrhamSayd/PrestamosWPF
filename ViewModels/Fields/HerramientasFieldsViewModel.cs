using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using PrestamosWPF.Models;
using PrestamosWPF.Repositories;
using PrestamosWPF.Views.Fields;

namespace PrestamosWPF.ViewModels.Fields;

public class HerramientasFieldsViewModel : ViewModelBase
{
    private ToolsModel _toolsModel;
    private readonly IToolsRepository toolsRepository;
    private string _id_tool;
    private string _nombre;
    private string _descripcion;
    private string _cantidad;
    private string _estado;


    public string id_tool
    {
        get => _id_tool;
        set
        {
            _id_tool = value;
            OnPropertyChanged(nameof(id_tool));
        }
    }

    public string nombre
    {
        get => _nombre;
        set
        {
            _nombre = value;
            OnPropertyChanged(nameof(nombre));
        }
    }

    public string descripcion
    {
        get => _descripcion;
        set
        {
            _descripcion = value;
            OnPropertyChanged(nameof(descripcion));
        }
    }

    public string cantidad
    {
        get => _cantidad;
        set
        {
            _cantidad = value;
            OnPropertyChanged(nameof(cantidad));
        }
    }

    public string estado
    {
        get => _estado;
        set
        {
            _estado = value;
            OnPropertyChanged(nameof(estado));
        }
    }

    public ICommand AddCommand { get; }

    public HerramientasFieldsViewModel()
    {
        toolsRepository = new ToolsRepository();
        AddCommand = new ViewModelCommand(ExecuteAddCommand);
    }

    private void ExecuteAddCommand(object obj)
    {
        _toolsModel = new ToolsModel()
        {
            id_tool = 1.ToString(),
            cantidad = _cantidad,
            descripcion = _descripcion,
            estado = _estado, nombre = _nombre
        };
        toolsRepository.Add(_toolsModel);
        
    }
}