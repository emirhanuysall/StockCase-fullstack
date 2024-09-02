using System.Collections.Generic;
using System.Linq;
using Backend.Models;
using Backend.Data;

namespace Backend.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly DataContext _context;

        public CompanyService(DataContext context)
        {
            _context = context;
        }

        public List<Company> GetAllCompanies()
        {
            return _context.Companies.ToList();
        }

        public Company GetCompanyById(int id)
        {
            return _context.Companies.Find(id);
        }

        public void CreateCompany(Company company)
        {
            _context.Companies.Add(company);
            _context.SaveChanges();
        }

        public Company UpdateCompany(Company company)
        {
            var existingCompany = _context.Companies.Find(company.Id);
            if (existingCompany == null) return null;

            existingCompany.Name = company.Name;
            existingCompany.Address = company.Address;
            existingCompany.PhoneNumber = company.PhoneNumber;
            existingCompany.Email = company.Email;
            _context.SaveChanges();

            return existingCompany;
        }

        public bool DeleteCompany(int id)
        {
            var company = _context.Companies.Find(id);
            if (company == null) return false;

            _context.Companies.Remove(company);
            _context.SaveChanges();

            return true;
        }
    }
}

