using CatalogManagement.Domain.Entities;
using CatalogManagement.Domain.Repositories;
using CatalogManagement.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogManagement.Infrastructure.Seeders
{
    internal class ProductSeeder : IProductSeeder
    {
        private readonly CatalogManagementContext _context;
        private readonly DbSet<Product> _dbSet;

        public ProductSeeder(CatalogManagementContext context)
        {
            _context = context;
            _dbSet = _context.Set<Product>();
        }

        //: IProductSeeder

        public async Task ProductSeed()
        {
            if (await _context.Database.CanConnectAsync())
            {
                if (!_dbSet.Any())
                {
                    _dbSet.AddRange(GetProducts());
                    await _context.SaveChangesAsync();
                }
            }
        }

        private IEnumerable<Product> GetProducts()
        {
            List<Product> products = [
                // ELECTRONIC CATEGORY
                new()
                {
                    Name = "Laptop",
                    Description = "",
                    SKU = "SHRT-NIKE-BLK-L",
                    Price = 60,
                    Quantity = 1,
                    CategoryId = 1,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now

                },
                new()
                {
                    Name = "Monitor",
                    Description = "A display screen that acts as the visual output device for a computer.",
                    SKU = "SHRT-CVBT-BLK-L",
                    Price = 60,
                    Quantity = 2,
                    CategoryId = 1,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now

                },
                new()
                {
                    Name = "Desktop Computer",
                    Description = "A stationary computer system used for intensive work, gaming, or general home use.",
                    SKU = "EWTY-GFGF-BLK-L",
                    Price = 60,
                    Quantity = 2,
                    CategoryId = 3,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now

                },
                new()
                {
                    Name = "Digital Camera",
                    Description = " A device that records images and videos digitally instead of on film. ",
                    SKU = "WERT-NIKE-BLK-L",
                    Price = 60,
                    Quantity = 2,
                    CategoryId = 5,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now

                },
                new()
                {
                    Name = "Portable Bluetooth Speaker",
                    Description = "A wireless, portable speaker that pairs with mobile devices to play music.",
                    SKU = "SHRT-XDDD-BLK-L",
                    Price = 60,
                    Quantity = 2,
                    CategoryId = 2,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now

                },
                new()
                {
                    Name = "TV (Television)",
                    Description = "A device designed to receive and display broadcast or streaming video content.",
                    SKU = "VCVC-XDDD-BLK-L",
                    Price = 60,
                    Quantity = 2,
                    CategoryId = 2,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now

                },
                new()
                {
                    Name = "Wireless Earbuds",
                    Description = "Portable, cordless earphones used for listening to audio from phones, computers, or music players.",
                    SKU = "SHRT-NIKE-BLK-L",
                    Price = 60,
                    Quantity = 2,
                    CategoryId = 1,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now

                },
                new()
                {
                    Name = "E-Reader",
                    Description = "A specialized tablet-like device optimized for reading digital books with electronic ink technology",
                    SKU = "SHRT-WEWW-BLK-L",
                    Price = 60,
                    Quantity = 2,
                    CategoryId = 1,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now

                },
                new()
                {
                    Name = "Smartwatch",
                    Description = "A wearable computer designed to be worn on the wrist",
                    SKU = "SHRT-VCVC-BLK-L",
                    Price = 60,
                    Quantity = 2,
                    CategoryId = 1,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now

                },
                new()
                {
                    Name = "Tablet",
                    Description = "A touchscreen device larger than a phone but more portable than a laptop",
                    SKU = "SHRT-FDFD-BLK-L",
                    Price = 60,
                    Quantity = 2,
                    CategoryId = 9,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now

                },
                new()
                {
                    Name = "Smartphone",
                    Description = "A mobile phone that combines computing capabilities",
                    SKU = "SHRT-NtyE-BLK-L",
                    Price = 6000,
                    Quantity = 2,
                    CategoryId = 9,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now

                },
                // FURNITURE CATEGORY
                new()
                {
                    Name = "Armchair",
                    Description = "a chair that has arm supports on each side. ",
                    SKU = "SHRT-VBVBV-BLK-L",
                    Price = 60,
                    Quantity = 2,
                    CategoryId = 9,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now

                },
                new()
                {
                    Name = "Bi-cast leather",
                    Description = " Split leather with a layer of polyurethane. \r\n",
                    SKU = "SHRT-CVBT-BLK-CV",
                    Price = 60,
                    Quantity = 2,
                    CategoryId = 1,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now

                },
                new()
                {
                    Name = "Card table",
                    Description = "Table used to play poker or other card games. Some have multi functionality and\r\ncould also be used as a regular table.",
                    SKU = "EWTY-GFGF-BLK-XC",
                    Price = 60,
                    Quantity = 2,
                    CategoryId = 4,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now

                },
                new()
                {
                    Name = "Chaise lounge ",
                    Description = "A chair with a long bottom cushion to put legs up and relax. Kind of a\r\ncombination between a chair and a sofa.",
                    SKU = "WERT-VC-BLK-LCV",
                    Price = 60,
                    Quantity = 2,
                    CategoryId = 9,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now

                },
                new()
                {
                    Name = "Portable Bluetooth Speaker",
                    Description = "A wireless, portable speaker that pairs with mobile devices to play music.",
                    SKU = "SHRT-XDDD-BLK-L",
                    Price = 60,
                    Quantity = 2,
                    CategoryId = 1,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now

                },
                new()
                {
                    Name = "Club chair",
                    Description = "a chair with a low back. Usually made from leather.",
                    SKU = "VCVC-ERE-BLK-VV",
                    Price = 60,
                    Quantity = 2,
                    CategoryId = 1,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now

                },
                new()
                {
                    Name = "Cocktail table ",
                    Description = "a short leg table that is normally placed in from of the sofa in the living room",
                    SKU = "SHRT-RTR-BLK-L",
                    Price = 60,
                    Quantity = 2,
                    CategoryId = 1,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now

                },
                new()
                {
                    Name = "Drawer glide",
                    Description = "a type of track that helps a furniture drawer move in and out of the piece. ",
                    SKU = "DS-WEWW-BLK-L",
                    Price = 60,
                    Quantity = 2,
                    CategoryId = 3,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now

                },
                new()
                {
                    Name = "Entertainment wall",
                    Description = " a large unit used for TV and other media components that also has\r\ncompartments for storage. ",
                    SKU = "SHRT-VCVC-FDFD-L",
                    Price = 60,
                    Quantity = 2,
                    CategoryId = 8,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now

                },
                new()
                {
                    Name = "English dovetail",
                    Description = "Type of drawer construction which usually signifies a better construction.\r\nThis results in stronger and more spacious drawers.",
                    SKU = "ERE-FDFD-BLK-L",
                    Price = 60,
                    Quantity = 2,
                    CategoryId = 8,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now

                },
                new()
                {
                    Name = "Headboard",
                    Description = "Panel that is attached to the head-end part of the bed frame or rails.",
                    SKU = "SHRT-NtyE-BLK-L",
                    Price = 6000,
                    Quantity = 2,
                    CategoryId = 9,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now

                },
            ];

            return products;
        }
    }
}
