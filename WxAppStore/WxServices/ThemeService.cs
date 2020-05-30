using Microsoft.Extensions.Configuration;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.Text;
using WxServices.Models;
using ZergDB;

namespace WxServices
{
   public class ThemeService:BaseService
    {
        public ThemeService(IConfiguration config):base(config) { 
        
        }

        public List<ThemeModel> getThemes()
        {
            List<ThemeModel> list = new List<ThemeModel>();
            using (var db = base.getDatabase())
            {
                Sql thsql = new Sql("SELECT *  FROM `theme`  ");
               var themelist = db.Fetch<theme>(thsql);
                for (int i = 0; i < themelist.Count; i++)
                {
                    ThemeModel tmodel = new ThemeModel();
                    tmodel.id = themelist[i].id;
                    tmodel.head_img_id = themelist[i].head_img_id;
                    tmodel.name = themelist[i].name;
                    tmodel.topic_img_id = themelist[i].topic_img_id;
                    thsql = new Sql("SELECT *  FROM  image where id = @0", themelist[i].topic_img_id);
                    image imagelist = db.FirstOrDefault<image>(thsql);
                    ImageModel imodel = new ImageModel();
                    imodel.id = imagelist.id;
                    imodel.url = imagelist.url;
                    tmodel.banImage= imodel;
                    tmodel.tempUrl = "https://localhost:44390/images" + imagelist.url;

                    list.Add(tmodel);
                }


            }

                return list;

        }

    }
}
