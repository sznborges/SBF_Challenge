using SBF.Domain.Entity;
using SBF.Domain.Exceptions;
using SBF.Domain.Interfaces.Repository;
using SBF.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace SBF.Domain.Services
{
    public class MoedaService : IMoedaService
    {
        private readonly IMoedaRepository _moedaRepository;

        public MoedaService(IMoedaRepository moedaRepository)
        {
            this._moedaRepository = moedaRepository;
        }

        public Moeda Get(int id)
        {
            return _moedaRepository.GetById(id);
        }

        public void Add(Moeda moeda)
        {
            _moedaRepository.Add(moeda);
            _moedaRepository.SaveChanges();
        }

        public void Update(Moeda moeda)
        {

            var moedaDb = this._moedaRepository.GetById(moeda.Id);
            if (moedaDb == null)
                throw new ProductNotFoundException();

            moedaDb.Sigla = moeda.Sigla;

            _moedaRepository.Update(moedaDb);
            _moedaRepository.SaveChanges();
        }

        public IEnumerable<Moeda> Listar()
        {
            return _moedaRepository.Listar();
        }

    }
}
