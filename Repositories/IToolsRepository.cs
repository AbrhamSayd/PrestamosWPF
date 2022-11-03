using PrestamosWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestamosWPF.Repositories
{
    public interface IToolsRepository
    {
        void Add(ToolsModel toolsModel);
        void Edit(ToolsModel toolsModel);
        void Remove(int id);
        IEnumerable<ToolsModel> GetByAll();
    }
}
