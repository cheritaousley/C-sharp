using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using boilerplate.Models;

namespace boilerplate.Migrations
{
    [DbContext(typeof(BoilerplateContext))]
    [Migration("20171121170447_FirstMigration")]
    partial class FirstMigration
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

                    b.Property<int>("AcceptingInviteId");

                    b.Property<int>("SendingInviteId");

                    b.Property<bool>("Status");

                    b.HasKey("ConnectionId");

                    b.HasIndex("AcceptingInviteId");

                    b.HasIndex("SendingInviteId");

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
                    b.HasOne("boilerplate.Models.User", "AcceptingInvite")
                        .WithMany("SendingInvite")
                        .HasForeignKey("AcceptingInviteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("boilerplate.Models.User", "SendingInvite")
                        .WithMany("AcceptingInvite")
                        .HasForeignKey("SendingInviteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
