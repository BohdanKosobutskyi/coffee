using Coffee.Repositories.Interfaces;
using Coffee.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coffee.Services
{
    public class SellerService : ISellerService
    {
        private IUserRepository _userRepository;
        private IUserCompanyRepository _userCompanyRepository;
        private ISellerRepository _sellerRepositoory;

        public SellerService(IUserRepository userRepository, IUserCompanyRepository userCompanyRepository, 
            ISellerRepository sellerRepository)
        {
            _userRepository = userRepository;
            _userCompanyRepository = userCompanyRepository;
            _sellerRepositoory = sellerRepository;
        }

        public void AddPoints(long userId, long points, long seellerId)
        {
            if (points <= 0) throw new Exception();

            var seller = _sellerRepositoory.Get(x => x.Id == seellerId).FirstOrDefault();

            if (seller == null) throw new Exception();

            var user = _userRepository.Get(x => x.Id == userId).FirstOrDefault();

            if (user == null) throw new Exception();
            
            var userCompany = _userCompanyRepository.Get(x => x.CompanyId == seller.CompanyId && x.UserId == user.Id).FirstOrDefault();

            if (userCompany == null) throw new Exception();

            userCompany.Points += points;

            _userCompanyRepository.Update(userCompany);
        }
    }
}
