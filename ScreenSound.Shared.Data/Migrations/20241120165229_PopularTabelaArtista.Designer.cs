﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ScreenSound.Banco;

#nullable disable

namespace ScreenSound.Migrations
{
    [DbContext(typeof(ScreenSoundContext))]
    [Migration("20241120165229_PopularTabelaArtista")]
    partial class PopularTabelaArtista
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ScreenSound.Models.Album", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ArtistaId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ArtistaId");

                    b.ToTable("Albuns");
                });

            modelBuilder.Entity("ScreenSound.Models.Artista", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FotoPerfil")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Artistas");
                });

            modelBuilder.Entity("ScreenSound.Models.AvaliacaoAlbum", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AlbumId")
                        .HasColumnType("int");

                    b.Property<int>("Nota")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.ToTable("AvaliacoesAlbum");
                });

            modelBuilder.Entity("ScreenSound.Models.AvaliacaoArtista", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ArtistaId")
                        .HasColumnType("int");

                    b.Property<int>("Nota")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArtistaId");

                    b.ToTable("AvaliacoesArtista");
                });

            modelBuilder.Entity("ScreenSound.Models.AvaliacaoMusica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("MusicaId")
                        .HasColumnType("int");

                    b.Property<int>("Nota")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MusicaId");

                    b.ToTable("AvaliacoesMusica");
                });

            modelBuilder.Entity("ScreenSound.Models.Musica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AlbumId")
                        .HasColumnType("int");

                    b.Property<int?>("AnoLancamento")
                        .HasColumnType("int");

                    b.Property<bool>("Disponivel")
                        .HasColumnType("bit");

                    b.Property<int>("Duracao")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.ToTable("Musicas");
                });

            modelBuilder.Entity("ScreenSound.Models.Album", b =>
                {
                    b.HasOne("ScreenSound.Models.Artista", "Artista")
                        .WithMany("Albuns")
                        .HasForeignKey("ArtistaId");

                    b.Navigation("Artista");
                });

            modelBuilder.Entity("ScreenSound.Models.AvaliacaoAlbum", b =>
                {
                    b.HasOne("ScreenSound.Models.Album", "Album")
                        .WithMany("AvaliacoesAlbum")
                        .HasForeignKey("AlbumId");

                    b.Navigation("Album");
                });

            modelBuilder.Entity("ScreenSound.Models.AvaliacaoArtista", b =>
                {
                    b.HasOne("ScreenSound.Models.Artista", "Artista")
                        .WithMany("AvaliacoesArtista")
                        .HasForeignKey("ArtistaId");

                    b.Navigation("Artista");
                });

            modelBuilder.Entity("ScreenSound.Models.AvaliacaoMusica", b =>
                {
                    b.HasOne("ScreenSound.Models.Musica", "Musica")
                        .WithMany("AvaliacoesMusica")
                        .HasForeignKey("MusicaId");

                    b.Navigation("Musica");
                });

            modelBuilder.Entity("ScreenSound.Models.Musica", b =>
                {
                    b.HasOne("ScreenSound.Models.Album", "Album")
                        .WithMany("Musicas")
                        .HasForeignKey("AlbumId");

                    b.Navigation("Album");
                });

            modelBuilder.Entity("ScreenSound.Models.Album", b =>
                {
                    b.Navigation("AvaliacoesAlbum");

                    b.Navigation("Musicas");
                });

            modelBuilder.Entity("ScreenSound.Models.Artista", b =>
                {
                    b.Navigation("Albuns");

                    b.Navigation("AvaliacoesArtista");
                });

            modelBuilder.Entity("ScreenSound.Models.Musica", b =>
                {
                    b.Navigation("AvaliacoesMusica");
                });
#pragma warning restore 612, 618
        }
    }
}
