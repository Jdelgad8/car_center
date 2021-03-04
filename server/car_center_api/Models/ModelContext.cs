using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace car_center_api.Models
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CalidadRepuesto> CalidadRepuesto { get; set; }
        public virtual DbSet<Ciudad> Ciudad { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<DctoFactura> DctoFactura { get; set; }
        public virtual DbSet<Departamento> Departamento { get; set; }
        public virtual DbSet<EstFactura> EstFactura { get; set; }
        public virtual DbSet<EstVehiculo> EstVehiculo { get; set; }
        public virtual DbSet<EstadoMecanico> EstadoMecanico { get; set; }
        public virtual DbSet<EstadoServicio> EstadoServicio { get; set; }
        public virtual DbSet<FacturaDeta> FacturaDeta { get; set; }
        public virtual DbSet<FacturaEnca> FacturaEnca { get; set; }
        public virtual DbSet<InventarioRepuesto> InventarioRepuesto { get; set; }
        public virtual DbSet<Mecanico> Mecanico { get; set; }
        public virtual DbSet<MedioPago> MedioPago { get; set; }
        public virtual DbSet<Pais> Pais { get; set; }
        public virtual DbSet<Repuesto> Repuesto { get; set; }
        public virtual DbSet<SerMecanico> SerMecanico { get; set; }
        public virtual DbSet<Serviciot> Serviciot { get; set; }
        public virtual DbSet<SolicitudSerRepuesto> SolicitudSerRepuesto { get; set; }
        public virtual DbSet<SolicitudServ> SolicitudServ { get; set; }
        public virtual DbSet<Taller> Taller { get; set; }
        public virtual DbSet<TipoDoc> TipoDoc { get; set; }
        public virtual DbSet<TipoMecanico> TipoMecanico { get; set; }
        public virtual DbSet<TipoRepuesto> TipoRepuesto { get; set; }
        public virtual DbSet<TipoServicio> TipoServicio { get; set; }
        public virtual DbSet<Vehiculo> Vehiculo { get; set; }
        public virtual DbSet<VehiculoCliente> VehiculoCliente { get; set; }
        public virtual DbSet<Zonat> Zonat { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseOracle("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=172.16.1.5)(PORT=1521))(CONNECT_DATA=(SERVER=DEDICATED)(SID=NOVASIS)));User ID=eaav_sep;Password=eaav_sep;Persist Security Info=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:DefaultSchema", "EAAV_SEP");

            modelBuilder.Entity<CalidadRepuesto>(entity =>
            {
                entity.HasKey(e => e.CodCalRep)
                    .HasName("PK_CAL_REP");

                entity.ToTable("CALIDAD_REPUESTO");

                entity.Property(e => e.CodCalRep)
                    .HasColumnName("COD_CAL_REP")
                    .HasColumnType("NUMBER(2)");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("DESCRIPCION")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ciudad>(entity =>
            {
                entity.HasKey(e => e.CodCiu);

                entity.ToTable("CIUDAD");

                entity.Property(e => e.CodCiu)
                    .HasColumnName("COD_CIU")
                    .HasColumnType("NUMBER(2)");

                entity.Property(e => e.CodDep)
                    .HasColumnName("COD_DEP")
                    .HasColumnType("NUMBER(2)");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("DESCRIPCION")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodDepNavigation)
                    .WithMany(p => p.Ciudad)
                    .HasForeignKey(d => d.CodDep)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CIU_COD_DEP");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.CodCli);

                entity.ToTable("CLIENTE");

                entity.Property(e => e.CodCli)
                    .HasColumnName("COD_CLI")
                    .HasColumnType("NUMBER(8)")
                    .ValueGeneratedNever();

                entity.Property(e => e.CodZona)
                    .HasColumnName("COD_ZONA")
                    .HasColumnType("NUMBER(2)");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasColumnName("DIRECCION")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.FecReg)
                    .HasColumnName("FEC_REG")
                    .HasColumnType("DATE");

                entity.Property(e => e.NroCel)
                    .IsRequired()
                    .HasColumnName("NRO_CEL")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NroDoc)
                    .IsRequired()
                    .HasColumnName("NRO_DOC")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PrimApe)
                    .IsRequired()
                    .HasColumnName("PRIM_APE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PrimNom)
                    .IsRequired()
                    .HasColumnName("PRIM_NOM")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SeguApe)
                    .IsRequired()
                    .HasColumnName("SEGU_APE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SeguNom)
                    .HasColumnName("SEGU_NOM")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TipoDoc)
                    .IsRequired()
                    .HasColumnName("TIPO_DOC")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.VlrMax)
                    .HasColumnName("VLR_MAX")
                    .HasColumnType("FLOAT");

                entity.HasOne(d => d.CodZonaNavigation)
                    .WithMany(p => p.Cliente)
                    .HasForeignKey(d => d.CodZona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_COD_ZONA_CLI");

                entity.HasOne(d => d.TipoDocNavigation)
                    .WithMany(p => p.Cliente)
                    .HasForeignKey(d => d.TipoDoc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TIPO_DOC");
            });

            modelBuilder.Entity<DctoFactura>(entity =>
            {
                entity.HasKey(e => e.CodDcto)
                    .HasName("PK_DCTO_FACT");

                entity.ToTable("DCTO_FACTURA");

                entity.Property(e => e.CodDcto)
                    .HasColumnName("COD_DCTO")
                    .HasColumnType("NUMBER(2)");

                entity.Property(e => e.PorcDcto)
                    .HasColumnName("PORC_DCTO")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.VlrMinDcto)
                    .HasColumnName("VLR_MIN_DCTO")
                    .HasColumnType("FLOAT");
            });

            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.HasKey(e => e.CodDep)
                    .HasName("PK_DEP");

                entity.ToTable("DEPARTAMENTO");

                entity.Property(e => e.CodDep)
                    .HasColumnName("COD_DEP")
                    .HasColumnType("NUMBER(2)");

                entity.Property(e => e.CodPais)
                    .HasColumnName("COD_PAIS")
                    .HasColumnType("NUMBER(2)");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("DESCRIPCION")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodPaisNavigation)
                    .WithMany(p => p.Departamento)
                    .HasForeignKey(d => d.CodPais)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DEP_COD_PAIS");
            });

            modelBuilder.Entity<EstFactura>(entity =>
            {
                entity.HasKey(e => e.CodEstFac)
                    .HasName("PK_EST_FAC");

                entity.ToTable("EST_FACTURA");

                entity.Property(e => e.CodEstFac)
                    .HasColumnName("COD_EST_FAC")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("DESCRIPCION")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EstVehiculo>(entity =>
            {
                entity.HasKey(e => e.CodEstVeh);

                entity.ToTable("EST_VEHICULO");

                entity.Property(e => e.CodEstVeh)
                    .HasColumnName("COD_EST_VEH")
                    .HasColumnType("NUMBER(2)")
                    .ValueGeneratedNever();

                entity.Property(e => e.CodVeh)
                    .HasColumnName("COD_VEH")
                    .HasColumnType("NUMBER(2)");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("DESCRIPCION")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.UrlImg)
                    .IsRequired()
                    .HasColumnName("URL_IMG")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodVehNavigation)
                    .WithMany(p => p.EstVehiculo)
                    .HasForeignKey(d => d.CodVeh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EST_VEH_COD_VEH");
            });

            modelBuilder.Entity<EstadoMecanico>(entity =>
            {
                entity.HasKey(e => e.CodEstMec)
                    .HasName("PK_EST_MEC");

                entity.ToTable("ESTADO_MECANICO");

                entity.Property(e => e.CodEstMec)
                    .HasColumnName("COD_EST_MEC")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("DESCRIPCION")
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EstadoServicio>(entity =>
            {
                entity.HasKey(e => e.CodEstServ)
                    .HasName("PK_EST_SERV");

                entity.ToTable("ESTADO_SERVICIO");

                entity.Property(e => e.CodEstServ)
                    .HasColumnName("COD_EST_SERV")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("DESCRIPCION")
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FacturaDeta>(entity =>
            {
                entity.HasKey(e => e.CodFacDet)
                    .HasName("PK_FAC_DET");

                entity.ToTable("FACTURA_DETA");

                entity.Property(e => e.CodFacDet)
                    .HasColumnName("COD_FAC_DET")
                    .HasColumnType("NUMBER(8)")
                    .ValueGeneratedNever();

                entity.Property(e => e.CodFacEnc)
                    .HasColumnName("COD_FAC_ENC")
                    .HasColumnType("NUMBER(8)");

                entity.Property(e => e.CodSolSerRep)
                    .HasColumnName("COD_SOL_SER_REP")
                    .HasColumnType("NUMBER(8)");

                entity.Property(e => e.CodSolic)
                    .HasColumnName("COD_SOLIC")
                    .HasColumnType("NUMBER(8)");

                entity.Property(e => e.VlrSub)
                    .HasColumnName("VLR_SUB")
                    .HasColumnType("NUMBER(8)");

                entity.HasOne(d => d.CodFacEncNavigation)
                    .WithMany(p => p.FacturaDeta)
                    .HasForeignKey(d => d.CodFacEnc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FAC_DET_COD_FAC_ENC");

                entity.HasOne(d => d.CodSolSerRepNavigation)
                    .WithMany(p => p.FacturaDeta)
                    .HasForeignKey(d => d.CodSolSerRep)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FAC_DET_COD_SOL_SER_REP");

                entity.HasOne(d => d.CodSolicNavigation)
                    .WithMany(p => p.FacturaDeta)
                    .HasForeignKey(d => d.CodSolic)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FAC_DET_COD_SOLIC");
            });

            modelBuilder.Entity<FacturaEnca>(entity =>
            {
                entity.HasKey(e => e.CodFacEnc)
                    .HasName("PK_FAC_ENC");

                entity.ToTable("FACTURA_ENCA");

                entity.Property(e => e.CodFacEnc)
                    .HasColumnName("COD_FAC_ENC")
                    .HasColumnType("NUMBER(8)")
                    .ValueGeneratedNever();

                entity.Property(e => e.CodCli)
                    .HasColumnName("COD_CLI")
                    .HasColumnType("NUMBER(8)");

                entity.Property(e => e.CodEstFac)
                    .IsRequired()
                    .HasColumnName("COD_EST_FAC")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.CodMec)
                    .HasColumnName("COD_MEC")
                    .HasColumnType("NUMBER(8)");

                entity.Property(e => e.CodPago)
                    .HasColumnName("COD_PAGO")
                    .HasColumnType("NUMBER(2)");

                entity.Property(e => e.FecFac)
                    .HasColumnName("FEC_FAC")
                    .HasColumnType("DATE");

                entity.Property(e => e.VlrDcto)
                    .HasColumnName("VLR_DCTO")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.VlrIva)
                    .HasColumnName("VLR_IVA")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.VlrTot)
                    .HasColumnName("VLR_TOT")
                    .HasColumnType("FLOAT");

                entity.HasOne(d => d.CodCliNavigation)
                    .WithMany(p => p.FacturaEnca)
                    .HasForeignKey(d => d.CodCli)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FAC_ENC_COD_CLI");

                entity.HasOne(d => d.CodEstFacNavigation)
                    .WithMany(p => p.FacturaEnca)
                    .HasForeignKey(d => d.CodEstFac)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FAC_ENC_COD_EST_FAC");

                entity.HasOne(d => d.CodMecNavigation)
                    .WithMany(p => p.FacturaEnca)
                    .HasForeignKey(d => d.CodMec)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FAC_ENC_COD_MEC");

                entity.HasOne(d => d.CodPagoNavigation)
                    .WithMany(p => p.FacturaEnca)
                    .HasForeignKey(d => d.CodPago)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FAC_ENC_COD_PAGO");
            });

            modelBuilder.Entity<InventarioRepuesto>(entity =>
            {
                entity.HasKey(e => new { e.CodRep, e.CodTaller })
                    .HasName("PK_INV_REP");

                entity.ToTable("INVENTARIO_REPUESTO");

                entity.Property(e => e.CodRep)
                    .HasColumnName("COD_REP")
                    .HasColumnType("NUMBER(8)");

                entity.Property(e => e.CodTaller)
                    .HasColumnName("COD_TALLER")
                    .HasColumnType("NUMBER(8)");

                entity.Property(e => e.Cantidad)
                    .HasColumnName("CANTIDAD")
                    .HasColumnType("NUMBER(8)");

                entity.Property(e => e.FecAct)
                    .HasColumnName("FEC_ACT")
                    .HasColumnType("DATE");
            });

            modelBuilder.Entity<Mecanico>(entity =>
            {
                entity.HasKey(e => e.CodMec);

                entity.ToTable("MECANICO");

                entity.Property(e => e.CodMec)
                    .HasColumnName("COD_MEC")
                    .HasColumnType("NUMBER(8)")
                    .ValueGeneratedNever();

                entity.Property(e => e.CodEstMec)
                    .IsRequired()
                    .HasColumnName("COD_EST_MEC")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.CodTaller)
                    .HasColumnName("COD_TALLER")
                    .HasColumnType("NUMBER(8)");

                entity.Property(e => e.CodTipo)
                    .HasColumnName("COD_TIPO")
                    .HasColumnType("NUMBER(2)");

                entity.Property(e => e.CodZona)
                    .HasColumnName("COD_ZONA")
                    .HasColumnType("NUMBER(2)");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasColumnName("DIRECCION")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.FecReg)
                    .HasColumnName("FEC_REG")
                    .HasColumnType("DATE");

                entity.Property(e => e.NroCel)
                    .IsRequired()
                    .HasColumnName("NRO_CEL")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NroDoc)
                    .IsRequired()
                    .HasColumnName("NRO_DOC")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PrimApe)
                    .IsRequired()
                    .HasColumnName("PRIM_APE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PrimNom)
                    .IsRequired()
                    .HasColumnName("PRIM_NOM")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SeguApe)
                    .IsRequired()
                    .HasColumnName("SEGU_APE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SeguNom)
                    .HasColumnName("SEGU_NOM")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TipoDoc)
                    .IsRequired()
                    .HasColumnName("TIPO_DOC")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodEstMecNavigation)
                    .WithMany(p => p.Mecanico)
                    .HasForeignKey(d => d.CodEstMec)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MEC_COD_EST_MEC");

                entity.HasOne(d => d.CodTallerNavigation)
                    .WithMany(p => p.Mecanico)
                    .HasForeignKey(d => d.CodTaller)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MEC_COD_TALLER");

                entity.HasOne(d => d.CodTipoNavigation)
                    .WithMany(p => p.Mecanico)
                    .HasForeignKey(d => d.CodTipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MEC_COD_TIPO");

                entity.HasOne(d => d.CodZonaNavigation)
                    .WithMany(p => p.Mecanico)
                    .HasForeignKey(d => d.CodZona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MEC_COD_ZONA");

                entity.HasOne(d => d.TipoDocNavigation)
                    .WithMany(p => p.Mecanico)
                    .HasForeignKey(d => d.TipoDoc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MEC_TIPO_DOC");
            });

            modelBuilder.Entity<MedioPago>(entity =>
            {
                entity.HasKey(e => e.CodPago)
                    .HasName("PK_PAGO");

                entity.ToTable("MEDIO_PAGO");

                entity.Property(e => e.CodPago)
                    .HasColumnName("COD_PAGO")
                    .HasColumnType("NUMBER(2)");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("DESCRIPCION")
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pais>(entity =>
            {
                entity.HasKey(e => e.CodPais);

                entity.ToTable("PAIS");

                entity.Property(e => e.CodPais)
                    .HasColumnName("COD_PAIS")
                    .HasColumnType("NUMBER(2)");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("DESCRIPCION")
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Repuesto>(entity =>
            {
                entity.HasKey(e => e.CodRep);

                entity.ToTable("REPUESTO");

                entity.Property(e => e.CodRep)
                    .HasColumnName("COD_REP")
                    .HasColumnType("NUMBER(8)")
                    .ValueGeneratedNever();

                entity.Property(e => e.CodCalRep)
                    .HasColumnName("COD_CAL_REP")
                    .HasColumnType("NUMBER(2)");

                entity.Property(e => e.CodTipo)
                    .HasColumnName("COD_TIPO")
                    .HasColumnType("NUMBER(2)");

                entity.Property(e => e.NomRep)
                    .IsRequired()
                    .HasColumnName("NOM_REP")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.VlrRep)
                    .HasColumnName("VLR_REP")
                    .HasColumnType("FLOAT");

                entity.HasOne(d => d.CodCalRepNavigation)
                    .WithMany(p => p.Repuesto)
                    .HasForeignKey(d => d.CodCalRep)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REP_COD_CAL_REP");

                entity.HasOne(d => d.CodTipoNavigation)
                    .WithMany(p => p.Repuesto)
                    .HasForeignKey(d => d.CodTipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REP_COD_TIPO");
            });

            modelBuilder.Entity<SerMecanico>(entity =>
            {
                entity.HasKey(e => new { e.CodSer, e.CodMec })
                    .HasName("PK_SER_MEC");

                entity.ToTable("SER_MECANICO");

                entity.Property(e => e.CodSer)
                    .HasColumnName("COD_SER")
                    .HasColumnType("NUMBER(2)");

                entity.Property(e => e.CodMec)
                    .HasColumnName("COD_MEC")
                    .HasColumnType("NUMBER(8)");
            });

            modelBuilder.Entity<Serviciot>(entity =>
            {
                entity.HasKey(e => e.CodSer)
                    .HasName("PK_SERVICIO");

                entity.ToTable("SERVICIOT");

                entity.Property(e => e.CodSer)
                    .HasColumnName("COD_SER")
                    .HasColumnType("NUMBER(2)");

                entity.Property(e => e.CodTipo)
                    .HasColumnName("COD_TIPO")
                    .HasColumnType("NUMBER(2)");

                entity.Property(e => e.DurMin)
                    .HasColumnName("DUR_MIN")
                    .HasColumnType("NUMBER(8)");

                entity.Property(e => e.VlrMax)
                    .HasColumnName("VLR_MAX")
                    .HasColumnType("FLOAT");

                entity.Property(e => e.VlrMin)
                    .HasColumnName("VLR_MIN")
                    .HasColumnType("FLOAT");

                entity.HasOne(d => d.CodTipoNavigation)
                    .WithMany(p => p.Serviciot)
                    .HasForeignKey(d => d.CodTipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SER_TIPO_SER");
            });

            modelBuilder.Entity<SolicitudSerRepuesto>(entity =>
            {
                entity.HasKey(e => e.CodSolSerRep)
                    .HasName("PK_SOL_SER_REP");

                entity.ToTable("SOLICITUD_SER_REPUESTO");

                entity.Property(e => e.CodSolSerRep)
                    .HasColumnName("COD_SOL_SER_REP")
                    .HasColumnType("NUMBER(8)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cantidad).HasColumnName("CANTIDAD");

                entity.Property(e => e.CodRep)
                    .HasColumnName("COD_REP")
                    .HasColumnType("NUMBER(8)");

                entity.Property(e => e.CodSolic)
                    .HasColumnName("COD_SOLIC")
                    .HasColumnType("NUMBER(8)");

                entity.HasOne(d => d.CodRepNavigation)
                    .WithMany(p => p.SolicitudSerRepuesto)
                    .HasForeignKey(d => d.CodRep)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SOL_SER_REP_COD_REP");

                entity.HasOne(d => d.CodSolicNavigation)
                    .WithMany(p => p.SolicitudSerRepuesto)
                    .HasForeignKey(d => d.CodSolic)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SOL_SER_REP_COD_SOL");
            });

            modelBuilder.Entity<SolicitudServ>(entity =>
            {
                entity.HasKey(e => e.CodSolic);

                entity.ToTable("SOLICITUD_SERV");

                entity.Property(e => e.CodSolic)
                    .HasColumnName("COD_SOLIC")
                    .HasColumnType("NUMBER(8)")
                    .ValueGeneratedNever();

                entity.Property(e => e.CodEstServ)
                    .HasColumnName("COD_EST_SERV")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.CodMec)
                    .HasColumnName("COD_MEC")
                    .HasColumnType("NUMBER(8)");

                entity.Property(e => e.CodSer)
                    .HasColumnName("COD_SER")
                    .HasColumnType("NUMBER(2)");

                entity.Property(e => e.CodVeh)
                    .HasColumnName("COD_VEH")
                    .HasColumnType("NUMBER(8)");

                entity.Property(e => e.FecEst)
                    .HasColumnName("FEC_EST")
                    .HasColumnType("DATE");

                entity.Property(e => e.FecSol)
                    .HasColumnName("FEC_SOL")
                    .HasColumnType("DATE");

                entity.Property(e => e.FecTer)
                    .HasColumnName("FEC_TER")
                    .HasColumnType("DATE");

                entity.Property(e => e.VlrSer)
                    .HasColumnName("VLR_SER")
                    .HasColumnType("FLOAT");

                entity.HasOne(d => d.CodEstServNavigation)
                    .WithMany(p => p.SolicitudServ)
                    .HasForeignKey(d => d.CodEstServ)
                    .HasConstraintName("FK_SOL_SER_COD_EST_SERV");

                entity.HasOne(d => d.CodMecNavigation)
                    .WithMany(p => p.SolicitudServ)
                    .HasForeignKey(d => d.CodMec)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SOL_SER_COD_MEC");

                entity.HasOne(d => d.CodSerNavigation)
                    .WithMany(p => p.SolicitudServ)
                    .HasForeignKey(d => d.CodSer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SOL_SER_COD_SER");

                entity.HasOne(d => d.CodVehNavigation)
                    .WithMany(p => p.SolicitudServ)
                    .HasForeignKey(d => d.CodVeh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SOL_SER_COD_VEH");
            });

            modelBuilder.Entity<Taller>(entity =>
            {
                entity.HasKey(e => e.CodTaller);

                entity.ToTable("TALLER");

                entity.Property(e => e.CodTaller)
                    .HasColumnName("COD_TALLER")
                    .HasColumnType("NUMBER(8)")
                    .ValueGeneratedNever();

                entity.Property(e => e.CodZona)
                    .HasColumnName("COD_ZONA")
                    .HasColumnType("NUMBER(2)");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasColumnName("DIRECCION")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.FecReg)
                    .HasColumnName("FEC_REG")
                    .HasColumnType("DATE");

                entity.Property(e => e.NroCel)
                    .IsRequired()
                    .HasColumnName("NRO_CEL")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodZonaNavigation)
                    .WithMany(p => p.Taller)
                    .HasForeignKey(d => d.CodZona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_COD_ZONA");
            });

            modelBuilder.Entity<TipoDoc>(entity =>
            {
                entity.HasKey(e => e.TipoDoc1)
                    .HasName("SYS_C00144705");

                entity.ToTable("TIPO_DOC");

                entity.Property(e => e.TipoDoc1)
                    .HasColumnName("TIPO_DOC")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("DESCRIPCION")
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoMecanico>(entity =>
            {
                entity.HasKey(e => e.CodTipo)
                    .HasName("PK_TIPO_MEC");

                entity.ToTable("TIPO_MECANICO");

                entity.Property(e => e.CodTipo)
                    .HasColumnName("COD_TIPO")
                    .HasColumnType("NUMBER(2)");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("DESCRIPCION")
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoRepuesto>(entity =>
            {
                entity.HasKey(e => e.CodTipo)
                    .HasName("PK_TIPO_REP");

                entity.ToTable("TIPO_REPUESTO");

                entity.Property(e => e.CodTipo)
                    .HasColumnName("COD_TIPO")
                    .HasColumnType("NUMBER(2)");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("DESCRIPCION")
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoServicio>(entity =>
            {
                entity.HasKey(e => e.CodTipo)
                    .HasName("PK_TIPO_SER");

                entity.ToTable("TIPO_SERVICIO");

                entity.Property(e => e.CodTipo)
                    .HasColumnName("COD_TIPO")
                    .HasColumnType("NUMBER(2)");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("DESCRIPCION")
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.HasKey(e => e.CodVeh);

                entity.ToTable("VEHICULO");

                entity.Property(e => e.CodVeh)
                    .HasColumnName("COD_VEH")
                    .HasColumnType("NUMBER(8)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasColumnName("COLOR")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Marca)
                    .IsRequired()
                    .HasColumnName("MARCA")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Modelo)
                    .HasColumnName("MODELO")
                    .HasColumnType("DATE");

                entity.Property(e => e.Placa)
                    .IsRequired()
                    .HasColumnName("PLACA")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VehiculoCliente>(entity =>
            {
                entity.HasKey(e => new { e.CodVeh, e.CodCli })
                    .HasName("PK_VEH_CLI");

                entity.ToTable("VEHICULO_CLIENTE");

                entity.Property(e => e.CodVeh)
                    .HasColumnName("COD_VEH")
                    .HasColumnType("NUMBER(8)");

                entity.Property(e => e.CodCli)
                    .HasColumnName("COD_CLI")
                    .HasColumnType("NUMBER(8)");
            });

            modelBuilder.Entity<Zonat>(entity =>
            {
                entity.HasKey(e => e.CodZona)
                    .HasName("PK_ZONA");

                entity.ToTable("ZONAT");

                entity.Property(e => e.CodZona)
                    .HasColumnName("COD_ZONA")
                    .HasColumnType("NUMBER(2)");

                entity.Property(e => e.CodCiu)
                    .HasColumnName("COD_CIU")
                    .HasColumnType("NUMBER(2)");

                entity.Property(e => e.NomZona)
                    .IsRequired()
                    .HasColumnName("NOM_ZONA")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodCiuNavigation)
                    .WithMany(p => p.Zonat)
                    .HasForeignKey(d => d.CodCiu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_COD_CIU");
            });

            modelBuilder.HasSequence("HNPQR_SEQ");

            modelBuilder.HasSequence("ISEQ$$_206723");

            modelBuilder.HasSequence("ISEQ$$_206851");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
