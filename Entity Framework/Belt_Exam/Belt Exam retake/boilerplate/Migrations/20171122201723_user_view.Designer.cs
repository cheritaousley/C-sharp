using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using boilerplate.Models;

namespace boilerplate.Migrations
{
    [DbContext(typeof(BoilerplateContext))]
    [Migration("20171122201723_user_view")]
    partial class user_view
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("boilerplate.Models.Auction", b =>
                {
                    b.Property<int>("AuctionId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("UserId");

                    b.Property<DateTime>("date");

                    b.Property<string>("description");

                    b.Property<double>("price");

                    b.Property<string>("product_name");

                    b.HasKey("AuctionId");

                    b.HasIndex("UserId");

                    b.ToTable("auctions");
                });

            modelBuilder.Entity("boilerplate.Models.Bidder", b =>
                {
                    b.Property<int>("BidderId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AuctionId");

                    b.Property<int>("Userid");

                    b.HasKey("BidderId");

                    b.HasIndex("AuctionId");

                    b.HasIndex("Userid");

                    b.ToTable("bidders");
                });

            modelBuilder.Entity("boilerplate.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("age");

                    b.Property<string>("email");

                    b.Property<string>("first_name");

                    b.Property<string>("last_name");

                    b.Property<string>("password");

                    b.Property<string>("username");

                    b.Property<int>("wallet");

                    b.HasKey("UserId");

                    b.ToTable("user");
                });

            modelBuilder.Entity("boilerplate.Models.Auction", b =>
                {
                    b.HasOne("boilerplate.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("boilerplate.Models.Bidder", b =>
                {
                    b.HasOne("boilerplate.Models.Auction", "Auction")
                        .WithMany("Bidder")
                        .HasForeignKey("AuctionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("boilerplate.Models.User", "User")
                        .WithMany("Auction")
                        .HasForeignKey("Userid")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
