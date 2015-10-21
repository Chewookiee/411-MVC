namespace FoamMVC.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FoamMVC.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FoamMVC.Models.ApplicationDbContext context)
        {
            #region initLocations

            var locations = new List<Location>
            {
                new Location() { PrimaryLocation = "Boston, MA", SecondaryLocation = "", IsDeleted = false,
                DateAdded = DateTime.Now, DateDeleted = null, DateUpdated = null},
                new Location() { PrimaryLocation = "Madisonville, LA", SecondaryLocation = "", IsDeleted = false,
                DateAdded = DateTime.Now, DateDeleted = null, DateUpdated = null},
                new Location() { PrimaryLocation = "Ireland", SecondaryLocation = "", IsDeleted = false,
                DateAdded = DateTime.Now, DateDeleted = null, DateUpdated = null}
            };
            locations.ForEach(s => context.Locations.AddOrUpdate(l => l.PrimaryLocation, s));
            context.SaveChanges();

            #endregion

            #region initCompanies

            var companies = new List<Company>
            {
                new Company() { Name = "Boston Beer", IsDeleted = false, DateAdded = DateTime.Now, DateDeleted = null,
                    DateUpdated = null,
                    LocationID = locations.Single( s => s.PrimaryLocation.Equals("Boston, MA")).ID,
                    Items = new List<Item>() },
                new Company() { Name = "Champagne Beverage", IsDeleted = false, DateAdded = DateTime.Now, DateDeleted = null,
                    DateUpdated = null,
                    LocationID = locations.Single( s => s.PrimaryLocation.Equals("Madisonville, LA")).ID,
                    Items = new List<Item>() },
                new Company() { Name = "Guinness", IsDeleted = false, DateAdded = DateTime.Now, DateDeleted = null,
                    DateUpdated = null,
                    LocationID = locations.Single( s => s.PrimaryLocation.Equals("Ireland")).ID,
                    Items = new List<Item>() }
            };
            companies.ForEach(s => context.Companies.AddOrUpdate(c => c.Name, s));
            context.SaveChanges();

            #endregion

            #region initCategories

            var categories = new List<Category>
            {
                new Category() { Name = "Beer", IsDeleted = false, DateAdded = DateTime.Now, DateDeleted = null,
                    DateUpdated = null,
                    PalletDescriptors = new List<PalletDescriptor>() },
                new Category() { Name = "Wine", IsDeleted = false, DateAdded = DateTime.Now, DateDeleted = null,
                    DateUpdated = null,
                    PalletDescriptors = new List<PalletDescriptor>()  },
                new Category() { Name = "Spirits", IsDeleted = false, DateAdded = DateTime.Now, DateDeleted = null,
                    DateUpdated = null,
                    PalletDescriptors = new List<PalletDescriptor>()  }
            };
            categories.ForEach(s => context.Categories.AddOrUpdate(c => c.Name, s));
            context.SaveChanges();

            #endregion

            #region initPalletDescriptors

            var palletDescriptors = new List<PalletDescriptor>
            {
                new PalletDescriptor { Name = "Bitter", IsDeleted = false, DateAdded = DateTime.Now, DateDeleted = null,
                    DateUpdated = null, },
                new PalletDescriptor { Name = "Hoppiness", IsDeleted = false, DateAdded = DateTime.Now, DateDeleted = null,
                    DateUpdated = null, },
                new PalletDescriptor { Name = "Sweet", IsDeleted = false, DateAdded = DateTime.Now, DateDeleted = null,
                    DateUpdated = null, }
            };
            palletDescriptors.ForEach(s => context.PalletDescriptors.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            #endregion

            #region initPalletGroups

            var palletGroups = new List<PalletGroup>
            {
                new PalletGroup { Name = "IPA", IsDeleted = false, DateAdded = DateTime.Now, DateDeleted = null,
                    DateUpdated = null,
                    PalletDescriptors = new List<PalletDescriptor>() },
                new PalletGroup { Name = "Lager", IsDeleted = false, DateAdded = DateTime.Now, DateDeleted = null,
                    DateUpdated = null,
                    PalletDescriptors = new List<PalletDescriptor>() },
                new PalletGroup { Name = "Stout", IsDeleted = false, DateAdded = DateTime.Now, DateDeleted = null,
                    DateUpdated = null,
                    PalletDescriptors = new List<PalletDescriptor>() }
            };
            palletGroups.ForEach(s => context.PalletGroups.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            #endregion

            #region initTags

            var tags = new List<Tag>
            {
                new Tag { Name = "Common", IsDeleted = false, DateAdded = DateTime.Now, DateDeleted = null,
                    DateUpdated = null, },
                new Tag { Name = "Imported", IsDeleted = false, DateAdded = DateTime.Now, DateDeleted = null,
                    DateUpdated = null, },
                new Tag { Name = "Editors Choice", IsDeleted = false, DateAdded = DateTime.Now, DateDeleted = null,
                    DateUpdated = null, }
            };
            tags.ForEach(s => context.Tags.AddOrUpdate(t => t.Name, s));
            context.SaveChanges();

            #endregion

            #region initUsers

            //var users = new List<User>
            //{
            //    new User { FirstName = "Matthew", LastName = "Puneky", IsDeleted = false, DateAdded = DateTime.Now,
            //        DateDeleted = null, DateUpdated = null, },
            //    new User { FirstName = "Lee", LastName = "White", IsDeleted = false, DateAdded = DateTime.Now,
            //        DateDeleted = null, DateUpdated = null, },
            //    new User { FirstName = "Aaron", LastName = "Gross", IsDeleted = false, DateAdded = DateTime.Now,
            //        DateDeleted = null, DateUpdated = null, }
            //};
            //users.ForEach(s => context.Users.AddOrUpdate(u => u.LastName, s));
            //context.SaveChanges();

            #endregion

            #region initUserScoreForDescriptors

            //var userScoreForDescriptors = new List<UserScoreForDescriptor>
            //{
            //    new UserScoreForDescriptor { UserSelectedScore = 101, GeneratedScore = -1, IsDeleted = false,
            //        DateAdded = DateTime.Now, DateDeleted = null, DateUpdated = null,
            //        UserID = users.Single(u => u.LastName.Equals("Puneky")).ID,
            //        PalletDescriptorID = palletDescriptors.Single(p => p.Name.Equals("Bitter")).ID },
            //    new UserScoreForDescriptor { UserSelectedScore = 102, GeneratedScore = -1, IsDeleted = false,
            //        DateAdded = DateTime.Now, DateDeleted = null, DateUpdated = null,
            //        UserID = users.Single(u => u.LastName.Equals("Puneky")).ID,
            //        PalletDescriptorID = palletDescriptors.Single(p => p.Name.Equals("Hoppiness")).ID },
            //    new UserScoreForDescriptor { UserSelectedScore = 103, GeneratedScore = -1, IsDeleted = false,
            //        DateAdded = DateTime.Now, DateDeleted = null, DateUpdated = null,
            //        UserID = users.Single(u => u.LastName.Equals("Puneky")).ID,
            //        PalletDescriptorID = palletDescriptors.Single(p => p.Name.Equals("Sweet")).ID },
            //    new UserScoreForDescriptor { UserSelectedScore = 104, GeneratedScore = -1, IsDeleted = false,
            //        DateAdded = DateTime.Now, DateDeleted = null, DateUpdated = null,
            //        UserID = users.Single(u => u.LastName.Equals("Gross")).ID,
            //        PalletDescriptorID = palletDescriptors.Single(p => p.Name.Equals("Bitter")).ID },
            //    new UserScoreForDescriptor { UserSelectedScore = 105, GeneratedScore = -1, IsDeleted = false,
            //        DateAdded = DateTime.Now, DateDeleted = null, DateUpdated = null,
            //        UserID = users.Single(u => u.LastName.Equals("White")).ID,
            //        PalletDescriptorID = palletDescriptors.Single(p => p.Name.Equals("Hoppiness")).ID },
            //};
            //userScoreForDescriptors.ForEach(s => context.UserScoreForDescriptors.AddOrUpdate(u => u.UserSelectedScore, s));
            //context.SaveChanges();

            #endregion

            #region initItem

            var items = new List<Item>
            {
                new Item { Name = "Boston Lager", UPC = "0000000", IsFeatured = true,
                    ImagePath = "root", StockCount = 50, ItemPrice = 2.99, IsDeleted = false,
                    DateAdded = DateTime.Now, DateDeleted = null, DateUpdated = null,
                    PalletGroupID = palletGroups.Single(p => p.Name.Equals("Lager")).ID,
                    CompanyID = companies.Single(c => c.Name.Equals("Boston Beer")).ID,
                    CategoryID = categories.Single(c => c.Name.Equals("Beer")).ID,
                    Tags = new List<Tag>(), },

                new Item { Name = "Budweiser Beer", UPC = "1111111", IsFeatured = true,
                    ImagePath = "root", StockCount = 25, ItemPrice = 1.99, IsDeleted = false,
                    DateAdded = DateTime.Now, DateDeleted = null, DateUpdated = null,
                    PalletGroupID = palletGroups.Single(p => p.Name.Equals("Lager")).ID,
                    CompanyID = companies.Single(c => c.Name.Equals("Champagne Beverage")).ID,
                    CategoryID = categories.Single(c => c.Name.Equals("Beer")).ID,
                    Tags = new List<Tag>(), },

                new Item { Name = "Samuel Adams Rebel IPA", UPC = "2222222", IsFeatured = true,
                    ImagePath = "root", StockCount = 34, ItemPrice = 4.49, IsDeleted = false,
                    DateAdded = DateTime.Now, DateDeleted = null, DateUpdated = null,
                    PalletGroupID = palletGroups.Single(p => p.Name.Equals("IPA")).ID,
                    CompanyID = companies.Single(c => c.Name.Equals("Boston Beer")).ID,
                    CategoryID = categories.Single(c => c.Name.Equals("Beer")).ID,
                    Tags = new List<Tag>(), },

                new Item { Name = "Guinness Extra Stout", UPC = "3333333", IsFeatured = true,
                    ImagePath = "root", StockCount = 34, ItemPrice = 4.49, IsDeleted = false,
                    DateAdded = DateTime.Now, DateDeleted = null, DateUpdated = null,
                    PalletGroupID = palletGroups.Single(p => p.Name.Equals("Stout")).ID,
                    CompanyID = companies.Single(c => c.Name.Equals("Guinness")).ID,
                    CategoryID = categories.Single(c => c.Name.Equals("Beer")).ID,
                    Tags = new List<Tag>(), }
            };
            items.ForEach(s => context.Items.AddOrUpdate(i => i.UPC, s));
            context.SaveChanges();

            #endregion

            #region initLike

            //var likes = new List<Like>
            //{
            //    new Like { ID = 1, IsLiked = true, IsDeleted = false,  DateAdded = DateTime.Now, DateDeleted = null,
            //        DateUpdated = null,
            //        UserID = users.Single(u => u.LastName.Equals("Puneky")).ID,
            //        ItemID = items.Single(i => i.UPC.Equals("0000000")).ID },
            //    new Like { ID = 2, IsLiked = true, IsDeleted = false, DateAdded = DateTime.Now, DateDeleted = null,
            //        DateUpdated = null,
            //        UserID = users.Single(u => u.LastName.Equals("Puneky")).ID,
            //        ItemID = items.Single(i => i.UPC.Equals("1111111")).ID },
            //    new Like { ID = 3, IsLiked = false, IsDeleted = false, DateAdded = DateTime.Now, DateDeleted = null,
            //        DateUpdated = null,
            //        UserID = users.Single(u => u.LastName.Equals("Puneky")).ID,
            //        ItemID = items.Single(i => i.UPC.Equals("2222222")).ID },
            //    new Like { ID = 4, IsLiked = false, IsDeleted = false, DateAdded = DateTime.Now, DateDeleted = null,
            //        DateUpdated = null,
            //        UserID = users.Single(u => u.LastName.Equals("Puneky")).ID,
            //        ItemID = items.Single(i => i.UPC.Equals("3333333")).ID },
            //    new Like { ID = 5, IsLiked = false, IsDeleted = false, DateAdded = DateTime.Now, DateDeleted = null,
            //        DateUpdated = null,
            //        UserID = users.Single(u => u.LastName.Equals("White")).ID,
            //        ItemID = items.Single(i => i.UPC.Equals("1111111")).ID },
            //    new Like { ID = 6, IsLiked = true, IsDeleted = false, DateAdded = DateTime.Now, DateDeleted = null,
            //        DateUpdated = null,
            //        UserID = users.Single(u => u.LastName.Equals("White")).ID,
            //        ItemID = items.Single(i => i.UPC.Equals("2222222")).ID },
            //    new Like { ID = 7, IsLiked = true, IsDeleted = false, DateAdded = DateTime.Now, DateDeleted = null,
            //        DateUpdated = null,
            //        UserID = users.Single(u => u.LastName.Equals("White")).ID,
            //        ItemID = items.Single(i => i.UPC.Equals("3333333")).ID },
            //    new Like { ID = 8, IsLiked = false, IsDeleted = false, DateAdded = DateTime.Now, DateDeleted = null,
            //        DateUpdated = null,
            //        UserID = users.Single(u => u.LastName.Equals("Gross")).ID,
            //        ItemID = items.Single(i => i.UPC.Equals("0000000")).ID },
            //    new Like { ID = 9, IsLiked = false, IsDeleted = false, DateAdded = DateTime.Now, DateDeleted = null,
            //        DateUpdated = null,
            //        UserID = users.Single(u => u.LastName.Equals("Gross")).ID,
            //        ItemID = items.Single(i => i.UPC.Equals("2222222")).ID },
            //    new Like { ID = 10, IsLiked = true, IsDeleted = false, DateAdded = DateTime.Now, DateDeleted = null,
            //        DateUpdated = null,
            //        UserID = users.Single(u => u.LastName.Equals("Gross")).ID,
            //        ItemID = items.Single(i => i.UPC.Equals("3333333")).ID }
            //};
            //likes.ForEach(s => context.Likes.AddOrUpdate(l => l.ID, s));
            //context.SaveChanges();

            #endregion

            #region initReviews

            //var reviews = new List<Review>
            //{
            //    new Review { ID = 1, IsDeleted = false, DateAdded = DateTime.Now, DateDeleted = null,
            //        DateUpdated = null,
            //        UserID = users.Single(u => u.LastName.Equals("Puneky")).ID,
            //        ItemID = items.Single(i => i.UPC.Equals("0000000")).ID },
            //    new Review { ID = 2, IsDeleted = false, DateAdded = DateTime.Now, DateDeleted = null,
            //        DateUpdated = null,
            //        UserID = users.Single(u => u.LastName.Equals("Puneky")).ID,
            //        ItemID = items.Single(i => i.UPC.Equals("2222222")).ID },
            //    new Review { ID = 3, IsDeleted = false, DateAdded = DateTime.Now, DateDeleted = null,
            //        DateUpdated = null,
            //        UserID = users.Single(u => u.LastName.Equals("Gross")).ID,
            //        ItemID = items.Single(i => i.UPC.Equals("2222222")).ID },
            //    new Review { ID = 4, IsDeleted = false, DateAdded = DateTime.Now, DateDeleted = null,
            //        DateUpdated = null,
            //        UserID = users.Single(u => u.LastName.Equals("Gross")).ID,
            //        ItemID = items.Single(i => i.UPC.Equals("3333333")).ID },
            //    new Review { ID = 5, IsDeleted = false, DateAdded = DateTime.Now, DateDeleted = null,
            //        DateUpdated = null,
            //        UserID = users.Single(u => u.LastName.Equals("White")).ID,
            //        ItemID = items.Single(i => i.UPC.Equals("1111111")).ID }
            //};
            //reviews.ForEach(s => context.Reviews.AddOrUpdate(r => r.ID, s));
            //context.SaveChanges();

            #endregion

            #region initReviewScoreForDescriptors

            //var reviewScoreForDescriptors = new List<ReviewScoreForDescriptor>
            //{
            //    new ReviewScoreForDescriptor { Score = 101, IsDeleted = false, DateAdded = DateTime.Now, DateDeleted = null,
            //        DateUpdated = null,
            //        ReviewID = reviews.Single(r => r.ID == 1).ID,
            //        PalletDescriptorID = palletDescriptors.Single(p => p.Name.Equals("Bitter")).ID },
            //    new ReviewScoreForDescriptor { Score = 102, IsDeleted = false, DateAdded = DateTime.Now, DateDeleted = null,
            //        DateUpdated = null,
            //        ReviewID = reviews.Single(r => r.ID == 1).ID,
            //        PalletDescriptorID = palletDescriptors.Single(p => p.Name.Equals("Hoppiness")).ID },
            //    new ReviewScoreForDescriptor { Score = 103, IsDeleted = false, DateAdded = DateTime.Now, DateDeleted = null,
            //        DateUpdated = null,
            //        ReviewID = reviews.Single(r => r.ID == 1).ID,
            //        PalletDescriptorID = palletDescriptors.Single(p => p.Name.Equals("Sweet")).ID },

            //    new ReviewScoreForDescriptor { Score = 104, IsDeleted = false, DateAdded = DateTime.Now, DateDeleted = null,
            //        DateUpdated = null,
            //        ReviewID = reviews.Single(r => r.ID == 2).ID,
            //        PalletDescriptorID = palletDescriptors.Single(p => p.Name.Equals("Bitter")).ID },
            //    new ReviewScoreForDescriptor { Score = 105, IsDeleted = false, DateAdded = DateTime.Now, DateDeleted = null,
            //        DateUpdated = null,
            //        ReviewID = reviews.Single(r => r.ID == 2).ID,
            //        PalletDescriptorID = palletDescriptors.Single(p => p.Name.Equals("Hoppiness")).ID },
            //    new ReviewScoreForDescriptor { Score = 106, IsDeleted = false, DateAdded = DateTime.Now, DateDeleted = null,
            //        DateUpdated = null,
            //        ReviewID = reviews.Single(r => r.ID == 2).ID,
            //        PalletDescriptorID = palletDescriptors.Single(p => p.Name.Equals("Sweet")).ID },

            //    new ReviewScoreForDescriptor { Score = 107, IsDeleted = false, DateAdded = DateTime.Now, DateDeleted = null,
            //        DateUpdated = null,
            //        ReviewID = reviews.Single(r => r.ID == 3).ID,
            //        PalletDescriptorID = palletDescriptors.Single(p => p.Name.Equals("Bitter")).ID },
            //    new ReviewScoreForDescriptor { Score = 108, IsDeleted = false, DateAdded = DateTime.Now, DateDeleted = null,
            //        DateUpdated = null,
            //        ReviewID = reviews.Single(r => r.ID == 3).ID,
            //        PalletDescriptorID = palletDescriptors.Single(p => p.Name.Equals("Hoppiness")).ID },
            //    new ReviewScoreForDescriptor { Score = 109, IsDeleted = false, DateAdded = DateTime.Now, DateDeleted = null,
            //        DateUpdated = null,
            //        ReviewID = reviews.Single(r => r.ID == 3).ID,
            //        PalletDescriptorID = palletDescriptors.Single(p => p.Name.Equals("Sweet")).ID },

            //    new ReviewScoreForDescriptor { Score = 110, IsDeleted = false, DateAdded = DateTime.Now, DateDeleted = null,
            //        DateUpdated = null,
            //        ReviewID = reviews.Single(r => r.ID == 4).ID,
            //        PalletDescriptorID = palletDescriptors.Single(p => p.Name.Equals("Bitter")).ID },
            //    new ReviewScoreForDescriptor { Score = 111, IsDeleted = false, DateAdded = DateTime.Now, DateDeleted = null,
            //        DateUpdated = null,
            //        ReviewID = reviews.Single(r => r.ID == 4).ID,
            //        PalletDescriptorID = palletDescriptors.Single(p => p.Name.Equals("Hoppiness")).ID },
            //    new ReviewScoreForDescriptor { Score = 112, IsDeleted = false, DateAdded = DateTime.Now, DateDeleted = null,
            //        DateUpdated = null,
            //        ReviewID = reviews.Single(r => r.ID == 4).ID,
            //        PalletDescriptorID = palletDescriptors.Single(p => p.Name.Equals("Sweet")).ID },

            //    new ReviewScoreForDescriptor { Score = 113, IsDeleted = false, DateAdded = DateTime.Now, DateDeleted = null,
            //        DateUpdated = null,
            //        ReviewID = reviews.Single(r => r.ID == 5).ID,
            //        PalletDescriptorID = palletDescriptors.Single(p => p.Name.Equals("Bitter")).ID },
            //    new ReviewScoreForDescriptor { Score = 114, IsDeleted = false, DateAdded = DateTime.Now, DateDeleted = null,
            //        DateUpdated = null,
            //        ReviewID = reviews.Single(r => r.ID == 5).ID,
            //        PalletDescriptorID = palletDescriptors.Single(p => p.Name.Equals("Hoppiness")).ID },
            //    new ReviewScoreForDescriptor { Score = 115, IsDeleted = false, DateAdded = DateTime.Now, DateDeleted = null,
            //        DateUpdated = null,
            //        ReviewID = reviews.Single(r => r.ID == 5).ID,
            //        PalletDescriptorID = palletDescriptors.Single(p => p.Name.Equals("Sweet")).ID }
            //};
            //reviewScoreForDescriptors.ForEach(s => context.ReviewScoreForDescriptors.AddOrUpdate(r => r.Score, s));
            //context.SaveChanges();

            #endregion

            GenerateManyToManyRelations(context);
        }

        private void GenerateManyToManyRelations(ApplicationDbContext context)
        {
            AddOrUpdateItemAndTag(context, "0000000", "Common");
            AddOrUpdateItemAndTag(context, "0000000", "Editors Choice");
            AddOrUpdateItemAndTag(context, "1111111", "Common");
            AddOrUpdateItemAndTag(context, "2222222", "Common");
            AddOrUpdateItemAndTag(context, "3333333", "Imported");
            AddOrUpdateItemAndTag(context, "3333333", "Editors Choice");

            AddOrUpdatePalletGroupAndPalletDescriptor(context, "IPA", "Bitter");
            AddOrUpdatePalletGroupAndPalletDescriptor(context, "IPA", "Hoppiness");
            AddOrUpdatePalletGroupAndPalletDescriptor(context, "IPA", "Sweet");
            AddOrUpdatePalletGroupAndPalletDescriptor(context, "Lager", "Bitter");
            AddOrUpdatePalletGroupAndPalletDescriptor(context, "Lager", "Hoppiness");
            AddOrUpdatePalletGroupAndPalletDescriptor(context, "Lager", "Sweet");
            AddOrUpdatePalletGroupAndPalletDescriptor(context, "Stout", "Bitter");
            AddOrUpdatePalletGroupAndPalletDescriptor(context, "Stout", "Hoppiness");
            AddOrUpdatePalletGroupAndPalletDescriptor(context, "Stout", "Sweet");

            AddOrUpdateCategoryAndPalletDescriptor(context, "Beer", "Bitter");
            AddOrUpdateCategoryAndPalletDescriptor(context, "Beer", "Hoppiness");
            AddOrUpdateCategoryAndPalletDescriptor(context, "Beer", "Sweet");
            AddOrUpdateCategoryAndPalletDescriptor(context, "Wine", "Bitter");
            AddOrUpdateCategoryAndPalletDescriptor(context, "Wine", "Sweet");
            AddOrUpdateCategoryAndPalletDescriptor(context, "Spirits", "Sweet");

            context.SaveChanges();
        }

        private void AddOrUpdateItemAndTag(ApplicationDbContext context, string itemUPC, string tagName)
        {
            var item = context.Items.SingleOrDefault(i => i.UPC.Equals(itemUPC));
            var tag = item.Tags.SingleOrDefault(t => t.Name.Equals(tagName));

            if (tag == null)
            {
                item.Tags.Add(context.Tags.Single(t => t.Name.Equals(tagName)));
            }
        }

        private void AddOrUpdatePalletGroupAndPalletDescriptor(ApplicationDbContext context, string palletGroupName, string palletDescriptorName)
        {
            var palletGroup = context.PalletGroups.SingleOrDefault(p => p.Name.Equals(palletGroupName));
            var palletDescriptor = palletGroup.PalletDescriptors.SingleOrDefault(p => p.Name.Equals(palletDescriptorName));

            if (palletDescriptor == null)
            {
                palletGroup.PalletDescriptors.Add(context.PalletDescriptors.Single(p => p.Name.Equals(palletDescriptorName)));
            }
        }

        private void AddOrUpdateCategoryAndPalletDescriptor(ApplicationDbContext context, string categoryName, string palletDescriptorName)
        {
            var category = context.Categories.SingleOrDefault(c => c.Name.Equals(categoryName));
            var palletDescriptor = category.PalletDescriptors.SingleOrDefault(p => p.Name.Equals(palletDescriptorName));

            if (palletDescriptor == null)
            {
                category.PalletDescriptors.Add(context.PalletDescriptors.Single(p => p.Name.Equals(palletDescriptorName)));
            }
        }
    }
}

