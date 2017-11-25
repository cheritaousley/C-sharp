using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using boilerplate.Models;

namespace boilerplate.Migrations
{
    [DbContext(typeof(BoilerplateContext))]
    [Migration("20171121180539_user_update")]
    partial class user_update
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("boilerplate.Models.Connection", b =>
                {
                    b.Property<int>("ConnectionId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("LeftId");

                    b.Property<int>("RightId");

                    b.Property<bool>("Status");

                    b.Property<int?>("UserId");

                    b.Property<int?>("UserId1");

                    b.HasKey("ConnectionId");

                    b.HasIndex("UserId");

                    b.HasIndex("UserId1");

                    b.ToTable("connections");
                });

            modelBuilder.Entity("boilerplate.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("age");

                    b.Property<string>("description");

                    b.Property<string>("email");

                    b.Property<string>("first_name");

                    b.Property<string>("last_name");

                    b.Property<string>("password");

                    b.Property<string>("username");

                    b.HasKey("UserId");

                    b.ToTable("user");
                });

            modelBuilder.Entity("boilerplate.Models.Connection", b =>
                {
                    b.HasOne("boilerplate.Models.User")
                        .WithMany("Left")
                        .HasForeignKey("UserId");

                    b.HasOne("boilerplate.Models.User")
                        .WithMany("Right")
                        .HasForeignKey("UserId1");
                });
        }
    }
}
