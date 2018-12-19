using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coffee.DbEntities.Mapping
{
    public class SellerMap
    {
        public SellerMap(EntityTypeBuilder<Seller> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.IsAdmin).IsRequired();
            entityBuilder.Property(t => t.IsSeller).IsRequired();
            entityBuilder.Property(t => t.Email);
            entityBuilder.Property(t => t.Password);
            entityBuilder.Property(t => t.Name);
            entityBuilder.Property(t => t.Photo);
            entityBuilder.HasOne(x => x.Company).WithMany().HasForeignKey(x => x.CompanyId);
        }
    }
}
