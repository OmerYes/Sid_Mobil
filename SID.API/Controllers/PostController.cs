using SID.API.Models.DTO;
using SID.Data.Model.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SID.API.Controllers
{
    public class PostController : BaseController
    {
        [HttpGet]
        public IHttpActionResult GetPostList(int id)
        {
            List<PostListVM> model = unit.InfluencerPostRepo.GetAll().Select(q => new PostListVM()
            {
                ID = q.ID,
                InfluencerID = q.InflucerID,
                InfluencerImgPath = q.Influencer.ImagePath,
                LikeCount = q.PostLikes.Where(x => x.IsDeleted == false).Count(),
                PostPath = q.PostImgPath,
                FullName = q.Influencer.Name + " " + q.Influencer.SurName

            }).ToList();

            


            foreach (var item in model)
            {

                PostLike postLike = unit.PostLikeRepo.FirstOrDefault(q => q.PostID == item.ID && q.InfluencerID == id );
                if (postLike != null)
                {
                    item.IsLiked = true;
                }
                else
                {
                    item.IsLiked = false;
                }
            }

            return Ok(model);
        }
        [HttpGet]
        public IHttpActionResult GetPostLikes(int id,int id2)
        {
            
                PostLikeDTO model = new PostLikeDTO();
                PostLike postLikemodel = unit.PostLikeRepo.FirstOrDefaultAll(q => q.PostID == id && q.InfluencerID == id2);

            if (postLikemodel == null)
            {
                PostLike post = new PostLike();
                post.PostID = id;
                post.InfluencerID = id2;
                unit.PostLikeRepo.Add(post);
                model.LikeCount = unit.PostLikeRepo.GetByID(q => q.PostID == id).Count();
                model.PostID = id;
                model.IsLiked = true;
                return Ok(model);
            }

            else if (postLikemodel.IsDeleted == true)
            {
                postLikemodel.IsDeleted = false;
                unit.PostLikeRepo.Update(postLikemodel);
                unit.Save();
                model.LikeCount = unit.PostLikeRepo.GetByID(q => q.PostID == id).Count();
                model.PostID = id;
                model.IsLiked = true;
                return Ok(model);

            }

            else
            {
                postLikemodel.IsDeleted = true;
                unit.PostLikeRepo.Update(postLikemodel);
                unit.Save();
                model.LikeCount = unit.PostLikeRepo.GetByID(q => q.PostID == id).Count();
                model.PostID = id;
                model.IsLiked = false;
                return Ok(model);
            }
               
            
        }

        [HttpPost]
        public IHttpActionResult AddPost(AddPostDTO addPost)
        {
            InfluencerPost model = new InfluencerPost();
            model.InflucerID = addPost.InfluencerID;
            model.Title = addPost.Title;
            model.Description = addPost.Description;
            model.IsActive = false;
            unit.InfluencerPostRepo.AddCore(model);
            return Ok(model.ID);
        }

        public IHttpActionResult GetSavedPost(int id)
        {
            InfluencerPost model = unit.InfluencerPostRepo.FirstOrDefaultAll(q => q.ID == id);

            return Ok(model);
        }

        [HttpPost]
        public IHttpActionResult PostInfluencerPostProduct(PostProductDTO model)
        {
            InfluencerPostProduct entity = new InfluencerPostProduct();
            entity.ProductID = model.ProductID;
            entity.Title = model.Title;
            entity.Description = model.Description;
            entity.Style = model.Style;

            unit.InfluencerPostProductRepo.Add(entity);

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult FinishInfluencerPostProduct(int id)
        {
            InfluencerPost entity = unit.InfluencerPostRepo.FirstOrDefault(q => q.ID == id);
            entity.IsActive = true;
            unit.InfluencerPostRepo.SaveChanges();

            return Ok();
        }


    }
}
