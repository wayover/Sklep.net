namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'0171063d-674b-492b-9842-0356333f11c6', N'qwertyu@234.pl', 0, N'AKfvx3zQ4AXzhZy43INWWtGwrHqcE6WLbGfZlJic4QAJ+jzHvh+VJqr3LOTqw1zWMA==', N'd500d58b-54af-40f8-9800-41b1524f4df4', NULL, 0, 0, NULL, 1, 0, N'qwertyu@234.pl')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7db2c1cc-75f2-4b7c-8ead-1ba004cd37da', N'admin@admin.pl', 0, N'ANkz4HChIf9BVXWL30DxO3QWskMHqGlCi5y/efYeGDiKk5K0kRXU42l13f1dSKgf8g==', N'8ee99741-bc63-4869-aa3b-5998417fbf97', NULL, 0, 0, NULL, 1, 0, N'admin@admin.pl')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'd0db3833-86d5-4cbc-ae21-6e6ebaf02c07', N'CanManagePredmiot')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'7db2c1cc-75f2-4b7c-8ead-1ba004cd37da', N'd0db3833-86d5-4cbc-ae21-6e6ebaf02c07')

");
        }
        
        public override void Down()
        {
        }
    }
}
