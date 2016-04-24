using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations.Infrastructure;
using ShEM.BazaPodataka.Models;

namespace ShEMMigrations
{
    [ContextType(typeof(DBContext))]
    partial class DBContextModelSnapshot : ModelSnapshot
    {
        public override void BuildModel(ModelBuilder builder)
        {
            builder
                .Annotation("ProductVersion", "7.0.0-beta6-13815");

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
        }
    }
}
