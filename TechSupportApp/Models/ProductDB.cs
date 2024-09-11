

namespace TechSupportApp.Models
{
    public static class ProductDB
    {

        public static List<ProductDTO> GetProducts()
        {
            using (TechSupportContext db = new TechSupportContext()) 
            {
                List<ProductDTO> products = db.Products.Select(
                    p => 
                    new ProductDTO {
                        ProductCode = p.ProductCode,
                        Name = p.Name,
                        Version = p.Version,
                        ReleaseDate = p.ReleaseDate
                    }).ToList();
                return products;
            }
        }

        public static void AddProduct(Product product)
        {
            using (TechSupportContext db = new TechSupportContext())
            {
                db.Products.Add(product);
                db.SaveChanges();
            }
        }

        internal static Product? FindProduct(string productCode)
        {
            using (TechSupportContext db = new TechSupportContext())
            {
                return db.Products.Find(productCode);
            }
        }

        internal static void UpdateProduct(Product selectedProduct)
        {
            using (TechSupportContext db = new TechSupportContext()) 
            { 
                db.Products.Update(selectedProduct);
                db.SaveChanges();
            }
        }

        internal static void RemoveProduct(Product selectedProduct)
        {
            using (TechSupportContext db = new TechSupportContext()) 
            { 
                db.Products.Remove(selectedProduct);
                db.SaveChanges();
            }
        }
    }    
}
