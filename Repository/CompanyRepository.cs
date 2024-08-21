using Contracts.Repositories;
using Entities;
using Shared.Dtos;

namespace Repository
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<Company> GetAllCompanies(bool trackChanges) =>
            FindAll(trackChanges)
                .OrderBy(x => x.Name)
                .ToList();

        public Company GetCompany(Guid companyId, bool trackChanges) =>
            FindByCondition(x => x.Id.Equals(companyId), trackChanges)
                .SingleOrDefault();
    }
}
