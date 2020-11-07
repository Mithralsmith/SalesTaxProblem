namespace SalesTaxProblem.Domain.Models
{
    public class Product:IProduct
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string ProdType { get; protected set; } = ProductType.Taxable.ToString();
        public bool IsImported { get; set; }

        public virtual void SetProductType(ProductType prodType)
        {
            ProdType = prodType.ToString();
        }

        public override string ToString()
        {
            return $"{(IsImported?"imported ":string.Empty)}{Name} at {Price:C}";
        }
    }
}
