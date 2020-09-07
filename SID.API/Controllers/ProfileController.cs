using SID.API.Models.DTO;
using SID.Data.Model.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.WebPages.Html;

namespace SID.API.Controllers
{
    public class ProfileController : BaseController
    {

        [HttpGet]
        public IHttpActionResult InfluencerPost(int id)
        {
            //var result =unit.InfluencerPostRepo.GetAll().Where(q => q.InflucerID == id && q.IsDeleted == false).ToList();

            List<InfluencerPostDTO> result = unit.InfluencerPostRepo.GetAllQuery().Select(q => new InfluencerPostDTO()
            {

                PostImgPath = q.PostImgPath,
                InfluencerID = q.InflucerID

            }).Where(q => q.InfluencerID == id).ToList();

            return Ok(result);
        }

        [HttpGet]
        public IHttpActionResult GetInfluencerUserInfo(int id)
        {
            Influencer influencer = unit.InfluencerRepo.FirstOrDefault(q => q.ID == id);
            InfluencerUserInfoDTO model = new InfluencerUserInfoDTO();
            model.FullName = influencer.Name + " " + influencer.SurName;
            model.EMail = influencer.Email;
            model.Phone = influencer.Phone;
            model.ImgPath = influencer.ImagePath;
            return Ok(model);
        }

        [HttpGet]
        public IHttpActionResult GetProfileAccount(int id)
        {
            InfluencerAccountDTO model = new InfluencerAccountDTO();
            Influencer influencer = unit.InfluencerRepo.FirstOrDefault(q => q.ID == id);
            if (influencer != null)
            {
                model.FullName = influencer.Name + " " + influencer.SurName;
                model.ImgPath = influencer.ImagePath;
            }
            model.FollowerUserCount = unit.InfluencerFollowRepo.GetAllQuerableWithQuery(q => q.InfluencerFollowerID == id).Count();
            model.FollowingUsersCount = unit.InfluencerFollowRepo.GetAllQuerableWithQuery(q => q.InfluencerFollowingID == id).Count();

            return Ok(model);

        }
        [HttpGet]
        public IHttpActionResult GetInfluencerAddress(int id)
        {
            List<InfluencerAddressDTO> model = new List<InfluencerAddressDTO>();

            model = unit.InfluencerAdressesRepo.GetAllQuerableWithQuery(q => q.InfluencerID == id).Select(x => new InfluencerAddressDTO()
            {
                City = x.Region.City.Name,
                Region = x.Region.Name,
                District = x.District,
                Street = x.Street,
                TypeName = x.TypeName,
                ImgPath = x.Influencer.ImagePath
            }).ToList();


            return Ok(model);
        }

        [HttpGet]
        public IHttpActionResult GetPostList(int id)
        {
            List<InfluencerPostDTO> model = new List<InfluencerPostDTO>();

            model = unit.InfluencerPostRepo.GetAllQuerableWithQuery(q => q.InflucerID == id).Select(x => new InfluencerPostDTO()
            {

                PostImgPath = x.PostImgPath,
            
            }).ToList();

            return Ok(model);
        }
        [HttpGet]
        public IHttpActionResult GetInfluencerWallets(int id)
        {
            List<InfluencerWalletDTO> model = unit.InfluencerWalletRepo.GetAllQuerableWithQuery(q => q.InfluencerID == id).Select(x => new InfluencerWalletDTO()
            {
                CardName = x.CardName,
                CardType = x.CardType,
                CardNumber = x.CardNumber.Substring(x.CardNumber.Length - 4),
                ImgPath = x.Influencer.ImagePath
            }).ToList();
            return Ok(model);
        }
        [HttpPost]
        public IHttpActionResult AddWallet(InfluencerWalletDTO influencerWallet)
        {
            InfluencerWallet model = new InfluencerWallet();
            model.InfluencerID = influencerWallet.ID;
            model.CardName = influencerWallet.CardName;
            model.CardNumber = influencerWallet.CardNumber;
            model.CardType = influencerWallet.CardType;
            unit.InfluencerWalletRepo.Add(model);

            return Ok();
        }

        [HttpGet]
        public IHttpActionResult GetCities()
        {
            CitiesDTO model = new CitiesDTO();
            model.drpCities = unit.CityRepo.GetAllQuery().Select(q => new SelectListItem()
            {
                Text = q.Name,
                Value = q.ID.ToString()
            }).ToList();
            return Ok(model);
        }

        [HttpGet]
        public IHttpActionResult GetRegion(int id)
        {
            RegionsDTO model = new RegionsDTO();
            model.drpRegions = unit.RegionRepo.GetAllQuerableWithQuery(q=>q.CityID==id).Select(q => new SelectListItem()
            {
                Text = q.Name,
                Value = q.ID.ToString()
            }).ToList();
            return Ok(model);
        }
        [HttpPost]
        public IHttpActionResult AddAddress(InfluencerAddAddressDTO influencerAddAddressDTO)
        {
            InfluencerAdresses model = new InfluencerAdresses();
            model.InfluencerID = influencerAddAddressDTO.InfluencerID;
            model.Street = influencerAddAddressDTO.Street;
            model.District = influencerAddAddressDTO.District;
            model.TypeName = influencerAddAddressDTO.TypeName;
            model.RegionID = influencerAddAddressDTO.RegionID;
            unit.InfluencerAdressesRepo.Add(model);
            return Ok();
        }

    }
}
