using Domain;
using Infrastructure.Interfaces;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/companies")]
public class CompanyController
{
    private readonly ICompanyService _companyService = new CompanyService();


    [HttpGet("{id:int}")]
    public async Task<Company?> GetByIdAsync(int id)
    {
        return await _companyService.GetCompanyById(id);
    }

    [HttpPost]
    public async Task AddAsync(Company company)
    {
        await _companyService.AddCompany(company);
    }

    [HttpPut]
    public async Task UpdateAsync(Company company)
    {
        await _companyService.UpdateCompany(company);
    }

    [HttpDelete("{id:int}")]
    public async Task DeleteAsync(int id)
    {
        await _companyService.DeleteCompany(id);
    }
}