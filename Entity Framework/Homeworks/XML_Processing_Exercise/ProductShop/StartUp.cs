using AutoMapper;
using ProductShop.Data;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System.IO;
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
                var inputXml = File.ReadAllText(@"../../../Datasets/products.xml");

                var result = ImportProducts(db, inputXml);

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
    }
}