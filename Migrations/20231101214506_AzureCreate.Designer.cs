﻿// <auto-generated />
using InvoiceGeneratorAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InvoiceGeneratorAPI.Migrations
{
    [DbContext(typeof(InvoiceTemplateContext))]
    [Migration("20231101214506_AzureCreate")]
    partial class AzureCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("InvoiceGeneratorAPI.Models.InvoiceTemplate", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("TemplateID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("id"));

                    b.Property<string>("companyEmailCell")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("companyNameCell")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("companyPOBoxCell")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("companyPhoneCell")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("customerAddressCell")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("customerNameCell")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("invoiceDateCell")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("invoiceIdCell")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("invoiceTotalCell")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("itemIdCell")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("itemPriceCell")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("itemPriceTotalCell")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("itemQuantityCell")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("itemSizeCell")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pONumCell")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("productTypeCell")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("shipDateCell")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("shipeeAddressCell")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("shipeeNameCell")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("templateName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("templatePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("trackingNumberCell")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("dbo.InvoiceTemplates");
                });
#pragma warning restore 612, 618
        }
    }
}
