namespace BootcampAres.BusinessModels.Models.Product
{
    public class ProductResponse : BaseResponse
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
    }
}
