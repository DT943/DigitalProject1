using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Authentication.Data.Migrations
{
    /// <inheritdoc />
    public partial class addmanagercode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "06ac0ccf-f158-48ad-b227-0dacfbc91eea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0ce50872-c060-49f0-af6a-52ddd097e50e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0d8334e6-c0fc-4a8d-a487-079ff5e45661");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a58cea6-cbca-4169-b8bf-1049e15d43a7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "34c7aa8d-27a6-4fd8-81c0-3e35ff4f0b38");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36d183ce-f422-4833-ae14-8b3a8c5dfcf5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44903731-1e44-4233-8c3a-d72dd7b63eeb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44a8b5b8-3a72-400e-ac54-8b7e161d9473");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a4fadf8-5cc9-4fe7-b9b7-13b6da40fb86");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "69925828-9fea-4b8c-96c2-75fd37e44948");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b4c75d1-1da8-4435-b4c4-d230106de5d8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d92af99-4ba2-4619-9215-e50920a98c44");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7b8f9123-4758-47da-ab0f-4aef706130ad");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "87d0ce8c-6877-4689-adac-0686a6fa907b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8a1910ec-64fa-4936-8c2e-533e21cbf0fc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8a5b0ba2-858c-4299-b0c8-505db9038c0f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f1fbea3-2a57-481d-a2ec-0740dc00b0ee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "968f0066-a3f5-482a-8aec-653c24692510");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "97b5a966-97e5-46ce-8871-6c7ece1ef839");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a6297a5-8562-42f3-b5d5-7459229c20aa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9ae19cb6-ab27-4aca-a925-8c02d47ccd7c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bb0c383b-4a5e-4dd8-aa17-1c623b47292f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c86cc9f6-31bb-4791-90e8-0106b5e8a464");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9406233-6e11-46fb-8a62-1fb000cbd40f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e001af42-b3fa-42af-a2dd-4477cd0990ae");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e363469a-1a7f-42e8-9d15-7c482d638f46");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e55357b8-3bc5-454a-8a12-3e4ee0c337a8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ecadd959-56f0-4bd5-a8f4-d3ebf420efdc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "efece749-6d30-49b3-994a-8c576ffa9d6a");

            migrationBuilder.AddColumn<string>(
                name: "ManagerCode",
                table: "AspNetUsers",
                type: "NVARCHAR2(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0cd26753-2b40-4f1d-b23e-2d4593d38b02", null, "Offer-Supervisor", "OFFER-SUPERVISOR" },
                    { "14729d21-cffb-427b-9f0e-a76f28348a2e", null, "CWCore-Officer", "CWCORE-OFFICER" },
                    { "25e48e04-96b2-415a-a32f-85695dc519ce", null, "Authntication-Manager", "AUTHNTICATION-MANAGER" },
                    { "2ae15542-3234-4f4f-9c99-f3b607934f65", null, "Authntication-Officer", "AUTHNTICATION-OFFICER" },
                    { "3ec5ed82-1b83-49c2-8373-754d0d2d3601", null, "Offer-Admin", "OFFER-ADMIN" },
                    { "40da937d-89a1-44a0-9929-05a55d8a96ec", null, "CWCore-Manager", "CWCORE-MANAGER" },
                    { "42dd9978-cf87-4392-b8a3-190afefbb458", null, "Hotel-Manager", "HOTEL-MANAGER" },
                    { "43743c92-129d-4911-a8f3-b68abfeecb5f", null, "Gallery-Admin", "GALLERY-ADMIN" },
                    { "473bc8dc-0e81-4513-b441-6e2f2ba2b342", null, "Authntication-Admin", "AUTHNTICATION-ADMIN" },
                    { "48554fa8-b615-49d9-b052-6d270d4828c3", null, "Offer-Manager", "OFFER-MANAGER" },
                    { "5265054c-b5fe-4169-a2e5-75fc82b7080b", null, "Authntication-Supervisor", "AUTHNTICATION-SUPERVISOR" },
                    { "5980f82b-c2f9-4147-9adc-edb777848d15", null, "Gallery-Manager", "GALLERY-MANAGER" },
                    { "5b71ea68-3495-4b44-adad-68e31dfaba24", null, "CMS-Supervisor", "CMS-SUPERVISOR" },
                    { "5c3af973-c4b0-4f9e-b82c-162556e0c7ac", null, "SuperAdmin", "SUPERADMIN" },
                    { "5fd346f5-b707-409d-a7dc-e6bb6fce648f", null, "Hotel-Supervisor", "HOTEL-SUPERVISOR" },
                    { "6877151c-7861-4098-afe1-e533f459b677", null, "CMS-Manager", "CMS-MANAGER" },
                    { "7a79e4be-16cc-4e83-877f-6cfeafd99f80", null, "Gallery-Supervisor", "GALLERY-SUPERVISOR" },
                    { "7aa2f339-130b-4581-9e47-acf943308fda", null, "CMS-Officer", "CMS-OFFICER" },
                    { "859b60db-7ae5-48bb-af9a-9085e3af662b", null, "CWCore-Admin", "CWCORE-ADMIN" },
                    { "96f56fa2-e69f-49f0-89cf-d299ad0211ce", null, "Notification-Manager", "NOTIFICATION-MANAGER" },
                    { "9d57d6ae-0fad-4545-a5c3-71553db17a8b", null, "Offer-Officer", "OFFER-OFFICER" },
                    { "9fa66e43-a816-4193-85d8-f3efd28d9141", null, "Notification-Admin", "NOTIFICATION-ADMIN" },
                    { "be0ee4a8-406e-4173-959d-854abd51c16c", null, "Hotel-Officer", "HOTEL-OFFICER" },
                    { "c20bf05a-9c60-4643-a0ed-445e1982c018", null, "Notification-Supervisor", "NOTIFICATION-SUPERVISOR" },
                    { "c4d8c247-7272-44e8-a0bf-6b86346724dc", null, "CMS-Admin", "CMS-ADMIN" },
                    { "c94ad0f3-9b55-4ae3-a600-a6e836dc19ec", null, "Gallery-Officer", "GALLERY-OFFICER" },
                    { "ce435273-d8fb-4cc7-a5f6-61fc461d53ba", null, "CWCore-Supervisor", "CWCORE-SUPERVISOR" },
                    { "deda16c8-1f7f-4c36-92c5-268b847039af", null, "Notification-Officer", "NOTIFICATION-OFFICER" },
                    { "ee0f60e3-0cb4-4390-8c43-8501f75f0fe2", null, "Hotel-Admin", "HOTEL-ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0cd26753-2b40-4f1d-b23e-2d4593d38b02");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "14729d21-cffb-427b-9f0e-a76f28348a2e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25e48e04-96b2-415a-a32f-85695dc519ce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2ae15542-3234-4f4f-9c99-f3b607934f65");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3ec5ed82-1b83-49c2-8373-754d0d2d3601");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "40da937d-89a1-44a0-9929-05a55d8a96ec");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "42dd9978-cf87-4392-b8a3-190afefbb458");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "43743c92-129d-4911-a8f3-b68abfeecb5f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "473bc8dc-0e81-4513-b441-6e2f2ba2b342");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "48554fa8-b615-49d9-b052-6d270d4828c3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5265054c-b5fe-4169-a2e5-75fc82b7080b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5980f82b-c2f9-4147-9adc-edb777848d15");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b71ea68-3495-4b44-adad-68e31dfaba24");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5c3af973-c4b0-4f9e-b82c-162556e0c7ac");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5fd346f5-b707-409d-a7dc-e6bb6fce648f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6877151c-7861-4098-afe1-e533f459b677");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a79e4be-16cc-4e83-877f-6cfeafd99f80");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7aa2f339-130b-4581-9e47-acf943308fda");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "859b60db-7ae5-48bb-af9a-9085e3af662b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "96f56fa2-e69f-49f0-89cf-d299ad0211ce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9d57d6ae-0fad-4545-a5c3-71553db17a8b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9fa66e43-a816-4193-85d8-f3efd28d9141");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be0ee4a8-406e-4173-959d-854abd51c16c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c20bf05a-9c60-4643-a0ed-445e1982c018");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c4d8c247-7272-44e8-a0bf-6b86346724dc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c94ad0f3-9b55-4ae3-a600-a6e836dc19ec");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ce435273-d8fb-4cc7-a5f6-61fc461d53ba");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "deda16c8-1f7f-4c36-92c5-268b847039af");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee0f60e3-0cb4-4390-8c43-8501f75f0fe2");

            migrationBuilder.DropColumn(
                name: "ManagerCode",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "06ac0ccf-f158-48ad-b227-0dacfbc91eea", null, "Offer-Manager", "OFFER-MANAGER" },
                    { "0ce50872-c060-49f0-af6a-52ddd097e50e", null, "Hotel-Manager", "HOTEL-MANAGER" },
                    { "0d8334e6-c0fc-4a8d-a487-079ff5e45661", null, "Authntication-Officer", "AUTHNTICATION-OFFICER" },
                    { "2a58cea6-cbca-4169-b8bf-1049e15d43a7", null, "Offer-Admin", "OFFER-ADMIN" },
                    { "34c7aa8d-27a6-4fd8-81c0-3e35ff4f0b38", null, "Hotel-Supervisor", "HOTEL-SUPERVISOR" },
                    { "36d183ce-f422-4833-ae14-8b3a8c5dfcf5", null, "CWCore-Supervisor", "CWCORE-SUPERVISOR" },
                    { "44903731-1e44-4233-8c3a-d72dd7b63eeb", null, "Offer-Officer", "OFFER-OFFICER" },
                    { "44a8b5b8-3a72-400e-ac54-8b7e161d9473", null, "Gallery-Manager", "GALLERY-MANAGER" },
                    { "4a4fadf8-5cc9-4fe7-b9b7-13b6da40fb86", null, "Notification-Officer", "NOTIFICATION-OFFICER" },
                    { "69925828-9fea-4b8c-96c2-75fd37e44948", null, "Gallery-Supervisor", "GALLERY-SUPERVISOR" },
                    { "6b4c75d1-1da8-4435-b4c4-d230106de5d8", null, "CWCore-Admin", "CWCORE-ADMIN" },
                    { "6d92af99-4ba2-4619-9215-e50920a98c44", null, "Offer-Supervisor", "OFFER-SUPERVISOR" },
                    { "7b8f9123-4758-47da-ab0f-4aef706130ad", null, "CMS-Officer", "CMS-OFFICER" },
                    { "87d0ce8c-6877-4689-adac-0686a6fa907b", null, "Notification-Admin", "NOTIFICATION-ADMIN" },
                    { "8a1910ec-64fa-4936-8c2e-533e21cbf0fc", null, "CWCore-Manager", "CWCORE-MANAGER" },
                    { "8a5b0ba2-858c-4299-b0c8-505db9038c0f", null, "Hotel-Officer", "HOTEL-OFFICER" },
                    { "8f1fbea3-2a57-481d-a2ec-0740dc00b0ee", null, "Authntication-Manager", "AUTHNTICATION-MANAGER" },
                    { "968f0066-a3f5-482a-8aec-653c24692510", null, "Notification-Supervisor", "NOTIFICATION-SUPERVISOR" },
                    { "97b5a966-97e5-46ce-8871-6c7ece1ef839", null, "Authntication-Supervisor", "AUTHNTICATION-SUPERVISOR" },
                    { "9a6297a5-8562-42f3-b5d5-7459229c20aa", null, "CMS-Supervisor", "CMS-SUPERVISOR" },
                    { "9ae19cb6-ab27-4aca-a925-8c02d47ccd7c", null, "CMS-Admin", "CMS-ADMIN" },
                    { "bb0c383b-4a5e-4dd8-aa17-1c623b47292f", null, "CMS-Manager", "CMS-MANAGER" },
                    { "c86cc9f6-31bb-4791-90e8-0106b5e8a464", null, "Authntication-Admin", "AUTHNTICATION-ADMIN" },
                    { "d9406233-6e11-46fb-8a62-1fb000cbd40f", null, "Notification-Manager", "NOTIFICATION-MANAGER" },
                    { "e001af42-b3fa-42af-a2dd-4477cd0990ae", null, "SuperAdmin", "SUPERADMIN" },
                    { "e363469a-1a7f-42e8-9d15-7c482d638f46", null, "Gallery-Officer", "GALLERY-OFFICER" },
                    { "e55357b8-3bc5-454a-8a12-3e4ee0c337a8", null, "Hotel-Admin", "HOTEL-ADMIN" },
                    { "ecadd959-56f0-4bd5-a8f4-d3ebf420efdc", null, "CWCore-Officer", "CWCORE-OFFICER" },
                    { "efece749-6d30-49b3-994a-8c576ffa9d6a", null, "Gallery-Admin", "GALLERY-ADMIN" }
                });
        }
    }
}
