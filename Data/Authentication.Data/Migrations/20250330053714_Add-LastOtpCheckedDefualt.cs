using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Authentication.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddLastOtpCheckedDefualt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "036af88c-7f26-4a5c-9f8e-b7275bb205b2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03ff3ee3-8950-41b1-8445-0bf577f9e150");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04934ab6-6c9c-4fa1-ab36-9c6ee954e748");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "071121a3-a5da-45b6-9e24-5014ccc6246e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "096a28ab-9b2e-45f0-b648-cd88b7517202");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "398137ed-cee2-4013-9c94-ccc90ef53e89");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3aaa5d33-d9d9-49aa-8756-f96a55a30d00");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "40d6aa2b-76f6-458a-869f-ac215526e07c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4334c7b8-b800-4561-8a0e-7785aaaa2887");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c00bc71-a1c3-4302-abd3-91dc2c10d6d5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "53bef389-bd02-478d-b970-a151b652a3a3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "69a8eac4-bf50-417c-84d9-32bdcabd908f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "705dd026-fd38-44ef-9b9b-850100a87de3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "70e941cd-dca5-4af7-a468-71abe33b80de");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "735ef191-4635-41b3-af9a-19ef21fb8964");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "83b1358a-d571-4494-888d-fe4f2456f0af");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "85edc6aa-54b7-4121-ae58-883aa6e0fcb6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88ab1ebd-e139-4654-9ab4-483373a4ad32");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a20b562-abd8-47e6-8252-bce057ebe10c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9aa58402-e520-47f7-afb3-b66ff512789d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9bbcf419-5c0a-4caa-85f1-245b2b947826");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e6f2224-16bf-4110-b648-b4ef6553e798");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a6480ac0-a844-49e1-abc0-316a752b076e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b78e69ab-dd6b-41e1-ad16-18ba3de500cb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "caec9049-8143-4d9c-b1b2-b07bba9adbb6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db2b3834-62ea-4363-b545-91b735424e24");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e606249e-f1cb-4534-abf2-8d0d4fe77e7d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "edd3383c-5aed-4374-8d4b-476203efd386");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fdecff09-b290-4c2f-89f5-e6af65955382");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "036af88c-7f26-4a5c-9f8e-b7275bb205b2", null, "Authntication-Manager", "AUTHNTICATION-MANAGER" },
                    { "03ff3ee3-8950-41b1-8445-0bf577f9e150", null, "Hotel-Officer", "HOTEL-OFFICER" },
                    { "04934ab6-6c9c-4fa1-ab36-9c6ee954e748", null, "CMS-Admin", "CMS-ADMIN" },
                    { "071121a3-a5da-45b6-9e24-5014ccc6246e", null, "Offer-Officer", "OFFER-OFFICER" },
                    { "096a28ab-9b2e-45f0-b648-cd88b7517202", null, "Notification-Admin", "NOTIFICATION-ADMIN" },
                    { "398137ed-cee2-4013-9c94-ccc90ef53e89", null, "Notification-Supervisor", "NOTIFICATION-SUPERVISOR" },
                    { "3aaa5d33-d9d9-49aa-8756-f96a55a30d00", null, "Gallery-Supervisor", "GALLERY-SUPERVISOR" },
                    { "40d6aa2b-76f6-458a-869f-ac215526e07c", null, "CWCore-Manager", "CWCORE-MANAGER" },
                    { "4334c7b8-b800-4561-8a0e-7785aaaa2887", null, "Hotel-Admin", "HOTEL-ADMIN" },
                    { "4c00bc71-a1c3-4302-abd3-91dc2c10d6d5", null, "Offer-Manager", "OFFER-MANAGER" },
                    { "53bef389-bd02-478d-b970-a151b652a3a3", null, "SuperAdmin", "SUPERADMIN" },
                    { "69a8eac4-bf50-417c-84d9-32bdcabd908f", null, "Gallery-Admin", "GALLERY-ADMIN" },
                    { "705dd026-fd38-44ef-9b9b-850100a87de3", null, "Authntication-Officer", "AUTHNTICATION-OFFICER" },
                    { "70e941cd-dca5-4af7-a468-71abe33b80de", null, "Hotel-Manager", "HOTEL-MANAGER" },
                    { "735ef191-4635-41b3-af9a-19ef21fb8964", null, "CMS-Manager", "CMS-MANAGER" },
                    { "83b1358a-d571-4494-888d-fe4f2456f0af", null, "Offer-Supervisor", "OFFER-SUPERVISOR" },
                    { "85edc6aa-54b7-4121-ae58-883aa6e0fcb6", null, "CWCore-Admin", "CWCORE-ADMIN" },
                    { "88ab1ebd-e139-4654-9ab4-483373a4ad32", null, "Notification-Manager", "NOTIFICATION-MANAGER" },
                    { "9a20b562-abd8-47e6-8252-bce057ebe10c", null, "CWCore-Supervisor", "CWCORE-SUPERVISOR" },
                    { "9aa58402-e520-47f7-afb3-b66ff512789d", null, "Authntication-Supervisor", "AUTHNTICATION-SUPERVISOR" },
                    { "9bbcf419-5c0a-4caa-85f1-245b2b947826", null, "Hotel-Supervisor", "HOTEL-SUPERVISOR" },
                    { "9e6f2224-16bf-4110-b648-b4ef6553e798", null, "Notification-Officer", "NOTIFICATION-OFFICER" },
                    { "a6480ac0-a844-49e1-abc0-316a752b076e", null, "Offer-Admin", "OFFER-ADMIN" },
                    { "b78e69ab-dd6b-41e1-ad16-18ba3de500cb", null, "Gallery-Officer", "GALLERY-OFFICER" },
                    { "caec9049-8143-4d9c-b1b2-b07bba9adbb6", null, "CMS-Supervisor", "CMS-SUPERVISOR" },
                    { "db2b3834-62ea-4363-b545-91b735424e24", null, "Authntication-Admin", "AUTHNTICATION-ADMIN" },
                    { "e606249e-f1cb-4534-abf2-8d0d4fe77e7d", null, "Gallery-Manager", "GALLERY-MANAGER" },
                    { "edd3383c-5aed-4374-8d4b-476203efd386", null, "CMS-Officer", "CMS-OFFICER" },
                    { "fdecff09-b290-4c2f-89f5-e6af65955382", null, "CWCore-Officer", "CWCORE-OFFICER" }
                });
        }
    }
}
