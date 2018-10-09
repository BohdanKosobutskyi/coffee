using Coffee.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coffee.DbEntities
{
    public class UserMap
    {
        public UserMap(EntityTypeBuilder<User> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(x => x.AddedDate).ValueGeneratedOnAdd().IsRequired();
            entityBuilder.Property(t => t.Phone).IsRequired();
            entityBuilder.Property(t => t.Password).IsRequired();
            entityBuilder.Property(t => t.RefreshToken).IsRequired();
        }
    }
}
