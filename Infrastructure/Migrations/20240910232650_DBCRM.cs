using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DBCRM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CampaignTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(25)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    Email = table.Column<string>(type: "varchar(255)", nullable: false),
                    Phone = table.Column<string>(type: "varchar(255)", nullable: false),
                    Company = table.Column<string>(type: "varchar(100)", nullable: false),
                    Address = table.Column<string>(type: "varchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientID);
                });

            migrationBuilder.CreateTable(
                name: "InteractionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(25)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InteractionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaskStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(25)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectName = table.Column<string>(type: "varchar(255)", nullable: false),
                    CampaignType = table.Column<int>(type: "int", nullable: false),
                    ClientID = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectID);
                    table.ForeignKey(
                        name: "FK_Projects_CampaignTypes_CampaignType",
                        column: x => x.CampaignType,
                        principalTable: "CampaignTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projects_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Interactions",
                columns: table => new
                {
                    InteractionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InteractionType = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "varchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interactions", x => x.InteractionID);
                    table.ForeignKey(
                        name: "FK_Interactions_InteractionTypes_InteractionType",
                        column: x => x.InteractionType,
                        principalTable: "InteractionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Interactions_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    TaskID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjectID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssignedTo = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.TaskID);
                    table.ForeignKey(
                        name: "FK_Tasks_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_TaskStatus_Status",
                        column: x => x.Status,
                        principalTable: "TaskStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Users_AssignedTo",
                        column: x => x.AssignedTo,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Interactions_InteractionType",
                table: "Interactions",
                column: "InteractionType");

            migrationBuilder.CreateIndex(
                name: "IX_Interactions_ProjectID",
                table: "Interactions",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CampaignType",
                table: "Projects",
                column: "CampaignType");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ClientID",
                table: "Projects",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_AssignedTo",
                table: "Tasks",
                column: "AssignedTo");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ProjectID",
                table: "Tasks",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_Status",
                table: "Tasks",
                column: "Status");
            //Insertar datos

            //Insertar Users
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Name", "Email" },
                values: new object[] { 1, "Joe Done", "jdone@marketing.com" }
                );
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Name", "Email" },
                values: new object[] { 2, "Nill Amstrong", "namstrong@marketing.com" }
                );
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Name", "Email" },
                values: new object[] { 3, "Marlyn Morales", "mmorales@marketing.com" }
                );
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Name", "Email" },
                values: new object[] { 4, "Antony Orué", "aorue@marketing.com" }
                );
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Name", "Email" },
                values: new object[] { 5, "Jazmin Fernandez", "jfernandez@marketing.com" }
                );

            //Insertar TaskStatus

            migrationBuilder.InsertData(
                table: "TaskStatus",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Pending" }
                );
            migrationBuilder.InsertData(
                table: "TaskStatus",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "In Progress" }
                );
            migrationBuilder.InsertData(
                table: "TaskStatus",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Blocked" }
                );
            migrationBuilder.InsertData(
                table: "TaskStatus",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "Done" }
                );
            migrationBuilder.InsertData(
                table: "TaskStatus",
                columns: new[] { "Id", "Name" },
                values: new object[] { 5, "Cancel" }
                );

            //Insertar InteractionType

            migrationBuilder.InsertData(
                table: "InteractionTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Initial Meeting" }
                );
            migrationBuilder.InsertData(
                table: "InteractionTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Phone call" }
                );
            migrationBuilder.InsertData(
                table: "InteractionTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Email" }
                );
            migrationBuilder.InsertData(
                table: "InteractionTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "Presentation of Results" }
                );

            //Insertar CampaignTypes
            migrationBuilder.InsertData(
                table: "CampaignTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "SEO" }
                );
            migrationBuilder.InsertData(
                table: "CampaignTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "PPC" }
                );
            migrationBuilder.InsertData(
                table: "CampaignTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Social Media" }
                );
            migrationBuilder.InsertData(
                table: "CampaignTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "Email Marketing" }
                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Interactions");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "InteractionTypes");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "TaskStatus");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "CampaignTypes");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
