using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Teretana.Models;

public partial class TeretanaContext : DbContext
{
    public TeretanaContext()
    {
    }

    public TeretanaContext(DbContextOptions<TeretanaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Clanarina> Clanarinas { get; set; }

    public virtual DbSet<Dobavljac> Dobavljacs { get; set; }

    public virtual DbSet<Klijent> Klijents { get; set; }

    public virtual DbSet<Porudzbenica> Porudzbenicas { get; set; }

    public virtual DbSet<Proizvod> Proizvods { get; set; }

    public virtual DbSet<Racun> Racuns { get; set; }

    public virtual DbSet<Radnik> Radniks { get; set; }

    public virtual DbSet<StavkaPorudzbenice> StavkaPorudzbenices { get; set; }

    public virtual DbSet<StavkaRacuna> StavkaRacunas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-UVCONGE\\SQLSERVER;Database=Teretana;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Clanarina>(entity =>
        {
            entity.ToTable("Clanarina");

            entity.Property(e => e.ClanarinaId)
                .HasMaxLength(50)
                .HasColumnName("ClanarinaID");
            entity.Property(e => e.NazivClanarine).HasMaxLength(50);
        });

        modelBuilder.Entity<Dobavljac>(entity =>
        {
            entity.ToTable("Dobavljac");

            entity.Property(e => e.DobavljacId)
                .HasMaxLength(50)
                .HasColumnName("DobavljacID");
            entity.Property(e => e.Adresa).HasMaxLength(50);
            entity.Property(e => e.BrojTelefona).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.NazivDobavljaca).HasMaxLength(50);
        });

        modelBuilder.Entity<Klijent>(entity =>
        {
            entity.ToTable("Klijent");

            entity.Property(e => e.KlijentId).HasColumnName("KlijentID");
            entity.Property(e => e.Adresa).HasMaxLength(50);
            entity.Property(e => e.BrojTelefona).HasMaxLength(50);
            entity.Property(e => e.ClanarinaId)
                .HasMaxLength(50)
                .HasColumnName("ClanarinaID");
            entity.Property(e => e.DatumIstekaClanarine).HasColumnType("date");
            entity.Property(e => e.DatumPocetkaClanarine).HasColumnType("date");
            entity.Property(e => e.DatumRodjenja).HasColumnType("date");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Ime).HasMaxLength(50);
            entity.Property(e => e.Prezime).HasMaxLength(50);
            entity.Property(e => e.Sifra).HasMaxLength(50);

            entity.HasOne(d => d.Clanarina).WithMany(p => p.Klijents)
                .HasForeignKey(d => d.ClanarinaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Klijent_Clanarina");
        });

        modelBuilder.Entity<Porudzbenica>(entity =>
        {
            entity.ToTable("Porudzbenica");

            entity.Property(e => e.PorudzbenicaId).HasColumnName("PorudzbenicaID");
            entity.Property(e => e.DatumKreiranja).HasColumnType("date");
            entity.Property(e => e.DobavljacId)
                .HasMaxLength(50)
                .HasColumnName("DobavljacID");
            entity.Property(e => e.RadnikId)
                .HasMaxLength(50)
                .HasColumnName("RadnikID");

            entity.HasOne(d => d.Dobavljac).WithMany(p => p.Porudzbenicas)
                .HasForeignKey(d => d.DobavljacId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Porudzbenica_Dobavljac");

            entity.HasOne(d => d.Radnik).WithMany(p => p.Porudzbenicas)
                .HasForeignKey(d => d.RadnikId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Porudzbenica_Radnik");
        });

        modelBuilder.Entity<Proizvod>(entity =>
        {
            entity.ToTable("Proizvod");

            entity.Property(e => e.ProizvodId)
                .HasMaxLength(50)
                .HasColumnName("ProizvodID");
            entity.Property(e => e.NazivProizvoda).HasMaxLength(50);
            entity.Property(e => e.Slika).HasMaxLength(50);
        });

        modelBuilder.Entity<Racun>(entity =>
        {
            entity.ToTable("Racun");

            entity.Property(e => e.RacunId).HasColumnName("RacunID");
            entity.Property(e => e.DatumKreiranja).HasColumnType("date");
            entity.Property(e => e.KlijentId).HasColumnName("KlijentID");

            entity.HasOne(d => d.Klijent).WithMany(p => p.Racuns)
                .HasForeignKey(d => d.KlijentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Racun_Klijent");
        });

        modelBuilder.Entity<Radnik>(entity =>
        {
            entity.ToTable("Radnik");

            entity.Property(e => e.RadnikId)
                .HasMaxLength(50)
                .HasColumnName("RadnikID");
            entity.Property(e => e.Adresa).HasMaxLength(50);
            entity.Property(e => e.BrojTelefona).HasMaxLength(50);
            entity.Property(e => e.DatumRodjenja).HasColumnType("date");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Ime).HasMaxLength(50);
            entity.Property(e => e.Prezime).HasMaxLength(50);
            entity.Property(e => e.Sifra).HasMaxLength(50);
        });

        modelBuilder.Entity<StavkaPorudzbenice>(entity =>
        {
            entity.HasKey(e => new { e.PorudzbenicaId, e.StavkaId });

            entity.ToTable("StavkaPorudzbenice");

            entity.Property(e => e.PorudzbenicaId).HasColumnName("PorudzbenicaID");
            entity.Property(e => e.StavkaId)
                .ValueGeneratedOnAdd()
                .HasColumnName("StavkaID");
            entity.Property(e => e.NazivStavke).HasMaxLength(50);
            entity.Property(e => e.ProizvodId)
                .HasMaxLength(50)
                .HasColumnName("ProizvodID");

            entity.HasOne(d => d.Porudzbenica).WithMany(p => p.StavkaPorudzbenices)
                .HasForeignKey(d => d.PorudzbenicaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StavkaPorudzbenice_Porudzbenica");

            entity.HasOne(d => d.Proizvod).WithMany(p => p.StavkaPorudzbenices)
                .HasForeignKey(d => d.ProizvodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StavkaPorudzbenice_Proizvod");
        });

        modelBuilder.Entity<StavkaRacuna>(entity =>
        {
            entity.HasKey(e => new { e.RacunId, e.StavkaId });

            entity.ToTable("StavkaRacuna");

            entity.Property(e => e.RacunId).HasColumnName("RacunID");
            entity.Property(e => e.StavkaId)
                .ValueGeneratedOnAdd()
                .HasColumnName("StavkaID");
            entity.Property(e => e.NazivStavke).HasMaxLength(50);
            entity.Property(e => e.ProizvodId)
                .HasMaxLength(50)
                .HasColumnName("ProizvodID");

            entity.HasOne(d => d.Proizvod).WithMany(p => p.StavkaRacunas)
                .HasForeignKey(d => d.ProizvodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StavkaRacuna_Proizvod");

            entity.HasOne(d => d.Racun).WithMany(p => p.StavkaRacunas)
                .HasForeignKey(d => d.RacunId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StavkaRacuna_Racun");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
