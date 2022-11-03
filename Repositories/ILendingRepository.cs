using System.Collections.Generic;
using PrestamosWPF.Models;

namespace PrestamosWPF.Repositories;

public interface ILendingRepository
{
    void Add(LendingModel lendingModel);
    void Edit(LendingModel lendingModel);
    void Remove(LendingModel lendingModel);
    LendingModel GetById(int id);
    IEnumerable<LendingModel> GetByAll();
}