﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Algebra_Seminar_Drdic.Data.Migrations
{
    public partial class InsertBasicAppData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Title" },
                values: new object[] { 1, "Chairs" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Title" },
                values: new object[] { 2, "Tables" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Title" },
                values: new object[] { 3, "Sofas" });

            /*Chairs*/

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Title", "Description", "Quantity", "Price", "ImageName" },
                values: new object[] { 1, "Daniil Silantev chair", "White soft chair", 9, 829.99, "daniil-silantev-chair.jpg" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Title", "Description", "Quantity", "Price", "ImageName" },
                values: new object[] { 2, "Jean-Phillipe del Berghe chair", "Plastic modern chairs aveilable in 5 colours", 17, 419.99, "jean-philippe-delberghe-chair.jpg" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Title", "Description", "Quantity", "Price", "ImageName" },
                values: new object[] { 3, "Laura Davidson chair", "Modern industial style chair", 4, 505.99, "laura-davidson-chair.jpg" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Title", "Description", "Quantity", "Price", "ImageName" },
                values: new object[] { 4, "Sam Moghadam chair", "Brown jeans style chair", 4, 779.99, "sam-moghadam-chair.jpg" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Title", "Description", "Quantity", "Price", "ImageName" },
                values: new object[] { 5, "Suchit Poojari chair", "Black hipster style chair", 11, 369.99, "suchit-poojari-chair.jpg" });

            /*Tables*/

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Title", "Description", "Quantity", "Price", "ImageName" },
                values: new object[] { 6, "Annie Spratt table", "Wooden table for eight", 4, 1899.99, "annie-spratt-table.jpg" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Title", "Description", "Quantity", "Price", "ImageName" },
                values: new object[] { 7, "Charles de Luvio table", "Round wooden table for coffee", 7, 869.99, "charles-deluvio-table.jpg" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Title", "Description", "Quantity", "Price", "ImageName" },
                values: new object[] { 8, "Laura Lauch table", "Small wooden living room", 8, 359.99, "laura-lauch-table.jpg" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Title", "Description", "Quantity", "Price", "ImageName" },
                values: new object[] { 9, "Skyler Undav table", "Golder marble round table", 13, 669.99, "skyler-undav-table.jpg" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Title", "Description", "Quantity", "Price", "ImageName" },
                values: new object[] { 10, "Tang Wu table", "Wooden table for ten", 11, 369.99, "tang-wu-table.jpg" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Title", "Description", "Quantity", "Price", "ImageName" },
                values: new object[] { 11, "Veronika Fittard table", "Small epoxy style table", 2, 1119.99, "veronika-fittard-table.jpg" });

            /*Sofas*/

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Title", "Description", "Quantity", "Price", "ImageName" },
                values: new object[] { 12, "Arann Prime sofa", "Brown fine leather sofa", 4, 3219.99, "aranprime-sofa.jpg" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Title", "Description", "Quantity", "Price", "ImageName" },
                values: new object[] { 13, "Nathan Fertig sofa", "Grey city style sofa", 3, 1889.99, "nathan-fertig-sofa.jpg" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Title", "Description", "Quantity", "Price", "ImageName" },
                values: new object[] { 14, "Paul Weaver sofa", "Light brown sofa for 3", 4, 4199.99, "paul-weaver-sofa.jpg" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Title", "Description", "Quantity", "Price", "ImageName" },
                values: new object[] { 15, "Phillip Goldsberry sofa", "Turquoise hipster style sofa", 11, 1119.99, "phillip-goldsberry-sofa.jpg" });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 1, 3 },
                    { 4, 1, 4 },
                    { 5, 1, 5 },
                    { 6, 2, 6 },
                    { 7, 2, 7 },
                    { 8, 2, 8 },
                    { 9, 2, 9 },
                    { 10, 2, 10 },
                    { 11, 2, 11 },
                    { 12, 3, 12 },
                    { 13, 3, 13 },
                    { 14, 3, 14 },
                    { 15, 3, 15 }
                });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
               name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "ProductCategories");
        }
    }
}
