using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightScheduler.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    RouteId = table.Column<int>(type: "int", nullable: false),
                    OriginCityId = table.Column<int>(type: "int", nullable: false),
                    DestinationCityId = table.Column<int>(type: "int", nullable: false),
                    DepartureDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.RouteId);
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    SubscriptionId = table.Column<int>(type: "int", nullable: false),
                    AgencyId = table.Column<short>(type: "smallint", nullable: false),
                    OriginCityId = table.Column<int>(type: "int", nullable: false),
                    DestinationCityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.SubscriptionId);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    FlightId = table.Column<int>(type: "int", nullable: false),
                    RouteId = table.Column<int>(type: "int", nullable: false),
                    DepartureTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArrivalTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AirlineId = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.FlightId);
                    table.ForeignKey(
                        name: "FK_Flights_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "RouteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "SubscriptionId", "AgencyId", "DestinationCityId", "OriginCityId" },
                values: new object[,]
                {
                    { 1, (short)1, 925, 4206 },
                    { 2, (short)1, 1046, 4206 },
                    { 3, (short)1, 1118, 4206 },
                    { 4, (short)1, 1192, 4206 },
                    { 5, (short)1, 1294, 4206 },
                    { 6, (short)1, 1485, 4206 },
                    { 7, (short)1, 4206, 925 },
                    { 8, (short)1, 217, 925 },
                    { 9, (short)1, 1587, 925 },
                    { 10, (short)1, 5330, 925 },
                    { 11, (short)1, 3398, 925 },
                    { 12, (short)1, 824, 925 },
                    { 13, (short)1, 152, 925 },
                    { 14, (short)1, 1294, 5086 },
                    { 15, (short)1, 925, 217 },
                    { 16, (short)1, 1046, 217 },
                    { 17, (short)1, 1118, 217 },
                    { 18, (short)1, 1192, 217 },
                    { 19, (short)1, 1046, 3596 },
                    { 20, (short)1, 1294, 3596 },
                    { 21, (short)1, 3398, 1003 },
                    { 22, (short)1, 824, 1005 },
                    { 23, (short)1, 3398, 1009 },
                    { 24, (short)1, 4206, 1046 },
                    { 25, (short)1, 217, 1046 },
                    { 26, (short)1, 3596, 1046 },
                    { 27, (short)1, 1587, 1046 },
                    { 28, (short)1, 3863, 1046 },
                    { 29, (short)1, 3398, 1046 },
                    { 30, (short)1, 824, 1046 },
                    { 31, (short)1, 4108, 1046 },
                    { 32, (short)1, 152, 1046 },
                    { 33, (short)1, 4206, 1118 },
                    { 34, (short)1, 217, 1118 },
                    { 35, (short)1, 1587, 1118 },
                    { 36, (short)1, 3863, 1118 },
                    { 37, (short)1, 3398, 1118 },
                    { 38, (short)1, 3398, 1124 },
                    { 39, (short)1, 4206, 1192 },
                    { 40, (short)1, 217, 1192 },
                    { 41, (short)1, 5330, 1192 },
                    { 42, (short)1, 3398, 1192 }
                });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "SubscriptionId", "AgencyId", "DestinationCityId", "OriginCityId" },
                values: new object[,]
                {
                    { 43, (short)1, 824, 1192 },
                    { 44, (short)1, 925, 1587 },
                    { 45, (short)1, 1118, 1587 },
                    { 46, (short)1, 1192, 1587 },
                    { 47, (short)1, 925, 5330 },
                    { 48, (short)1, 1009, 5330 },
                    { 49, (short)1, 1192, 5330 },
                    { 50, (short)1, 1118, 3863 },
                    { 51, (short)1, 1294, 3863 },
                    { 52, (short)1, 3398, 1253 },
                    { 53, (short)1, 4206, 1294 },
                    { 54, (short)1, 5086, 1294 },
                    { 55, (short)1, 3596, 1294 },
                    { 56, (short)1, 1587, 1294 },
                    { 57, (short)1, 3863, 1294 },
                    { 58, (short)1, 3398, 1294 },
                    { 59, (short)1, 824, 1294 },
                    { 60, (short)1, 4108, 1294 },
                    { 61, (short)1, 152, 1294 },
                    { 62, (short)1, 152, 1335 },
                    { 63, (short)1, 925, 3398 },
                    { 64, (short)1, 1009, 3398 },
                    { 65, (short)1, 1046, 3398 },
                    { 66, (short)1, 1118, 3398 },
                    { 67, (short)1, 1192, 3398 },
                    { 68, (short)1, 1253, 3398 },
                    { 69, (short)1, 1294, 3398 },
                    { 70, (short)1, 925, 824 },
                    { 71, (short)1, 1046, 824 },
                    { 72, (short)1, 1294, 824 },
                    { 73, (short)1, 3398, 1485 },
                    { 74, (short)1, 4108, 1485 },
                    { 75, (short)1, 1294, 4108 },
                    { 76, (short)1, 1294, 152 },
                    { 77, (short)1, 1294, 3594 },
                    { 78, (short)1, 1118, 925 },
                    { 79, (short)1, 1294, 925 },
                    { 80, (short)1, 1192, 925 },
                    { 81, (short)1, 1005, 925 },
                    { 82, (short)1, 1294, 1046 },
                    { 83, (short)1, 1485, 1046 },
                    { 84, (short)1, 1177, 1046 }
                });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "SubscriptionId", "AgencyId", "DestinationCityId", "OriginCityId" },
                values: new object[,]
                {
                    { 85, (short)1, 842, 1046 },
                    { 86, (short)1, 1046, 1192 },
                    { 87, (short)1, 1118, 1192 },
                    { 88, (short)1, 1051, 1192 },
                    { 89, (short)1, 44, 152 },
                    { 90, (short)1, 117, 152 },
                    { 91, (short)1, 68, 87 },
                    { 92, (short)1, 785, 1294 },
                    { 93, (short)1, 3596, 152 },
                    { 94, (short)1, 824, 152 },
                    { 95, (short)1, 3594, 152 },
                    { 96, (short)1, 4206, 3398 },
                    { 97, (short)1, 217, 3398 },
                    { 98, (short)1, 5330, 3398 },
                    { 99, (short)1, 213, 3398 },
                    { 100, (short)1, 1192, 3457 },
                    { 101, (short)1, 4651, 925 },
                    { 102, (short)1, 3353, 3398 },
                    { 103, (short)1, 3263, 3398 },
                    { 104, (short)1, 3464, 3398 },
                    { 105, (short)1, 5330, 842 },
                    { 106, (short)1, 3398, 842 },
                    { 107, (short)1, 1177, 4206 },
                    { 108, (short)1, 4163, 925 },
                    { 109, (short)1, 1046, 5086 },
                    { 110, (short)1, 4206, 963 },
                    { 111, (short)1, 217, 963 },
                    { 112, (short)1, 1587, 963 },
                    { 113, (short)1, 3398, 963 },
                    { 114, (short)1, 1003, 217 },
                    { 115, (short)1, 1294, 217 },
                    { 116, (short)1, 4206, 1003 },
                    { 117, (short)1, 217, 1003 },
                    { 118, (short)1, 3863, 1003 },
                    { 119, (short)1, 152, 1003 },
                    { 120, (short)1, 217, 1009 },
                    { 121, (short)1, 5330, 1009 },
                    { 122, (short)1, 1815, 1046 },
                    { 123, (short)1, 5086, 1046 },
                    { 124, (short)1, 3353, 1046 },
                    { 125, (short)1, 4020, 1046 },
                    { 126, (short)1, 3577, 1046 }
                });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "SubscriptionId", "AgencyId", "DestinationCityId", "OriginCityId" },
                values: new object[,]
                {
                    { 127, (short)1, 3594, 1046 },
                    { 128, (short)1, 1580, 1118 },
                    { 129, (short)1, 217, 1124 },
                    { 130, (short)1, 1587, 1124 },
                    { 131, (short)1, 5330, 1124 },
                    { 132, (short)1, 4206, 1177 },
                    { 133, (short)1, 3863, 1177 },
                    { 134, (short)1, 3398, 1177 },
                    { 135, (short)1, 4108, 1177 },
                    { 136, (short)1, 152, 1177 },
                    { 137, (short)1, 3353, 1192 },
                    { 138, (short)1, 3863, 1192 },
                    { 139, (short)1, 3577, 1192 },
                    { 140, (short)1, 3594, 1192 },
                    { 141, (short)1, 1294, 5093 },
                    { 142, (short)1, 4206, 1253 },
                    { 143, (short)1, 5330, 1253 },
                    { 144, (short)1, 3863, 1253 },
                    { 145, (short)1, 824, 1253 },
                    { 146, (short)1, 3577, 1253 },
                    { 147, (short)1, 152, 1253 },
                    { 148, (short)1, 3594, 1253 },
                    { 149, (short)1, 217, 1294 },
                    { 150, (short)1, 5093, 1294 },
                    { 151, (short)1, 3577, 1294 },
                    { 152, (short)1, 3594, 1294 },
                    { 153, (short)1, 4206, 1335 },
                    { 154, (short)1, 217, 1335 },
                    { 155, (short)1, 1587, 1335 },
                    { 156, (short)1, 5330, 1335 },
                    { 157, (short)1, 3863, 1335 },
                    { 158, (short)1, 3398, 1335 },
                    { 159, (short)1, 824, 1335 },
                    { 160, (short)1, 1003, 3398 },
                    { 161, (short)1, 1124, 3398 },
                    { 162, (short)1, 1177, 3398 },
                    { 163, (short)1, 1046, 3577 },
                    { 164, (short)1, 1192, 3577 },
                    { 165, (short)1, 1253, 3577 },
                    { 166, (short)1, 1294, 3577 },
                    { 167, (short)1, 217, 1485 },
                    { 168, (short)1, 3863, 1485 }
                });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "SubscriptionId", "AgencyId", "DestinationCityId", "OriginCityId" },
                values: new object[,]
                {
                    { 169, (short)1, 152, 1485 },
                    { 170, (short)1, 3594, 1485 },
                    { 171, (short)1, 3398, 1506 },
                    { 172, (short)1, 925, 152 },
                    { 173, (short)1, 1046, 152 },
                    { 174, (short)1, 1046, 3594 },
                    { 175, (short)1, 1192, 3594 },
                    { 176, (short)1, 1253, 3594 },
                    { 177, (short)1, 1485, 3594 },
                    { 178, (short)1, 1815, 925 },
                    { 179, (short)1, 5086, 925 },
                    { 180, (short)1, 3596, 925 },
                    { 181, (short)1, 5030, 925 },
                    { 182, (short)1, 925, 5086 },
                    { 183, (short)1, 1192, 5086 },
                    { 184, (short)1, 3398, 961 },
                    { 185, (short)1, 1192, 3596 },
                    { 186, (short)1, 3398, 984 },
                    { 187, (short)1, 1815, 1003 },
                    { 188, (short)1, 1587, 1003 },
                    { 189, (short)1, 5330, 1003 },
                    { 190, (short)1, 1587, 1005 },
                    { 191, (short)1, 152, 1005 },
                    { 192, (short)1, 217, 1007 },
                    { 193, (short)1, 5330, 1007 },
                    { 194, (short)1, 3398, 1007 },
                    { 195, (short)1, 4206, 1009 },
                    { 196, (short)1, 213, 1009 },
                    { 197, (short)1, 3596, 1009 },
                    { 198, (short)1, 213, 1029 },
                    { 199, (short)1, 217, 1029 },
                    { 200, (short)1, 3398, 1029 },
                    { 201, (short)1, 213, 1046 },
                    { 202, (short)1, 4225, 1046 },
                    { 203, (short)1, 4227, 1046 },
                    { 204, (short)1, 824, 1051 },
                    { 205, (short)1, 213, 1118 },
                    { 206, (short)1, 5330, 1118 },
                    { 207, (short)1, 6857, 1118 },
                    { 208, (short)1, 4231, 1118 },
                    { 209, (short)1, 4225, 1118 },
                    { 210, (short)1, 4206, 1124 }
                });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "SubscriptionId", "AgencyId", "DestinationCityId", "OriginCityId" },
                values: new object[,]
                {
                    { 211, (short)1, 785, 1124 },
                    { 212, (short)1, 1815, 1177 },
                    { 213, (short)1, 3596, 1177 },
                    { 214, (short)1, 213, 1192 },
                    { 215, (short)1, 5086, 1192 },
                    { 216, (short)1, 3596, 1192 },
                    { 217, (short)1, 925, 5030 },
                    { 218, (short)1, 3596, 1253 },
                    { 219, (short)1, 5330, 1294 },
                    { 220, (short)1, 5086, 1335 },
                    { 221, (short)1, 3596, 1335 },
                    { 222, (short)1, 5093, 1335 },
                    { 223, (short)1, 683, 1418 },
                    { 224, (short)1, 3863, 1418 },
                    { 225, (short)1, 3398, 1418 },
                    { 226, (short)1, 785, 1418 },
                    { 227, (short)1, 4206, 1485 },
                    { 228, (short)1, 1815, 1485 },
                    { 229, (short)1, 5086, 1485 },
                    { 230, (short)1, 3596, 1485 },
                    { 231, (short)1, 5330, 1485 },
                    { 232, (short)1, 824, 1485 },
                    { 233, (short)1, 4020, 1485 },
                    { 234, (short)1, 4042, 1485 },
                    { 235, (short)1, 785, 1485 },
                    { 236, (short)1, 3596, 1506 },
                    { 237, (short)1, 152, 1506 },
                    { 238, (short)1, 5093, 1253 },
                    { 239, (short)1, 4910, 925 },
                    { 240, (short)1, 4937, 925 },
                    { 241, (short)1, 197, 925 },
                    { 242, (short)1, 204, 925 },
                    { 243, (short)1, 3594, 925 },
                    { 244, (short)1, 160, 925 },
                    { 245, (short)1, 4910, 1003 },
                    { 246, (short)1, 3565, 1046 },
                    { 247, (short)1, 3562, 1046 },
                    { 248, (short)1, 3593, 1046 },
                    { 249, (short)1, 3551, 1046 },
                    { 250, (short)1, 4910, 1046 },
                    { 251, (short)1, 197, 1046 },
                    { 252, (short)1, 204, 1046 }
                });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "SubscriptionId", "AgencyId", "DestinationCityId", "OriginCityId" },
                values: new object[,]
                {
                    { 253, (short)1, 160, 1046 },
                    { 254, (short)1, 3584, 1046 },
                    { 255, (short)1, 3594, 1118 },
                    { 256, (short)1, 4910, 1118 },
                    { 257, (short)1, 160, 1118 },
                    { 258, (short)1, 4910, 6447 },
                    { 259, (short)1, 4910, 1192 },
                    { 260, (short)1, 4910, 1253 },
                    { 261, (short)1, 3565, 1294 },
                    { 262, (short)1, 3562, 1294 },
                    { 263, (short)1, 3593, 1294 },
                    { 264, (short)1, 3551, 1294 },
                    { 265, (short)1, 4937, 1294 },
                    { 266, (short)1, 4910, 1294 },
                    { 267, (short)1, 197, 1294 },
                    { 268, (short)1, 204, 1294 },
                    { 269, (short)1, 160, 1294 },
                    { 270, (short)1, 3584, 1294 },
                    { 271, (short)1, 3565, 1485 },
                    { 272, (short)1, 3562, 1485 },
                    { 273, (short)1, 3593, 1485 },
                    { 274, (short)1, 3577, 1485 },
                    { 275, (short)1, 3551, 1485 },
                    { 276, (short)1, 4937, 1485 },
                    { 277, (short)1, 4910, 1485 },
                    { 278, (short)1, 197, 1485 },
                    { 279, (short)1, 204, 1485 },
                    { 280, (short)1, 160, 1485 },
                    { 281, (short)1, 3584, 1485 },
                    { 282, (short)1, 3574, 1294 },
                    { 283, (short)1, 3574, 1485 },
                    { 284, (short)1, 3574, 1046 },
                    { 285, (short)3, 925, 785 },
                    { 286, (short)3, 1294, 785 },
                    { 287, (short)3, 1485, 785 },
                    { 288, (short)3, 1197, 785 },
                    { 289, (short)3, 3398, 785 },
                    { 290, (short)3, 1118, 785 },
                    { 291, (short)3, 1192, 785 },
                    { 292, (short)3, 3457, 785 },
                    { 293, (short)3, 3863, 785 },
                    { 294, (short)3, 7469, 785 }
                });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "SubscriptionId", "AgencyId", "DestinationCityId", "OriginCityId" },
                values: new object[,]
                {
                    { 295, (short)3, 152, 785 },
                    { 296, (short)3, 4123, 785 },
                    { 297, (short)3, 3791, 785 },
                    { 298, (short)3, 3353, 785 },
                    { 299, (short)3, 925, 713 },
                    { 300, (short)3, 1294, 713 },
                    { 301, (short)3, 1485, 713 },
                    { 302, (short)3, 1197, 713 },
                    { 303, (short)3, 3398, 713 },
                    { 304, (short)3, 1118, 713 },
                    { 305, (short)3, 1192, 713 },
                    { 306, (short)3, 3457, 713 },
                    { 307, (short)3, 3863, 713 },
                    { 308, (short)3, 7469, 713 },
                    { 309, (short)3, 152, 713 },
                    { 310, (short)3, 4123, 713 },
                    { 311, (short)3, 3791, 713 },
                    { 312, (short)3, 3353, 713 },
                    { 313, (short)3, 925, 683 },
                    { 314, (short)3, 1294, 683 },
                    { 315, (short)3, 1485, 683 },
                    { 316, (short)3, 1197, 683 },
                    { 317, (short)3, 3398, 683 },
                    { 318, (short)3, 1118, 683 },
                    { 319, (short)3, 1192, 683 },
                    { 320, (short)3, 3457, 683 },
                    { 321, (short)3, 3863, 683 },
                    { 322, (short)3, 7469, 683 },
                    { 323, (short)3, 152, 683 },
                    { 324, (short)3, 4123, 683 },
                    { 325, (short)3, 3791, 683 },
                    { 326, (short)3, 3353, 683 },
                    { 327, (short)4, 1221, 925 },
                    { 328, (short)4, 1170, 925 },
                    { 329, (short)4, 1025, 925 },
                    { 330, (short)4, 1079, 925 },
                    { 331, (short)4, 1046, 925 },
                    { 332, (short)4, 1170, 1221 },
                    { 333, (short)4, 1025, 1221 },
                    { 334, (short)4, 1079, 1221 },
                    { 335, (short)4, 1046, 1221 },
                    { 336, (short)4, 1079, 1170 }
                });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "SubscriptionId", "AgencyId", "DestinationCityId", "OriginCityId" },
                values: new object[,]
                {
                    { 337, (short)4, 1046, 1170 },
                    { 338, (short)4, 1079, 1025 },
                    { 339, (short)4, 1046, 1025 },
                    { 340, (short)4, 1025, 1046 },
                    { 341, (short)4, 1170, 1046 },
                    { 342, (short)4, 1221, 1046 },
                    { 343, (short)4, 925, 1046 },
                    { 344, (short)4, 1025, 1079 },
                    { 345, (short)4, 1170, 1079 },
                    { 346, (short)4, 1221, 1079 },
                    { 347, (short)4, 925, 1079 },
                    { 348, (short)4, 1221, 1025 },
                    { 349, (short)4, 925, 1025 },
                    { 350, (short)4, 1221, 1170 },
                    { 351, (short)4, 925, 1170 },
                    { 352, (short)4, 925, 1221 },
                    { 353, (short)4, 1046, 1079 },
                    { 354, (short)4, 1079, 1046 },
                    { 355, (short)4, 1170, 1222 },
                    { 356, (short)4, 1025, 1222 },
                    { 357, (short)4, 1079, 1222 },
                    { 358, (short)4, 1046, 1222 },
                    { 359, (short)4, 925, 1222 },
                    { 360, (short)4, 1222, 1046 },
                    { 361, (short)4, 1222, 1079 },
                    { 362, (short)4, 1222, 1025 },
                    { 363, (short)4, 1222, 1170 },
                    { 364, (short)5, 1118, 925 },
                    { 365, (short)6, 925, 1118 },
                    { 366, (short)2, 1593, 1587 },
                    { 367, (short)7, 7911, 7116 },
                    { 368, (short)7, 5214, 7116 },
                    { 369, (short)7, 7285, 7116 },
                    { 370, (short)7, 6021, 5587 },
                    { 371, (short)7, 6526, 6021 },
                    { 372, (short)7, 5587, 6526 },
                    { 373, (short)7, 7202, 6964 },
                    { 374, (short)7, 7202, 7747 },
                    { 375, (short)7, 7747, 6964 },
                    { 376, (short)7, 7116, 7911 },
                    { 377, (short)7, 7116, 5214 },
                    { 378, (short)7, 7116, 7285 }
                });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "SubscriptionId", "AgencyId", "DestinationCityId", "OriginCityId" },
                values: new object[,]
                {
                    { 379, (short)7, 5587, 6021 },
                    { 380, (short)7, 6021, 6526 },
                    { 381, (short)7, 6526, 5587 },
                    { 382, (short)7, 6964, 7202 },
                    { 383, (short)7, 7747, 7202 },
                    { 384, (short)7, 6964, 7747 },
                    { 385, (short)7, 6572, 7116 },
                    { 386, (short)7, 7116, 6572 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flights_RouteId",
                table: "Flights",
                column: "RouteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "Routes");
        }
    }
}
