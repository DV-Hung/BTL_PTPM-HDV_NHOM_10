using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GOATBOOKING.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    service_id = table.Column<long>(type: "bigint", nullable: false),
                    service_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    price = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    created_at = table.Column<long>(type: "bigint", nullable: false),
                    updated_at = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Services", x => x.service_id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    user_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    password = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    phone_number = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    gender = table.Column<int>(type: "int", nullable: false),
                    full_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    avatar = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    created_at = table.Column<long>(type: "bigint", nullable: false),
                    updated_at = table.Column<long>(type: "bigint", nullable: false),
                    role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Users", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    booking_id = table.Column<long>(type: "bigint", nullable: false),
                    check_in_date = table.Column<long>(type: "bigint", nullable: false),
                    check_out_date = table.Column<long>(type: "bigint", nullable: false),
                    deposit_price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    total_price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<long>(type: "bigint", nullable: false),
                    updated_at = table.Column<long>(type: "bigint", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Bookings", x => x.booking_id);
                    table.ForeignKey(
                        name: "fk_Users",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Homestays",
                columns: table => new
                {
                    homestay_id = table.Column<long>(type: "bigint", nullable: false),
                    name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    ward = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    district = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    province = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_at = table.Column<long>(type: "bigint", nullable: false),
                    updated_at = table.Column<long>(type: "bigint", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Homestays", x => x.homestay_id);
                    table.ForeignKey(
                        name: "fk_Users_Homestays",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    photo_id = table.Column<long>(type: "bigint", nullable: false),
                    name_photo = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    created_at = table.Column<long>(type: "bigint", nullable: false),
                    updated_at = table.Column<long>(type: "bigint", nullable: false),
                    homestay_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Photos", x => x.photo_id);
                    table.ForeignKey(
                        name: "fk_Photos_Homestays",
                        column: x => x.homestay_id,
                        principalTable: "Homestays",
                        principalColumn: "homestay_id");
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    review_id = table.Column<long>(type: "bigint", nullable: false),
                    rate = table.Column<int>(type: "int", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<long>(type: "bigint", nullable: false),
                    updated_at = table.Column<long>(type: "bigint", nullable: false),
                    homestay_id = table.Column<long>(type: "bigint", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    HomestayId1 = table.Column<long>(type: "bigint", nullable: true),
                    UserId1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Reviews", x => x.review_id);
                    table.ForeignKey(
                        name: "FK_Reviews_Homestays_HomestayId1",
                        column: x => x.HomestayId1,
                        principalTable: "Homestays",
                        principalColumn: "homestay_id");
                    table.ForeignKey(
                        name: "FK_Reviews_Users_UserId1",
                        column: x => x.UserId1,
                        principalTable: "Users",
                        principalColumn: "user_id");
                    table.ForeignKey(
                        name: "fk_Reviews_Homestays",
                        column: x => x.homestay_id,
                        principalTable: "Homestays",
                        principalColumn: "homestay_id");
                    table.ForeignKey(
                        name: "fk_Reviews_Users",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    room_id = table.Column<long>(type: "bigint", nullable: false),
                    room_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    room_type = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<long>(type: "bigint", nullable: false),
                    updated_at = table.Column<long>(type: "bigint", nullable: false),
                    homestay_id = table.Column<long>(type: "bigint", nullable: false),
                    booking_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Rooms", x => x.room_id);
                    table.ForeignKey(
                        name: "fk_Rooms_Bookings",
                        column: x => x.booking_id,
                        principalTable: "Bookings",
                        principalColumn: "booking_id");
                    table.ForeignKey(
                        name: "fk_Rooms_Homestays",
                        column: x => x.homestay_id,
                        principalTable: "Homestays",
                        principalColumn: "homestay_id");
                });

            migrationBuilder.CreateTable(
                name: "Services_advantage",
                columns: table => new
                {
                    homestay_id = table.Column<long>(type: "bigint", nullable: false),
                    service_id = table.Column<long>(type: "bigint", nullable: false),
                    description = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Services_advantage", x => new { x.homestay_id, x.service_id });
                    table.ForeignKey(
                        name: "fk_Services_advantage_Homestays",
                        column: x => x.homestay_id,
                        principalTable: "Homestays",
                        principalColumn: "homestay_id");
                    table.ForeignKey(
                        name: "fk_Services_advantage_Services",
                        column: x => x.service_id,
                        principalTable: "Services",
                        principalColumn: "service_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_user_id",
                table: "Bookings",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Homestays_user_id",
                table: "Homestays",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_homestay_id",
                table: "Photos",
                column: "homestay_id");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_homestay_id",
                table: "Reviews",
                column: "homestay_id");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_HomestayId1",
                table: "Reviews",
                column: "HomestayId1");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_user_id",
                table: "Reviews",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId1",
                table: "Reviews",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_booking_id",
                table: "Rooms",
                column: "booking_id");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_homestay_id",
                table: "Rooms",
                column: "homestay_id");

            migrationBuilder.CreateIndex(
                name: "IX_Services_advantage_service_id",
                table: "Services_advantage",
                column: "service_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Services_advantage");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Homestays");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
