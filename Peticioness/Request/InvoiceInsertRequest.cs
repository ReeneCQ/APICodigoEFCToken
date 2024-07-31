namespace Peticioness.Request
{
    public class InvoiceInsertRequest
    {
        public string Number { get; set; }
        public string Description { get; set; }
        public int CustomerID { get; set; }
    }
}
