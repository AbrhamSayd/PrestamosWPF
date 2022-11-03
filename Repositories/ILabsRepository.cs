using System.Collections.Generic;
using PrestamosWPF.Models;

namespace PrestamosWPF.Repositories;

public interface ILabsRepository
{
    void Add(LabsModel labsModel);
    void Edit(LabsModel labsModel);
    void Remove(int id);
    IEnumerable<LabsModel> GetByAll();
}