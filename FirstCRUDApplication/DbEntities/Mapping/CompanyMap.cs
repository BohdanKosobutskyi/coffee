using Coffee.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coffee.DbEntities.Mapping
{
    public class CompanyMap
    {
        public CompanyMap(EntityTypeBuilder<Company> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(x => x.AddedDate).IsRequired();
            entityBuilder.Property(t => t.Email).IsRequired();
            entityBuilder.Property(x => x.Password).IsRequired();
            entityBuilder.Property(x => x.IsAproved);
        }
    }
}
