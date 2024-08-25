using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.LinkModels;
using Entities.Models;
using Service.Contracts;
using Service.DataShaping;
using Shared.Dtos;
using Shared.RequestFeatures;
using System.Dynamic;

namespace Service
{
    internal sealed class EmployeeService : IEmployeeService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly IDataShaper<EmployeeDto> _dataShaper;
        private readonly IEmployeeLinks _employeeLinks;

        public EmployeeService(IRepositoryManager repository, 
            ILoggerManager logger, IMapper mapper, 
            IDataShaper<EmployeeDto> dataShaper, IEmployeeLinks employeeLinks)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
            _dataShaper = dataShaper;
            _employeeLinks = employeeLinks;
        }

        public async Task<(LinkResponse linkResponse, MetaData metaData)> GetEmployeesAsync(Guid companyId,
            LinkParameters linkParameters, bool trackChanges)
        {
            if (!linkParameters.employeeParameters.ValidAgeRange)
                throw new MaxAgeRangeBadRequestException();

            await CheckIfCompanyExists(companyId, trackChanges);

            var employeesWithMetaData = await _repository.Employee.GetEmployeesAsync(companyId,
                linkParameters.employeeParameters, trackChanges);

            var employeesDto = _mapper.Map<IEnumerable<EmployeeDto>>(employeesWithMetaData);
            var links = _employeeLinks.TryGenerateLinks(employeesDto,
                linkParameters.employeeParameters.Fields!, companyId, linkParameters.httpContext);

            return (linkResponse: links, metaData: employeesWithMetaData.MetaData);
        }

        public async Task<EmployeeDto> GetEmployeeAsync(Guid companyId, Guid id, bool trackChanges)
        {
            await CheckIfCompanyExists(companyId, trackChanges);

            var employee = await GetEmployeeForCompanyAndCheckIfItExists(companyId, id, trackChanges);

            var employeeDto = _mapper.Map<EmployeeDto>(employee);
            return employeeDto;
        }

        public async Task<EmployeeDto> CreateEmployeeForCompanyAsync(Guid companyId, EmployeeForCreationDto employeeForCreationDto,
            bool trackChanges)
        {
            await CheckIfCompanyExists(companyId, trackChanges);

            var employeeEntity = _mapper.Map<Employee>(employeeForCreationDto);

            _repository.Employee.CreateEmployeeForCompany(companyId, employeeEntity);
            await _repository.SaveAsync();

            var employeeToReturn = _mapper.Map<EmployeeDto>(employeeEntity);
            return employeeToReturn;
        }

        public async Task DeleteEmployeeForCompanyAsync(Guid companyId, Guid id, bool trackChanges)
        {
            await CheckIfCompanyExists(companyId, trackChanges);

            var employeeForCompany = await GetEmployeeForCompanyAndCheckIfItExists(companyId, id, trackChanges);

            _repository.Employee.DeleteEmployee(employeeForCompany);
            await _repository.SaveAsync();
        }

        public async Task UpdateEmployeeForCompanyAsync(Guid companyId, Guid id, 
            EmployeeForUpdateDto employeeForUpdateDto, bool compTrackChanges, bool empTrackChanges)
        {
            await CheckIfCompanyExists(companyId, compTrackChanges);

            var employeeEntity = await GetEmployeeForCompanyAndCheckIfItExists(companyId, id, empTrackChanges);

            _mapper.Map(employeeForUpdateDto, employeeEntity);
            await _repository.SaveAsync();
        }

        public async Task<(EmployeeForUpdateDto employeeToPatch, Employee employeeEntity)> GetEmployeeForPatchAsync(
            Guid companyId, Guid id, bool compTrackChanges, bool empTrackChanges)
        {
            await CheckIfCompanyExists(companyId, compTrackChanges);

            var employeeEntity = await GetEmployeeForCompanyAndCheckIfItExists(companyId, id, empTrackChanges);

            var employeeToPatch = _mapper.Map<EmployeeForUpdateDto>(employeeEntity);

            return (employeeToPatch, employeeEntity);
        }

        public async Task SaveChangesForPatchAsync(EmployeeForUpdateDto employeeToPatch, Employee employeeEntity)
        {
            _mapper.Map(employeeToPatch, employeeEntity);
            await _repository.SaveAsync();
        }

        private async Task CheckIfCompanyExists(Guid companyId, bool compTrackChanges)
        {
            var company = await _repository.Company.GetCompanyAsync(companyId, compTrackChanges);
            if (company is null)
                throw new CompanyNotFoundException(companyId);
        }

        private async Task<Employee?> GetEmployeeForCompanyAndCheckIfItExists(Guid companyId, Guid id, bool empTrackChanges)
        {
            var employeeEntity = await _repository.Employee.GetEmployeeAsync(companyId, id, empTrackChanges);
            if (employeeEntity is null)
                throw new EmployeeNotFoundException(id);

            return employeeEntity;
        }
    }
}
