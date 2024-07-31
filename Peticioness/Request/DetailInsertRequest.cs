namespace Peticioness.Request
{
    public class DetailInsertRequest
    {
        public int ProductId { get; set; }
        public int InvoiceId { get; set; }
        public double SubTotal { get; set; }
        public double Amount { get; set; }
        public double Price { get; set; }
    }
}
