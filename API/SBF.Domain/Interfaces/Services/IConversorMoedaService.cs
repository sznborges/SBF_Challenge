using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SBF.Domain.Interfaces.Services
{
    public interface IConversorMoedaService
    {
        double GetConversorMoeda(string de, string para);
    }
}
