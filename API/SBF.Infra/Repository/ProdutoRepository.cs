using SBF.Domain.Entity;
using SBF.Domain.Interfaces.Repository;
using SBF.Infra.Data;

namespace SBF.Infra.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(Context dbContext) : base(dbContext)
        {

        }
    }
}
