namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'33832b2e-cee2-4625-ac7c-3908c85f19b6', N'admingil@ewn.com', 0, N'ALHGOHQClWreitvkuKj/W5UWGu7vfQBqxJo+vme2Zeo0QoALwH604fyNsAXM/ybucg==', N'954489f5-091b-4d6d-9453-14cbb99065a3', NULL, 0, 0, NULL, 1, 0, N'admingil@ewn.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'47b1f85a-18a1-46a3-aa47-32d7c33374ad', N'gil@ewn.com', 0, N'AKlH85q9wEcgSWQnQhiuqQ/OSnmFT0p/7TpLqAx3joc3LnenY4/RWLN5kigmnrKZIA==', N'86265cd0-6686-4bcf-b477-a20e10bff1e7', NULL, 0, 0, NULL, 1, 0, N'gil@ewn.com')
                
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'77986a31-7ced-497e-8483-70b4885f3c45', N'CanManageMovies')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'33832b2e-cee2-4625-ac7c-3908c85f19b6', N'77986a31-7ced-497e-8483-70b4885f3c45')

                ");
        }
        
        public override void Down()
        {
        }
    }
}
