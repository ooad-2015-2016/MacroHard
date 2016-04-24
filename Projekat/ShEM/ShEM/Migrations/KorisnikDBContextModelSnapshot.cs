using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations.Infrastructure;
using ShEM.BazaPodataka.Models;

namespace ShEMMigrations
{
    [ContextType(typeof(KorisnikDBContext))]
    partial class KorisnikDBContextModelSnapshot : ModelSnapshot
    {
        public override void BuildModel(ModelBuilder builder)
        {
            builder
                .Annotation("ProductVersion", "7.0.0-beta6-13815");

            builder.Entity("ShEM.BazaPodataka.Models.Korisnik", b =>
                {
                    b.Property<int>("userID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("email");

                    b.Property<string>("lName");

                    b.Property<string>("name");

                    b.Property<int>("numberOfColections");

                    b.Property<byte[]>("picture")
                        .Annotation("Relational:ColumnType", "picture");

                    b.Property<string>("username");

                    b.Key("userID");
                });
        }
    }
}
