using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Authentication.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddLastOtpCheckedDefualt1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "020d60ac-78e7-46ed-855f-159c69a609f5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "05b85d54-66b4-4553-918a-e353c704c6da");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a1f0e8b-756b-4b05-80db-23df4c1bead7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12f35d91-4395-493c-8286-9aca814e89bc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b9dae3f-a369-4c0b-9574-d0c0e0eda64e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2b62626c-84c0-498a-96c9-df883ce1b60f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a050682-d744-4b34-918e-6cc9ba978f57");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "418452c5-721b-4c3d-8845-09416c7a7715");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "448ecdb9-fee1-4939-9358-5e2bef96e817");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "454dabe9-9b14-40b5-b429-179da3a6a7b7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49e6341e-cb38-4e53-b4ad-ddfc47ac3265");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "59630bbb-bc8f-4cfd-9fa0-77564628def0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5af77219-e944-4461-97a2-6990fd969a0e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "660e7e45-1d70-4801-a294-003694b6b8c5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e60310d-7fe9-49b6-879b-c0ffc47a923e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "775e89da-d8af-4e09-ab57-ad64abc38863");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ffbffaa-d6d2-4dfe-ba3f-791584dde974");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "82482d6e-f9c2-4dd3-a53a-d1fde553dfb8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8439ec37-ec16-4e3c-9a09-df3217d215c3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "860a44f4-c0e7-4d2c-a70a-8c9f23a41444");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "936db107-ed29-413d-8d33-1312afa09ea6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a37f78e-f856-41fa-9510-5d80f37e4930");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f16beed-85c0-4c2c-8b25-1a35a59abd81");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bdcc8ecf-ef40-4ec5-9531-da6fc4a5535c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d200f10f-9b4c-4524-b877-03d310956b86");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6caaba6-8288-45ff-b235-ee143f202d87");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "edf82bed-f183-4776-ac6c-eb32c7b8256a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "efc4891a-430c-4350-b82a-35d49b7e6e62");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f3991da0-25cc-4232-8368-b5f0b92014a2");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "020d60ac-78e7-46ed-855f-159c69a609f5", null, "Gallery-Supervisor", "GALLERY-SUPERVISOR" },
                    { "05b85d54-66b4-4553-918a-e353c704c6da", null, "CWCore-Admin", "CWCORE-ADMIN" },
                    { "0a1f0e8b-756b-4b05-80db-23df4c1bead7", null, "Gallery-Admin", "GALLERY-ADMIN" },
                    { "12f35d91-4395-493c-8286-9aca814e89bc", null, "Authntication-Manager", "AUTHNTICATION-MANAGER" },
                    { "1b9dae3f-a369-4c0b-9574-d0c0e0eda64e", null, "CWCore-Supervisor", "CWCORE-SUPERVISOR" },
                    { "2b62626c-84c0-498a-96c9-df883ce1b60f", null, "Offer-Manager", "OFFER-MANAGER" },
                    { "3a050682-d744-4b34-918e-6cc9ba978f57", null, "Authntication-Admin", "AUTHNTICATION-ADMIN" },
                    { "418452c5-721b-4c3d-8845-09416c7a7715", null, "CMS-Manager", "CMS-MANAGER" },
                    { "448ecdb9-fee1-4939-9358-5e2bef96e817", null, "Gallery-Manager", "GALLERY-MANAGER" },
                    { "454dabe9-9b14-40b5-b429-179da3a6a7b7", null, "Hotel-Admin", "HOTEL-ADMIN" },
                    { "49e6341e-cb38-4e53-b4ad-ddfc47ac3265", null, "Offer-Supervisor", "OFFER-SUPERVISOR" },
                    { "59630bbb-bc8f-4cfd-9fa0-77564628def0", null, "Notification-Admin", "NOTIFICATION-ADMIN" },
                    { "5af77219-e944-4461-97a2-6990fd969a0e", null, "CWCore-Officer", "CWCORE-OFFICER" },
                    { "660e7e45-1d70-4801-a294-003694b6b8c5", null, "CMS-Supervisor", "CMS-SUPERVISOR" },
                    { "6e60310d-7fe9-49b6-879b-c0ffc47a923e", null, "Notification-Officer", "NOTIFICATION-OFFICER" },
                    { "775e89da-d8af-4e09-ab57-ad64abc38863", null, "CMS-Admin", "CMS-ADMIN" },
                    { "7ffbffaa-d6d2-4dfe-ba3f-791584dde974", null, "Offer-Officer", "OFFER-OFFICER" },
                    { "82482d6e-f9c2-4dd3-a53a-d1fde553dfb8", null, "SuperAdmin", "SUPERADMIN" },
                    { "8439ec37-ec16-4e3c-9a09-df3217d215c3", null, "Hotel-Supervisor", "HOTEL-SUPERVISOR" },
                    { "860a44f4-c0e7-4d2c-a70a-8c9f23a41444", null, "Authntication-Officer", "AUTHNTICATION-OFFICER" },
                    { "936db107-ed29-413d-8d33-1312afa09ea6", null, "Gallery-Officer", "GALLERY-OFFICER" },
                    { "9a37f78e-f856-41fa-9510-5d80f37e4930", null, "Hotel-Officer", "HOTEL-OFFICER" },
                    { "9f16beed-85c0-4c2c-8b25-1a35a59abd81", null, "Authntication-Supervisor", "AUTHNTICATION-SUPERVISOR" },
                    { "bdcc8ecf-ef40-4ec5-9531-da6fc4a5535c", null, "CWCore-Manager", "CWCORE-MANAGER" },
                    { "d200f10f-9b4c-4524-b877-03d310956b86", null, "Offer-Admin", "OFFER-ADMIN" },
                    { "e6caaba6-8288-45ff-b235-ee143f202d87", null, "Notification-Supervisor", "NOTIFICATION-SUPERVISOR" },
                    { "edf82bed-f183-4776-ac6c-eb32c7b8256a", null, "CMS-Officer", "CMS-OFFICER" },
                    { "efc4891a-430c-4350-b82a-35d49b7e6e62", null, "Hotel-Manager", "HOTEL-MANAGER" },
                    { "f3991da0-25cc-4232-8368-b5f0b92014a2", null, "Notification-Manager", "NOTIFICATION-MANAGER" }
                });
        }
    }
}
