using System;
using DesafioAtosCapital.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DesafioAtosCapital.Data
{
    public partial class dbAtosCapitalContext : DbContext
    {
        public dbAtosCapitalContext()
        {
        }

        public dbAtosCapitalContext(DbContextOptions<dbAtosCapitalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbBanco> TbBanco { get; set; }
        public virtual DbSet<TbBandeira> TbBandeira { get; set; }
        public virtual DbSet<TbContaCorrente> TbContaCorrente { get; set; }
        public virtual DbSet<TbEmpresa> TbEmpresa { get; set; }
        public virtual DbSet<TbFormaPagamento> TbFormaPagamento { get; set; }
        public virtual DbSet<TbMovimentoBanco> TbMovimentoBanco { get; set; }
        public virtual DbSet<TbPagamentoVenda> TbPagamentoVenda { get; set; }
        public virtual DbSet<TbParcela> TbParcela { get; set; }
        public virtual DbSet<TbStatusParcela> TbStatusParcela { get; set; }
        public virtual DbSet<VwPagamentosCartao> VwPagamentosCartao { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbBanco>(entity =>
            {
                entity.HasKey(e => e.IdBanco)
                    .HasName("PK__tbBanco__D8FFCB751E4A4E31");

                entity.ToTable("tbBanco", "card");

                entity.Property(e => e.IdBanco).HasColumnName("idBanco");

                entity.Property(e => e.CdBanco)
                    .IsRequired()
                    .HasColumnName("cdBanco")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.NmBanco)
                    .IsRequired()
                    .HasColumnName("nmBanco")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbBandeira>(entity =>
            {
                entity.HasKey(e => e.IdBandeira)
                    .HasName("PK__tbBandei__BE8181A9BD103FC4");

                entity.ToTable("tbBandeira", "card");

                entity.Property(e => e.IdBandeira).HasColumnName("idBandeira");

                entity.Property(e => e.DsBandeira)
                    .IsRequired()
                    .HasColumnName("dsBandeira")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbContaCorrente>(entity =>
            {
                entity.HasKey(e => e.IdContaCorrente)
                    .HasName("PK__tbContaC__5CDA6508B32FE1C2");

                entity.ToTable("tbContaCorrente", "card");

                entity.Property(e => e.IdContaCorrente).HasColumnName("idContaCorrente");

                entity.Property(e => e.DsContaCorrente)
                    .IsRequired()
                    .HasColumnName("dsContaCorrente")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdBanco).HasColumnName("idBanco");

                entity.Property(e => e.IdEmpresa).HasColumnName("idEmpresa");

                entity.Property(e => e.NrAgencia)
                    .IsRequired()
                    .HasColumnName("nrAgencia")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NrConta)
                    .IsRequired()
                    .HasColumnName("nrConta")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdBancoNavigation)
                    .WithMany(p => p.TbContaCorrente)
                    .HasForeignKey(d => d.IdBanco)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbContaCo__idBan__46E78A0C");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.TbContaCorrente)
                    .HasForeignKey(d => d.IdEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbContaCo__idEmp__45F365D3");
            });

            modelBuilder.Entity<TbEmpresa>(entity =>
            {
                entity.HasKey(e => e.IdEmpresa)
                    .HasName("PK__tbEmpres__75D2CED486A67951");

                entity.ToTable("tbEmpresa", "card");

                entity.Property(e => e.IdEmpresa).HasColumnName("idEmpresa");

                entity.Property(e => e.DsFantasia)
                    .IsRequired()
                    .HasColumnName("dsFantasia")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DsRazaoSocial)
                    .IsRequired()
                    .HasColumnName("dsRazaoSocial")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NrCnpj)
                    .IsRequired()
                    .HasColumnName("nrCNPJ")
                    .HasMaxLength(14)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbFormaPagamento>(entity =>
            {
                entity.HasKey(e => e.IdFormaPagamento)
                    .HasName("PK__tbFormaP__B30C1EFD04147478");

                entity.ToTable("tbFormaPagamento", "card");

                entity.Property(e => e.IdFormaPagamento).HasColumnName("idFormaPagamento");

                entity.Property(e => e.DsFormaPagamento)
                    .HasColumnName("dsFormaPagamento")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbMovimentoBanco>(entity =>
            {
                entity.HasKey(e => e.IdMovimentoBanco)
                    .HasName("PK__tbMovime__44A70E4DDEE46944");

                entity.ToTable("tbMovimentoBanco", "card");

                entity.Property(e => e.IdMovimentoBanco).HasColumnName("idMovimentoBanco");

                entity.Property(e => e.DsMovimento)
                    .IsRequired()
                    .HasColumnName("dsMovimento")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DtMovimento)
                    .HasColumnName("dtMovimento")
                    .HasColumnType("date");

                entity.Property(e => e.IdContaCorrente).HasColumnName("idContaCorrente");

                entity.Property(e => e.IdEmpresa).HasColumnName("idEmpresa");

                entity.Property(e => e.NrDocumento)
                    .HasColumnName("nrDocumento")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TpOperacao)
                    .IsRequired()
                    .HasColumnName("tpOperacao")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasComment(@"E - Entrada
S - Saída");

                entity.Property(e => e.VlMovimento)
                    .HasColumnName("vlMovimento")
                    .HasColumnType("numeric(9, 2)");

                entity.HasOne(d => d.IdContaCorrenteNavigation)
                    .WithMany(p => p.TbMovimentoBanco)
                    .HasForeignKey(d => d.IdContaCorrente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbMovimen__idCon__4AB81AF0");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.TbMovimentoBanco)
                    .HasForeignKey(d => d.IdEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbMovimen__idEmp__49C3F6B7");
            });

            modelBuilder.Entity<TbPagamentoVenda>(entity =>
            {
                entity.HasKey(e => e.IdPagamentoVenda)
                    .HasName("PK__tbPagame__38CD1B7A5541CBF9");

                entity.ToTable("tbPagamentoVenda", "card");

                entity.Property(e => e.IdPagamentoVenda)
                    .HasColumnName("idPagamentoVenda")
                    .ValueGeneratedNever();

                entity.Property(e => e.DtEmissao)
                    .HasColumnName("dtEmissao")
                    .HasColumnType("date");

                entity.Property(e => e.IdBandeira).HasColumnName("idBandeira");

                entity.Property(e => e.IdEmpresa).HasColumnName("idEmpresa");

                entity.Property(e => e.IdFormaPagamento).HasColumnName("idFormaPagamento");

                entity.Property(e => e.NrNsu)
                    .HasColumnName("nrNSU")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.QtParcelas).HasColumnName("qtParcelas");

                entity.Property(e => e.VlPagamento)
                    .HasColumnName("vlPagamento")
                    .HasColumnType("numeric(9, 2)");

                entity.HasOne(d => d.IdBandeiraNavigation)
                    .WithMany(p => p.TbPagamentoVenda)
                    .HasForeignKey(d => d.IdBandeira)
                    .HasConstraintName("FK__tbPagamen__idBan__3E52440B");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.TbPagamentoVenda)
                    .HasForeignKey(d => d.IdEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbPagamen__idEmp__3D5E1FD2");

                entity.HasOne(d => d.IdFormaPagamentoNavigation)
                    .WithMany(p => p.TbPagamentoVenda)
                    .HasForeignKey(d => d.IdFormaPagamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbPagamen__idFor__3F466844");
            });

            modelBuilder.Entity<TbParcela>(entity =>
            {
                entity.HasKey(e => new { e.IdPagamentoVenda, e.NrParcela });

                entity.ToTable("tbParcela", "card");

                entity.Property(e => e.IdPagamentoVenda).HasColumnName("idPagamentoVenda");

                entity.Property(e => e.NrParcela).HasColumnName("nrParcela");

                entity.Property(e => e.DtEmissao)
                    .HasColumnName("dtEmissao")
                    .HasColumnType("date");

                entity.Property(e => e.DtPagamento)
                    .HasColumnName("dtPagamento")
                    .HasColumnType("date");

                entity.Property(e => e.DtVencimento)
                    .HasColumnName("dtVencimento")
                    .HasColumnType("date");

                entity.Property(e => e.IdContaCorrente).HasColumnName("idContaCorrente");

                entity.Property(e => e.IdEmpresa).HasColumnName("idEmpresa");

                entity.Property(e => e.IdMovimentoBanco).HasColumnName("idMovimentoBanco");

                entity.Property(e => e.IdStatusParcela).HasColumnName("idStatusParcela");

                entity.Property(e => e.VlPago)
                    .HasColumnName("vlPago")
                    .HasColumnType("numeric(9, 2)");

                entity.Property(e => e.VlParcela)
                    .HasColumnName("vlParcela")
                    .HasColumnType("numeric(9, 2)");

                entity.Property(e => e.VlTaxaAdministracao)
                    .HasColumnName("vlTaxaAdministracao")
                    .HasColumnType("numeric(9, 2)");

                entity.HasOne(d => d.IdContaCorrenteNavigation)
                    .WithMany(p => p.TbParcela)
                    .HasForeignKey(d => d.IdContaCorrente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbParcela__idCon__4E88ABD4");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.TbParcela)
                    .HasForeignKey(d => d.IdEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbParcela__idEmp__4D94879B");

                entity.HasOne(d => d.IdMovimentoBancoNavigation)
                    .WithMany(p => p.TbParcela)
                    .HasForeignKey(d => d.IdMovimentoBanco)
                    .HasConstraintName("FK__tbParcela__idMov__5070F446");

                entity.HasOne(d => d.IdPagamentoVendaNavigation)
                    .WithMany(p => p.TbParcela)
                    .HasForeignKey(d => d.IdPagamentoVenda)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbParcela__idPag__4CA06362");

                entity.HasOne(d => d.IdStatusParcelaNavigation)
                    .WithMany(p => p.TbParcela)
                    .HasForeignKey(d => d.IdStatusParcela)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbParcela__idSta__4F7CD00D");
            });

            modelBuilder.Entity<TbStatusParcela>(entity =>
            {
                entity.HasKey(e => e.IdStatusParcela)
                    .HasName("PK__tbStatus__E3A791340E9333A8");

                entity.ToTable("tbStatusParcela", "card");

                entity.Property(e => e.IdStatusParcela).HasColumnName("idStatusParcela");

                entity.Property(e => e.DsStatusParcela)
                    .IsRequired()
                    .HasColumnName("dsStatusParcela")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VwPagamentosCartao>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VW_Pagamentos_Cartao");

                entity.Property(e => e.CdBandeira).HasColumnName("cdBandeira");

                entity.Property(e => e.CdErp).HasColumnName("cdERP");

                entity.Property(e => e.DsBandeira)
                    .HasColumnName("dsBandeira")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DtVenda)
                    .HasColumnName("dtVenda")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.NrCnpj)
                    .HasColumnName("nrCNPJ")
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.NrNsu)
                    .HasColumnName("nrNSU")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.QtParcelas).HasColumnName("qtParcelas");

                entity.Property(e => e.VlVenda)
                    .HasColumnName("vlVenda")
                    .HasMaxLength(4000);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
