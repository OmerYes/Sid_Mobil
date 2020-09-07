using SID.Data.Model.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SID.Data.Model.ORM.Context
{
   public class SIDContext:DbContext
    {
        public SIDContext()
        {
            //Database.Connection.ConnectionString = @"Server=localhost\SQLEXPRESS;Database=SIDTEST;trusted_connection=true";
            Database.Connection.ConnectionString = @"Server=195.142.153.74;Database=SIDTest;UID=user_sid;PWD=Sid45!a";
        }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<BrandUser> BrandUsers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<AdminUser> AdminUsers { get; set; }
        public DbSet<Influencer> Influencers { get; set; }
        public DbSet<BrandInflucerMessage> BrandInflucerMessages { get; set; }

        public DbSet<InflucersBrand> InflucersBrands { get; set; }

        public DbSet<InfluencerPost> InfluencerPosts { get; set; }

        public DbSet<InflucerAddress> InflucerAddresses { get; set; }

        public DbSet<InfluencerFollow> InfluencerFollows { get; set; }

        public DbSet<InfluencerPaymentMethod> InfluencerPaymentMethods { get; set; }

        public DbSet<InfluencerAdresses> InfluencerAdresses { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<PostLike> PostLikes { get; set; }

        public DbSet<InfluencerWallet> InfluencerWallets { get; set; }

        public DbSet<InfluencerPostProduct> InfluencerPostProducts { get; set; }

        public DbSet<InfluencerSaveProduct> InfluencerSaveProducts { get; set; }
    }
}
