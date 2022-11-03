using System.Collections.Generic;
using PrestamosWPF.Models;
using PrestamosWPF.Repositories;

namespace PrestamosWPF.ViewModels.Fields;

public class HerramientasFieldsViewModel : ViewModelBase, IToolsRepository
{

    private ToolsModel _toolsModel;
    private readonly IToolsRepository toolsRepository;

    public ToolsModel ToolsModel
    {
        get => _toolsModel;
        set
        {
            _toolsModel = value;
            OnPropertyChanged(nameof(ToolsModel));
        }
    }





    public void Add(ToolsModel toolsModel)
    {
        toolsRepository.Add(_toolsModel);
    }

    public void Edit(ToolsModel toolsModel)
    {
        throw new System.NotImplementedException();
    }

    public void Remove(int id)
    {
        throw new System.NotImplementedException();
    }

    public IEnumerable<ToolsModel> GetByAll()
    {
        throw new System.NotImplementedException();
    }
}