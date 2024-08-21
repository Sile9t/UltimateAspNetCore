using AutoMapper;
using Contracts;
using Entities;
using Service.Contracts;
using Shared.Dtos;

namespace Service
{
    internal sealed class CompanyService : ICompanyService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public CompanyService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<CompanyDto> GetAllCompanies(bool trackChanges)
        {
            try
            {
                var companies = _repository.Company.GetAllCompanies(trackChanges);

                var companiesDto = companies.Select(x =>
                    new CompanyDto(x.Id, x.Name ?? "", string.Join(' ', x.Address, x.Country)))
                    .ToList();

                return companiesDto;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something want wrong in the {nameof(GetAllCompanies)} service method {ex}");
                throw;
            }
        }
    }
}
