using Domain.Models;
using Domain.Models.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Context
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ProfileCategory> ProfileCategories { get; set; }
        public DbSet<ProfileCategoryList> ProfileCategoryLists { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<DialyActivity> DialyActivities { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<ModuleTopic> ModuleTopics { get; set; }
        public DbSet<Sponsor> Sponsors { get; set; }
        public DbSet<TestCategory> TestCategories { get; set; }
        public DbSet<TestSheet> TestSheets { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<TrainingCategory> TrainingCategories { get; set; }
        public DbSet<TrainingFacilitator> TrainingFacilitators { get; set; }
        public DbSet<TrainingParticipant> TrainingParticipants { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<TrainingTest> TrainingTests { get; set; }
        public DbSet<UserTest> UserTests { get; set; }
        public DbSet<EvaluationQuestion> EvaluationQuestions { get; set; }
        public DbSet<DialyUserEvaluation> DialyUserEvaluations { get; set; }
        public DbSet<EvaluationQuestionCategory> EvaluationQuestionCategories { get; set; }
        public DbSet<DialyEvaluationQuestion> DialyEvaluationQuestions { get; set; }
        public DbSet<TimeTable> TimeTables { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<SupervisorSectionQuestion> SupervisorSectionQuestions { get; set; }
        public DbSet<SupervisorSection> SupervisorSections { get; set; }
        public DbSet<SupervisorTrainingForm> SupervisorTrainingForms { get; set; }
        public DbSet<StatesAndAbbreviation> StatesAndAbbreviations { get; set; }
        public DbSet<Batch> Batches { get; set; }
        public DbSet<Provider> Providers { get; set; }


        public DbSet<ClientRequest> ClientRequests { get; set; }
         
        public DbSet<DialCode> DialCodes { get; set; } = null!;
        public DbSet<PriceSetting> PriceSettings { get; set; } = null!;
        public DbSet<SuperSetting> SuperSettings { get; set; } = null!; 
        public DbSet<TemplateCategory> TemplateCategories { get; set; } = null!;
        public DbSet<TemplateType> TemplateTypes { get; set; } = null!; 
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<WebPage> WebPages { get; set; }
        public DbSet<FAQ> FAQs { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogCategory> BlogCategories { get; set; }
        public DbSet<PageSection> PageSections { get; set; }
        public DbSet<PageSectionList> PageSectionLists { get; set; } 
        public DbSet<PageCategory> PageCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }
        public DbSet<ProductSample> ProductSamples { get; set; }
        public DbSet<Testimony> Testimonies { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; } 
         
        public DbSet<PostModal> PostModal { get; set; }
        public DbSet<DataConfig> DataConfigs { get; set; }
        public DbSet<UserCategory> UserCategories { get; set; }
        public DbSet<UserCategoryGroup> UserCategoryGroups { get; set; }








    }
}
