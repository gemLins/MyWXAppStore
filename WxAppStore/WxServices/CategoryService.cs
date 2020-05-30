using Microsoft.Extensions.Configuration;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.Text;
using WxServices.Models;

namespace WxServices
{
    public class CategoryService : BaseService
    {
        public CategoryService(IConfiguration config) : base(config)
        {

        }


        public List<CategoryModel> getCategoryType()
        {
            List<CategoryModel> list = new List<CategoryModel>();
            Sql sql = new Sql("SELECT c.id cid, name,url,description FROM `category`  c  inner join image i on i.id = c.topic_img_id");
            using (var db = base.getDatabase())
            {
                var catgorys = db.Fetch<dynamic>(sql);
                for (int i = 0; i < catgorys.Count; i++)
                {
                    CategoryModel cmode = new CategoryModel();
                    cmode.id = catgorys[i].cid;
                    cmode.name = catgorys[i].name;
                    cmode.description = catgorys[i].description;
                    cmode.img_url = imgUrl + catgorys[i].url;
                    list.Add(cmode);
                }
            }

            return list;
        }

        public List<ProductModel> getProductsByCategory(string id)
        {
            List<ProductModel> tproductlist = new List<ProductModel>();
            using (var db = getDatabase())
            {

                Sql sql = new Sql(@"SELECT p.id  product_id, c.id cid, p.`name` product_name,price,stock,main_img_url,img_id ,i.url  FROM `category` c
                                inner join product p on  p.category_id= c.id
                                inner join image i on i.id = p.img_id  where c.id =@0", id);

                var list = db.Fetch<dynamic>(sql);
                for (int i = 0; i < list.Count; i++)
                {
                    ProductModel tps = new ProductModel();
                    tps.id = list[i].product_id;
                    tps.category_id = list[i].cid;
                    tps.name = list[i].product_name;
                    tps.price = list[i].price;
                    tps.stock = list[i].stock;
                    tps.main_img_url = imgUrl + list[i].main_img_url;
                    tps.img_id = list[i].img_id;
                    tproductlist.Add(tps);
                }

            }

            return tproductlist;
        }



    }
}
