﻿using Shared.Dtos;

namespace Service.Contracts
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDto> GetEmployees(Guid companyId, bool trackChanges);
        EmployeeDto GetEmployee(Guid companyId, Guid id, bool trackChanges);
        EmployeeDto CreateEmployeeForCompany(Guid companyId, EmployeeForCreationDto, bool trackChanges);
        EmployeeDto DeleteEmployeeForCompany(Guid companyId, Guid id, bool trackChanges);
    }
}
