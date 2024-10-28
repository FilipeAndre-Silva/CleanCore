namespace CleanCore.Application.Dtos.Product.Response
{
    public class GetProductResponse
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int Units { get; private set; }
        public double ValuePerUnit { get; private set; }
        public double TotalValue { get; private set; }
        public DateTime ExpirationDate { get; private set; }
    }
}