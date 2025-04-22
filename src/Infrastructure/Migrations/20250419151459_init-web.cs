using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initweb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccountName",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccountNumber",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ActivateProductsInHome",
                table: "Settings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AddBlogToFooter",
                table: "Settings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AddBlogToHome",
                table: "Settings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AddBlogToMenu",
                table: "Settings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AddCareerToFooter",
                table: "Settings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AddCareerToMenu",
                table: "Settings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AddFaqToFooter",
                table: "Settings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AddFaqToHome",
                table: "Settings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AddPartnerToHome",
                table: "Settings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AddTestimonyToFooter",
                table: "Settings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AddTestimonyToHome",
                table: "Settings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "AddressOne",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressTwo",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankName",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BlogDisplayTitle",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BreakingNewsRibonTitle",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CareerDisplayTitle",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomMenuTop",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DefaultAttendanceCloseTime",
                table: "Settings",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DefaultAttendanceStartTime",
                table: "Settings",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DefaultAttendanceStartTimeSaturday",
                table: "Settings",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DefaultTitleBackgroundKey",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DefaultTitleBackgroundUrl",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "DisableMainTopMenu",
                table: "Settings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "EarlyMinute",
                table: "Settings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "EmailOne",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmailThree",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmailTwo",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EnableBreakingNewsRibon",
                table: "Settings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "FacebookPage",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GoogleMap",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstagramPage",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobCardNote",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobCardTitleBackgroundKey",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobCardTitleBackgroundUrl",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LateMinute",
                table: "Settings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OntimeMinute",
                table: "Settings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PhoneOne",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneThree",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneTwo",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Qoute",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReportCloseTime",
                table: "Settings",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RibonPosition",
                table: "Settings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "ShowAddressOneInTop",
                table: "Settings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ShowContactUsFooter",
                table: "Settings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ShowContactUsMenu",
                table: "Settings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ShowEmailOneInFooter",
                table: "Settings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ShowEmailOneInTop",
                table: "Settings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ShowEmailThreeInFooter",
                table: "Settings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ShowEmailThreeInTop",
                table: "Settings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ShowEmailTwoInFooter",
                table: "Settings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ShowEmailTwoInTop",
                table: "Settings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ShowPhoneOneInFooter",
                table: "Settings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ShowPhoneOneInTop",
                table: "Settings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ShowPhoneThreeInFooter",
                table: "Settings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ShowPhoneThreeInTop",
                table: "Settings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ShowPhoneTwoInFooter",
                table: "Settings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ShowPhoneTwoInTop",
                table: "Settings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ShowProductsInFooter",
                table: "Settings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ShowProductsInMenu",
                table: "Settings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ShowSixProducts",
                table: "Settings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ShowThreeProducts",
                table: "Settings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ShowTwoProducts",
                table: "Settings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SignatureKey",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SignatureName",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SignatureTitle",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SignatureUrl",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TiktokPage",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TopNote",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TwitterPage",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "UseCategoryBlog",
                table: "Settings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "UseCustomMenuTop",
                table: "Settings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "VeryLateMinute",
                table: "Settings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "WorkingHour",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "YoutubeChannel",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BlogCategories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Publish = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientRequests",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DataConfigs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoginCSS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LayoutCSS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LayoutJavaScript = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DashboardCSS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RedirectTohttpswww = table.Column<bool>(type: "bit", nullable: false),
                    RedirectTohttps = table.Column<bool>(type: "bit", nullable: false),
                    Configuration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LiveConfiguration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MailSender = table.Column<int>(type: "int", nullable: false),
                    OutlookServer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OutlookPort = table.Column<int>(type: "int", nullable: false),
                    OutlookUsername = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OutlookSecurity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OutlookSenderEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OutlookSSLEnable = table.Column<bool>(type: "bit", nullable: false),
                    OutlookUseDefaultCredentials = table.Column<bool>(type: "bit", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoogleServer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GooglePort = table.Column<int>(type: "int", nullable: false),
                    GoogleUsername = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoogleSecurity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoogleSenderEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoogleSSLEnable = table.Column<bool>(type: "bit", nullable: false),
                    GoogleUseDefaultCredentials = table.Column<bool>(type: "bit", nullable: false),
                    WebmailServer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebmailPort = table.Column<int>(type: "int", nullable: false),
                    WebmailUsername = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebmailSecurity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebmailSenderEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebmailSSLEnable = table.Column<bool>(type: "bit", nullable: false),
                    WebmailUseDefaultCredentials = table.Column<bool>(type: "bit", nullable: false),
                    CCmails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BBmails = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataConfigs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FAQs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    Show = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAQs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PageCategories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Publish = table.Column<bool>(type: "bit", nullable: false),
                    MenuSortOrder = table.Column<int>(type: "int", nullable: false),
                    HomeSortFrom = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostModal",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModalTime = table.Column<int>(type: "int", nullable: false),
                    ModalOccurance = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StopTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ShowOnlyImage = table.Column<bool>(type: "bit", nullable: false),
                    ShowTitle = table.Column<bool>(type: "bit", nullable: false),
                    ShowDescription = table.Column<bool>(type: "bit", nullable: false),
                    ShowImage = table.Column<bool>(type: "bit", nullable: false),
                    Publish = table.Column<bool>(type: "bit", nullable: false),
                    ButtonLink = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostModal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PriceSettings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NetworkProvider = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DigitCount = table.Column<int>(type: "int", nullable: false),
                    UnitsPerSms = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InternationalDialCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Publish = table.Column<bool>(type: "bit", nullable: false),
                    MenuSortOrder = table.Column<int>(type: "int", nullable: false),
                    HomeSortFrom = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sliders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YoutubeVideo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsVideo = table.Column<bool>(type: "bit", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    Show = table.Column<bool>(type: "bit", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiniTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ButtonText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ButtonLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisableVideoButton = table.Column<bool>(type: "bit", nullable: false),
                    VideoLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoButtonText = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sliders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SuperSettings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BucketName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserNipssArea = table.Column<bool>(type: "bit", nullable: false),
                    ActivateLogin = table.Column<bool>(type: "bit", nullable: false),
                    ActivateLoginInMenu = table.Column<bool>(type: "bit", nullable: false),
                    MaximumUsers = table.Column<int>(type: "int", nullable: false),
                    TemplateLayoutKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoginTemplateKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColorTemplateKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SliderTemplateKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductTemplateKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BlogTemplateKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReloaderTemplateKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PageHeaderTemplateKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FooterTemplateKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebsiteTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyNameAbbreviation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyWebsiteLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DashboardTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyLogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyLogoKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyWhiteLogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyWhiteLogoKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyIconUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyIconKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReloaderIconUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReloaderIconKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JustWebsite = table.Column<bool>(type: "bit", nullable: false),
                    ActivateOnlyAuthorizedDevice = table.Column<bool>(type: "bit", nullable: false),
                    ActivateSMS = table.Column<bool>(type: "bit", nullable: false),
                    EmailTemplate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SMSTemplate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoginBackgroundImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoginBackgroundImageKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UseNormalLogoInLogin = table.Column<bool>(type: "bit", nullable: false),
                    UseWhiteLogoInLogin = table.Column<bool>(type: "bit", nullable: false),
                    LoginTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoginNoteTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoginNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoginNoteFooter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActivateComingSoon = table.Column<bool>(type: "bit", nullable: false),
                    ProductTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductTitleHome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShowMadeByJuray = table.Column<bool>(type: "bit", nullable: false),
                    ShowMadeByXYZ = table.Column<bool>(type: "bit", nullable: false),
                    ActivateProfilePortfolio = table.Column<bool>(type: "bit", nullable: false),
                    VerifyTokenFolio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PortfolioImageOneUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PortfolioImageOneKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PortfolioImageTwoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PortfolioImageTwoKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PortfolioBreacrumImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PortfolioBreacrumImageKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PortfolioTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PortfolioMiniTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PortfolioDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShowInMenuPortfolio = table.Column<bool>(type: "bit", nullable: false),
                    ShowInFooterPortfolio = table.Column<bool>(type: "bit", nullable: false),
                    SpecialMenuButtonText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecialMenuButtonLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecialMenuButtonActivate = table.Column<bool>(type: "bit", nullable: false),
                    ActivateWorkWithUsFooter = table.Column<bool>(type: "bit", nullable: false),
                    TitleWorkWithUsFooter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActivateDownloadOurAppFooter = table.Column<bool>(type: "bit", nullable: false),
                    ActivateSubscribeFormOnFooter = table.Column<bool>(type: "bit", nullable: false),
                    TitleDownloadOurAppFooter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionDownloadOurAppFooter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlayStoreImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlayStoreImageKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlayStoreLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppStoreImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppStoreImageKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppStoreLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EncryptionNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EncryptionUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EncryptionKey = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuperSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TemplateCategories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Layout = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoginLayout = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TemplateName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TemplateColorPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UniqueKey = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Testimonies",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SortOrder = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Show = table.Column<bool>(type: "bit", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Testimonies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Publish = table.Column<bool>(type: "bit", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BlogCategoryId = table.Column<long>(type: "bigint", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddToRibon = table.Column<bool>(type: "bit", nullable: false),
                    RibonCustomDisplayTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RibonSortOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blogs_BlogCategories_BlogCategoryId",
                        column: x => x.BlogCategoryId,
                        principalTable: "BlogCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WebPages",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    Publish = table.Column<bool>(type: "bit", nullable: false),
                    SecurityPage = table.Column<bool>(type: "bit", nullable: false),
                    PageCategoryId = table.Column<long>(type: "bigint", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShowInMainTop = table.Column<bool>(type: "bit", nullable: false),
                    ShowInMenuDropDown = table.Column<bool>(type: "bit", nullable: false),
                    ShowInMainMenu = table.Column<bool>(type: "bit", nullable: false),
                    ShowInFooter = table.Column<bool>(type: "bit", nullable: false),
                    EnableDirectUrl = table.Column<bool>(type: "bit", nullable: false),
                    DirectUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeSortFrom = table.Column<int>(type: "int", nullable: false),
                    MainPageId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebPages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WebPages_PageCategories_PageCategoryId",
                        column: x => x.PageCategoryId,
                        principalTable: "PageCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DialCodes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberPrefix = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriceSettingId = table.Column<int>(type: "int", nullable: false),
                    PriceSettingId1 = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DialCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DialCodes_PriceSettings_PriceSettingId1",
                        column: x => x.PriceSettingId1,
                        principalTable: "PriceSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiniTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductCategoryId = table.Column<long>(type: "bigint", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DisableAmount = table.Column<bool>(type: "bit", nullable: false),
                    ShowSamples = table.Column<bool>(type: "bit", nullable: false),
                    StatusNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ButtonText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShowInDropdown = table.Column<bool>(type: "bit", nullable: false),
                    ShowInHome = table.Column<bool>(type: "bit", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    TitleBackgroundUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleBackgroundKey = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductCategories_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TemplateTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrackKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TemplateCategoryId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TemplateTypes_TemplateCategories_TemplateCategoryId",
                        column: x => x.TemplateCategoryId,
                        principalTable: "TemplateCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PageSections",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondImageKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YoutubeUrlLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiniTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Qoute = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ButtonText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ButtonLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DirectUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShowInHome = table.Column<bool>(type: "bit", nullable: false),
                    DisableButton = table.Column<bool>(type: "bit", nullable: false),
                    Disable = table.Column<bool>(type: "bit", nullable: false),
                    FixedAfterFooter = table.Column<bool>(type: "bit", nullable: false),
                    HomePageSortOrder = table.Column<int>(type: "int", nullable: false),
                    HomeSortFrom = table.Column<int>(type: "int", nullable: false),
                    PageSortOrder = table.Column<int>(type: "int", nullable: false),
                    BlogSectionPosition = table.Column<int>(type: "int", nullable: false),
                    ShowSectionInBlog = table.Column<bool>(type: "bit", nullable: false),
                    WebPageId = table.Column<long>(type: "bigint", nullable: true),
                    TemplateKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddToRibon = table.Column<bool>(type: "bit", nullable: false),
                    RibonCustomDisplayTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RibonSortOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageSections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PageSections_WebPages_WebPageId",
                        column: x => x.WebPageId,
                        principalTable: "WebPages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductFeatures",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IconText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductFeatures_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductSamples",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSamples", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductSamples_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PageSectionLists",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IconText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiniTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoreDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ButtonText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ButtonLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DirectUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disable = table.Column<bool>(type: "bit", nullable: false),
                    PageSectionId = table.Column<long>(type: "bigint", nullable: true),
                    AddToRibon = table.Column<bool>(type: "bit", nullable: false),
                    RibonCustomDisplayTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RibonSortOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageSectionLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PageSectionLists_PageSections_PageSectionId",
                        column: x => x.PageSectionId,
                        principalTable: "PageSections",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_BlogCategoryId",
                table: "Blogs",
                column: "BlogCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_DialCodes_PriceSettingId1",
                table: "DialCodes",
                column: "PriceSettingId1");

            migrationBuilder.CreateIndex(
                name: "IX_PageSectionLists_PageSectionId",
                table: "PageSectionLists",
                column: "PageSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_PageSections_WebPageId",
                table: "PageSections",
                column: "WebPageId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductFeatures_ProductId",
                table: "ProductFeatures",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCategoryId",
                table: "Products",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSamples_ProductId",
                table: "ProductSamples",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateTypes_TemplateCategoryId",
                table: "TemplateTypes",
                column: "TemplateCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_WebPages_PageCategoryId",
                table: "WebPages",
                column: "PageCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "ClientRequests");

            migrationBuilder.DropTable(
                name: "DataConfigs");

            migrationBuilder.DropTable(
                name: "DialCodes");

            migrationBuilder.DropTable(
                name: "FAQs");

            migrationBuilder.DropTable(
                name: "PageSectionLists");

            migrationBuilder.DropTable(
                name: "PostModal");

            migrationBuilder.DropTable(
                name: "ProductFeatures");

            migrationBuilder.DropTable(
                name: "ProductSamples");

            migrationBuilder.DropTable(
                name: "Sliders");

            migrationBuilder.DropTable(
                name: "SuperSettings");

            migrationBuilder.DropTable(
                name: "TemplateTypes");

            migrationBuilder.DropTable(
                name: "Testimonies");

            migrationBuilder.DropTable(
                name: "BlogCategories");

            migrationBuilder.DropTable(
                name: "PriceSettings");

            migrationBuilder.DropTable(
                name: "PageSections");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "TemplateCategories");

            migrationBuilder.DropTable(
                name: "WebPages");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "PageCategories");

            migrationBuilder.DropColumn(
                name: "AccountName",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "AccountNumber",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "ActivateProductsInHome",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "AddBlogToFooter",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "AddBlogToHome",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "AddBlogToMenu",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "AddCareerToFooter",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "AddCareerToMenu",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "AddFaqToFooter",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "AddFaqToHome",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "AddPartnerToHome",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "AddTestimonyToFooter",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "AddTestimonyToHome",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "AddressOne",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "AddressTwo",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "BankName",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "BlogDisplayTitle",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "BreakingNewsRibonTitle",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "CareerDisplayTitle",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "CustomMenuTop",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "DefaultAttendanceCloseTime",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "DefaultAttendanceStartTime",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "DefaultAttendanceStartTimeSaturday",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "DefaultTitleBackgroundKey",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "DefaultTitleBackgroundUrl",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "DisableMainTopMenu",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "EarlyMinute",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "EmailOne",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "EmailThree",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "EmailTwo",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "EnableBreakingNewsRibon",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "FacebookPage",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "GoogleMap",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "InstagramPage",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "JobCardNote",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "JobCardTitleBackgroundKey",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "JobCardTitleBackgroundUrl",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "LateMinute",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "OntimeMinute",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "PhoneOne",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "PhoneThree",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "PhoneTwo",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "Qoute",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "ReportCloseTime",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "RibonPosition",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "ShowAddressOneInTop",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "ShowContactUsFooter",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "ShowContactUsMenu",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "ShowEmailOneInFooter",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "ShowEmailOneInTop",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "ShowEmailThreeInFooter",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "ShowEmailThreeInTop",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "ShowEmailTwoInFooter",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "ShowEmailTwoInTop",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "ShowPhoneOneInFooter",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "ShowPhoneOneInTop",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "ShowPhoneThreeInFooter",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "ShowPhoneThreeInTop",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "ShowPhoneTwoInFooter",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "ShowPhoneTwoInTop",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "ShowProductsInFooter",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "ShowProductsInMenu",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "ShowSixProducts",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "ShowThreeProducts",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "ShowTwoProducts",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "SignatureKey",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "SignatureName",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "SignatureTitle",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "SignatureUrl",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "TiktokPage",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "TopNote",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "TwitterPage",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "UseCategoryBlog",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "UseCustomMenuTop",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "VeryLateMinute",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "WorkingHour",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "YoutubeChannel",
                table: "Settings");
        }
    }
}
