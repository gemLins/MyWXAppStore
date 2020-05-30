
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.Text;
using ZergDB;

namespace WxServices
{
    public class BannerService : BaseService
    {

        public BannerService(IConfiguration config) : base(config)
        {

        }

        public dynamic GetAllBanners()
        {
            //List<banner> list = new List<banner>();
            //Sql sql = new Sql(" select * from banner   b ");
            //sql.Append(" INNER JOIN banner_item bi  on  b.id=bi.banner_id ");
            //  sql.Append("  INNER JOIN image i on i.id=bi.img_id");
            Sql sql = new Sql(" select * from image ");
            using (var db = base.getDatabase())
            {
                var list = db.Fetch<image>(sql);
                return list;
            }

        }

        public dynamic GetAllBannerItems(string bannerid)
        {
            Models.BannerModel bmodel = new Models.BannerModel();
            using (var db = base.getDatabase())
            {
                Sql sqlbanner = new Sql("select * from banner  where id=@0", bannerid);
                banner ban = db.FirstOrDefault<banner>(sqlbanner);
                bmodel.id = ban.id;
                bmodel.name = ban.name;
                bmodel.description = ban.description;
                Sql sqlbanneritem = new Sql("select * from banner_item  where banner_id=@0", ban.id);
                List<banner_item> banitem = db.Fetch<banner_item>(sqlbanneritem);
                List<Models.Banneritem> banitemlist = new List<Models.Banneritem>();
                for (int j = 0; j < banitem.Count; j++)
                {
                    Models.Banneritem bitem = new Models.Banneritem();
                    bitem.id = banitem[j].id;
                    bitem.img_id = banitem[j].img_id;
                    bitem.key_word = banitem[j].key_word;
                    bitem.type = banitem[j].type;
                    bitem.banner_id = banitem[j].banner_id;
                    Sql sqlimg = new Sql("select * from image  where id=@0", banitem[j].img_id);
                    image banimage = db.FirstOrDefault<image>(sqlimg);
                    
                    Models.ImageModel images = new Models.ImageModel();
                    images.id = banimage.id;
                    images.url = banimage.url;
                    images.from = banimage.from;
                    bitem.banImage = images;
                    bitem.tempUrl = "https://localhost:44390/images"+banimage.url;
                    banitemlist.Add(bitem);
                }
                bmodel.item = banitemlist;

            }
            return bmodel;
        }

        //public dynamic GetAllBannerItems(string bannerid)
        //{
        //    List<Models.BannerModel> list = new List<Models.BannerModel>();
        //    using (var db = base.getDatabase())
        //    {
        //        Sql sqlbanner = new Sql("select * from banner  where id=@0", bannerid);
        //        List<banner> ban= db.Fetch<banner>(sqlbanner);
        //        for (int i = 0; i < ban.Count; i++)
        //        {
        //            Models.BannerModel bmodel = new Models.BannerModel();
        //            bmodel.id = ban[i].id;
        //            bmodel.name = ban[i].name;
        //            bmodel.description = ban[i].description;
        //            Sql sqlbanneritem = new Sql("select * from banner_item  where banner_id=@0", ban[i].id);
        //            List<banner_item> banitem = db.Fetch<banner_item>(sqlbanneritem);
        //            List<Models.Banneritem> banitemlist = new List<Models.Banneritem>();
        //            for (int j = 0; j < banitem.Count; j++)
        //            {
        //                Models.Banneritem bitem = new Models.Banneritem();
        //                bitem.id = banitem[j].id;
        //                bitem.img_id = banitem[j].img_id;
        //                bitem.key_word = banitem[j].key_word;
        //                bitem.type = banitem[j].type;
        //                bitem.banner_id = banitem[j].banner_id;
        //                Sql sqlimg = new Sql("select * from image  where id=@0", banitem[j].img_id);
        //                List<image> banimage = db.Fetch<image>(sqlimg);
        //                List<Models.ImageModel> imglist = new List<Models.ImageModel>();
        //                for (int k = 0; k < banimage.Count; k++)
        //                {
        //                    Models.ImageModel images = new Models.ImageModel();
        //                    images.id = banimage[k].id;
        //                    images.url = banimage[k].url;
        //                    images.from = banimage[k].from;
        //                    imglist.Add(images);
        //                }
        //                bitem.banImage = imglist;

        //                banitemlist.Add(bitem);
        //            }
        //            bmodel.banItem = banitemlist;
        //            list.Add(bmodel);
        //        }
        //    }
        //    return list;
        //}

    }
}
