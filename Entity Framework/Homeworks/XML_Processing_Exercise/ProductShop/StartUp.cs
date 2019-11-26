using AutoMapper;
using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Mapper.Initialize(cfg => cfg.AddProfile<ProductShopProfile>());

            using (var db = new ProductShopContext())
            {
                //var inputXml = File.ReadAllText(@"../../../Datasets/categories-products.xml");

                var result = GetUsersWithProducts(db);

                System.Console.WriteLine(result);
            }
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportUsersDto[]),
                                new XmlRootAttribute("Users"));

            var usersDto = (ImportUsersDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var users = Mapper.Map<User[]>(usersDto);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportProductsDto[]),
                                new XmlRootAttribute("Products"));

            var productsDto = (ImportProductsDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var products = Mapper.Map<Product[]>(productsDto);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportCategoriesDto[]),
                                new XmlRootAttribute("Categories"));

            var categoriesDto = (ImportCategoriesDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var categories = Mapper.Map<Category[]>(categoriesDto);

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Length}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportCategoriesProductsDto[]),
                                new XmlRootAttribute("CategoryProducts"));

            var categoryProductsDto = (ImportCategoriesProductsDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var categoryProducts = new List<CategoryProduct>();

            foreach (var categoryProductDto in categoryProductsDto)
            {
                var targetProduct = context.Products.Find(categoryProductDto.ProductId);
                var targetCategory = context.Categories.Find(categoryProductDto.CategoryId);

                if (targetCategory != null && targetProduct != null)
                {
                    var category = Mapper.Map<CategoryProduct>(categoryProductDto);

                    categoryProducts.Add(category);
                }
            }

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new ExportProductsInRangeDto
                {
                    Name = p.Name,
                    Price = p.Price,
                    BuyerName = $"{p.Buyer.FirstName} {p.Buyer.LastName}"
                })
                .Take(10)
                .ToArray();

            var xmlSerializer =
                new XmlSerializer(typeof(ExportProductsInRangeDto[]), new XmlRootAttribute("Products"));

            StringBuilder sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(new StringWriter(sb), products, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Count() >= 1)
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new SoldProductsDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Products = u.ProductsSold.Select(p => new ProductDto
                    {
                        Name = p.Name,
                        Price = p.Price
                    })
                    .ToArray()
                })
                .Take(5)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(SoldProductsDto[]),
                                new XmlRootAttribute("Users"));

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(new StringWriter(sb), users, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
               .Select(c => new GetCategoriesByProductsCountDto
               {
                   Name = c.Name,
                   Count = c.CategoryProducts.Count(),
                   AveragePrice = c.CategoryProducts.Average(cp => cp.Product.Price),
                   TotalRevenue = c.CategoryProducts.Sum(p => p.Product.Price)
               })
               .OrderByDescending(c => c.Count)
               .ThenBy(c => c.TotalRevenue)
               .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(GetCategoriesByProductsCountDto[]), new XmlRootAttribute("Categories"));

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(new StringWriter(sb), categories, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any())
                .OrderByDescending(p => p.ProductsSold.Count())
                .Select(u => new UsersWithProductsDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new SoldProductsCountDto
                    {
                        Count = u.ProductsSold.Count(),
                        Products = u.ProductsSold
                        .Select(p => new ProductDto
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                        .OrderByDescending(p => p.Price)
                        .ToArray()
                    }
                })
                .Take(10)
                .ToArray();

            var result = new UsersAndProductsDto
            {
                Count = context.Users.Count(p => p.ProductsSold.Any()),
                Users = users
            };

            var xmlSerializer = new XmlSerializer(typeof(UsersAndProductsDto), new XmlRootAttribute("Users"));

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(new StringWriter(sb), result, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}