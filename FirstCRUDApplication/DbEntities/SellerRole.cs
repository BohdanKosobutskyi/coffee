namespace Coffee.DbEntities
{
    public class SellerRole
    {
        public long UserId { get; set; }

        public long RoleId { get; set; }

        public Seller Seller { get; set; }

        public Role Role { get; set; }
    }
}
