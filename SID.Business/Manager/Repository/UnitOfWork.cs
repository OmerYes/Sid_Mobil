using SID.Data.Model.ORM.Context;
using SID.Data.Model.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SID.Business.Manager.Repository
{
    public class UnitOfWork : IDisposable
    {
        private SIDContext context = new SIDContext();
        public UnitOfWork()
        {
            context = new SIDContext();
        }
        public UnitOfWork(SIDContext db)
        {
            context = db;
        }

        private GenericRepository<Product> productRepo;
        private GenericRepository<Brand> brandRepo;
        private GenericRepository<BrandUser> brandUserRepo;
        private GenericRepository<Category> categoryRepo;
        private GenericRepository<ProductImage> productImageRepo;
        private GenericRepository<AdminUser> adminUserRepo;
        private GenericRepository<Influencer> influencerRepo;
        private GenericRepository<InfluencerFollow> influencerFollowRepo;
        private GenericRepository<InfluencerPost> influencerPostRepo;
        private GenericRepository<InfluencerAdresses> influencerAdressesRepo;
        private GenericRepository<City> cityRepo;
        private GenericRepository<Region> regionRepo;
        private GenericRepository<PostLike> postlikeRepo;
        private GenericRepository<InfluencerWallet> influencerWalletRepo;
        private GenericRepository<InfluencerPostProduct> influencerPostProductRepo;
        private GenericRepository<InfluencerSaveProduct> influencerSaveProductRepo;




        public GenericRepository<AdminUser> AdminUserRepo
        {
            get
            {
                if (this.adminUserRepo == null)
                {
                    this.adminUserRepo = new GenericRepository<AdminUser>(context);
                }
                return adminUserRepo;
            }
        }

        public GenericRepository<InfluencerSaveProduct> InfluencerSaveProductRepo
        {
            get
            {
                if (this.influencerSaveProductRepo == null)
                {
                    this.influencerSaveProductRepo = new GenericRepository<InfluencerSaveProduct>(context);
                }
                return influencerSaveProductRepo
;
            }
        }

        public GenericRepository<InfluencerPostProduct> InfluencerPostProductRepo
        {
            get
            {
                if (this.influencerPostProductRepo == null)
                {
                    this.influencerPostProductRepo = new GenericRepository<InfluencerPostProduct>(context);
                }
                return influencerPostProductRepo;
            }
        }

        public GenericRepository<InfluencerWallet> InfluencerWalletRepo
        {
            get
            {
                if (this.influencerWalletRepo == null)
                {
                    this.influencerWalletRepo = new GenericRepository<InfluencerWallet>(context);
                }
                return influencerWalletRepo;
            }
        }

        public GenericRepository<Region> RegionRepo
        {
            get
            {
                if (this.regionRepo == null)
                {
                    this.regionRepo = new GenericRepository<Region>(context);
                }
                return regionRepo;
            }
        }

        public GenericRepository<City> CityRepo
        {
            get
            {
                if (this.cityRepo == null)
                {
                    this.cityRepo = new GenericRepository<City>(context);
                }
                return cityRepo;
            }
        }

        public GenericRepository<InfluencerAdresses> InfluencerAdressesRepo
        {
            get
            {
                if (this.influencerAdressesRepo == null)
                {
                    this.influencerAdressesRepo = new GenericRepository<InfluencerAdresses>(context);
                }
                return influencerAdressesRepo;
            }
        }

        public GenericRepository<InfluencerPost> InfluencerPostRepo
        {
            get
            {
                if (this.influencerPostRepo == null)
                {
                    this.influencerPostRepo = new GenericRepository<InfluencerPost>(context);
                }
                return influencerPostRepo;
            }
        }

        public GenericRepository<InfluencerFollow> InfluencerFollowRepo
        {
            get
            {
                if (this.influencerFollowRepo == null)
                {
                    this.influencerFollowRepo = new GenericRepository<InfluencerFollow>(context);
                }
                return influencerFollowRepo;
            }
        }

        public GenericRepository<Product> ProductRepo
        {
            get
            {
                if (this.productRepo == null)
                {
                    this.productRepo = new GenericRepository<Product>(context);
                }
                return productRepo;
            }
        }

        public GenericRepository<Brand> BrandRepo
        {
            get
            {
                if (this.brandRepo == null)
                {
                    this.brandRepo = new GenericRepository<Brand>(context);
                }
                return brandRepo;
            }
        }

        public GenericRepository<BrandUser> BrandUserRepo
        {
            get
            {
                if (this.brandUserRepo == null)
                {
                    this.brandUserRepo = new GenericRepository<BrandUser>(context);
                }
                return brandUserRepo;
            }
        }

        public GenericRepository<Category> CategoryRepo
        {
            get
            {
                if (this.categoryRepo == null)
                {
                    this.categoryRepo = new GenericRepository<Category>(context);
                }
                return categoryRepo;
            }
        }

        public GenericRepository<ProductImage> ProductImageRepo
        {
            get
            {
                if (this.productImageRepo == null)
                {
                    this.productImageRepo = new GenericRepository<ProductImage>(context);
                }
                return productImageRepo;
            }
        }

        public GenericRepository<Influencer> InfluencerRepo
        {
            get
            {
                if (this.influencerRepo == null)
                {
                    this.influencerRepo = new GenericRepository<Influencer>(context);
                }
                return influencerRepo;

            }
        }

        public GenericRepository<PostLike> PostLikeRepo
        {
            get
            {
                if (this.postlikeRepo == null)
                {
                    this.postlikeRepo = new GenericRepository<PostLike>(context);
                }
                return postlikeRepo;

            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
