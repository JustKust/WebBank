using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bank.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    CurID = table.Column<int>(type: "INT", nullable: false),
                    Name = table.Column<int>(type: "INT", nullable: false),
                    ExchangeRate = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.CurID);
                });

            migrationBuilder.CreateTable(
                name: "positions",
                columns: table => new
                {
                    PosID = table.Column<int>(type: "INT", nullable: false),
                    PosName = table.Column<string>(type: "VARCHAR(60)", nullable: false),
                    Salary = table.Column<int>(type: "INT", nullable: false),
                    Responsibilities = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    Requirements = table.Column<string>(type: "VARCHAR(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_positions", x => x.PosID);
                });

            migrationBuilder.CreateTable(
                name: "Deposits",
                columns: table => new
                {
                    DepID = table.Column<int>(type: "INT", nullable: false),
                    DepName = table.Column<string>(type: "VARCHAR(60)", nullable: false),
                    MinDepTern = table.Column<int>(type: "INT", nullable: false),
                    MinDepAmount = table.Column<int>(type: "INT", nullable: false),
                    AddCond = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    InRate = table.Column<int>(type: "INT", nullable: false),
                    CurID = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deposits", x => x.DepID);
                    table.ForeignKey(
                        name: "FK_Deposits_Currency_CurID",
                        column: x => x.CurID,
                        principalTable: "Currency",
                        principalColumn: "CurID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmID = table.Column<int>(type: "INT", nullable: false),
                    Full_Name = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Adress = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Telephone = table.Column<string>(type: "VARCHAR(11)", nullable: false),
                    Age = table.Column<int>(type: "INT", nullable: false),
                    Gender = table.Column<string>(type: "CHAR(1)", nullable: false),
                    PosID = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmID);
                    table.ForeignKey(
                        name: "FK_Employee_positions_PosID",
                        column: x => x.PosID,
                        principalTable: "positions",
                        principalColumn: "PosID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Depositors",
                columns: table => new
                {
                    PassData = table.Column<string>(type: "VARCHAR(20)", nullable: false),
                    FullName = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Adress = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    PhoneNum = table.Column<string>(type: "VARCHAR(11)", nullable: false),
                    DeposDate = table.Column<DateTime>(type: "DATE", nullable: false),
                    RefundDate = table.Column<DateTime>(type: "DATE", nullable: false),
                    SummAm = table.Column<int>(type: "INT", nullable: false),
                    SummRef = table.Column<int>(type: "INT", nullable: false),
                    DepRafMark = table.Column<int>(type: "INT", nullable: false),
                    EmID = table.Column<int>(type: "INT", nullable: false),
                    DepID = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Depositors", x => x.PassData);
                    table.ForeignKey(
                        name: "FK_Depositors_Deposits_DepID",
                        column: x => x.DepID,
                        principalTable: "Deposits",
                        principalColumn: "DepID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Depositors_Employee_EmID",
                        column: x => x.EmID,
                        principalTable: "Employee",
                        principalColumn: "EmID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Depositors_DepID",
                table: "Depositors",
                column: "DepID");

            migrationBuilder.CreateIndex(
                name: "IX_Depositors_EmID",
                table: "Depositors",
                column: "EmID");

            migrationBuilder.CreateIndex(
                name: "IX_Deposits_CurID",
                table: "Deposits",
                column: "CurID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_PosID",
                table: "Employee",
                column: "PosID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Depositors");

            migrationBuilder.DropTable(
                name: "Deposits");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.DropTable(
                name: "positions");
        }
    }
}
