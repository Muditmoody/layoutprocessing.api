using Microsoft.EntityFrameworkCore;
using PWCLayoutProcessingWebApp.Models.ETL;
using PWCLayoutProcessingWebApp.Models.Model;
using PWCLayoutProcessingWebApp.Models.Mapping;

namespace PWCLayoutProcessingWebApp.Data
{
    public class LayoutProcessingDbContext : DbContext
    {
        private ILogger _logger;
        private IConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="LayoutProcessingDbContext"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="configuration">The configuration.</param>
        /// <param name="options">The options.</param>
        public LayoutProcessingDbContext(ILogger<LayoutProcessingDbContext> logger, IConfiguration configuration, DbContextOptions<LayoutProcessingDbContext> options)
           : base(options)
        {
            this._logger = logger;
            this._configuration = configuration;
        }

        /// <summary>
        /// Ons the configuring.
        /// </summary>
        /// <param name="optionsBuilder">The options builder.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("layoutProcessing"));
        }

        /// <summary>
        /// Gets or sets the cause codes.
        /// </summary>
        public virtual DbSet<CauseCode> CauseCodes { get; set; }

        /// <summary>
        /// Gets or sets the group codes.
        /// </summary>
        public virtual DbSet<CodeGroup> GroupCodes { get; set; }

        /// <summary>
        /// Gets or sets the coding codes.
        /// </summary>
        public virtual DbSet<CodingCode> CodingCodes { get; set; }

        /// <summary>
        /// Gets or sets the damage codes.
        /// </summary>
        public virtual DbSet<DamageCode> DamageCodes { get; set; }

        /// <summary>
        /// Gets or sets the materials.
        /// </summary>
        public virtual DbSet<Material> Materials { get; set; }

        /// <summary>
        /// Gets or sets the supplier vendors.
        /// </summary>
        public virtual DbSet<SupplierVendor> SupplierVendors { get; set; }

        /// <summary>
        /// Gets or sets the task codes.
        /// </summary>
        public virtual DbSet<TaskCode> TaskCodes { get; set; }

        /// <summary>
        /// Gets or sets the task owners.
        /// </summary>
        public virtual DbSet<TaskOwner> TaskOwners { get; set; }

        /// <summary>
        /// Gets or sets the task statuses.
        /// </summary>
        public virtual DbSet<Models.ETL.TaskStatus> TaskStatuses { get; set; }

        /// <summary>
        /// Gets or sets the engine programs.
        /// </summary>
        public virtual DbSet<EngineProgram> EnginePrograms { get; set; }

        /// <summary>
        /// Gets or sets the layout types.
        /// </summary>
        public virtual DbSet<LayoutType> LayoutTypes { get; set; }

        /// <summary>
        /// Gets or sets the layout processing tasks.
        /// </summary>
        public virtual DbSet<LayoutProcessingTask> LayoutProcessingTasks { get; set; }

        /// <summary>
        /// Gets or sets the categories.
        /// </summary>
        public virtual DbSet<Category> Categories { get; set; }

        /// <summary>
        /// Gets or sets the planning task codes.
        /// </summary>
        public virtual DbSet<PlanningTaskCode> PlanningTaskCodes { get; set; }

        /// <summary>
        /// Gets or sets the sequence similarities.
        /// </summary>
        public virtual DbSet<SequenceSimilarity> SequenceSimilarities { get; set; }

        /// <summary>
        /// Gets or sets the group task code matches.
        /// </summary>
        public virtual DbSet<GroupTaskCodeMatchMap> GroupTaskCodeMatches { get; set; }

        /// <summary>
        /// Gets or sets the clean model inputs.
        /// </summary>
        public virtual DbSet<CleanModelInput> CleanModelInputs { get; set; }

        /// <summary>
        /// Gets or sets the task duration predictions.
        /// </summary>
        public virtual DbSet<TaskDurationPrediction> TaskDurationPredictions { get; set; }

        /// <summary>
        /// Gets or sets the inactive item configs.
        /// </summary>
        public virtual DbSet<InactiveItemConfig> InactiveItemConfigs { get; set; }

        /// <summary>
        /// Ons the model creating.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CauseCode>(entity =>
            {
                entity.HasKey(e => e.CauseCodeId);
                entity.ToTable("CauseCode", "etl");

                entity.Property(e => e.CauseCodeId).HasColumnName("Id");
                entity.Property(e => e.CauseCodeName).HasColumnName("CauseCode");
                entity.Property(e => e.CauseText).HasColumnName("CauseText");
            });

            modelBuilder.Entity<CodeGroup>(entity =>
            {
                entity.HasKey(e => e.CodeGroupId);
                entity.ToTable("CodeGroup", "etl");

                entity.Property(e => e.CodeGroupId).HasColumnName("Id");
                entity.Property(e => e.CodeGroupName).HasColumnName("GroupCode");
                entity.Property(e => e.CodeGroupText).HasColumnName("GroupText");
                entity.HasMany(e => e.TaskCodes).WithOne(e => e.GroupCode).HasForeignKey(e => e.GroupCodeId);
            });

            modelBuilder.Entity<CodingCode>(entity =>
            {
                entity.HasKey(e => e.CodingCodeId);
                entity.ToTable("CodingCode", "etl");

                entity.Property(e => e.CodingCodeId).HasColumnName("Id");
                entity.Property(e => e.CodingCodeName).HasColumnName("Coding");
                entity.Property(e => e.CodingCodeText).HasColumnName("CodingText");
            });

            modelBuilder.Entity<DamageCode>(entity =>
            {
                entity.HasKey(e => e.DamageCodeId);
                entity.ToTable("DamageCode", "etl");

                entity.Property(e => e.DamageCodeId).HasColumnName("Id");
                entity.Property(e => e.DamageCodeName).HasColumnName("DamageCode");
                entity.Property(e => e.DamageCodeText).HasColumnName("DamageText");
            });

            modelBuilder.Entity<Material>(entity =>
            {
                entity.HasKey(e => e.MaterialId);
                entity.ToTable("Material", "etl");

                entity.Property(e => e.MaterialId).HasColumnName("Id");
                entity.Property(e => e.MaterialCode).HasColumnName("Material_Id");
                entity.Property(e => e.Description).HasColumnName("Description");
                entity.Property(e => e.CategoryId).HasColumnName("Category_Id");
                entity.HasOne(e => e.Category);
            });

            modelBuilder.Entity<SupplierVendor>(entity =>
            {
                entity.HasKey(e => e.SupplierVendorId);
                entity.ToTable("SupplierVendor", "etl");

                entity.Property(e => e.SupplierVendorId).HasColumnName("Id");
                entity.Property(e => e.SupplierVendorCode).HasColumnName("SupplierVendor_Id");
            });

            modelBuilder.Entity<TaskCode>(entity =>
            {
                entity.HasKey(e => e.TaskCodeId);
                entity.ToTable("TaskCode", "etl");

                entity.Property(e => e.TaskCodeId).HasColumnName("Id");
                entity.Property(e => e.TaskCodeName).HasColumnName("TaskCode");
                entity.Property(e => e.TaskCodeText).HasColumnName("TaskCodeText");
                entity.Property(e => e.GroupCodeId).HasColumnName("GroupCode");

                entity.HasOne(e => e.GroupCode).WithMany(e => e.TaskCodes).HasForeignKey(e => e.GroupCodeId);
            });

            modelBuilder.Entity<TaskOwner>(entity =>
            {
                entity.HasKey(e => e.TaskOwnerId);
                entity.ToTable("TaskOwner", "etl");

                entity.Property(e => e.TaskOwnerId).HasColumnName("Id");
                entity.Property(e => e.TaskOwnerCode).HasColumnName("TaskOwner_Id");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CategoryId);
                entity.ToTable("Category", "etl");

                entity.Property(e => e.CategoryId).HasColumnName("Id");
                entity.Property(e => e.CategoryName).HasColumnName("CategoryName");
            });

            modelBuilder.Entity<Models.ETL.TaskStatus>(entity =>
            {
                entity.HasKey(e => e.TaskStatusId);
                entity.ToTable("TaskStatus", "etl");

                entity.Property(e => e.TaskStatusId).HasColumnName("Id");
                entity.Property(e => e.TaskStatusCode).HasColumnName("TaskStatus");
            });

            modelBuilder.Entity<EngineProgram>(entity =>
            {
                entity.HasKey(e => e.EngineProgramId);
                entity.ToTable("EngineProgram", "etl");

                entity.Property(e => e.EngineProgramId).HasColumnName("Id");
                entity.Property(e => e.NotificationCode).HasColumnName("Notification_Id");
                entity.Property(e => e.Description).HasColumnName("Description");
                entity.Property(e => e.CodingCodeId).HasColumnName("CodingCode");

                entity.HasOne(e => e.CodingCode);
                entity.HasMany(e => e.layouts).WithOne(e => e.EngineProgram).HasForeignKey(e => e.NotificationId);
            });

            modelBuilder.Entity<LayoutType>(entity =>
            {
                entity.HasKey(e => e.LayoutTypeId);
                entity.ToTable("LayoutType", "etl");

                entity.Property(e => e.LayoutTypeId).HasColumnName("Id");
                entity.Property(e => e.NotificationId).HasColumnName("Notification_Id");
                entity.HasOne(e => e.EngineProgram).WithMany(e => e.layouts);

                entity.Property(e => e.ItemNumber).HasColumnName("Item_Number");
                entity.Property(e => e.LayoutText).HasColumnName("Layout_Text");

                entity.Property(e => e.DamageCodeId).HasColumnName("DamageCode");
                entity.HasOne(e => e.DamageCode);

                entity.Property(e => e.CauseCodeId).HasColumnName("CauseCode");
                entity.HasOne(e => e.CauseCode);
            });

            modelBuilder.Entity<LayoutProcessingTask>(entity =>
            {
                entity.HasKey(e => e.LayoutTaskId);
                entity.ToTable("LayoutProcessingTasks", "etl");

                entity.Property(e => e.LayoutTaskId).HasColumnName("Id");

                entity.Property(e => e.LayoutId).HasColumnName("Layout_Id");
                entity.HasOne(e => e.Layout);

                entity.Property(e => e.TaskId).HasColumnName("Task_Id");

                entity.Property(e => e.MaterialId).HasColumnName("Material_Id");
                entity.HasOne(e => e.Material);

                entity.Property(e => e.CreatedOn).HasColumnName("Created_On");
                entity.Property(e => e.CompletedOn).HasColumnName("Completed_On");

                entity.Property(e => e.TaskText).HasColumnName("Task_Text");

                entity.Property(e => e.TaskCodeId).HasColumnName("Task_Code_Id");
                entity.HasOne(e => e.TaskCode);

                entity.Property(e => e.PlannedStart).HasColumnName("Planned_Start");
                entity.Property(e => e.PlannedFinish).HasColumnName("Planned_Finish");

                entity.Property(e => e.SupplierVendorId).HasColumnName("SupplierVendor_Id");
                entity.HasOne(e => e.SupplierVendor);

                entity.Property(e => e.TaskOwnerId).HasColumnName("Task_Owner_Id");
                entity.HasOne(e => e.TaskOwner);

                entity.Property(e => e.TaskStatusId).HasColumnName("Task_Status_Id");
                entity.HasOne(e => e.TaskStatus);
            });

            modelBuilder.Entity<PlanningTaskCode>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("PlanningTaskCode", "etl");

                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.TaskCodeId).HasColumnName("TaskCode_id");
                entity.HasOne(e => e.TaskCode);
            });

            modelBuilder.Entity<SequenceSimilarity>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("SimilarityScore", "model");

                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.LayoutIdTest).HasColumnName("Layout_Id_Test");
                entity.Property(e => e.LayoutIdRef).HasColumnName("Layout_Id_Ref");
                entity.Property(e => e.TaskSequenceTest).HasColumnName("Seq_Test");
                entity.Property(e => e.TaskSequenceRef).HasColumnName("Seq_ref");
                entity.Property(e => e.AlignTaskSequenceTest).HasColumnName("Align_Seq_Test");
                entity.Property(e => e.AlignTaskSequenceRef).HasColumnName("Align_Seq_Ref");
                entity.Property(e => e.Score).HasColumnName("Score");
                entity.Property(e => e.RunDate).HasColumnName("Run_Date");
            });

            modelBuilder.Entity<GroupTaskCodeMatchMap>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("GroupTaskCodeMatchMap", "model");

                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.CodeGroup).HasColumnName("CodeGroup");
                entity.Property(e => e.TaskCode).HasColumnName("TaskCode");
                entity.Property(e => e.GeneralCode).HasColumnName("GeneralCode");
            });

            modelBuilder.Entity<CleanModelInput>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("CleanModelInput", "model");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.NotificationCode).HasColumnName("NotificationCode");
                entity.Property(e => e.ItemNumber).HasColumnName("ItemNumber");
                entity.Property(e => e.LayoutTaskId).HasColumnName("LayoutTaskId");
                entity.Property(e => e.TaskNumber).HasColumnName("TaskNumber");
                entity.Property(e => e.MaterialCode).HasColumnName("MaterialCode");
                entity.Property(e => e.CreatedDate).HasColumnName("CreatedDate");
                entity.Property(e => e.CompletedDate).HasColumnName("CompletedDate");
                entity.Property(e => e.TaskText).HasColumnName("TaskText");
                entity.Property(e => e.TaskCodeId).HasColumnName("TaskCodeId");
                entity.Property(e => e.TaskCode).HasColumnName("TaskCode");
                entity.Property(e => e.SupplierVendorId).HasColumnName("SupplierVendorId");
                entity.Property(e => e.SupplierVendorCode).HasColumnName("SupplierVendorCode");
                entity.Property(e => e.TaskOwnerId).HasColumnName("TaskOwnerId");
                entity.Property(e => e.TaskOwnerCode).HasColumnName("TaskOwnerCode");
                entity.Property(e => e.PlannedStart).HasColumnName("PlannedStart");
                entity.Property(e => e.PlannedFinish).HasColumnName("PlannedFinish");

                entity.Property(e => e.TaskStatusId).HasColumnName("TaskStatusId");

                entity.Property(e => e.TaskStatusCode).HasColumnName("TaskStatusCode");
                entity.Property(e => e.DamageCodeId).HasColumnName("DamageCodeId");
                entity.Property(e => e.DamageCode).HasColumnName("DamageCode");
                entity.Property(e => e.CauseCodeId).HasColumnName("CauseCodeId");
                entity.Property(e => e.CauseCode).HasColumnName("CauseCode");
                entity.Property(e => e.GroupCodeId).HasColumnName("GroupCodeId");
                entity.Property(e => e.GroupCode).HasColumnName("GroupCode");
                entity.Property(e => e.CategoryId).HasColumnName("CategoryId");
                entity.Property(e => e.Category).HasColumnName("Category");
                entity.Property(e => e.CodingCodeId).HasColumnName("CodingCodeId");
                entity.Property(e => e.EngineProgram).HasColumnName("EngineProgram");
                entity.Property(e => e.GeneralCode).HasColumnName("GeneralCode");
                entity.Property(e => e.PlannedStart).HasColumnName("PlannedStart");
                entity.Property(e => e.PlannedFinish).HasColumnName("PlannedFinish");
                entity.Property(e => e.IsTaskCompleted).HasColumnName("IsTaskCompleted").HasConversion<int>();
                entity.Property(e => e.IsItemCompleted).HasColumnName("IsItemCompleted").HasConversion<int>();
                entity.Property(e => e.IsTurnback).HasColumnName("IsTurnback").HasConversion<int>();
                entity.Property(e => e.IsLife).HasColumnName("IsLife").HasConversion<int>();
                entity.Property(e => e.IsPlanning).HasColumnName("IsPlanning").HasConversion<int>();
                entity.Property(e => e.Available).HasColumnName("Available");
                entity.Property(e => e.RunDate).HasColumnName("RunDate");
                entity.HasAlternateKey(e => e.Id).HasName("ModelInputId");
            });

            modelBuilder.Entity<TaskDurationPrediction>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("TaskDurationPrediction", "model");

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.ModelDataInputId).HasColumnName("ModelDataInput_Id");
                entity.Property(e => e.PredictionResult).HasColumnName("PredictionResult");
                entity.Property(e => e.RunDate).HasColumnName("RunDate");

                entity.HasOne(e => e.ModelDataInput);
            });

            modelBuilder.Entity<InactiveItemConfig>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.ToTable("InactiveItemConfig", "etl");

                entity.Property(e => e.ID).HasColumnName("ID");
                entity.Property(e => e.NotificationCode).HasColumnName("NotificationCode");
                entity.Property(e => e.ItemNumber).HasColumnName("ItemNumber");
                entity.Property(e => e.IgnoreInactiveItem).HasColumnName("IgnoreInactiveItem").HasConversion<int>();
                entity.Property(e => e.IgnoreInactiveTask).HasColumnName("IgnoreInactiveTask").HasConversion<int>();
            });
        }
    }
}