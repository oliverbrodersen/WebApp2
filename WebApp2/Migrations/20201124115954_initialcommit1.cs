using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp2.Migrations
{
    public partial class initialcommit1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Families",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StreetName = table.Column<string>(nullable: false),
                    HouseNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Families", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Interest",
                columns: table => new
                {
                    Type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interest", x => x.Type);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(nullable: true),
                    Domain = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    BirthYear = table.Column<int>(nullable: false),
                    Role = table.Column<string>(nullable: true),
                    SecurityLevel = table.Column<int>(nullable: false),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Adults",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FamilyId = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    HairColor = table.Column<string>(nullable: true),
                    EyeColor = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Weight = table.Column<float>(nullable: false),
                    Height = table.Column<int>(nullable: false),
                    Sex = table.Column<string>(nullable: true),
                    JobTitle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adults_Families_FamilyId",
                        column: x => x.FamilyId,
                        principalTable: "Families",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Children",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FamilyId = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    HairColor = table.Column<string>(nullable: true),
                    EyeColor = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Weight = table.Column<float>(nullable: false),
                    Height = table.Column<int>(nullable: false),
                    Sex = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Children", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Children_Families_FamilyId",
                        column: x => x.FamilyId,
                        principalTable: "Families",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    RealId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FamilyId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    Species = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Age = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.RealId);
                    table.ForeignKey(
                        name: "FK_Pets_Families_FamilyId",
                        column: x => x.FamilyId,
                        principalTable: "Families",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChildInterest",
                columns: table => new
                {
                    InterestId = table.Column<string>(nullable: false),
                    ChildId = table.Column<int>(nullable: false),
                    InterestType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildInterest", x => x.InterestId);
                    table.ForeignKey(
                        name: "FK_ChildInterest_Children_ChildId",
                        column: x => x.ChildId,
                        principalTable: "Children",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChildInterest_Interest_InterestType",
                        column: x => x.InterestType,
                        principalTable: "Interest",
                        principalColumn: "Type",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChildInterestTable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ChildId = table.Column<int>(nullable: true),
                    InterestId = table.Column<string>(nullable: true),
                    ChildInterestInterestId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildInterestTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChildInterestTable_Children_ChildId",
                        column: x => x.ChildId,
                        principalTable: "Children",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChildInterestTable_ChildInterest_ChildInterestInterestId",
                        column: x => x.ChildInterestInterestId,
                        principalTable: "ChildInterest",
                        principalColumn: "InterestId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adults_FamilyId",
                table: "Adults",
                column: "FamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_ChildInterest_ChildId",
                table: "ChildInterest",
                column: "ChildId");

            migrationBuilder.CreateIndex(
                name: "IX_ChildInterest_InterestType",
                table: "ChildInterest",
                column: "InterestType");

            migrationBuilder.CreateIndex(
                name: "IX_ChildInterestTable_ChildId",
                table: "ChildInterestTable",
                column: "ChildId");

            migrationBuilder.CreateIndex(
                name: "IX_ChildInterestTable_ChildInterestInterestId",
                table: "ChildInterestTable",
                column: "ChildInterestInterestId");

            migrationBuilder.CreateIndex(
                name: "IX_Children_FamilyId",
                table: "Children",
                column: "FamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_FamilyId",
                table: "Pets",
                column: "FamilyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adults");

            migrationBuilder.DropTable(
                name: "ChildInterestTable");

            migrationBuilder.DropTable(
                name: "Pets");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ChildInterest");

            migrationBuilder.DropTable(
                name: "Children");

            migrationBuilder.DropTable(
                name: "Interest");

            migrationBuilder.DropTable(
                name: "Families");
        }
    }
}
