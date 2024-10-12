using H_Shopping.Models;
using Microsoft.EntityFrameworkCore;

namespace H_Shopping.DAL
{
    public class SeedData
    {
        public static void SeedingData(DataContext _context)
        {
            _context.Database.Migrate();
            if (!_context.Categories.Any())
            {
                List<CategoryModel> categories = new List<CategoryModel>()
                {
                    new CategoryModel() { Name="Laptop", Slug="laptop", Description="Explore our diverse collection of laptops from top brands like Apple, Dell, HP, Asus, and more. Whether you're looking for a laptop for work, study, entertainment, or gaming, we've got something for every need. Featuring sleek designs, powerful performance, and advanced features, our laptops are built to deliver efficiency, durability, and portability.\r\n\r\nFind the perfect laptop to boost your productivity and enhance your entertainment experience today!", Status=1 },
                    new CategoryModel() { Name="PC", Slug="pc", Description="Discover our range of desktop PCs from trusted brands like Dell, HP, Asus, Lenovo, and more. With powerful performance, easy upgrade options, and exceptional durability, our PCs are perfect for everything from work and study to gaming and professional graphic design.\r\n\r\nChoose the right PC to experience cutting-edge technology and maximize your productivity today!", Status=1 },
                    new CategoryModel() { Name="Electronic Componet", Slug="electronic-componet", Description="Browse our wide selection of electronic components, including resistors, capacitors, transistors, and integrated circuits. Whether you're a hobbyist or a professional, we provide high-quality components that are essential for building, repairing, or upgrading electronic devices. Our products are sourced from trusted manufacturers to ensure reliability, precision, and performance in every project.\r\n\r\nFind the perfect components to power your next innovation today!", Status=1 },
                    new CategoryModel() { Name="Computer Monitor", Slug="computer-monitor", Description="Explore our range of high-performance computer monitors, designed to meet the needs of both casual users and professionals. Whether you're looking for a monitor for gaming, graphic design, or everyday work, we offer a variety of sizes, resolutions, and features such as 4K, ultra-wide displays, and high refresh rates. Our monitors deliver sharp visuals, vibrant colors, and smooth performance for an immersive viewing experience.\r\n\r\nChoose the ideal monitor to enhance your productivity and entertainment today!", Status=1 },
                    new CategoryModel() { Name="Gamming Gear", Slug="gamming-gear", Description="Gear up for victory with our premium selection of gaming gear, including high-performance keyboards, mice, headsets, and controllers. Designed for gamers of all levels, our products offer precision, comfort, and durability to enhance your gameplay. Whether you're into competitive esports or casual gaming, you'll find the perfect accessories to elevate your experience and give you the edge you need.\r\n\r\nEquip yourself with the ultimate gaming gear and dominate every match!\r\n\r\n", Status=1 },
                    new CategoryModel() { Name="Accessories", Slug="accessories", Description="Discover a wide range of accessories to complement and enhance your devices. From chargers and cables to cases and adapters, we offer high-quality products that ensure convenience and protection for your gadgets. Whether you're looking to upgrade your setup or keep your devices safe on the go, our selection of accessories has everything you need to stay connected and productive.\r\n\r\nFind the perfect accessory to match your lifestyle and keep your tech running smoothly!", Status=1 },
                };
                _context.Categories.AddRange(categories);
            }
            if (!_context.Brands.Any())
            {
                List<BrandModel> brands = new List<BrandModel>()
                {
                    new BrandModel() { Name = "MSI", Slug = "msi", Description = "MSI is a world leader in AI PC, gaming, content creation, business & productivity and AIoT solutions. Bolstered by its cutting-edge R&D capabilities and customer-driven innovation, MSI has a wide-ranging global presence spanning over 120 countries. Its comprehensive lineup of laptops, graphics cards, monitors, motherboards, desktops, peripherals, servers, IPCs, robotic appliances, vehicle infotainment and telematics systems, and EV charger are globally acclaimed. Committed to advancing user experiences through the finest product quality, intuitive user interface and design aesthetics, MSI is a leading brand that shapes the future of technology.", Status = 1 },
                    new BrandModel() { Name = "ACER", Slug = "acer", Description = "Discover Acer’s innovative range of laptops, desktops, monitors, and accessories, designed to meet a variety of needs from everyday computing to high-performance gaming. Acer is renowned for its commitment to quality and technology, offering reliable devices that combine performance, style, and value. Whether you're seeking a powerful gaming machine, a versatile work laptop, or a sleek monitor, Acer provides cutting-edge solutions to enhance your computing experience.\r\n\r\nExplore Acer’s lineup to find the perfect technology that fits your lifestyle and boosts your productivity.", Status = 1 },
                    new BrandModel() { Name = "LENOVO", Slug = "lenovo", Description = "Explore Lenovo’s comprehensive range of laptops, desktops, tablets, and accessories designed to deliver superior performance and reliability. Lenovo is renowned for its innovative technology and commitment to quality, offering solutions that cater to a wide range of needs, from powerful business laptops to versatile 2-in-1 devices and high-performance gaming systems. With a focus on cutting-edge design and exceptional durability, Lenovo products are built to support your productivity, creativity, and entertainment.\r\n\r\nFind the perfect Lenovo device to meet your needs and experience excellence in technology.", Status = 1 },
                    new BrandModel() { Name = "HP", Slug = "hp", Description = "Explore HP’s diverse range of laptops, desktops, printers, and accessories designed to meet the demands of modern life. HP combines innovative technology with sleek design to deliver high-quality devices for home, office, and on-the-go use. From powerful business laptops and cutting-edge all-in-one PCs to reliable printers and versatile accessories, HP provides solutions that enhance productivity and streamline everyday tasks.\r\n\r\nFind the ideal HP product to elevate your computing experience with reliability, performance, and style.", Status = 1 },
                };
                _context.Brands.AddRange(brands);
            }
            if (!_context.Products.Any())
            {
                List<ProductModel> brands = new List<ProductModel>()
                {
                    new ProductModel() { Name="Laptop Acer Predator Helios 16", Description="Acer Predator Helios 16 PH16-71-72BV Gaming Laptop is equipped with a 13th generation Intel® Core™ i9 processor that provides fast processing speed with high clock speeds. Combined with built-in super-speed 32GB DDR5 Ram with the purpose of optimizing the user's usage process to always run smoothly even when opening multiple tasks at the same time.", BrandId=2, CategoryId=1, DateCreated=DateTime.Now, Price=51990000, Stock=12 },
                    new ProductModel() { Name="Laptop Acer Predator Helios 16", Description="Acer Predator Helios 16 PH16-71-72BV Gaming Laptop is equipped with a 13th generation Intel® Core™ i9 processor that provides fast processing speed with high clock speeds. Combined with built-in super-speed 32GB DDR5 Ram with the purpose of optimizing the user's usage process to always run smoothly even when opening multiple tasks at the same time.", BrandId=2, CategoryId=1, DateCreated=DateTime.Now, Price=51990000, Stock=12 },
                };
                _context.Products.AddRange(brands);
            }

            _context.SaveChanges();
        }
    }
}
