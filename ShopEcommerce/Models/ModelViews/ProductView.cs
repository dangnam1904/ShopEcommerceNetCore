namespace ShopEcommerce.Models.ModelViews
{
    public class ProductView
    {
        public Product Product { get; set; }
        public List<GroupOption> GroupOptions { get; set; }
        public List<OptionProduct> OptionProducts { get; set; }

        public ProductView()
        {
        }

        public ProductView(Product product, List<GroupOption> groupOptions, List<OptionProduct> optionProducts)
        {
            Product = product;
            GroupOptions = groupOptions;
            OptionProducts = optionProducts;
        }
    }
}
