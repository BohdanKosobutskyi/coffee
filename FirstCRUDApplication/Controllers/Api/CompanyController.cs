using Coffee.Contracts.Company;
using Coffee.DbEntities;
using Coffee.Interface;
using Coffee.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

        [HttpPost("/api/web/company/register")]
        public async Task Register([FromBody] CompanyCreateView company)
        {
            if (_dataValidator.IsValidEmail(company.email))
            {
                var companyDb = _companyRepository.Get(item => item.Email == company.email).FirstOrDefault(); 
                if(companyDb != null)
                {
                    Response.StatusCode = 400;
                    await Response.WriteAsync("Company with this email already exist.");
                    return;
                }

                companyDb = new Company
                {
                    Email = company.email,
                    Title = company.title,
                    Password = company.password,
                    Phone = company.phone
                };

                _companyRepository.Create(companyDb);
                Response.StatusCode = 200;
                return;
            }

            throw new ArgumentException();
        }

        [ProducesResponseType(200, Type = typeof(IEnumerable<CompanyListView>))]
        [HttpGet("/api/web/company/all")]
        public async Task GetAll()
        {
            var response = _companyRepository.Get().Select(x => new CompanyListView
            {
                company_id = x.Id,
                email = x.Email,
                is_approved = x.IsAproved,
                title = x.Title
            });

            Response.ContentType = "application/json";
            await Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented }));
        }

        [HttpPost("/api/web/company/approve")]
        public async Task Approve([FromBody] CompanyApproveView company)
        {
            var companyId = company.company_id;

            var companyDb = _companyRepository.Get(item => item.Id == companyId).FirstOrDefault();

            if(company == null)
            {
                Response.StatusCode = 400;
                await Response.WriteAsync("Company with this parameters not exist.");
                return;
            }

            companyDb.IsAproved = true;

            _companyRepository.Update(companyDb);

            Response.StatusCode = 200;
            return;
        }

        [HttpPost("/api/web/company/delete")]
        public async Task Delete([FromBody] CompanyDeleteView company)
        {
            var companyId = company.company_id;

            var companyDb = _companyRepository.Get(item => item.Id == companyId).FirstOrDefault();

            if (companyDb == null)
            {
                Response.StatusCode = 400;
                await Response.WriteAsync("Company with this parameters not exist.");
                return;
            }

            _companyRepository.Remove(companyDb);

            Response.StatusCode = 200;
            return;
        }
    }
}