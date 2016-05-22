using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations.Infrastructure;
using ShEM.BazaPodataka.Models;

namespace ShEMMigrations
{
    [ContextType(typeof(DBContext))]
    partial class InitialMigrations
    {
        public override string Id
        {
            get { return "20160522074702_InitialMigrations"; }
        }

        public override string ProductVersion
        {
            get { return "7.0.0-beta6-13815"; }
        }

        public override void BuildTargetModel(ModelBuilder builder)
        {
            builder
                .Annotation("ProductVersion", "7.0.0-beta6-13815");

            builder.Entity("ShEM.BazaPodataka.Models.Film", b =>
                {
                    b.Property<int>("ArticleID")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("ArticlePicture")
                        .Annotation("Relational:ColumnType", "picture");

                    b.Property<string>("Director");

                    b.Property<string>("Genre");

                    b.Property<int>("Length");

                    b.Property<string>("Name");

                    b.Key("ArticleID");
                });

            builder.Entity("ShEM.BazaPodataka.Models.Knjiga", b =>
                {
                    b.Property<int>("ArticleID")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("ArticlePicture")
                        .Annotation("Relational:ColumnType", "picture");

                    b.Property<string>("Author");

                    b.Property<string>("Genre");

                    b.Property<string>("Name");

                    b.Property<string>("Publisher");

                    b.Key("ArticleID");
                });

            builder.Entity("ShEM.BazaPodataka.Models.Kolekcija", b =>
                {
                    b.Property<int>("CollectionId")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("CollectionPicture")
                        .Annotation("Relational:ColumnType", "picture");

                    b.Property<int>("CreatorId");

                    b.Property<string>("Name");

                    b.Property<bool>("status");

                    b.Key("CollectionId");
                });

            builder.Entity("ShEM.BazaPodataka.Models.Komentar", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CollectionID");

                    b.Property<int>("CreatorId");

                    b.Property<byte[]>("CreatorPicture")
                        .Annotation("Relational:ColumnType", "picture");

                    b.Property<string>("Text");

                    b.Key("CommentId");
                });

            builder.Entity("ShEM.BazaPodataka.Models.Korisnik", b =>
                {
                    b.Property<int>("userID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("email");

                    b.Property<string>("lName");

                    b.Property<string>("name");

                    b.Property<int>("numberOfCollections");

                    b.Property<byte[]>("picture")
                        .Annotation("Relational:ColumnType", "picture");

                    b.Property<string>("username");

                    b.Key("userID");
                });

            builder.Entity("ShEM.BazaPodataka.Models.Pjesma", b =>
                {
                    b.Property<int>("ArticleID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Album");

                    b.Property<byte[]>("ArticlePicture")
                        .Annotation("Relational:ColumnType", "picture");

                    b.Property<string>("Genre");

                    b.Property<double>("Length");

                    b.Property<string>("Musician");

                    b.Property<string>("Name");

                    b.Key("ArticleID");
                });
        }
    }
}
