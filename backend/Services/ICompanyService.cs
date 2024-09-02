using Backend.Models;
using System.Collections.Generic;

namespace Backend.Services
{
    public interface ICompanyService
    {
        List<Company> GetAllCompanies();
        Company GetCompanyById(int id);
        void CreateCompany(Company company);
        Company UpdateCompany(Company company);
        bool DeleteCompany(int id);
    }
}

