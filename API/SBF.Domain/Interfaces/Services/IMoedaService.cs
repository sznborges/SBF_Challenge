using SBF.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SBF.Domain.Interfaces.Services
{
    public interface IMoedaService
    {
        Moeda Get(int id);
        void Add(Moeda moeda);
        void Update(Moeda moeda);
        IEnumerable<Moeda> Listar();
    }
}
