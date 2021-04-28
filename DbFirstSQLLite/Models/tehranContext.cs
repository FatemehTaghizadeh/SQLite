using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DbFirstSQLLite.Models
{
    public partial class tehranContext : DbContext
    {
        public tehranContext()
        {
        }

        public tehranContext(DbContextOptions<tehranContext> options)
            : base(options)
        {
        }

        public virtual DbSet<GpkgContent> GpkgContents { get; set; }
        public virtual DbSet<GpkgGeometryColumn> GpkgGeometryColumns { get; set; }
        public virtual DbSet<GpkgMetadataReference> GpkgMetadataReferences { get; set; }
        public virtual DbSet<GpkgMetadatum> GpkgMetadata { get; set; }
        public virtual DbSet<GpkgSpatialRefSy> GpkgSpatialRefSys { get; set; }
        public virtual DbSet<GpkgTileMatrix> GpkgTileMatrices { get; set; }
        public virtual DbSet<GpkgTileMatrixSet> GpkgTileMatricesSet { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Map> Maps { get; set; }
        public virtual DbSet<Metadatum> Metadata { get; set; }
        public virtual DbSet<Omtm> Omtms { get; set; }
        public virtual DbSet<PackageTile> PackageTiles { get; set; }
        public virtual DbSet<Tile> Tiles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("Data Source=.\\tehran.mbtiles;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GpkgContent>(entity =>
            {
                entity.HasKey(e => e.TableName);

                entity.ToTable("gpkg_contents");

                entity.HasIndex(e => e.Identifier, "IX_gpkg_contents_identifier")
                    .IsUnique();

                entity.Property(e => e.TableName).HasColumnName("table_name");

                entity.Property(e => e.DataType)
                    .IsRequired()
                    .HasColumnName("data_type");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Identifier).HasColumnName("identifier");

                entity.Property(e => e.LastChange)
                    .IsRequired()
                    .HasColumnType("DATETIME")
                    .HasColumnName("last_change")
                    .HasDefaultValueSql("strftime('%Y-%m-%dT%H:%M:%fZ', CURRENT_TIMESTAMP)");

                entity.Property(e => e.MaxX)
                    .HasColumnType("DOUBLE")
                    .HasColumnName("max_x");

                entity.Property(e => e.MaxY)
                    .HasColumnType("DOUBLE")
                    .HasColumnName("max_y");

                entity.Property(e => e.MinX)
                    .HasColumnType("DOUBLE")
                    .HasColumnName("min_x");

                entity.Property(e => e.MinY)
                    .HasColumnType("DOUBLE")
                    .HasColumnName("min_y");

                entity.Property(e => e.SrsId).HasColumnName("srs_id");

                entity.HasOne(d => d.Srs)
                    .WithMany(p => p.GpkgContents)
                    .HasForeignKey(d => d.SrsId);
            });

            modelBuilder.Entity<GpkgGeometryColumn>(entity =>
            {
                entity.HasKey(e => new { e.TableName, e.ColumnName });

                entity.ToTable("gpkg_geometry_columns");

                entity.HasIndex(e => e.TableName, "IX_gpkg_geometry_columns_table_name")
                    .IsUnique();

                entity.Property(e => e.TableName).HasColumnName("table_name");

                entity.Property(e => e.ColumnName).HasColumnName("column_name");

                entity.Property(e => e.GeometryTypeName)
                    .IsRequired()
                    .HasColumnName("geometry_type_name");

                entity.Property(e => e.M)
                    .HasColumnType("TINYINT")
                    .HasColumnName("m");

                entity.Property(e => e.SrsId).HasColumnName("srs_id");

                entity.Property(e => e.Z)
                    .HasColumnType("TINYINT")
                    .HasColumnName("z");

                entity.HasOne(d => d.Srs)
                    .WithMany(p => p.GpkgGeometryColumns)
                    .HasForeignKey(d => d.SrsId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.TableNameNavigation)
                    .WithOne(p => p.GpkgGeometryColumn)
                    .HasForeignKey<GpkgGeometryColumn>(d => d.TableName)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<GpkgMetadataReference>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("gpkg_metadata_reference");

                entity.Property(e => e.ColumnName).HasColumnName("column_name");

                entity.Property(e => e.MdFileId).HasColumnName("md_file_id");

                entity.Property(e => e.MdParentId).HasColumnName("md_parent_id");

                entity.Property(e => e.ReferenceScope)
                    .IsRequired()
                    .HasColumnName("reference_scope");

                entity.Property(e => e.RowIdValue).HasColumnName("row_id_value");

                entity.Property(e => e.TableName).HasColumnName("table_name");

                entity.Property(e => e.Timestamp)
                    .IsRequired()
                    .HasColumnType("DATETIME")
                    .HasColumnName("timestamp")
                    .HasDefaultValueSql("strftime('%Y-%m-%dT%H:%M:%fZ',CURRENT_TIMESTAMP)");

                entity.HasOne(d => d.MdFile)
                    .WithMany()
                    .HasForeignKey(d => d.MdFileId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.MdParent)
                    .WithMany()
                    .HasForeignKey(d => d.MdParentId);
            });

            modelBuilder.Entity<GpkgMetadatum>(entity =>
            {
                entity.ToTable("gpkg_metadata");

                entity.HasIndex(e => e.Id, "IX_gpkg_metadata_id")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.MdScope)
                    .IsRequired()
                    .HasColumnName("md_scope")
                    .HasDefaultValueSql("'dataset'");

                entity.Property(e => e.MdStandardUri)
                    .IsRequired()
                    .HasColumnName("md_standard_uri");

                entity.Property(e => e.Metadata)
                    .IsRequired()
                    .HasColumnName("metadata");

                entity.Property(e => e.MimeType)
                    .IsRequired()
                    .HasColumnName("mime_type")
                    .HasDefaultValueSql("'text/xml'");
            });

            modelBuilder.Entity<GpkgSpatialRefSy>(entity =>
            {
                entity.HasKey(e => e.SrsId);

                entity.ToTable("gpkg_spatial_ref_sys");

                entity.Property(e => e.SrsId)
                    .ValueGeneratedNever()
                    .HasColumnName("srs_id");

                entity.Property(e => e.Definition)
                    .IsRequired()
                    .HasColumnName("definition");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Organization)
                    .IsRequired()
                    .HasColumnName("organization");

                entity.Property(e => e.OrganizationCoordsysId).HasColumnName("organization_coordsys_id");

                entity.Property(e => e.SrsName)
                    .IsRequired()
                    .HasColumnName("srs_name");
            });

            modelBuilder.Entity<GpkgTileMatrix>(entity =>
            {
                entity.HasKey(e => new { e.TableName, e.ZoomLevel });

                entity.ToTable("gpkg_tile_matrix");

                entity.Property(e => e.TableName).HasColumnName("table_name");

                entity.Property(e => e.ZoomLevel).HasColumnName("zoom_level");

                entity.Property(e => e.MatrixHeight).HasColumnName("matrix_height");

                entity.Property(e => e.MatrixWidth).HasColumnName("matrix_width");

                entity.Property(e => e.PixelXSize)
                    .HasColumnType("DOUBLE")
                    .HasColumnName("pixel_x_size");

                entity.Property(e => e.PixelYSize)
                    .HasColumnType("DOUBLE")
                    .HasColumnName("pixel_y_size");

                entity.Property(e => e.TileHeight).HasColumnName("tile_height");

                entity.Property(e => e.TileWidth).HasColumnName("tile_width");

                entity.HasOne(d => d.TableNameNavigation)
                    .WithMany(p => p.GpkgTileMatrices)
                    .HasForeignKey(d => d.TableName)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<GpkgTileMatrixSet>(entity =>
            {
                entity.HasKey(e => e.TableName);

                entity.ToTable("gpkg_tile_matrix_set");

                entity.Property(e => e.TableName).HasColumnName("table_name");

                entity.Property(e => e.MaxX)
                    .HasColumnType("DOUBLE")
                    .HasColumnName("max_x");

                entity.Property(e => e.MaxY)
                    .HasColumnType("DOUBLE")
                    .HasColumnName("max_y");

                entity.Property(e => e.MinX)
                    .HasColumnType("DOUBLE")
                    .HasColumnName("min_x");

                entity.Property(e => e.MinY)
                    .HasColumnType("DOUBLE")
                    .HasColumnName("min_y");

                entity.Property(e => e.SrsId).HasColumnName("srs_id");

                entity.HasOne(d => d.Srs)
                    .WithMany(p => p.GpkgTileMatricesSet)
                    .HasForeignKey(d => d.SrsId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.TableNameNavigation)
                    .WithOne(p => p.GpkgTileMatrixSet)
                    .HasForeignKey<GpkgTileMatrixSet>(d => d.TableName)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.HasKey(e => e.TileId);

                entity.ToTable("images");

                entity.HasIndex(e => e.TileId, "images_index");

                entity.Property(e => e.TileData).HasColumnName("tile_data");

                entity.Property(e => e.TileId).HasColumnName("tile_id");
            });

            modelBuilder.Entity<Map>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("map");

                entity.HasIndex(e => new { e.ZoomLevel, e.TileColumn, e.TileRow }, "map_index");

                entity.Property(e => e.TileColumn).HasColumnName("tile_column");

                entity.Property(e => e.TileId).HasColumnName("tile_id");

                entity.Property(e => e.TileRow).HasColumnName("tile_row");

                entity.Property(e => e.ZoomLevel).HasColumnName("zoom_level");
            });

            modelBuilder.Entity<Metadatum>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("metadata");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Value).HasColumnName("value");
            });

            modelBuilder.Entity<Omtm>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("omtm");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Value).HasColumnName("value");
            });

            modelBuilder.Entity<PackageTile>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("package_tiles");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.TileColumn).HasColumnName("tile_column");

                entity.Property(e => e.TileData).HasColumnName("tile_data");

                entity.Property(e => e.TileRow).HasColumnName("tile_row");

                entity.Property(e => e.ZoomLevel).HasColumnName("zoom_level");
            });

            modelBuilder.Entity<Tile>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("tiles");

                entity.Property(e => e.TileColumn).HasColumnName("tile_column");

                entity.Property(e => e.TileData).HasColumnName("tile_data");

                entity.Property(e => e.TileRow).HasColumnName("tile_row");

                entity.Property(e => e.ZoomLevel).HasColumnName("zoom_level");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
