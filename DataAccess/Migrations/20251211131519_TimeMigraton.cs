using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class TimeMigraton : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    SkillID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Skills__DFA091E7944D1A2F", x => x.SkillID);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ManagerID = table.Column<int>(type: "int", nullable: true),
                    Budget = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Departme__B2079BCDA34A321C", x => x.DepartmentID);
                });

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    ResourceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResourceName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ResourceType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    CostPerHour = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    CostPerUnit = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Availability = table.Column<int>(type: "int", nullable: true, defaultValue: 100),
                    DepartmentID = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Resource__4ED1814F3DEA3B39", x => x.ResourceID);
                    table.ForeignKey(
                        name: "FK_Resources_Departments",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "DepartmentID");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Position = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DepartmentID = table.Column<int>(type: "int", nullable: true),
                    HireDate = table.Column<DateOnly>(type: "date", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Users__1788CCAC28179AB0", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Users_Departments",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "DepartmentID");
                });

            migrationBuilder.CreateTable(
                name: "Goals",
                columns: table => new
                {
                    GoalID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TargetDate = table.Column<DateOnly>(type: "date", nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: true, defaultValue: 3),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValue: "Active"),
                    Progress = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Goals__8A4FFF31510AB60C", x => x.GoalID);
                    table.ForeignKey(
                        name: "FK_Goals_Users",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DepartmentID = table.Column<int>(type: "int", nullable: true),
                    ProjectManagerID = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: true),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: true),
                    Budget = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValue: "Active"),
                    Priority = table.Column<int>(type: "int", nullable: true, defaultValue: 3),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Projects__761ABED0D20A58C2", x => x.ProjectID);
                    table.ForeignKey(
                        name: "FK_Projects_Departments",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "DepartmentID");
                    table.ForeignKey(
                        name: "FK_Projects_Manager",
                        column: x => x.ProjectManagerID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "UserSkills",
                columns: table => new
                {
                    UserSkillID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    SkillID = table.Column<int>(type: "int", nullable: true),
                    ProficiencyLevel = table.Column<int>(type: "int", nullable: true),
                    YearsOfExperience = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserSkil__2F28BFB6FD29AA02", x => x.UserSkillID);
                    table.ForeignKey(
                        name: "FK_UserSkills_Skills",
                        column: x => x.SkillID,
                        principalTable: "Skills",
                        principalColumn: "SkillID");
                    table.ForeignKey(
                        name: "FK_UserSkills_Users",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Meetings",
                columns: table => new
                {
                    MeetingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    OrganizerID = table.Column<int>(type: "int", nullable: true),
                    ProjectID = table.Column<int>(type: "int", nullable: true),
                    StartDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    MeetingType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Meetings__E9F9E9AC481FFB96", x => x.MeetingID);
                    table.ForeignKey(
                        name: "FK_Meetings_Projects",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ProjectID");
                    table.ForeignKey(
                        name: "FK_Meetings_Users",
                        column: x => x.OrganizerID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "UserTasks",
                columns: table => new
                {
                    TaskID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ProjectID = table.Column<int>(type: "int", nullable: true),
                    AssignedTo = table.Column<int>(type: "int", nullable: true),
                    EstimatedHours = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    ActualHours = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: true),
                    DueDate = table.Column<DateOnly>(type: "date", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValue: "New"),
                    Priority = table.Column<int>(type: "int", nullable: true, defaultValue: 3),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserTask__7C6949D1EE7F8366", x => x.TaskID);
                    table.ForeignKey(
                        name: "FK_UserTasks_Projects",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ProjectID");
                    table.ForeignKey(
                        name: "FK_UserTasks_Users",
                        column: x => x.AssignedTo,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "MeetingParticipants",
                columns: table => new
                {
                    ParticipantID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeetingID = table.Column<int>(type: "int", nullable: true),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    ResponseStatus = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValue: "Pending"),
                    Attendance = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__MeetingP__7227997E40069F2B", x => x.ParticipantID);
                    table.ForeignKey(
                        name: "FK_MeetingParticipants_Meetings",
                        column: x => x.MeetingID,
                        principalTable: "Meetings",
                        principalColumn: "MeetingID");
                    table.ForeignKey(
                        name: "FK_MeetingParticipants_Users",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "ResourceAssignments",
                columns: table => new
                {
                    AssignmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResourceID = table.Column<int>(type: "int", nullable: true),
                    TaskID = table.Column<int>(type: "int", nullable: true),
                    ProjectID = table.Column<int>(type: "int", nullable: true),
                    AssignedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ReturnDate = table.Column<DateOnly>(type: "date", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true, defaultValue: 1),
                    HoursUsed = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValue: "Assigned"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Resource__32499E5721E123D0", x => x.AssignmentID);
                    table.ForeignKey(
                        name: "FK_ResourceAssignments_Projects",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ProjectID");
                    table.ForeignKey(
                        name: "FK_ResourceAssignments_Resources",
                        column: x => x.ResourceID,
                        principalTable: "Resources",
                        principalColumn: "ResourceID");
                    table.ForeignKey(
                        name: "FK_ResourceAssignments_UserTasks",
                        column: x => x.TaskID,
                        principalTable: "UserTasks",
                        principalColumn: "TaskID");
                });

            migrationBuilder.CreateTable(
                name: "TimeEntries",
                columns: table => new
                {
                    TimeEntryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    TaskID = table.Column<int>(type: "int", nullable: true),
                    EntryDate = table.Column<DateOnly>(type: "date", nullable: false),
                    HoursWorked = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Billable = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    Approved = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TimeEntr__36FCE7E951552FBD", x => x.TimeEntryID);
                    table.ForeignKey(
                        name: "FK_TimeEntries_UserTasks",
                        column: x => x.TaskID,
                        principalTable: "UserTasks",
                        principalColumn: "TaskID");
                    table.ForeignKey(
                        name: "FK_TimeEntries_Users",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_ManagerID",
                table: "Departments",
                column: "ManagerID");

            migrationBuilder.CreateIndex(
                name: "IX_Goals_UserID",
                table: "Goals",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingParticipants_UserID",
                table: "MeetingParticipants",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "UC_MeetingParticipant",
                table: "MeetingParticipants",
                columns: new[] { "MeetingID", "UserID" },
                unique: true,
                filter: "[MeetingID] IS NOT NULL AND [UserID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_DateTime",
                table: "Meetings",
                columns: new[] { "StartDateTime", "EndDateTime" });

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_OrganizerID",
                table: "Meetings",
                column: "OrganizerID");

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_ProjectID",
                table: "Meetings",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_DepartmentID",
                table: "Projects",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectManagerID",
                table: "Projects",
                column: "ProjectManagerID");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceAssignments_ProjectID",
                table: "ResourceAssignments",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceAssignments_Resource",
                table: "ResourceAssignments",
                column: "ResourceID");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceAssignments_Task",
                table: "ResourceAssignments",
                column: "TaskID");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_DepartmentID",
                table: "Resources",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_TimeEntries_TaskID",
                table: "TimeEntries",
                column: "TaskID");

            migrationBuilder.CreateIndex(
                name: "IX_TimeEntries_UserDate",
                table: "TimeEntries",
                columns: new[] { "UserID", "EntryDate" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Department",
                table: "Users",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "UQ__Users__A9D10534A262626A",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserSkills_SkillID",
                table: "UserSkills",
                column: "SkillID");

            migrationBuilder.CreateIndex(
                name: "IX_UserSkills_User",
                table: "UserSkills",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "UC_UserSkill",
                table: "UserSkills",
                columns: new[] { "UserID", "SkillID" },
                unique: true,
                filter: "[UserID] IS NOT NULL AND [SkillID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserTasks_AssignedTo",
                table: "UserTasks",
                column: "AssignedTo");

            migrationBuilder.CreateIndex(
                name: "IX_UserTasks_Project",
                table: "UserTasks",
                column: "ProjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Manager",
                table: "Departments",
                column: "ManagerID",
                principalTable: "Users",
                principalColumn: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Manager",
                table: "Departments");

            migrationBuilder.DropTable(
                name: "Goals");

            migrationBuilder.DropTable(
                name: "MeetingParticipants");

            migrationBuilder.DropTable(
                name: "ResourceAssignments");

            migrationBuilder.DropTable(
                name: "TimeEntries");

            migrationBuilder.DropTable(
                name: "UserSkills");

            migrationBuilder.DropTable(
                name: "Meetings");

            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropTable(
                name: "UserTasks");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}