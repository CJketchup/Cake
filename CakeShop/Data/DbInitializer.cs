using CakeShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;


namespace CakeShop.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            // 確保資料庫已建立（不會重複建立）
            context.Database.EnsureCreated();

            //  如果已經有蛋糕資料，就不重複新增
            /*if (context.Cakes.Any())
            {
                return; // DB has been seeded
            }
            */
            //  強制清除舊資料
            if (context.Cakes.Any())
            {
                context.Cakes.RemoveRange(context.Cakes);
                context.SaveChanges();
            }



            //  建立預設蛋糕資料
            var cakes = new Cake[]
            {
                new Cake {
                    Name = "經典巧克力蛋糕",
                    Description = "濃郁滑順的黑巧克力甘納許",
                    Price = 550.00m,
                    ImageUrl = "/images/cake6.jpg"
                },
                new Cake {
                    Name = "水果千層",
                    Description = "新鮮水果搭配千層蛋糕",
                    Price = 620.00m,
                    ImageUrl = "/images/cake1.jpg"
                },
                new Cake {
                    Name = "檸檬起司蛋糕",
                    Description = "清爽檸檬與底部的重乳酪搭配",
                    Price = 580.00m,
                    ImageUrl = "/images/cake4.jpg"
                },
                new Cake {
                    Name = "黑芝麻蛋糕",
                    Description = "黑芝麻跟奶油的完美結合",
                    Price = 650.00m,
                    ImageUrl = "/images/cake5.jpg"
                },
                new Cake {
                    Name = "提拉米蘇",
                    Description = "義大利經典咖啡酒香甜點",
                    Price = 500.00m,
                    ImageUrl = "/images/cake3.jpg"
                }
            };

            // 新增資料進資料庫並儲存
            foreach (Cake c in cakes)
            {
                context.Cakes.Add(c);
            }
                        
            context.SaveChanges();
        }
    }
}
