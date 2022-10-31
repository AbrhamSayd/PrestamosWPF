using PrestamosWPF.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestamosWPF.Repositories
{
    public interface ILabsRepository
    {
        void Add(LabsModel labsModel);
        void Edit(LabsModel labsModel);
        void Remove(int id);
        DataTable GetByAll();
    }
}
