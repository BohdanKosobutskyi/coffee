﻿using Coffee.Models;
namespace Coffee.DbEntities.Mapping
{
    public class UserCompany
    {
        public long UserId { get; set; }
        public User User { get; set; }

        public long CompanyId { get; set; }
        public Company Company { get; set; }
    }
}