using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace HandsOnAPIUsingEF.Entities
{
    public partial class TrainingContext : DbContext
    {
        public TrainingContext()
        {
        }

        public TrainingContext(DbContextOptions<TrainingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BookMaster> BookMasters { get; set; }
        public virtual DbSet<BookTransaction> BookTransactions { get; set; }
        public virtual DbSet<Contractor> Contractors { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<DepartmentMaster> DepartmentMasters { get; set; }
        public virtual DbSet<DesignMaster> DesignMasters { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<StaffMaster> StaffMasters { get; set; }
        public virtual DbSet<StudentMark> StudentMarks { get; set; }
        public virtual DbSet<StudentMaster> StudentMasters { get; set; }
        public virtual DbSet<TestRethrow> TestRethrows { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-8I01QIN;Initial Catalog=Training;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<BookMaster>(entity =>
            {
                entity.HasKey(e => e.BookCode)
                    .HasName("PK__Book_Mas__BC2BA8A7041F4D24");

                entity.ToTable("Book_Master");

                entity.Property(e => e.BookCode)
                    .HasColumnType("numeric(10, 0)")
                    .HasColumnName("Book_code");

                entity.Property(e => e.Author)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.BookCategory)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("book_category");

                entity.Property(e => e.BookName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Book_name");

                entity.Property(e => e.PubYear).HasColumnName("pub_year");
            });

            modelBuilder.Entity<BookTransaction>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Book_Transaction");

                entity.Property(e => e.ActualReturnDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Actual_Return_date");

                entity.Property(e => e.BookCode)
                    .HasColumnType("numeric(10, 0)")
                    .HasColumnName("Book_code");

                entity.Property(e => e.ExpReturnDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Exp_Return_date");

                entity.Property(e => e.IssueDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Issue_date");

                entity.Property(e => e.StaffCode)
                    .HasColumnType("numeric(8, 0)")
                    .HasColumnName("Staff_code");

                entity.Property(e => e.StudCode)
                    .HasColumnType("numeric(6, 0)")
                    .HasColumnName("Stud_code");

                entity.HasOne(d => d.BookCodeNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.BookCode)
                    .HasConstraintName("FK__Book_Tran__Book___3A81B327");

                entity.HasOne(d => d.StaffCodeNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.StaffCode)
                    .HasConstraintName("FK__Book_Tran__Staff__3C69FB99");

                entity.HasOne(d => d.StudCodeNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.StudCode)
                    .HasConstraintName("FK__Book_Tran__Stud___3B75D760");
            });

            modelBuilder.Entity<Contractor>(entity =>
            {
                entity.Property(e => e.ContractorId).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Customer");

                entity.HasIndex(e => e.Customerid, "UQ__Customer__A4AD5891AAA7EA4C")
                    .IsUnique();

                entity.Property(e => e.Address1)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Address2)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ContactNumber)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DepartmentMaster>(entity =>
            {
                entity.HasKey(e => e.DeptCode)
                    .HasName("PK__Departme__B5AD70E913BDB6B1");

                entity.ToTable("Department_Master");

                entity.HasIndex(e => e.DeptName, "UQ__Departme__B744FF0F63548C46")
                    .IsUnique();

                entity.Property(e => e.DeptCode)
                    .HasColumnType("numeric(2, 0)")
                    .HasColumnName("Dept_code");

                entity.Property(e => e.DeptName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Dept_Name");
            });

            modelBuilder.Entity<DesignMaster>(entity =>
            {
                entity.HasKey(e => e.DesignCode)
                    .HasName("PK__Desig_ma__C6271B67D2B533C6");

                entity.ToTable("Design_Master");

                entity.HasIndex(e => e.DesignName, "UQ__Desig_ma__E07C1CF55501FF49")
                    .IsUnique();

                entity.Property(e => e.DesignCode)
                    .HasColumnType("numeric(3, 0)")
                    .HasColumnName("Design_Code");

                entity.Property(e => e.DesignName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Design_Name");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.EmployeeId).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<StaffMaster>(entity =>
            {
                entity.HasKey(e => e.StaffCode)
                    .HasName("PK__Staff_Ma__5FB09B0E87850450");

                entity.ToTable("Staff_Master");

                entity.Property(e => e.StaffCode)
                    .HasColumnType("numeric(8, 0)")
                    .HasColumnName("Staff_Code");

                entity.Property(e => e.Address)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DeptCode)
                    .HasColumnType("numeric(2, 0)")
                    .HasColumnName("Dept_Code");

                entity.Property(e => e.DesCode)
                    .HasColumnType("numeric(3, 0)")
                    .HasColumnName("Des_Code");

                entity.Property(e => e.Hiredate).HasColumnType("datetime");

                entity.Property(e => e.MgrCode)
                    .HasColumnType("numeric(8, 0)")
                    .HasColumnName("Mgr_code");

                entity.Property(e => e.MgrName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Mgr_name");

                entity.Property(e => e.Salary).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.StaffDob)
                    .HasColumnType("datetime")
                    .HasColumnName("Staff_dob");

                entity.Property(e => e.StaffName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Staff_Name");

                entity.HasOne(d => d.DeptCodeNavigation)
                    .WithMany(p => p.StaffMasters)
                    .HasForeignKey(d => d.DeptCode)
                    .HasConstraintName("FK__Staff_Mas__Dept___36B12243");

                entity.HasOne(d => d.DesCodeNavigation)
                    .WithMany(p => p.StaffMasters)
                    .HasForeignKey(d => d.DesCode)
                    .HasConstraintName("FK__Staff_Mas__Des_C__35BCFE0A");
            });

            modelBuilder.Entity<StudentMark>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Student_Marks");

                entity.Property(e => e.StudCode)
                    .HasColumnType("numeric(6, 0)")
                    .HasColumnName("Stud_Code");

                entity.Property(e => e.StudYear).HasColumnName("Stud_Year");

                entity.Property(e => e.Subject1).HasColumnType("numeric(3, 0)");

                entity.Property(e => e.Subject2).HasColumnType("numeric(3, 0)");

                entity.Property(e => e.Subject3).HasColumnType("numeric(3, 0)");

                entity.HasOne(d => d.StudCodeNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.StudCode)
                    .HasConstraintName("FK__Student_M__Stud___32E0915F");
            });

            modelBuilder.Entity<StudentMaster>(entity =>
            {
                entity.HasKey(e => e.StudCode)
                    .HasName("PK__Student___67F2A9643F41718B");

                entity.ToTable("Student_Master");

                entity.Property(e => e.StudCode)
                    .HasColumnType("numeric(6, 0)")
                    .HasColumnName("Stud_Code");

                entity.Property(e => e.Address)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DeptCode)
                    .HasColumnType("numeric(2, 0)")
                    .HasColumnName("Dept_Code");

                entity.Property(e => e.StudDob)
                    .HasColumnType("datetime")
                    .HasColumnName("Stud_Dob");

                entity.Property(e => e.StudName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Stud_Name");

                entity.HasOne(d => d.DeptCodeNavigation)
                    .WithMany(p => p.StudentMasters)
                    .HasForeignKey(d => d.DeptCode)
                    .HasConstraintName("FK__Student_m__Dept___30F848ED");
            });

            modelBuilder.Entity<TestRethrow>(entity =>
            {
                entity.ToTable("TestRethrow");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
