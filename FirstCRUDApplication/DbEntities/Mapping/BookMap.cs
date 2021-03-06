﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Coffee.DbEntities
{
    public class BookMap 
    {
        public BookMap(EntityTypeBuilder<Book> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);            
            entityBuilder.Property(t => t.Name).IsRequired();
            entityBuilder.Property(x => x.AddedDate).IsRequired();
            entityBuilder.Property(t => t.Author).IsRequired();
            entityBuilder.Property(t => t.Publisher).IsRequired();           
        }
    }
}
