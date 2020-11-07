namespace SalesTaxProblem.Domain.Models
{
    public class Product:IProduct
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string ProdType { get; set; }
        public bool IsImported { get; set; }

        public override string ToString()
        {
            return $"{(IsImported?"imported ":string.Empty)}{Name} at {Price:C}";
        }
    }
}
