using System;

namespace FirstCRUDApplication.DbEntities
{
    public class BaseEntity
    {
        public Int64 Id { get; set; }

        public DateTime AddedDate { get; set; }
    }
}
