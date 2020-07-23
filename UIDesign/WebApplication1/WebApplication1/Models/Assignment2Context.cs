using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HuntingAssociation.Models
{
    public partial class Assignment2Context : DbContext
    {
        public Assignment2Context()
        {
        }

        public Assignment2Context(DbContextOptions<Assignment2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Association> Association { get; set; }
        public virtual DbSet<Authorisation> Authorisation { get; set; }
        public virtual DbSet<AuthorisationRifle> AuthorisationRifle { get; set; }
        public virtual DbSet<AuthorisationSpecies> AuthorisationSpecies { get; set; }
        public virtual DbSet<AuthorisationUser> AuthorisationUser { get; set; }
        public virtual DbSet<County> County { get; set; }
        public virtual DbSet<HuntingGround> HuntingGround { get; set; }
        public virtual DbSet<HuntingGroundSpecies> HuntingGroundSpecies { get; set; }
        public virtual DbSet<HuntingType> HuntingType { get; set; }
        public virtual DbSet<Rifle> Rifle { get; set; }
        public virtual DbSet<RiflePipeType> RiflePipeType { get; set; }
        public virtual DbSet<Species> Species { get; set; }
        public virtual DbSet<SpeciesHuntingType> SpeciesHuntingType { get; set; }
        public virtual DbSet<SpeciesRifle> SpeciesRifle { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserAssociation> UserAssociation { get; set; }
        public virtual DbSet<UserFunction> UserFunction { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=206.225.95.122;Database=Assignment2;user id=victor;password=Assignment2");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Association>(entity =>
            {
                entity.ToTable("association");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.IdCounty).HasColumnName("id_county");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCountyNavigation)
                    .WithMany(p => p.Association)
                    .HasForeignKey(d => d.IdCounty)
                    .HasConstraintName("FK_association_county");
            });

            modelBuilder.Entity<Authorisation>(entity =>
            {
                entity.ToTable("authorisation");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EndDate)
                    .HasColumnName("end_date")
                    .HasColumnType("date");

                entity.Property(e => e.IdHuntingGround).HasColumnName("id_hunting_ground");

                entity.Property(e => e.IdHuntingType).HasColumnName("id_hunting_type");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.InsertDate)
                    .HasColumnName("insert_date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NoHunts).HasColumnName("no_hunts");

                entity.Property(e => e.StartDate)
                    .HasColumnName("start_date")
                    .HasColumnType("date");

                entity.HasOne(d => d.IdHuntingGroundNavigation)
                    .WithMany(p => p.Authorisation)
                    .HasForeignKey(d => d.IdHuntingGround)
                    .HasConstraintName("FK_authorisation_huntingground");

                entity.HasOne(d => d.IdHuntingTypeNavigation)
                    .WithMany(p => p.Authorisation)
                    .HasForeignKey(d => d.IdHuntingType)
                    .HasConstraintName("FK_authorisation_hunting_type");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Authorisation)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK_authorisation_user");
            });

            modelBuilder.Entity<AuthorisationRifle>(entity =>
            {
                entity.ToTable("authorisation_rifle");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdAuthorisation).HasColumnName("id_authorisation");

                entity.Property(e => e.IdRifle).HasColumnName("id_rifle");

                entity.HasOne(d => d.IdAuthorisationNavigation)
                    .WithMany(p => p.AuthorisationRifle)
                    .HasForeignKey(d => d.IdAuthorisation)
                    .HasConstraintName("FK_authorisation_rifle_authorisation");

                entity.HasOne(d => d.IdRifleNavigation)
                    .WithMany(p => p.AuthorisationRifle)
                    .HasForeignKey(d => d.IdRifle)
                    .HasConstraintName("FK_authorisation_rifle_rifle");
            });

            modelBuilder.Entity<AuthorisationSpecies>(entity =>
            {
                entity.ToTable("authorisation_species");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdAuthorisation).HasColumnName("id_authorisation");

                entity.Property(e => e.IdSpecies).HasColumnName("id_species");

                entity.Property(e => e.NoAllowed).HasColumnName("no_allowed");

                entity.Property(e => e.NoKilled).HasColumnName("no_killed");

                entity.HasOne(d => d.IdAuthorisationNavigation)
                    .WithMany(p => p.AuthorisationSpecies)
                    .HasForeignKey(d => d.IdAuthorisation)
                    .HasConstraintName("FK_speciesauth_authorisation");

                entity.HasOne(d => d.IdSpeciesNavigation)
                    .WithMany(p => p.AuthorisationSpecies)
                    .HasForeignKey(d => d.IdSpecies)
                    .HasConstraintName("FK_speciesauth_species");
            });

            modelBuilder.Entity<AuthorisationUser>(entity =>
            {
                entity.ToTable("authorisation_user");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdAuthorisation).HasColumnName("id_authorisation");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.HasOne(d => d.IdAuthorisationNavigation)
                    .WithMany(p => p.AuthorisationUser)
                    .HasForeignKey(d => d.IdAuthorisation)
                    .HasConstraintName("FK_userauth_authorisation");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.AuthorisationUser)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK_userauth_user");
            });

            modelBuilder.Entity<County>(entity =>
            {
                entity.ToTable("county");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.County1)
                    .HasColumnName("county")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HuntingGround>(entity =>
            {
                entity.ToTable("hunting_ground");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdAssociation).HasColumnName("id_association");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAssociationNavigation)
                    .WithMany(p => p.HuntingGround)
                    .HasForeignKey(d => d.IdAssociation)
                    .HasConstraintName("FK_hunting_ground_association");
            });

            modelBuilder.Entity<HuntingGroundSpecies>(entity =>
            {
                entity.ToTable("hunting_ground_species");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdHuntingground).HasColumnName("id_huntingground");

                entity.Property(e => e.IdSpecies).HasColumnName("id_species");

                entity.Property(e => e.Quota).HasColumnName("quota");

                entity.Property(e => e.Season).HasColumnName("season");

                entity.HasOne(d => d.IdHuntinggroundNavigation)
                    .WithMany(p => p.HuntingGroundSpecies)
                    .HasForeignKey(d => d.IdHuntingground)
                    .HasConstraintName("FK_auxSpeciesHunting_huntingground");

                entity.HasOne(d => d.IdSpeciesNavigation)
                    .WithMany(p => p.HuntingGroundSpecies)
                    .HasForeignKey(d => d.IdSpecies)
                    .HasConstraintName("FK_auxSpeciesHunting_species");
            });

            modelBuilder.Entity<HuntingType>(entity =>
            {
                entity.ToTable("hunting_type");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.TypeName)
                    .HasColumnName("type_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Rifle>(entity =>
            {
                entity.ToTable("rifle");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CartridgeDiameter)
                    .HasColumnName("cartridge_diameter")
                    .HasColumnType("decimal(3, 1)");

                entity.Property(e => e.CartridgeLength).HasColumnName("cartridge_length");

                entity.Property(e => e.CartridgeWeight).HasColumnName("cartridge_weight");

                entity.Property(e => e.Energy).HasColumnName("energy");

                entity.Property(e => e.IdRiflePipeType).HasColumnName("id_rifle_pipe_type");

                entity.Property(e => e.PelletDiameter)
                    .HasColumnName("pellet_diameter")
                    .HasColumnType("decimal(3, 1)");

                entity.HasOne(d => d.IdRiflePipeTypeNavigation)
                    .WithMany(p => p.Rifle)
                    .HasForeignKey(d => d.IdRiflePipeType)
                    .HasConstraintName("FK_rifle_rifle_pipe_type");
            });

            modelBuilder.Entity<RiflePipeType>(entity =>
            {
                entity.ToTable("rifle_pipe_type");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.PipeType)
                    .HasColumnName("pipe_type")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Species>(entity =>
            {
                entity.ToTable("species");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EndDate)
                    .HasColumnName("end_date")
                    .HasColumnType("date");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sex).HasColumnName("sex");

                entity.Property(e => e.StartDate)
                    .HasColumnName("start_date")
                    .HasColumnType("date");

                entity.Property(e => e.Type).HasColumnName("type");
            });

            modelBuilder.Entity<SpeciesHuntingType>(entity =>
            {
                entity.ToTable("species_hunting_type");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdHuntingType).HasColumnName("id_hunting_type");

                entity.Property(e => e.IdSpecies).HasColumnName("id_species");

                entity.HasOne(d => d.IdHuntingTypeNavigation)
                    .WithMany(p => p.SpeciesHuntingType)
                    .HasForeignKey(d => d.IdHuntingType)
                    .HasConstraintName("FK_species_hunting_type_hunting_type");

                entity.HasOne(d => d.IdSpeciesNavigation)
                    .WithMany(p => p.SpeciesHuntingType)
                    .HasForeignKey(d => d.IdSpecies)
                    .HasConstraintName("FK_species_hunting_type_species");
            });

            modelBuilder.Entity<SpeciesRifle>(entity =>
            {
                entity.ToTable("species_rifle");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdRifle).HasColumnName("id_rifle");

                entity.Property(e => e.IdSpecies).HasColumnName("id_species");

                entity.HasOne(d => d.IdRifleNavigation)
                    .WithMany(p => p.SpeciesRifle)
                    .HasForeignKey(d => d.IdRifle)
                    .HasConstraintName("FK_auxGunSpecies_gun");

                entity.HasOne(d => d.IdSpeciesNavigation)
                    .WithMany(p => p.SpeciesRifle)
                    .HasForeignKey(d => d.IdSpecies)
                    .HasConstraintName("FK_auxGunSpecies_species");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cnp)
                    .HasColumnName("cnp")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Insurance)
                    .HasColumnName("insurance")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.License)
                    .HasColumnName("license")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .HasColumnName("surname")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserAssociation>(entity =>
            {
                entity.ToTable("user_association");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdAssociation).HasColumnName("id_association");

                entity.Property(e => e.IdFunction).HasColumnName("id_function");

                entity.Property(e => e.IdRole).HasColumnName("id_role");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.HasOne(d => d.IdAssociationNavigation)
                    .WithMany(p => p.UserAssociation)
                    .HasForeignKey(d => d.IdAssociation)
                    .HasConstraintName("FK_auxUserAssoc_association");

                entity.HasOne(d => d.IdFunctionNavigation)
                    .WithMany(p => p.UserAssociation)
                    .HasForeignKey(d => d.IdFunction)
                    .HasConstraintName("FK_user_association_user_function");

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.UserAssociation)
                    .HasForeignKey(d => d.IdRole)
                    .HasConstraintName("FK_user_association_user_role");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.UserAssociation)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK_auxUserAssoc_user");
            });

            modelBuilder.Entity<UserFunction>(entity =>
            {
                entity.ToTable("user_function");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FunctionName)
                    .HasColumnName("function_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("user_role");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
