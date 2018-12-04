using Coffee.DbEntities;
using Coffee.Interface;
using Coffee.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Coffee.Controllers.Api
{
    [Produces("application/json")]
    [Consumes("application/json")]
    public class CompanyController : Controller
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IDataValidator _dataValidator;

        public CompanyController(ICompanyRepository companyRepository, IDataValidator dataValidator)
        {
            _companyRepository = companyRepository;
            _dataValidator = dataValidator;
        }

        [HttpPost("/api/company/register")]
        public void Register([FromBody] CompanyModel company)
        {
            if (_dataValidator.IsValidEmail(company.email))
            {
                var companyDb = _companyRepository.Get(item => item.Email == company.email).FirstOrDefault(); 
                if(companyDb != null)
                {
                    throw new ArgumentException("Company with this email already exist");
                }

                companyDb = new Company
                {
                    Email = company.email,
                    Title = company.title,
                    Password = company.password
                };

                _companyRepository.Create(companyDb);
                Response.StatusCode = 200;
                return;
            }

            throw new ArgumentException();
        }
    }

    public class CompanyModel
    {
        public string email { get; set; }
        public string title { get; set; }
        public string password { get; set; }
    }
}