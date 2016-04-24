using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Migrations.Builders;
using Microsoft.Data.Entity.Migrations.Operations;

namespace ShEMMigrations
{
    public partial class InitialMigration : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.CreateTable(
                name: "Komentar",
                columns: table => new
                {
                    CommentId = table.Column(type: "INTEGER", nullable: false),
                   //     .Annotation("Sqlite:Autoincrement", true),
                    CollectionID = table.Column(type: "INTEGER", nullable: false),
                    CreatorId = table.Column(type: "INTEGER", nullable: false),
                    CreatorPicture = table.Column(type: "picture", nullable: true),
                    Text = table.Column(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Komentar", x => x.CommentId);
                });
            migration.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    userID = table.Column(type: "INTEGER", nullable: false),
                 //       .Annotation("Sqlite:Autoincrement", true),
                    email = table.Column(type: "TEXT", nullable: true),
                    lName = table.Column(type: "TEXT", nullable: true),
                    name = table.Column(type: "TEXT", nullable: true),
                    numberOfCollections = table.Column(type: "INTEGER", nullable: false),
                    picture = table.Column(type: "picture", nullable: true),
                    username = table.Column(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik", x => x.userID);
                });
        }

        public override void Down(MigrationBuilder migration)
        {
            migration.DropTable("Komentar");
            migration.DropTable("Korisnik");
        }
    }
}
