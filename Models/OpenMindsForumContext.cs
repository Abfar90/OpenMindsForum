using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OpenMindsForum.Models;

public partial class OpenMindsForumContext : DbContext
{
    public OpenMindsForumContext()
    {
    }

    public OpenMindsForumContext(DbContextOptions<OpenMindsForumContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<Thread> Threads { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comment>(entity =>
        {
            entity.ToTable("Comment");

            entity.Property(e => e.CommentId).HasColumnName("commentID");
            entity.Property(e => e.Comment1).HasColumnName("comment");
            entity.Property(e => e.CommentStamp)
                .HasColumnType("datetime")
                .HasColumnName("commentStamp");
            entity.Property(e => e.PostId).HasColumnName("postID");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasColumnName("title");

            entity.HasOne(d => d.Post).WithMany(p => p.Comments)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comment_Post");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.ToTable("Post");

            entity.Property(e => e.PostId).HasColumnName("postID");
            entity.Property(e => e.PostContent).HasColumnName("postContent");
            entity.Property(e => e.PostStamp)
                .HasColumnType("datetime")
                .HasColumnName("postStamp");
            entity.Property(e => e.SubjectId).HasColumnName("subjectID");
            entity.Property(e => e.ThreadId).HasColumnName("threadID");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("title");

            entity.HasOne(d => d.Subject).WithMany(p => p.Posts)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Post_Subject");

            entity.HasOne(d => d.Thread).WithMany(p => p.Posts)
                .HasForeignKey(d => d.ThreadId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Post_Thread");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.ToTable("Subject");

            entity.Property(e => e.SubjectId).HasColumnName("subjectID");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Thread>(entity =>
        {
            entity.ToTable("Thread");

            entity.Property(e => e.ThreadId).HasColumnName("threadID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
