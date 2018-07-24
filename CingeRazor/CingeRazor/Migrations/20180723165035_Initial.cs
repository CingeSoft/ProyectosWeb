using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CingeRazor.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cedulas",
                columns: table => new
                {
                    CódigoCédula = table.Column<string>(maxLength: 10, nullable: false),
                    Cédula = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cedulas", x => x.CódigoCédula);
                });

            migrationBuilder.CreateTable(
                name: "Compañia",
                columns: table => new
                {
                    IdCompañia = table.Column<string>(maxLength: 4, nullable: false),
                    NombreCompañia = table.Column<string>(maxLength: 50, nullable: false),
                    Telefono = table.Column<string>(maxLength: 50, nullable: false),
                    Fax = table.Column<string>(maxLength: 50, nullable: false),
                    ApartadoPostal = table.Column<string>(maxLength: 50, nullable: false),
                    Direccion = table.Column<string>(nullable: false),
                    CedulaJuridica = table.Column<string>(maxLength: 50, nullable: false),
                    Correo = table.Column<string>(maxLength: 50, nullable: false),
                    PaginaWeb = table.Column<string>(maxLength: 50, nullable: false),
                    FacturaElectronica = table.Column<string>(maxLength: 100, nullable: false),
                    DireccionLogo = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compañia", x => x.IdCompañia);
                });

            migrationBuilder.CreateTable(
                name: "Medidas",
                columns: table => new
                {
                    CódigoUnidad = table.Column<string>(maxLength: 10, nullable: false),
                    NombreUnidad = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medidas", x => x.CódigoUnidad);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    IdRol = table.Column<string>(maxLength: 50, nullable: false),
                    NombreRol = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.IdRol);
                });

            migrationBuilder.CreateTable(
                name: "TipoArticulos",
                columns: table => new
                {
                    TipoArticulo = table.Column<string>(maxLength: 20, nullable: false),
                    NombreTipo = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoArticulos", x => x.TipoArticulo);
                });

            migrationBuilder.CreateTable(
                name: "Zonas",
                columns: table => new
                {
                    CódigoZona = table.Column<string>(maxLength: 20, nullable: false),
                    NombreZona = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zonas", x => x.CódigoZona);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Usuario = table.Column<string>(maxLength: 50, nullable: false),
                    NombreUsuario = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    Contraseñas = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    IdRol = table.Column<string>(maxLength: 50, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    UltimoLogeo = table.Column<DateTime>(type: "datetime", nullable: false),
                    Email = table.Column<string>(unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Usuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_Roles",
                        column: x => x.IdRol,
                        principalTable: "Roles",
                        principalColumn: "IdRol",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Articulos",
                columns: table => new
                {
                    Código = table.Column<string>(maxLength: 20, nullable: false),
                    Nombre = table.Column<string>(maxLength: 2000, nullable: false),
                    TipoArticulo = table.Column<string>(maxLength: 20, nullable: false),
                    CódigoUnidad = table.Column<string>(maxLength: 10, nullable: false),
                    CostoPromedio = table.Column<decimal>(type: "numeric(18, 4)", nullable: false),
                    MargenUtilida = table.Column<decimal>(type: "numeric(18, 8)", nullable: false),
                    PrecioVenta = table.Column<decimal>(type: "numeric(18, 4)", nullable: false),
                    PagaImpuesto = table.Column<bool>(nullable: false),
                    FechaCreacíon = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulos", x => x.Código);
                    table.ForeignKey(
                        name: "FK_Articulos_Medidas",
                        column: x => x.CódigoUnidad,
                        principalTable: "Medidas",
                        principalColumn: "CódigoUnidad",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Articulos_TipoProductos",
                        column: x => x.TipoArticulo,
                        principalTable: "TipoArticulos",
                        principalColumn: "TipoArticulo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Código = table.Column<string>(maxLength: 20, nullable: false),
                    Nombre = table.Column<string>(maxLength: 200, nullable: false),
                    Localidad = table.Column<string>(maxLength: 200, nullable: false),
                    CódigoCédula = table.Column<string>(maxLength: 10, nullable: false),
                    Cédula = table.Column<string>(maxLength: 50, nullable: false),
                    TelefonoCodigoArea = table.Column<string>(maxLength: 5, nullable: false),
                    Teléfono = table.Column<string>(maxLength: 20, nullable: false),
                    Dirección = table.Column<string>(maxLength: 250, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    FechaCreacíon = table.Column<DateTime>(type: "datetime", nullable: false),
                    CódigoZona = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Código);
                    table.ForeignKey(
                        name: "FK_Clientes_Cedulas",
                        column: x => x.CódigoCédula,
                        principalTable: "Cedulas",
                        principalColumn: "CódigoCédula",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clientes_Zonas",
                        column: x => x.CódigoZona,
                        principalTable: "Zonas",
                        principalColumn: "CódigoZona",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_CódigoUnidad",
                table: "Articulos",
                column: "CódigoUnidad");

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_TipoArticulo",
                table: "Articulos",
                column: "TipoArticulo");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_CódigoCédula",
                table: "Clientes",
                column: "CódigoCédula");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_CódigoZona",
                table: "Clientes",
                column: "CódigoZona");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IdRol",
                table: "Usuarios",
                column: "IdRol");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articulos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Compañia");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Medidas");

            migrationBuilder.DropTable(
                name: "TipoArticulos");

            migrationBuilder.DropTable(
                name: "Cedulas");

            migrationBuilder.DropTable(
                name: "Zonas");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
