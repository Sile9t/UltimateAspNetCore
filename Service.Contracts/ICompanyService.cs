﻿using Entities;
using Entities.Responses;
using Shared.Dtos;

namespace Service.Contracts
{
    public interface ICompanyService
    {
        //Task<IEnumerable<CompanyDto>> GetAllCompaniesAsync(bool trackChanges);
        Task<ApiBaseResponse> GetAllCompaniesAsync(bool trackChanges);
        //Task<CompanyDto> GetCompanyAsync(Guid id, bool trackChanges);
        Task<ApiBaseResponse> GetCompanyAsync(Guid id, bool trackChanges);
        Task<CompanyDto> CreateCompanyAsync(CompanyForCreationDto company);
        Task<IEnumerable<CompanyDto>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
        Task<(IEnumerable<CompanyDto> companies, string ids)> CreateCompanyCollectionAsync(
            IEnumerable<CompanyForCreationDto> companyCollection);
        Task DeleteCompanyAsync(Guid companyId, bool trackChanges);
        Task UpdateCompanyAsync(Guid companyId, CompanyForUpdateDto companyForUpdate, bool trackChanges);
    }
}
