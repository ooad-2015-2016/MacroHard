using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Migrations.Builders;
using Microsoft.Data.Entity.Migrations.Operations;

namespace ShEMMigrations
{
    public partial class InitialMigrations : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.CreateTable(
                name: "Film",
                columns: table => new
                {
                    ArticleID = table.Column(type: "INTEGER", nullable: false),
                   //     .Annotation("Sqlite:Autoincrement", true),
                    ArticlePicture = table.Column(type: "picture", nullable: true),
                    Director = table.Column(type: "TEXT", nullable: true),
                    Genre = table.Column(type: "TEXT", nullable: true),
                    Length = table.Column(type: "INTEGER", nullable: false),
                    Name = table.Column(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Film", x => x.ArticleID);
                });
            migration.CreateTable(
                name: "Knjiga",
                columns: table => new
                {
                    ArticleID = table.Column(type: "INTEGER", nullable: false),
                 //       .Annotation("Sqlite:Autoincrement", true),
                    ArticlePicture = table.Column(type: "picture", nullable: true),
                    Author = table.Column(type: "TEXT", nullable: true),
                    Genre = table.Column(type: "TEXT", nullable: true),
                    Name = table.Column(type: "TEXT", nullable: true),
                    Publisher = table.Column(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Knjiga", x => x.ArticleID);
                });
            migration.CreateTable(
                name: "Kolekcija",
                columns: table => new
                {
                    CollectionId = table.Column(type: "INTEGER", nullable: false),
               //         .Annotation("Sqlite:Autoincrement", true),
                    CollectionPicture = table.Column(type: "picture", nullable: true),
                    CreatorId = table.Column(type: "INTEGER", nullable: false),
                    Name = table.Column(type: "TEXT", nullable: true),
                    status = table.Column(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kolekcija", x => x.CollectionId);
                });
            migration.CreateTable(
                name: "Komentar",
                columns: table => new
                {
                    CommentId = table.Column(type: "INTEGER", nullable: false),
              //          .Annotation("Sqlite:Autoincrement", true),
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
               //         .Annotation("Sqlite:Autoincrement", true),
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
            migration.CreateTable(
                name: "Pjesma",
                columns: table => new
                {
                    ArticleID = table.Column(type: "INTEGER", nullable: false),
               //         .Annotation("Sqlite:Autoincrement", true),
                    Album = table.Column(type: "TEXT", nullable: true),
                    ArticlePicture = table.Column(type: "picture", nullable: true),
                    Genre = table.Column(type: "TEXT", nullable: true),
                    Length = table.Column(type: "REAL", nullable: false),
                    Musician = table.Column(type: "TEXT", nullable: true),
                    Name = table.Column(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pjesma", x => x.ArticleID);
                });
        }

        public override void Down(MigrationBuilder migration)
        {
            migration.DropTable("Film");
            migration.DropTable("Knjiga");
            migration.DropTable("Kolekcija");
            migration.DropTable("Komentar");
            migration.DropTable("Korisnik");
            migration.DropTable("Pjesma");
        }
    }
}
