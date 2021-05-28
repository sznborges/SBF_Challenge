using SBF.Domain.Entity;
using SBF.Domain.Interfaces.Repository;
using SBF.Infra.Data;
using System.Collections.Generic;
using System.Linq;

namespace SBF.Infra.Repository
{
    public class MoedaRepository : Repository<Moeda>, IMoedaRepository
    {

        public MoedaRepository(Context dbContext) : base(dbContext)
        {

        }
        public IEnumerable<Moeda> Listar()
        {
            var query = GetQuery();

            return query.ToArray();
        }
    }
}
