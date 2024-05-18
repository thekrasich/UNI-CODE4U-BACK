using CashRegisterStore.DAL.Data.Entities;
using CashRegisterStore.DAL.Data.Enums;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CashRegisterStore.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddTestData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new string[]
                {
                    "Id",
                    "Name",
                    "Surname",
                    "Role",
                    "UserName",
                    "NormalizedUserName",
                    "Email",
                    "NormalizedEmail",
                    "EmailConfirmed",
                    "PasswordHash",
                    "SecurityStamp",
                    "ConcurrencyStamp",
                    "PhoneNumber",
                    "PhoneNumberConfirmed",
                    "TwoFactorEnabled",
                    "LockoutEnd",
                    "LockoutEnabled",
                    "AccessFailedCount",
                },
                values: new object[,]
                {
                    { 1, "Panas", "Ivaniuk", "A", "Panas_Ivaniuk", "PANAS_IVANIUK", "test@lnu.edu.ua", "TEST@LNU.EDU.UA", false, "AQAAAAIAAYagAAAAELwAjYoySL6zGKOV8mRCbkvYc5BDWs5NPIOGicSVpT2QkJh3txsS9S0ZzgeuS4s2sA==", "ZUWUXCJCEZFV6STTH4XDWGFAIGV6PNK4", "4e8fc298-d00e-4c4a-ba50-8844ba26ed80", "+380976543210", false, false, null, true, 0 },
                    { 2, "Anna", "Yarosh", "C", "Anna_Yarosh", "ANNA_YAROSH", "test@lnu.edu.ua", "TEST@LNU.EDU.UA", false, "AQAAAAIAAYagAAAAEMOQOgm6K7LOW3eoL9TpYWwpNrvOLJu4gBYSPbiJwqfGm3ivTvSt8SGOfJ7jXL/QhA==", "ROT3QU7HJ44TM2D2MDZVVEPPXHS7TJB3", "ad387583-0357-4669-bf8d-1c784828d7c4", "+380951234567", false, false, null, true , 0 }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new string[]
                {
                    "Id",
                    "Name"
                },
                values: new object[,]
                {
                    { (short)ProductCategory.POS_Equipment,  nameof(ProductCategory.POS_Equipment) },
                    { (short)ProductCategory.BarcodeScanner, nameof(ProductCategory.BarcodeScanner) },
                    { (short)ProductCategory.LabelPrinter,   nameof(ProductCategory.LabelPrinter) },
                    { (short)ProductCategory.Scales,         nameof(ProductCategory.Scales) },
                    { (short)ProductCategory.Software,       nameof(ProductCategory.Software) }
                });

            migrationBuilder.InsertData(
                table: "Subcategories",
                columns: new string[]
                {
                    "Id",
                    "CategoryId",
                    "Name"
                },
                values: new object[,]
                {
                    { 1, (short)ProductCategory.POS_Equipment,  "POS terminal" },
                    { 2, (short)ProductCategory.POS_Equipment,  "POS monitor" },

                    { 3, (short)ProductCategory.BarcodeScanner, "Handheld barcode scanner" },
                    { 4, (short)ProductCategory.BarcodeScanner, "Wireless scanner" },

                    { 5, (short)ProductCategory.LabelPrinter,   "Industrial label printer" },
                    { 6, (short)ProductCategory.LabelPrinter,   "Mobile label printer" },

                    { 7, (short)ProductCategory.Scales,         "Kitchen scales" },
                    { 8, (short)ProductCategory.Scales,         "Analytical scales" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new string[]
                {
                    "Id",
                    "SubcategoryId",
                    "Name",
                    "Description",
                    "Price",
                    "AvailableCount",
                },
                values: new object[,]
                {
                    { 1, 1, "LikePOS 15 Dual", "LikePOS 15 Dual — це універсальний POS-термінал з компактним дизайном і високою продуктивністю, призначений для різних галузей бізнесу, включаючи роздрібну торгівлю, гастрономічні закладів, готелі, кафе, кіоски самообслуговування та інші.", 25999, 10 },
                    { 2, 1, "QUADMini", "QUADMini — це компактний POS-термінал, який поєднує високу продуктивність і зручність використання. Завдяки своїм компактним розмірам, він ідеально підходить для місць з обмеженим простором і створює зручні умови для обслуговування клієнтів.", 18399, 17 },

                    { 3, 2, "ІКС PD 970-IT", "Нова модель POS монітора PD 970-IT поєднує елегантність і гнучкість із продуктивністю й енергоефективністю, що дає змогу захистити інвестиції. Технічно гнучка та продуктивна система має сучасний дизайн і здатна задовольнити будь-які запити. Чи то ритейл, готельний бізнес, ресторан або бутик, монітор PD 970-IT прекрасно підійде для будь-якого касового місця й інтер'єру.", 8416, 25 },
                    { 4, 2, "Geos SM1502C", "POS монітор Geos PRO SM1502C – це сучасний та надійний монітор для POS-систем. Завдяки високоякісному сенсорному екрану з діагоналлю 15 дюймів, взаємодія з системою стає максимально зручною та швидкою. Ідеально підходить для автоматизації торгових залів, касових місць, а також готельно-ресторанних комплексів. Компактний дизайн дозволяє економити простір на робочому місці, а потужний процесор забезпечує швидку обробку даних та ефективне управління продажами. Висока якість зображення та надійність роботи роблять Geos PRO SM1502C відмінним вибором для покращення ефективності вашого бізнесу.", 16158, 3 },

                    { 5, 3, "Newland HR1250", "Newland HR1250 - це потужні можливості сканування та високий комфорт за доступною ціною.", 1649, 6 },

                    { 6, 4, "Zebra DS2278", "Новий бездротовий сканер Zebra DS2278 виробництва всесвітньо відомої компанії Zebra Technologies представляє лінійку бюджетних, і водночас високонадійних сканерів штрих-коду з технологією імідж-сканування.", 9999, 1 },
                });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new string[]
                {
                    "Id",
                    "ProductId",
                    "Path"
                },
                values: new object[,]
                {
                    { 1, 1, "https://ideapos.com.ua/content/images/46/500x500l80mc0/43829107236080.webp" },

                    { 2, 2, "https://ideapos.com.ua/content/images/48/566x521l80mc0/67491251311758.webp" },
                    { 3, 2, "https://ideapos.com.ua/content/images/48/575x522l80mc0/19274085267910.webp" },

                    { 4, 3, "https://content1.rozetka.com.ua/goods/images/big/82679957.jpg" },

                    { 5, 4, "https://content1.rozetka.com.ua/goods/images/big/433564613.png" },

                    { 6, 5, "https://ideapos.com.ua/content/images/17/592x500l80mc0/57915912052808.webp" },

                    { 7, 6, "https://content2.rozetka.com.ua/goods/images/big/12869370.jpg" },
                    { 8, 6, "https://content.rozetka.com.ua/goods/images/big/12869380.png" },
                });

            migrationBuilder.InsertData(
                table: "Baskets",
                columns: new string[]
                {
                    "Id",
                    "UserId"
                },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "BasketProducts",
                columns: new string[]
                {
                    "BasketId",
                    "ProductId",
                    "Quantity"
                },
                values: new object[,]
                {
                    { 1, 6, 4 },
                    { 1, 3, 2 },

                    { 2, 1, 2 },
                    { 2, 2, 3 },
                    { 2, 4, 1 },
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new string[]
                {
                    "Id",
                    "UserId",
                    "CreationDateTime",
                    "Status"
                },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2024, 05, 10, 14, 50, 03, DateTimeKind.Utc), "D" }
                });

            migrationBuilder.InsertData(
                table: "OrderProducts",
                columns: new string[]
                {
                    "OrderId",
                    "ProductId",
                    "Quantity"
                },
                values: new object[,]
                {
                    { 1, 6, 1 },
                    { 1, 3, 2 },
                    { 1, 1, 2 },
                    { 1, 2, 3 },
                    { 1, 4, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                DELETE FROM ""Categories""
                    WHERE ""Id"" > 0 AND ""Id"" < 6;

                DELETE FROM ""Users""
                    WHERE ""Id"" > 0 AND ""Id"" < 3;");
        }
    }
}
