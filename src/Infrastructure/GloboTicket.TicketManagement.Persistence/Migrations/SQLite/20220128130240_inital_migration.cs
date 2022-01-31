﻿using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GloboTicket.TicketManagement.Persistence.Migrations.SQLITE
{
    [ExcludeFromCodeCoverage]
    public partial class inital_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "varchar(450)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    MessageContent = table.Column<string>(type: "TEXT", nullable: false),
                    Language = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    OrderTotal = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderPlaced = table.Column<DateTime>(type: "TEXT", nullable: false),
                    OrderPaid = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "varchar(450)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    Price = table.Column<int>(type: "INTEGER", nullable: false),
                    Artist = table.Column<string>(type: "varchar(50)", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "varchar(500)", nullable: false),
                    ImageUrl = table.Column<string>(type: "varchar(200)", nullable: false),
                    CategoryId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "varchar(450)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_Events_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[] { new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Musicals" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[] { new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Concerts" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[] { new Guid("bf3f3002-7e53-441e-8b76-f6280be284aa"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Plays" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[] { new Guid("fe98f549-e790-4e9f-aa16-18c2292a2ee9"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Conferences" });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "MessageId", "Code", "Language", "MessageContent", "Type" },
                values: new object[] { new Guid("253c75d5-32af-4dbf-ab63-1af449bde7bd"), "1", "en", "{PropertyName} is required.", "Error" });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "MessageId", "Code", "Language", "MessageContent", "Type" },
                values: new object[] { new Guid("ed0cc6b6-11f4-4512-a441-625941917502"), "2", "en", "{PropertyName} must not exceed {MaxLength} characters.", "Error" });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "MessageId", "Code", "Language", "MessageContent", "Type" },
                values: new object[] { new Guid("fafe649a-3e2a-4153-8fd8-9dcd0b87e6d8"), "3", "en", "An event with the same name and date already exists.", "Error" });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "OrderPaid", "OrderPlaced", "OrderTotal", "UserId" },
                values: new object[] { new Guid("3dcb3ea0-80b1-4781-b5c0-4d85c41e55a6"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, new DateTime(2022, 1, 28, 13, 2, 39, 868, DateTimeKind.Utc).AddTicks(6171), 245, new Guid("4ad901be-f447-46dd-bcf7-dbe401afa203") });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "OrderPaid", "OrderPlaced", "OrderTotal", "UserId" },
                values: new object[] { new Guid("771cca4b-066c-4ac7-b3df-4d12837fe7e0"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, new DateTime(2022, 1, 28, 13, 2, 39, 868, DateTimeKind.Utc).AddTicks(6147), 85, new Guid("d97a15fc-0d32-41c6-9ddf-62f0735c4c1c") });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "OrderPaid", "OrderPlaced", "OrderTotal", "UserId" },
                values: new object[] { new Guid("7e94bc5b-71a5-4c8c-bc3b-71bb7976237e"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, new DateTime(2022, 1, 28, 13, 2, 39, 868, DateTimeKind.Utc).AddTicks(6096), 400, new Guid("a441eb40-9636-4ee6-be49-a66c5ec1330b") });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "OrderPaid", "OrderPlaced", "OrderTotal", "UserId" },
                values: new object[] { new Guid("86d3a045-b42d-4854-8150-d6a374948b6e"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, new DateTime(2022, 1, 28, 13, 2, 39, 868, DateTimeKind.Utc).AddTicks(6122), 135, new Guid("ac3cfaf5-34fd-4e4d-bc04-ad1083ddc340") });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "OrderPaid", "OrderPlaced", "OrderTotal", "UserId" },
                values: new object[] { new Guid("ba0eb0ef-b69b-46fd-b8e2-41b4178ae7cb"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, new DateTime(2022, 1, 28, 13, 2, 39, 868, DateTimeKind.Utc).AddTicks(6237), 116, new Guid("7aeb2c01-fe8e-4b84-a5ba-330bdf950f5c") });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "OrderPaid", "OrderPlaced", "OrderTotal", "UserId" },
                values: new object[] { new Guid("e6a2679c-79a3-4ef1-a478-6f4c91b405b6"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, new DateTime(2022, 1, 28, 13, 2, 39, 868, DateTimeKind.Utc).AddTicks(6192), 142, new Guid("7aeb2c01-fe8e-4b84-a5ba-330bdf950f5c") });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "OrderPaid", "OrderPlaced", "OrderTotal", "UserId" },
                values: new object[] { new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, new DateTime(2022, 1, 28, 13, 2, 39, 868, DateTimeKind.Utc).AddTicks(6216), 40, new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923") });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "Artist", "CategoryId", "CreatedBy", "CreatedDate", "Date", "Description", "ImageUrl", "LastModifiedBy", "LastModifiedDate", "Name", "Price" },
                values: new object[] { new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"), "Many", new Guid("fe98f549-e790-4e9f-aa16-18c2292a2ee9"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 11, 28, 13, 2, 39, 868, DateTimeKind.Utc).AddTicks(6044), "The best tech conference in the world", "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/conf.jpg", null, null, "Techorama 2021", 400 });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "Artist", "CategoryId", "CreatedBy", "CreatedDate", "Date", "Description", "ImageUrl", "LastModifiedBy", "LastModifiedDate", "Name", "Price" },
                values: new object[] { new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"), "Michael Johnson", new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 28, 13, 2, 39, 868, DateTimeKind.Utc).AddTicks(5977), "Michael Johnson doesn't need an introduction. His 25 concert across the globe last year were seen by thousands. Can we add you to the list?", "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/michael.jpg", null, null, "The State of Affairs: Michael Live!", 85 });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "Artist", "CategoryId", "CreatedBy", "CreatedDate", "Date", "Description", "ImageUrl", "LastModifiedBy", "LastModifiedDate", "Name", "Price" },
                values: new object[] { new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"), "Manuel Santinonisi", new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 5, 28, 13, 2, 39, 868, DateTimeKind.Utc).AddTicks(6024), "Get on the hype of Spanish Guitar concerts with Manuel.", "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/guitar.jpg", null, null, "Spanish guitar hits with Manuel", 25 });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "Artist", "CategoryId", "CreatedBy", "CreatedDate", "Date", "Description", "ImageUrl", "LastModifiedBy", "LastModifiedDate", "Name", "Price" },
                values: new object[] { new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"), "Nick Sailor", new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 28, 13, 2, 39, 868, DateTimeKind.Utc).AddTicks(6071), "The critics are over the moon and so will you after you've watched this sing and dance extravaganza written by Nick Sailor, the man from 'My dad and sister'.", "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/musical.jpg", null, null, "To the Moon and Back", 135 });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "Artist", "CategoryId", "CreatedBy", "CreatedDate", "Date", "Description", "ImageUrl", "LastModifiedBy", "LastModifiedDate", "Name", "Price" },
                values: new object[] { new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"), "DJ 'The Mike'", new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 5, 28, 13, 2, 39, 868, DateTimeKind.Utc).AddTicks(6000), "DJs from all over the world will compete in this epic battle for eternal fame.", "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/dj.jpg", null, null, "Clash of the DJs", 85 });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "Artist", "CategoryId", "CreatedBy", "CreatedDate", "Date", "Description", "ImageUrl", "LastModifiedBy", "LastModifiedDate", "Name", "Price" },
                values: new object[] { new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"), "John Egbert", new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 28, 13, 2, 39, 868, DateTimeKind.Utc).AddTicks(5934), "Join John for his farwell tour across 15 continents. John really needs no introduction since he has already mesmerized the world with his banjo.", "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/banjo.jpg", null, null, "John Egbert Live", 65 });

            migrationBuilder.CreateIndex(
                name: "IX_Events_CategoryId",
                table: "Events",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
