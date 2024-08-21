using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LFYS_Project.Models;

public partial class WlfysProjContext : DbContext
{
    public WlfysProjContext()
    {
    }

    public WlfysProjContext(DbContextOptions<WlfysProjContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Badge> Badges { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<CategoryExercise> CategoryExercises { get; set; }

    public virtual DbSet<CategoryOfExercise> CategoryOfExercises { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<Exercise> Exercises { get; set; }

    public virtual DbSet<FileDocument> FileDocuments { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserBadge> UserBadges { get; set; }

    public virtual DbSet<Video> Videos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=KHANGLAP;Initial Catalog=WLFYS_Proj;Integrated Security=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Badge>(entity =>
        {
            entity.HasKey(e => e.BadgeId).HasName("PK__Badge__E7989656D00D235F");

            entity.ToTable("Badge");

            entity.Property(e => e.BadgeId).HasColumnName("badge_id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .HasColumnName("image_url");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Category__D54EE9B448E430AA");

            entity.ToTable("Category");

            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(255)
                .HasColumnName("category_name");
        });

        modelBuilder.Entity<CategoryExercise>(entity =>
        {
            entity.HasKey(e => e.CeId).HasName("PK__Category__DD9025CDA8A59C7D");

            entity.ToTable("CategoryExercise");

            entity.Property(e => e.CeId).HasColumnName("ce_id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.ExerciseId).HasColumnName("exercise_id");

            entity.HasOne(d => d.Category).WithMany(p => p.CategoryExercises)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__CategoryE__categ__778AC167");

            entity.HasOne(d => d.Exercise).WithMany(p => p.CategoryExercises)
                .HasForeignKey(d => d.ExerciseId)
                .HasConstraintName("FK__CategoryE__exerc__787EE5A0");
        });

        modelBuilder.Entity<CategoryOfExercise>(entity =>
        {
            entity.HasKey(e => e.CoeId).HasName("PK__Category__93E65D001E710CB9");

            entity.ToTable("CategoryOfExercise");

            entity.Property(e => e.CoeId).HasColumnName("coe_id");
            entity.Property(e => e.CoeName)
                .HasMaxLength(50)
                .HasColumnName("coe_name");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK__Course__8F1EF7AED99E5679");

            entity.ToTable("Course");

            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.Avt)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("avt");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CourseName)
                .HasMaxLength(255)
                .HasColumnName("course_name");
            entity.Property(e => e.Description)
                .HasColumnType("ntext")
                .HasColumnName("description");
            entity.Property(e => e.Discount).HasColumnName("discount");
            entity.Property(e => e.IsFree).HasColumnName("is_free");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Category).WithMany(p => p.Courses)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Course__category__6754599E");

            entity.HasOne(d => d.User).WithMany(p => p.Courses)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Course__user_id__68487DD7");
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.HasKey(e => e.DocumentId).HasName("PK__Document__9666E8AC43F29900");

            entity.ToTable("Document");

            entity.Property(e => e.DocumentId).HasColumnName("document_id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasColumnType("ntext")
                .HasColumnName("description");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Category).WithMany(p => p.Documents)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Document__catego__5535A963");

            entity.HasOne(d => d.User).WithMany(p => p.Documents)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Document__user_i__5441852A");
        });

        modelBuilder.Entity<Exercise>(entity =>
        {
            entity.HasKey(e => e.ExerciseId).HasName("PK__Exercise__C121418EF4F5647B");

            entity.ToTable("Exercise");

            entity.Property(e => e.ExerciseId).HasColumnName("exercise_id");
            entity.Property(e => e.Ac).HasColumnName("ac");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasColumnType("ntext")
                .HasColumnName("description");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Exercises)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Exercise__user_i__74AE54BC");
        });

        modelBuilder.Entity<FileDocument>(entity =>
        {
            entity.HasKey(e => e.FiledocId).HasName("PK__FileDocu__6070B1A89C157B42");

            entity.ToTable("FileDocument");

            entity.Property(e => e.FiledocId).HasColumnName("filedoc_id");
            entity.Property(e => e.DocumentId).HasColumnName("document_id");
            entity.Property(e => e.FileContent)
                .HasColumnType("ntext")
                .HasColumnName("file_content");
            entity.Property(e => e.FileTitle)
                .HasMaxLength(255)
                .HasColumnName("file_title");

            entity.HasOne(d => d.Document).WithMany(p => p.FileDocuments)
                .HasForeignKey(d => d.DocumentId)
                .HasConstraintName("FK__FileDocum__docum__6FE99F9F");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.NotificationId).HasName("PK__Notifica__E059842F62BBEACA");

            entity.ToTable("Notification");

            entity.Property(e => e.NotificationId).HasColumnName("notification_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Message)
                .HasMaxLength(255)
                .HasColumnName("message");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Notificat__user___403A8C7D");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__B9BE370F3EB7A837");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.AvatarUrl)
                .HasMaxLength(255)
                .HasColumnName("avatar_url");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.FullName)
                .HasMaxLength(100)
                .HasColumnName("full_name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .HasColumnName("role");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
        });

        modelBuilder.Entity<UserBadge>(entity =>
        {
            entity.HasKey(e => e.UserbadgeId).HasName("PK__UserBadg__B0DE4084117CEE19");

            entity.ToTable("UserBadge");

            entity.Property(e => e.UserbadgeId).HasColumnName("userbadge_id");
            entity.Property(e => e.AwardedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("awarded_at");
            entity.Property(e => e.BadgeId).HasColumnName("badge_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Badge).WithMany(p => p.UserBadges)
                .HasForeignKey(d => d.BadgeId)
                .HasConstraintName("FK__UserBadge__badge__46E78A0C");

            entity.HasOne(d => d.User).WithMany(p => p.UserBadges)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__UserBadge__user___45F365D3");
        });

        modelBuilder.Entity<Video>(entity =>
        {
            entity.HasKey(e => e.VideoId).HasName("PK__Video__E8F11E107C8BF2FB");

            entity.ToTable("Video");

            entity.Property(e => e.VideoId).HasColumnName("video_id");
            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasColumnType("ntext")
                .HasColumnName("description");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.VideoUrl)
                .HasMaxLength(255)
                .HasColumnName("video_url");

            entity.HasOne(d => d.Course).WithMany(p => p.Videos)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__Video__course_id__6D0D32F4");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
