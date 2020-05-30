using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.Text;
using WxServices.Models;
using ZergDB;

namespace WxServices
{
    public class ProductService : BaseService
    {
        public ProductService(IConfiguration config) : base(config)
        {

        }
        public List<product> GetAllProduct()
        {
            List<product> list = new List<product>();
            Sql sql = new Sql("select * from product where category_id =2");
            using (var db = base.getDatabase())
            {
                list = db.Fetch<product>(sql);
            }
            return list;
        }

        public List<product> getRecents()
        {
            List<product> list = new List<product>();
            Sql sql = new Sql("select * from product order by create_time desc  limit 0,10 ");
            using (var db = base.getDatabase())
            {
                list = db.Fetch<product>(sql);
            }
            return list;
        }
        public ThemeProducts getThemeProducts(string id)
        {
            Sql themesql = new Sql("SELECT t.id,t.name,i.url FROM theme t inner join image i on t.head_img_id = i.id where t.id = @0", id);
            ThemeProducts tmodel = new ThemeProducts();
            using (var db = base.getDatabase())
            {
                var t = db.FirstOrDefault<dynamic>(themesql);
                tmodel.theme_id = t.id;
                tmodel.theme_name = t.name;
                tmodel.head_img_url = imgUrl + t.url;


                List<ProductModel> tproductlist = new List<ProductModel>();
                Sql sql = new Sql(@"SELECT product_id,theme_id,p.`name` product_name,price,stock,main_img_url,img_id ,i.url  FROM `theme_product` tp
                                inner join product p on  p.id= tp.product_id
                                inner join image i on i.id = p.img_id
                                where tp.theme_id =@0", id);

                var list = db.Fetch<dynamic>(sql);
                for (int i = 0; i < list.Count; i++)
                {
                    ProductModel tps = new ProductModel();
                    // tps.product_id = list[i].product_id;
                    //tps.theme_id = list[i].theme_id;
                    tps.name = list[i].product_name;
                    // tps.theme_name = list[i].theme_name;
                    tps.price = list[i].price;
                    tps.stock = list[i].stock;
                    // tps.theme_description = list[i].description;
                    // tps.topic_img_id = list[i].topic_img_id;
                    tps.main_img_url = list[i].main_img_url;
                    // tps.head_img_id = list[i].head_img_id;
                    tps.img_id = list[i].img_id;
                    // tps.head_img_url = list[i].head_img_url;
                    tproductlist.Add(tps);
                }


                tmodel.products = tproductlist;

            }



            return tmodel;
        }

        public ProductModel getDetailInfo(string id)
        {
            ProductModel info = new ProductModel();
            Sql sql = new Sql("select * from product  where id= @0 ", id);
            using (var db = base.getDatabase())
            {
                product pro = db.FirstOrDefault<product>(sql);
                info.id = pro.id;
                info.name = pro.name;
                info.price = pro.price;
                info.stock = pro.stock;
                info.category_id = (int)pro.category_id;
                info.summary = pro.summary;
             
              
                info.main_img_url = base.imgUrl + pro.main_img_url;
                Sql proimage = new Sql("SELECT pi.* ,url FROM `product_image` pi  inner join image i on pi.img_id = i.id where product_id = @0  order by pi.`order`", id);
                List<ProductImage> pimagelist = new List<ProductImage>();
                var proimagelist = db.Fetch<dynamic>(proimage);
                for (int i = 0; i < proimagelist.Count; i++)
                {
                    ProductImage pImage = new ProductImage();
                    pImage.id = proimagelist[i].id;
                    pImage.order = proimagelist[i].order;
                    pImage.url = base.imgUrl + proimagelist[i].url;
                    pimagelist.Add(pImage);
                }
                info.images = pimagelist;
                Sql propro = new Sql("SELECT  *   FROM `product_property`   where product_id = @0  order by  `id`", id);
                List<ProductProperty> pprolist = new List<ProductProperty>();
                var proprolist = db.Fetch<dynamic>(propro);
                for (int i = 0; i < proprolist.Count; i++)
                {
                    ProductProperty pPro = new ProductProperty();
                    pPro.id = proprolist[i].id;
                    pPro.name = proprolist[i].name;
                    pPro.detail = proprolist[i].detail;

                    pprolist.Add(pPro);
                }
                info.properties = pprolist;
            }
            return info;
        }














        //public List<product> GetAllProduct()
        //{
        //    List<product> list = new List<product>();
        //    //连接数据库
        //    using (MySqlConnection msconnection = base.GetConnection())
        //    {
        //        msconnection.Open();
        //        //查找数据库里面的表
        //        MySqlCommand mscommand = new MySqlCommand("select * from product", msconnection);
        //        using (MySqlDataReader reader = mscommand.ExecuteReader())
        //        {
        //            //读取数据
        //            while (reader.Read())
        //            {
        //                list.Add(new product()
        //                {
        //                    id = reader.GetInt32("id"),
        //                    name = reader.GetString("name"),
        //                    price = reader.GetDecimal("price"),
        //                    stock = reader.GetInt32("stock")
        //                });
        //            }
        //        }
        //    }
        //    return list;
        //}



    }
}
