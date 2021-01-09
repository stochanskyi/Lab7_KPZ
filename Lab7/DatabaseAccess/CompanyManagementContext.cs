using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Lab7.DatabaseAccess
{
    public partial class CompanyManagementContext : DbContext
    {
        public CompanyManagementContext()
        {
        }

        public CompanyManagementContext(DbContextOptions<CompanyManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccessLevel> AccessLevels { get; set; }
        public virtual DbSet<AllPayment> AllPayments { get; set; }
        public virtual DbSet<Board> Boards { get; set; }
        public virtual DbSet<BoardTask> BoardTasks { get; set; }
        public virtual DbSet<BordColum> BordColums { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerPayment> CustomerPayments { get; set; }
        public virtual DbSet<PaymentType> PaymentTypes { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ProjectPhase> ProjectPhases { get; set; }
        public virtual DbSet<ProjectStatus> ProjectStatuses { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<TeamInBoard> TeamInBoards { get; set; }
        public virtual DbSet<TeamInProject> TeamInProjects { get; set; }
        public virtual DbSet<Worker> Workers { get; set; }
        public virtual DbSet<WorkerInTeam> WorkerInTeams { get; set; }
        public virtual DbSet<WorkerPayment> WorkerPayments { get; set; }
        public virtual DbSet<WorkerPaymentStatus> WorkerPaymentStatuses { get; set; }
        public virtual DbSet<WorkerProject> WorkerProjects { get; set; }
        public virtual DbSet<WorkerSelary> WorkerSelarys { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-59EBKJC;Database=CompanyManagement;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AccessLevel>(entity =>
            {
                entity.HasKey(e => e.LevelId);

                entity.Property(e => e.LevelId).HasColumnName("level_id");

                entity.Property(e => e.LevelName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("level_name");
            });

            modelBuilder.Entity<AllPayment>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("AllPayments", "Bookkeeper");

                entity.Property(e => e.Amount)
                    .HasColumnType("numeric(6, 2)")
                    .HasColumnName("amount");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("last_name");

                entity.Property(e => e.PaymentDate)
                    .HasColumnType("date")
                    .HasColumnName("payment_date");
            });

            modelBuilder.Entity<Board>(entity =>
            {
                entity.Property(e => e.BoardId).HasColumnName("board_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("name");

                entity.Property(e => e.ProjectId).HasColumnName("project_id");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Boards)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK_Boards_Projects");
            });

            modelBuilder.Entity<BoardTask>(entity =>
            {
                entity.HasKey(e => e.TaskId);

                entity.Property(e => e.TaskId).HasColumnName("task_id");

                entity.Property(e => e.AssignedId).HasColumnName("assigned_id");

                entity.Property(e => e.ColumnId).HasColumnName("column_id");

                entity.Property(e => e.DueDate)
                    .HasColumnType("date")
                    .HasColumnName("due_date");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.PhaseId).HasColumnName("phase_id");

                entity.HasOne(d => d.Assigned)
                    .WithMany(p => p.BoardTasks)
                    .HasForeignKey(d => d.AssignedId)
                    .HasConstraintName("FK_BoardTasks_Workers");

                entity.HasOne(d => d.Column)
                    .WithMany(p => p.BoardTasks)
                    .HasForeignKey(d => d.ColumnId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BoardTasks_BordColums");

                entity.HasOne(d => d.Phase)
                    .WithMany(p => p.BoardTasks)
                    .HasForeignKey(d => d.PhaseId)
                    .HasConstraintName("FK_BoardTasks_ProjectPhases");
            });

            modelBuilder.Entity<BordColum>(entity =>
            {
                entity.HasKey(e => e.ColumnId)
                    .HasName("PK_BardColums");

                entity.Property(e => e.ColumnId).HasColumnName("column_id");

                entity.Property(e => e.BoardId).HasColumnName("board_id");

                entity.Property(e => e.ColumnPosition).HasColumnName("column_position");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.HasOne(d => d.Board)
                    .WithMany(p => p.BordColums)
                    .HasForeignKey(d => d.BoardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BordColums_Boards");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustId);

                entity.Property(e => e.CustId).HasColumnName("cust_id");

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .HasColumnName("country");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasColumnName("last_name");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("phone_number");
            });

            modelBuilder.Entity<CustomerPayment>(entity =>
            {
                entity.HasKey(e => e.PaymentId);

                entity.Property(e => e.PaymentId).HasColumnName("payment_id");

                entity.Property(e => e.Amount)
                    .HasColumnType("numeric(9, 2)")
                    .HasColumnName("amount");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.ProjectId).HasColumnName("project_id");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerPayments)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerPayments_Customers1");
            });

            modelBuilder.Entity<PaymentType>(entity =>
            {
                entity.HasKey(e => e.TypeId);

                entity.Property(e => e.TypeId).HasColumnName("type_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.Property(e => e.PositionId).HasColumnName("position_id");

                entity.Property(e => e.PositionName)
                    .HasMaxLength(50)
                    .HasColumnName("position_name");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasIndex(e => e.StatusId, "IDX_Project_Status");

                entity.Property(e => e.ProjectId).HasColumnName("project_id");

                entity.Property(e => e.Budget)
                    .HasColumnType("numeric(10, 2)")
                    .HasColumnName("budget");

                entity.Property(e => e.CustId).HasColumnName("cust_id");

                entity.Property(e => e.Description)
                    .HasMaxLength(300)
                    .HasColumnName("description");

                entity.Property(e => e.ProjectName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("project_name");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.CustId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Projects_Customers");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Projects_ProjectStatuses");
            });

            modelBuilder.Entity<ProjectPhase>(entity =>
            {
                entity.HasKey(e => e.PhaseId);

                entity.Property(e => e.PhaseId).HasColumnName("phase_id");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("end_date");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.ProjectId).HasColumnName("project_id");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("start_date");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ProjectPhases)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProjectPhases_Projects");
            });

            modelBuilder.Entity<ProjectStatus>(entity =>
            {
                entity.HasKey(e => e.StatusId);

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.Property(e => e.StatusName)
                    .HasMaxLength(50)
                    .HasColumnName("status_name");
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.Property(e => e.TeamId).HasColumnName("team_id");

                entity.Property(e => e.TeamName)
                    .HasMaxLength(50)
                    .HasColumnName("team_name");
            });

            modelBuilder.Entity<TeamInBoard>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TeamInBoard");

                entity.Property(e => e.BoardId).HasColumnName("board_id");

                entity.Property(e => e.TeamId).HasColumnName("team_id");

                entity.HasOne(d => d.Board)
                    .WithMany()
                    .HasForeignKey(d => d.BoardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TeamInBoard_Boards");

                entity.HasOne(d => d.Team)
                    .WithMany()
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TeamInBoard_Teams");
            });

            modelBuilder.Entity<TeamInProject>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TeamInProject");

                entity.Property(e => e.ProjectId).HasColumnName("project_id");

                entity.Property(e => e.TeamId).HasColumnName("team_id");
            });

            modelBuilder.Entity<Worker>(entity =>
            {
                entity.HasIndex(e => e.PositionId, "IDX_Worker_Position");

                entity.Property(e => e.WorkerId).HasColumnName("worker_id");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("last_name");

                entity.Property(e => e.LevelId).HasColumnName("level_id");

                entity.Property(e => e.PositionId).HasColumnName("position_id");

                entity.HasOne(d => d.Level)
                    .WithMany(p => p.Workers)
                    .HasForeignKey(d => d.LevelId)
                    .HasConstraintName("FK_Workers_AccessLevels");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Workers)
                    .HasForeignKey(d => d.PositionId)
                    .HasConstraintName("FK_Workers_Positions");
            });

            modelBuilder.Entity<WorkerInTeam>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("WorkerInTeam");

                entity.Property(e => e.TeamId).HasColumnName("team_id");

                entity.Property(e => e.WorkerId).HasColumnName("worker_id");

                entity.HasOne(d => d.Team)
                    .WithMany()
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WorkerInTeam_Teams");

                entity.HasOne(d => d.Worker)
                    .WithMany()
                    .HasForeignKey(d => d.WorkerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WorkerInTeam_Workers");
            });

            modelBuilder.Entity<WorkerPayment>(entity =>
            {
                entity.HasKey(e => e.PaymentId)
                    .HasName("PK_Payments");

                entity.Property(e => e.PaymentId).HasColumnName("payment_id");

                entity.Property(e => e.Amount)
                    .HasColumnType("numeric(6, 2)")
                    .HasColumnName("amount");

                entity.Property(e => e.ConfirmerId).HasColumnName("confirmer_id");

                entity.Property(e => e.PaymentDate)
                    .HasColumnType("date")
                    .HasColumnName("payment_date");

                entity.Property(e => e.PaymentStatusId).HasColumnName("payment_status_id");

                entity.Property(e => e.PaymentTypeId).HasColumnName("payment_type_id");

                entity.Property(e => e.ReceiverId).HasColumnName("receiver_id");

                entity.HasOne(d => d.Confirmer)
                    .WithMany(p => p.WorkerPaymentConfirmers)
                    .HasForeignKey(d => d.ConfirmerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WorkerPayments_Workers1");

                entity.HasOne(d => d.PaymentStatus)
                    .WithMany(p => p.WorkerPayments)
                    .HasForeignKey(d => d.PaymentStatusId)
                    .HasConstraintName("FK_WorkerPayments_WorkerPayments");

                entity.HasOne(d => d.PaymentType)
                    .WithMany(p => p.WorkerPayments)
                    .HasForeignKey(d => d.PaymentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WorkerPayments_PaymentTypes");

                entity.HasOne(d => d.Receiver)
                    .WithMany(p => p.WorkerPaymentReceivers)
                    .HasForeignKey(d => d.ReceiverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WorkerPayments_Workers");
            });

            modelBuilder.Entity<WorkerPaymentStatus>(entity =>
            {
                entity.HasKey(e => e.StatusId);

                entity.ToTable("WorkerPaymentStatus");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<WorkerProject>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("WorkerProjects");

                entity.Property(e => e.Description)
                    .HasMaxLength(300)
                    .HasColumnName("description");

                entity.Property(e => e.ProjectName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("project_name");

                entity.Property(e => e.StatusId).HasColumnName("status_id");
            });

            modelBuilder.Entity<WorkerSelary>(entity =>
            {
                entity.HasKey(e => e.WorkerId);

                entity.Property(e => e.WorkerId)
                    .ValueGeneratedNever()
                    .HasColumnName("worker_id");

                entity.Property(e => e.Selary)
                    .HasColumnType("numeric(6, 2)")
                    .HasColumnName("selary");

                entity.HasOne(d => d.Worker)
                    .WithOne(p => p.WorkerSelary)
                    .HasForeignKey<WorkerSelary>(d => d.WorkerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WorkerSelarys_Workers");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
