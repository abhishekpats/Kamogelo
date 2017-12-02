using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using PhoneBook.Data;

namespace PhoneBook.Migrations
{
    [DbContext(typeof(PhonebookDbContext))]
    [Migration("20171130124216_PhoneBookMig")]
    partial class PhoneBookMig
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PhoneBook.Models.Entries", b =>
                {
                    b.Property<int>("EntryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int?>("PhoneBookId");

                    b.Property<string>("PhoneNumber");

                    b.HasKey("EntryId");

                    b.HasIndex("PhoneBookId");

                    b.ToTable("Entries");
                });

            modelBuilder.Entity("PhoneBook.Models.PhoneBooks", b =>
                {
                    b.Property<int>("PhoneBookId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("PhoneBookId");

                    b.ToTable("PhonesBooks");
                });

            modelBuilder.Entity("PhoneBook.Models.Entries", b =>
                {
                    b.HasOne("PhoneBook.Models.PhoneBooks", "PhoneBook")
                        .WithMany("Entries")
                        .HasForeignKey("PhoneBookId");
                });
        }
    }
}
