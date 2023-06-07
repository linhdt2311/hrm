﻿// <auto-generated />
using System;
using HRM.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HRM.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HRM.Entities.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatorUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DeleteUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Icon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LastModifierUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("HRM.Entities.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Bank")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BankAccount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatorUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DateOfIssue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("DeleteUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DepartmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DoB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Identify")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InsuranceStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("IssuedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LastModifierUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("LeaveDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("PlaceOfOrigin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlaceOfResidence")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<int?>("PositionId")
                        .HasColumnType("int");

                    b.Property<string>("PublicId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Sex")
                        .HasColumnType("bit");

                    b.Property<DateTime>("StartingDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("TaxCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("PositionId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("HRM.Entities.EmployeeSalary", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ActualSalary")
                        .HasColumnType("int");

                    b.Property<int>("Bounty")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatorUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DeleteUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("IsConfirm")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LastModifierUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Punish")
                        .HasColumnType("int");

                    b.Property<Guid>("Salary")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SalaryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TotalWorkdays")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("SalaryId");

                    b.ToTable("EmployeeSalary");
                });

            modelBuilder.Entity("HRM.Entities.Evaluate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatorUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateEvaluate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DeleteUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LastModifierUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("NewLevel")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OldLevel")
                        .HasColumnType("int");

                    b.Property<Guid>("PMId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Evaluate");
                });

            modelBuilder.Entity("HRM.Entities.MemberProject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatorUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DeleteUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LastModifierUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ProjectId");

                    b.ToTable("MemberProject");
                });

            modelBuilder.Entity("HRM.Entities.Message", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatorUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DateRead")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DeleteUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("EmployeeId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LastModifierUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("MessageSent")
                        .HasColumnType("datetime2");

                    b.Property<bool>("RecipientDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("RecipientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RecipientUserName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<bool>("SenderDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("SenderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SenderUserName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("EmployeeId1");

                    b.ToTable("Message");
                });

            modelBuilder.Entity("HRM.Entities.Notification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatorUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DeleteUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LastModifierUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Thumbnail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Notification");
                });

            modelBuilder.Entity("HRM.Entities.NotificationEmployee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatorUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DeleteUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRead")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LastModifierUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("NotificationId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("NotificationEmployee");
                });

            modelBuilder.Entity("HRM.Entities.OnLeave", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatorUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateLeave")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DeleteUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LastModifierUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Option")
                        .HasColumnType("int");

                    b.Property<string>("Reason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("OnLeave");
                });

            modelBuilder.Entity("HRM.Entities.Payoff", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatorUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DeleteUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LastModifierUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Punish")
                        .HasColumnType("bit");

                    b.Property<string>("Reason")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Payoff");
                });

            modelBuilder.Entity("HRM.Entities.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Position");
                });

            modelBuilder.Entity("HRM.Entities.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CompleteDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatorUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DeadlineDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DeleteUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LastModifierUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("PriorityCode")
                        .HasColumnType("int");

                    b.Property<string>("ProjectCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ProjectType")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.Property<int>("StatusCode")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("HRM.Entities.Salary", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatorUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DeleteUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LastModifierUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<int>("Money")
                        .HasColumnType("int");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<string>("SalaryCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Welfare")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Salary");
                });

            modelBuilder.Entity("HRM.Entities.Tasks", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CompleteDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreateUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatorUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DeadlineDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DeleteUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LastModifierUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("PriorityCode")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ReasonForDelay")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusCode")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.Property<string>("TaskCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TaskName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TaskType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("HRM.Entities.TimeKeeping", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Checkin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Checkout")
                        .HasColumnType("datetime2");

                    b.Property<string>("Complain")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatorUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DeleteUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LastModifierUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PhotoCheckin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoCheckout")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Punish")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("TimeKeeping");
                });

            modelBuilder.Entity("HRM.Entities.TimeWorking", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AfternoonEndTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("AfternoonStartTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ApplyDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatorUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DeleteUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LastModifierUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("MorningEndTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("MorningStartTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("TimeWorking");
                });

            modelBuilder.Entity("HRM.Entities.Employee", b =>
                {
                    b.HasOne("HRM.Entities.Department", null)
                        .WithMany("Employee")
                        .HasForeignKey("DepartmentId");

                    b.HasOne("HRM.Entities.Position", null)
                        .WithMany("Employee")
                        .HasForeignKey("PositionId");
                });

            modelBuilder.Entity("HRM.Entities.EmployeeSalary", b =>
                {
                    b.HasOne("HRM.Entities.Employee", null)
                        .WithMany("EmployeeSalary")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HRM.Entities.Salary", null)
                        .WithMany("EmployeeSalary")
                        .HasForeignKey("SalaryId");
                });

            modelBuilder.Entity("HRM.Entities.Evaluate", b =>
                {
                    b.HasOne("HRM.Entities.Employee", null)
                        .WithMany("Evaluate")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HRM.Entities.MemberProject", b =>
                {
                    b.HasOne("HRM.Entities.Employee", null)
                        .WithMany("MemberProject")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HRM.Entities.Project", null)
                        .WithMany("MemberProject")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HRM.Entities.Message", b =>
                {
                    b.HasOne("HRM.Entities.Employee", null)
                        .WithMany("MessagesReceived")
                        .HasForeignKey("EmployeeId");

                    b.HasOne("HRM.Entities.Employee", null)
                        .WithMany("MessagesSent")
                        .HasForeignKey("EmployeeId1");
                });

            modelBuilder.Entity("HRM.Entities.OnLeave", b =>
                {
                    b.HasOne("HRM.Entities.Employee", null)
                        .WithMany("OnLeave")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HRM.Entities.Payoff", b =>
                {
                    b.HasOne("HRM.Entities.Employee", null)
                        .WithMany("Payoff")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HRM.Entities.Tasks", b =>
                {
                    b.HasOne("HRM.Entities.Employee", null)
                        .WithMany("Tasks")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HRM.Entities.Project", null)
                        .WithMany("Tasks")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HRM.Entities.TimeKeeping", b =>
                {
                    b.HasOne("HRM.Entities.Employee", null)
                        .WithMany("TimeKeeping")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HRM.Entities.TimeWorking", b =>
                {
                    b.HasOne("HRM.Entities.Employee", null)
                        .WithMany("TimeWorking")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HRM.Entities.Department", b =>
                {
                    b.Navigation("Employee");
                });

            modelBuilder.Entity("HRM.Entities.Employee", b =>
                {
                    b.Navigation("EmployeeSalary");

                    b.Navigation("Evaluate");

                    b.Navigation("MemberProject");

                    b.Navigation("MessagesReceived");

                    b.Navigation("MessagesSent");

                    b.Navigation("OnLeave");

                    b.Navigation("Payoff");

                    b.Navigation("Tasks");

                    b.Navigation("TimeKeeping");

                    b.Navigation("TimeWorking");
                });

            modelBuilder.Entity("HRM.Entities.Position", b =>
                {
                    b.Navigation("Employee");
                });

            modelBuilder.Entity("HRM.Entities.Project", b =>
                {
                    b.Navigation("MemberProject");

                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("HRM.Entities.Salary", b =>
                {
                    b.Navigation("EmployeeSalary");
                });
#pragma warning restore 612, 618
        }
    }
}
