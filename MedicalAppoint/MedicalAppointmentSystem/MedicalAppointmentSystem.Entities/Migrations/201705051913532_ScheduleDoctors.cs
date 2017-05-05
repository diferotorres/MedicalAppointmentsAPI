namespace MedicalAppointmentSystem.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ScheduleDoctors : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ScheduleDoctors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DoctorId = c.Int(nullable: false),
                        PatientId = c.Int(nullable: false),
                        ScheduleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Schedules", t => t.ScheduleId, cascadeDelete: true)
                .Index(t => t.ScheduleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ScheduleDoctors", "ScheduleId", "dbo.Schedules");
            DropIndex("dbo.ScheduleDoctors", new[] { "ScheduleId" });
            DropTable("dbo.ScheduleDoctors");
        }
    }
}
