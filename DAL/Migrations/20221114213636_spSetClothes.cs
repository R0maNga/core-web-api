using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class spSetClothes : Migration
    {




        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE[dbo].[Procedure]

            AS
                Select k.CupboardId, k.ClothesId, c.DefaultQuantity, k.Id
                From CupboardEntities as t
            Left Join CupboardClothesEntities as k
            ON t.Id = k.CupboardId
            Left Join ClothesEntities as c
            on k.ClothesId = c.Id
            WHERE k.Quantity = 0";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }



    }
}
