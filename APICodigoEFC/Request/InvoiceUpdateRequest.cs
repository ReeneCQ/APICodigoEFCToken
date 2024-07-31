namespace APICodigoEFC.Request
{
    public class InvoiceUpdateRequest
    {
        public int InvoiceID { get; set; }
        public string Number { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public int CustomerID { get; set; } // ID del cliente asociado con la factura
    }
}
