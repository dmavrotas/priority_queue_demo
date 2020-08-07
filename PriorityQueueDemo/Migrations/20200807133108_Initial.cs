using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PriorityQueueDemo.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "queue_type",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    duration = table.Column<int>(nullable: true),
                    delay = table.Column<int>(nullable: true),
                    created = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_queue_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "priority_queue",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    order_id = table.Column<int>(nullable: false),
                    user_id = table.Column<int>(nullable: true),
                    entry_time = table.Column<DateTime>(nullable: true),
                    pick_time = table.Column<DateTime>(nullable: true),
                    end_time = table.Column<DateTime>(nullable: true),
                    queue_type_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_priority_queue", x => x.id);
                    table.ForeignKey(
                        name: "fk_priority_queue_queue_type_queue_type_id",
                        column: x => x.queue_type_id,
                        principalTable: "queue_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_priority_queue_queue_type_id",
                table: "priority_queue",
                column: "queue_type_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "priority_queue");

            migrationBuilder.DropTable(
                name: "queue_type");
        }
    }
}
