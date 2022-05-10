using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace backendv3.Migrations
{
    public partial class Migration05 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey("PK_UserGame", "UserGame");
            migrationBuilder.DropForeignKey("FK_UserGame_AspNetUsers_UserId", "UserGame");
            migrationBuilder.DropForeignKey("FK_UserGame_Game_GameId", "UserGame");

            migrationBuilder.DropPrimaryKey("PK_UserFriend", "UserFriend");
            migrationBuilder.DropForeignKey("FK_UserFriend_AspNetUsers_UserId", "UserFriend");
            migrationBuilder.DropForeignKey("FK_UserFriend_AspNetUsers_FriendId", "UserFriend");

            migrationBuilder.DropPrimaryKey("PK_Game", "Game"); 

            migrationBuilder.DropPrimaryKey("PK_AspNetUserTokens", "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey("PK_AspNetUsers", "AspNetUsers");
            migrationBuilder.DropForeignKey("FK_AspNetUserTokens_AspNetUsers_UserId", "AspNetUserTokens");
            migrationBuilder.DropForeignKey("FK_AspNetUserRoles_AspNetUsers_UserId", "AspNetUserRoles");
            migrationBuilder.DropForeignKey("FK_AspNetUserLogins_AspNetUsers_UserId", "AspNetUserLogins");
            migrationBuilder.DropForeignKey("FK_AspNetUserClaims_AspNetUsers_UserId", "AspNetUserClaims");


            //dropping and readding keys for database update errors
            #region alter columns
            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "UserGame",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<Guid>(
                name: "GameId",
                table: "UserGame",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "UserFriend",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<Guid>(
                name: "FriendId",
                table: "UserFriend",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<Guid>(
                name: "GameId",
                table: "Game",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "AspNetUserTokens",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<Guid>(
                name: "RoleId",
                table: "AspNetUserRoles",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "AspNetUserRoles",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "AspNetUserLogins",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "AspNetUserClaims",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "AspNetRoles",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<Guid>(
                name: "RoleId",
                table: "AspNetRoleClaims",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
            #endregion alter columns

            migrationBuilder.AddPrimaryKey("PK_UserGame", "UserGame", new string [] { "UserId", "GameId" });
            migrationBuilder.AddForeignKey(name: "FK_UserGame_AspNetUsers_UserId", table: "UserGame", column: "UserId", principalTable: "AspNetUsers", principalColumn: "Id", schema: null, principalSchema: null, onUpdate: ReferentialAction.NoAction, onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(name: "FK_UserGame_Game_GameId", table: "UserGame", column: "GameId", principalTable: "Game", principalColumn: "GameId", schema: null, principalSchema: null, onUpdate: ReferentialAction.NoAction, onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddPrimaryKey("PK_UserFriend", "UserFriend", new string [] { "UserId", "FriendId" });
            migrationBuilder.AddForeignKey(name: "FK_UserFriend_AspNetUsers_UserId", table: "UserFriend", column: "UserId", principalTable: "AspNetUsers", principalColumn: "Id", schema: null, principalSchema: null, onUpdate: ReferentialAction.NoAction, onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(name: "FK_UserFriend_AspNetUsers_FriendId", table: "UserFriend", column: "FriendId", principalTable: "AspNetUsers", principalColumn: "Id", schema: null, principalSchema: null, onUpdate: ReferentialAction.NoAction, onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddPrimaryKey("PK_Game", "Game", "GameId");

            migrationBuilder.AddPrimaryKey("PK_AspNetUserTokens", "AspNetUserTokens", new String[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey("PK_AspNetUsers", "AspNetUsers", "Id");
            migrationBuilder.AddForeignKey(name: "FK_AspNetUserTokens_AspNetUsers_UserId", table: "AspNetUserTokens", column: "UserId", principalTable: "AspNetUsers",principalColumn: "Id", schema: null, principalSchema: null,onUpdate: ReferentialAction.NoAction, onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(name: "FK_AspNetUserRoles_AspNetUsers_UserId", table: "AspNetUserRoles", column: "UserId", principalTable: "AspNetUsers",principalColumn: "Id", schema: null, principalSchema: null,onUpdate: ReferentialAction.NoAction, onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(name: "FK_AspNetUserLogins_AspNetUsers_UserId", table: "AspNetUserLogins", column: "UserId", principalTable: "AspNetUsers",principalColumn: "Id", schema: null, principalSchema: null,onUpdate: ReferentialAction.NoAction, onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(name: "FK_AspNetUserClaims_AspNetUsers_UserId", table: "AspNetUserClaims", column: "UserId", principalTable: "AspNetUsers",principalColumn: "Id", schema: null, principalSchema: null,onUpdate: ReferentialAction.NoAction, onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserGame",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "GameId",
                table: "UserGame",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserFriend",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "FriendId",
                table: "UserFriend",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "GameId",
                table: "Game",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "RoleId",
                table: "AspNetUserRoles",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AspNetUserRoles",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AspNetUserClaims",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "AspNetRoles",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "RoleId",
                table: "AspNetRoleClaims",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }
    }
}
