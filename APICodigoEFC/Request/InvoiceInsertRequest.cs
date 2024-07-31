namespace APICodigoEFC.Request
{
    public class InvoiceInsertRequest
    {
        public string Number { get; set; }
        public string Description { get; set; }
        public int CustomerID { get; set; } // ID del cliente asociado con la factura
    }
}
