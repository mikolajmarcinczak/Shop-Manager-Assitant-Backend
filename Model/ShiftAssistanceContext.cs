using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Shop_Manager_Assitant_Backend.Model;

public partial class ShiftAssistanceContext : DbContext
{
    public ShiftAssistanceContext()
    {
    }

    public ShiftAssistanceContext(DbContextOptions<ShiftAssistanceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<DayValue> DayValues { get; set; }

    public virtual DbSet<Shift> Shifts { get; set; }

    public virtual DbSet<ShiftValue> ShiftValues { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=ESPER\\SQLEXPRESSLOCAL;Initial Catalog=ShiftAssistance;Trusted_Connection=true;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__City__3214EC077057F442");

            entity.ToTable("City");

            entity.Property(e => e.RoleName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DayValue>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DayValue__3214EC0724F8CC4A");

            entity.ToTable("DayValue");

            entity.Property(e => e.Friday).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Monday).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Saturday).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Sunday).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Thursday).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Tuesday).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Wednesday).HasColumnType("decimal(18, 0)");
        });

        modelBuilder.Entity<Shift>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Shift__3214EC075466FDD5");

            entity.ToTable("Shift");

            entity.Property(e => e.AccountBalance).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Date).HasColumnType("datetime");

            entity.HasOne(d => d.City).WithMany(p => p.Shifts)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("FK__Shift__CityId__2E1BDC42");

            entity.HasOne(d => d.ShiftNumberNavigation).WithMany(p => p.Shifts)
                .HasForeignKey(d => d.ShiftNumber)
                .HasConstraintName("FK__Shift__ShiftNumb__2D27B809");

            entity.HasOne(d => d.User2).WithMany(p => p.ShiftUser2s)
                .HasForeignKey(d => d.User2Id)
                .HasConstraintName("FK__Shift__User2Id__300424B4");

            entity.HasOne(d => d.User3).WithMany(p => p.ShiftUser3s)
                .HasForeignKey(d => d.User3Id)
                .HasConstraintName("FK__Shift__User3Id__30F848ED");

            entity.HasOne(d => d.User4).WithMany(p => p.ShiftUser4s)
                .HasForeignKey(d => d.User4Id)
                .HasConstraintName("FK__Shift__User4Id__31EC6D26");

            entity.HasOne(d => d.User).WithMany(p => p.ShiftUsers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Shift__UserId__2F10007B");
        });

        modelBuilder.Entity<ShiftValue>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ShiftVal__3214EC0769217961");

            entity.ToTable("ShiftValue");

            entity.Property(e => e.ShiftNumber)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ShiftValueVal)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("ShiftValue_val");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC079E209094");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Surname)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.City).WithMany(p => p.Users)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("FK__Users__CityId__267ABA7A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
