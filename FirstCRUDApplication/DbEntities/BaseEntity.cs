using System;

namespace Coffee.DbEntities
{
    public class BaseEntity
    {
        public long Id { get; set; }

        public DateTime AddedDate { get; set; }

        public BaseEntity()
        {
            AddedDate = DateTime.UtcNow;
        }
    }
}
