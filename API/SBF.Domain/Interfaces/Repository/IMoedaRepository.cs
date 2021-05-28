using SBF.Domain.Entity;
using System.Collections.Generic;

namespace SBF.Domain.Interfaces.Repository
{
    public interface IMoedaRepository : IRepository<Moeda>
    {
        IEnumerable<Moeda> Listar();
    }
}
