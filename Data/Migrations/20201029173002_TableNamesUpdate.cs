using Microsoft.EntityFrameworkCore.Migrations;

namespace eDoc.Data.Migrations
{
    public partial class TableNamesUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Country_CountryId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_Municipality_MunicipalityId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_Region_RegionId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_AmbulatoryList_AspNetUsers_DoctorId",
                table: "AmbulatoryList");

            migrationBuilder.DropForeignKey(
                name: "FK_AmbulatoryList_AspNetUsers_PatientId",
                table: "AmbulatoryList");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Address_AddressId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Workplace_WorkplaceId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_MedicalCenter_MedicalCenterId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Contact_AspNetUsers_ApplicationUserId",
                table: "Contact");

            migrationBuilder.DropForeignKey(
                name: "FK_IssuedDoc_AmbulatoryList_AmbulatoryListId",
                table: "IssuedDoc");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalCenter_Address_AddressId",
                table: "MedicalCenter");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_AspNetUsers_DoctorId",
                table: "Recipe");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_AspNetUsers_PatientId",
                table: "Recipe");

            migrationBuilder.DropForeignKey(
                name: "FK_SickLeaveList_AspNetUsers_DoctorId",
                table: "SickLeaveList");

            migrationBuilder.DropForeignKey(
                name: "FK_SickLeaveList_MKBDiagnose_MKBDiagnoseId",
                table: "SickLeaveList");

            migrationBuilder.DropForeignKey(
                name: "FK_SickLeaveList_AspNetUsers_PatientId",
                table: "SickLeaveList");

            migrationBuilder.DropForeignKey(
                name: "FK_Test_AmbulatoryList_AmbulatoryListId",
                table: "Test");

            migrationBuilder.DropForeignKey(
                name: "FK_Workplace_Address_AddressId",
                table: "Workplace");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Workplace",
                table: "Workplace");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Test",
                table: "Test");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SickLeaveList",
                table: "SickLeaveList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Region",
                table: "Region");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recipe",
                table: "Recipe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Municipality",
                table: "Municipality");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MKBDiagnose",
                table: "MKBDiagnose");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicalCenter",
                table: "MedicalCenter");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IssuedDoc",
                table: "IssuedDoc");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Country",
                table: "Country");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contact",
                table: "Contact");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AmbulatoryList",
                table: "AmbulatoryList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Address",
                table: "Address");

            migrationBuilder.RenameTable(
                name: "Workplace",
                newName: "Workplaces");

            migrationBuilder.RenameTable(
                name: "Test",
                newName: "Tests");

            migrationBuilder.RenameTable(
                name: "SickLeaveList",
                newName: "SickLeaveLists");

            migrationBuilder.RenameTable(
                name: "Region",
                newName: "Regions");

            migrationBuilder.RenameTable(
                name: "Recipe",
                newName: "Recipes");

            migrationBuilder.RenameTable(
                name: "Municipality",
                newName: "Municipalities");

            migrationBuilder.RenameTable(
                name: "MKBDiagnose",
                newName: "MKBDiagnoses");

            migrationBuilder.RenameTable(
                name: "MedicalCenter",
                newName: "MedicalCenters");

            migrationBuilder.RenameTable(
                name: "IssuedDoc",
                newName: "IssuedDocuments");

            migrationBuilder.RenameTable(
                name: "Country",
                newName: "Countries");

            migrationBuilder.RenameTable(
                name: "Contact",
                newName: "Contacts");

            migrationBuilder.RenameTable(
                name: "AmbulatoryList",
                newName: "AmbulatoryLists");

            migrationBuilder.RenameTable(
                name: "Address",
                newName: "Addresses");

            migrationBuilder.RenameIndex(
                name: "IX_Workplace_AddressId",
                table: "Workplaces",
                newName: "IX_Workplaces_AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Test_AmbulatoryListId",
                table: "Tests",
                newName: "IX_Tests_AmbulatoryListId");

            migrationBuilder.RenameIndex(
                name: "IX_SickLeaveList_PatientId",
                table: "SickLeaveLists",
                newName: "IX_SickLeaveLists_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_SickLeaveList_MKBDiagnoseId",
                table: "SickLeaveLists",
                newName: "IX_SickLeaveLists_MKBDiagnoseId");

            migrationBuilder.RenameIndex(
                name: "IX_SickLeaveList_DoctorId",
                table: "SickLeaveLists",
                newName: "IX_SickLeaveLists_DoctorId");

            migrationBuilder.RenameIndex(
                name: "IX_Recipe_PatientId",
                table: "Recipes",
                newName: "IX_Recipes_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_Recipe_DoctorId",
                table: "Recipes",
                newName: "IX_Recipes_DoctorId");

            migrationBuilder.RenameIndex(
                name: "IX_MedicalCenter_AddressId",
                table: "MedicalCenters",
                newName: "IX_MedicalCenters_AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_IssuedDoc_AmbulatoryListId",
                table: "IssuedDocuments",
                newName: "IX_IssuedDocuments_AmbulatoryListId");

            migrationBuilder.RenameIndex(
                name: "IX_Contact_ApplicationUserId",
                table: "Contacts",
                newName: "IX_Contacts_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_AmbulatoryList_PatientId",
                table: "AmbulatoryLists",
                newName: "IX_AmbulatoryLists_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_AmbulatoryList_DoctorId",
                table: "AmbulatoryLists",
                newName: "IX_AmbulatoryLists_DoctorId");

            migrationBuilder.RenameIndex(
                name: "IX_Address_RegionId",
                table: "Addresses",
                newName: "IX_Addresses_RegionId");

            migrationBuilder.RenameIndex(
                name: "IX_Address_MunicipalityId",
                table: "Addresses",
                newName: "IX_Addresses_MunicipalityId");

            migrationBuilder.RenameIndex(
                name: "IX_Address_CountryId",
                table: "Addresses",
                newName: "IX_Addresses_CountryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Workplaces",
                table: "Workplaces",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tests",
                table: "Tests",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SickLeaveLists",
                table: "SickLeaveLists",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Regions",
                table: "Regions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recipes",
                table: "Recipes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Municipalities",
                table: "Municipalities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MKBDiagnoses",
                table: "MKBDiagnoses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicalCenters",
                table: "MedicalCenters",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IssuedDocuments",
                table: "IssuedDocuments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Countries",
                table: "Countries",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AmbulatoryLists",
                table: "AmbulatoryLists",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Countries_CountryId",
                table: "Addresses",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Municipalities_MunicipalityId",
                table: "Addresses",
                column: "MunicipalityId",
                principalTable: "Municipalities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Regions_RegionId",
                table: "Addresses",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AmbulatoryLists_AspNetUsers_DoctorId",
                table: "AmbulatoryLists",
                column: "DoctorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AmbulatoryLists_AspNetUsers_PatientId",
                table: "AmbulatoryLists",
                column: "PatientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Addresses_AddressId",
                table: "AspNetUsers",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Workplaces_WorkplaceId",
                table: "AspNetUsers",
                column: "WorkplaceId",
                principalTable: "Workplaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_MedicalCenters_MedicalCenterId",
                table: "AspNetUsers",
                column: "MedicalCenterId",
                principalTable: "MedicalCenters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_AspNetUsers_ApplicationUserId",
                table: "Contacts",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IssuedDocuments_AmbulatoryLists_AmbulatoryListId",
                table: "IssuedDocuments",
                column: "AmbulatoryListId",
                principalTable: "AmbulatoryLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalCenters_Addresses_AddressId",
                table: "MedicalCenters",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_AspNetUsers_DoctorId",
                table: "Recipes",
                column: "DoctorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_AspNetUsers_PatientId",
                table: "Recipes",
                column: "PatientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SickLeaveLists_AspNetUsers_DoctorId",
                table: "SickLeaveLists",
                column: "DoctorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SickLeaveLists_MKBDiagnoses_MKBDiagnoseId",
                table: "SickLeaveLists",
                column: "MKBDiagnoseId",
                principalTable: "MKBDiagnoses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SickLeaveLists_AspNetUsers_PatientId",
                table: "SickLeaveLists",
                column: "PatientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_AmbulatoryLists_AmbulatoryListId",
                table: "Tests",
                column: "AmbulatoryListId",
                principalTable: "AmbulatoryLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Workplaces_Addresses_AddressId",
                table: "Workplaces",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Countries_CountryId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Municipalities_MunicipalityId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Regions_RegionId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_AmbulatoryLists_AspNetUsers_DoctorId",
                table: "AmbulatoryLists");

            migrationBuilder.DropForeignKey(
                name: "FK_AmbulatoryLists_AspNetUsers_PatientId",
                table: "AmbulatoryLists");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Addresses_AddressId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Workplaces_WorkplaceId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_MedicalCenters_MedicalCenterId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_AspNetUsers_ApplicationUserId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_IssuedDocuments_AmbulatoryLists_AmbulatoryListId",
                table: "IssuedDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalCenters_Addresses_AddressId",
                table: "MedicalCenters");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_AspNetUsers_DoctorId",
                table: "Recipes");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_AspNetUsers_PatientId",
                table: "Recipes");

            migrationBuilder.DropForeignKey(
                name: "FK_SickLeaveLists_AspNetUsers_DoctorId",
                table: "SickLeaveLists");

            migrationBuilder.DropForeignKey(
                name: "FK_SickLeaveLists_MKBDiagnoses_MKBDiagnoseId",
                table: "SickLeaveLists");

            migrationBuilder.DropForeignKey(
                name: "FK_SickLeaveLists_AspNetUsers_PatientId",
                table: "SickLeaveLists");

            migrationBuilder.DropForeignKey(
                name: "FK_Tests_AmbulatoryLists_AmbulatoryListId",
                table: "Tests");

            migrationBuilder.DropForeignKey(
                name: "FK_Workplaces_Addresses_AddressId",
                table: "Workplaces");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Workplaces",
                table: "Workplaces");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tests",
                table: "Tests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SickLeaveLists",
                table: "SickLeaveLists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Regions",
                table: "Regions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recipes",
                table: "Recipes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Municipalities",
                table: "Municipalities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MKBDiagnoses",
                table: "MKBDiagnoses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicalCenters",
                table: "MedicalCenters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IssuedDocuments",
                table: "IssuedDocuments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Countries",
                table: "Countries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AmbulatoryLists",
                table: "AmbulatoryLists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses");

            migrationBuilder.RenameTable(
                name: "Workplaces",
                newName: "Workplace");

            migrationBuilder.RenameTable(
                name: "Tests",
                newName: "Test");

            migrationBuilder.RenameTable(
                name: "SickLeaveLists",
                newName: "SickLeaveList");

            migrationBuilder.RenameTable(
                name: "Regions",
                newName: "Region");

            migrationBuilder.RenameTable(
                name: "Recipes",
                newName: "Recipe");

            migrationBuilder.RenameTable(
                name: "Municipalities",
                newName: "Municipality");

            migrationBuilder.RenameTable(
                name: "MKBDiagnoses",
                newName: "MKBDiagnose");

            migrationBuilder.RenameTable(
                name: "MedicalCenters",
                newName: "MedicalCenter");

            migrationBuilder.RenameTable(
                name: "IssuedDocuments",
                newName: "IssuedDoc");

            migrationBuilder.RenameTable(
                name: "Countries",
                newName: "Country");

            migrationBuilder.RenameTable(
                name: "Contacts",
                newName: "Contact");

            migrationBuilder.RenameTable(
                name: "AmbulatoryLists",
                newName: "AmbulatoryList");

            migrationBuilder.RenameTable(
                name: "Addresses",
                newName: "Address");

            migrationBuilder.RenameIndex(
                name: "IX_Workplaces_AddressId",
                table: "Workplace",
                newName: "IX_Workplace_AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Tests_AmbulatoryListId",
                table: "Test",
                newName: "IX_Test_AmbulatoryListId");

            migrationBuilder.RenameIndex(
                name: "IX_SickLeaveLists_PatientId",
                table: "SickLeaveList",
                newName: "IX_SickLeaveList_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_SickLeaveLists_MKBDiagnoseId",
                table: "SickLeaveList",
                newName: "IX_SickLeaveList_MKBDiagnoseId");

            migrationBuilder.RenameIndex(
                name: "IX_SickLeaveLists_DoctorId",
                table: "SickLeaveList",
                newName: "IX_SickLeaveList_DoctorId");

            migrationBuilder.RenameIndex(
                name: "IX_Recipes_PatientId",
                table: "Recipe",
                newName: "IX_Recipe_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_Recipes_DoctorId",
                table: "Recipe",
                newName: "IX_Recipe_DoctorId");

            migrationBuilder.RenameIndex(
                name: "IX_MedicalCenters_AddressId",
                table: "MedicalCenter",
                newName: "IX_MedicalCenter_AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_IssuedDocuments_AmbulatoryListId",
                table: "IssuedDoc",
                newName: "IX_IssuedDoc_AmbulatoryListId");

            migrationBuilder.RenameIndex(
                name: "IX_Contacts_ApplicationUserId",
                table: "Contact",
                newName: "IX_Contact_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_AmbulatoryLists_PatientId",
                table: "AmbulatoryList",
                newName: "IX_AmbulatoryList_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_AmbulatoryLists_DoctorId",
                table: "AmbulatoryList",
                newName: "IX_AmbulatoryList_DoctorId");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_RegionId",
                table: "Address",
                newName: "IX_Address_RegionId");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_MunicipalityId",
                table: "Address",
                newName: "IX_Address_MunicipalityId");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_CountryId",
                table: "Address",
                newName: "IX_Address_CountryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Workplace",
                table: "Workplace",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Test",
                table: "Test",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SickLeaveList",
                table: "SickLeaveList",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Region",
                table: "Region",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recipe",
                table: "Recipe",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Municipality",
                table: "Municipality",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MKBDiagnose",
                table: "MKBDiagnose",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicalCenter",
                table: "MedicalCenter",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IssuedDoc",
                table: "IssuedDoc",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Country",
                table: "Country",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contact",
                table: "Contact",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AmbulatoryList",
                table: "AmbulatoryList",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Address",
                table: "Address",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Country_CountryId",
                table: "Address",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Municipality_MunicipalityId",
                table: "Address",
                column: "MunicipalityId",
                principalTable: "Municipality",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Region_RegionId",
                table: "Address",
                column: "RegionId",
                principalTable: "Region",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AmbulatoryList_AspNetUsers_DoctorId",
                table: "AmbulatoryList",
                column: "DoctorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AmbulatoryList_AspNetUsers_PatientId",
                table: "AmbulatoryList",
                column: "PatientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Address_AddressId",
                table: "AspNetUsers",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Workplace_WorkplaceId",
                table: "AspNetUsers",
                column: "WorkplaceId",
                principalTable: "Workplace",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_MedicalCenter_MedicalCenterId",
                table: "AspNetUsers",
                column: "MedicalCenterId",
                principalTable: "MedicalCenter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_AspNetUsers_ApplicationUserId",
                table: "Contact",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IssuedDoc_AmbulatoryList_AmbulatoryListId",
                table: "IssuedDoc",
                column: "AmbulatoryListId",
                principalTable: "AmbulatoryList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalCenter_Address_AddressId",
                table: "MedicalCenter",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_AspNetUsers_DoctorId",
                table: "Recipe",
                column: "DoctorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_AspNetUsers_PatientId",
                table: "Recipe",
                column: "PatientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SickLeaveList_AspNetUsers_DoctorId",
                table: "SickLeaveList",
                column: "DoctorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SickLeaveList_MKBDiagnose_MKBDiagnoseId",
                table: "SickLeaveList",
                column: "MKBDiagnoseId",
                principalTable: "MKBDiagnose",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SickLeaveList_AspNetUsers_PatientId",
                table: "SickLeaveList",
                column: "PatientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Test_AmbulatoryList_AmbulatoryListId",
                table: "Test",
                column: "AmbulatoryListId",
                principalTable: "AmbulatoryList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Workplace_Address_AddressId",
                table: "Workplace",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
