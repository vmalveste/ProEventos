﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProEventos.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Evento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Local = table.Column<string>(type: "TEXT", nullable: true),
                    DataEvento = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Tema = table.Column<string>(type: "TEXT", nullable: true),
                    QtdPessoas = table.Column<int>(type: "INTEGER", nullable: false),
                    ImageURL = table.Column<string>(type: "TEXT", nullable: true),
                    Fone = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Palestrantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    MiniCurriculo = table.Column<string>(type: "TEXT", nullable: true),
                    ImagemURL = table.Column<string>(type: "TEXT", nullable: true),
                    Telefone = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Palestrantes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Preco = table.Column<decimal>(type: "TEXT", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DataFim = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Quantidade = table.Column<int>(type: "INTEGER", nullable: false),
                    EventoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lotes_Evento_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Evento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PalestrantesEventos",
                columns: table => new
                {
                    PalestranteId = table.Column<int>(type: "INTEGER", nullable: false),
                    EventoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PalestrantesEventos", x => new { x.EventoId, x.PalestranteId });
                    table.ForeignKey(
                        name: "FK_PalestrantesEventos_Evento_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Evento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PalestrantesEventos_Palestrantes_PalestranteId",
                        column: x => x.PalestranteId,
                        principalTable: "Palestrantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RedesSociais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    URL = table.Column<string>(type: "TEXT", nullable: true),
                    EventoId = table.Column<int>(type: "INTEGER", nullable: true),
                    PalestranteId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RedesSociais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RedesSociais_Evento_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Evento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RedesSociais_Palestrantes_PalestranteId",
                        column: x => x.PalestranteId,
                        principalTable: "Palestrantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lotes_EventoId",
                table: "Lotes",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_PalestrantesEventos_PalestranteId",
                table: "PalestrantesEventos",
                column: "PalestranteId");

            migrationBuilder.CreateIndex(
                name: "IX_RedesSociais_EventoId",
                table: "RedesSociais",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_RedesSociais_PalestranteId",
                table: "RedesSociais",
                column: "PalestranteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lotes");

            migrationBuilder.DropTable(
                name: "PalestrantesEventos");

            migrationBuilder.DropTable(
                name: "RedesSociais");

            migrationBuilder.DropTable(
                name: "Evento");

            migrationBuilder.DropTable(
                name: "Palestrantes");
        }
    }
}
