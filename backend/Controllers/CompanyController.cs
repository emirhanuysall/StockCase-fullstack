using Microsoft.AspNetCore.Mvc;
using Backend.Models;
using Backend.Services;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public IActionResult GetAllCompanies()
        {
            var companies = _companyService.GetAllCompanies();
            return Ok(companies);
        }

        [HttpGet("{id}")]
        public IActionResult GetCompanyById(int id)
        {
            var company = _companyService.GetCompanyById(id);
            if (company == null) return NotFound();
            return Ok(company);
        }

        [HttpPost]
        public IActionResult CreateCompany(Company company)
        {
            _companyService.CreateCompany(company);
            return CreatedAtAction(nameof(GetCompanyById), new { id = company.Id }, company);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCompany(int id, Company company)
        {
            if (id != company.Id) return BadRequest();
            var updatedCompany = _companyService.UpdateCompany(company);
            if (updatedCompany == null) return NotFound();
            return Ok(updatedCompany);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCompany(int id)
        {
            var success = _companyService.DeleteCompany(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
