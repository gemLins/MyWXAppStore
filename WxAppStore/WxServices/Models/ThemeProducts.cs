using System;
using System.Collections.Generic;
using System.Text;

namespace WxServices.Models
{
    public class ThemeProducts
    {
        public int theme_id { get; set; }// int (11) NOT NULL COMMENT '主题外键',
        public int product_id { get; set; }//int (11) NOT NULL COMMENT '商品外键',

        public string product_name {get;set;}

        public decimal product_price { get; set; }
        public int product_stock { get; set; }
        public int categroyId { get; set; }

        public string main_img_url { get; set; }
        public int from { get; set; }

        public int img_id { get; set; }
        public string theme_name { get; set; }
        public string theme_description { get; set; }

        public int topic_img_id { get; set; }
        public int head_img_id { get; set; }
        public string head_img_url { get; set; }

        public List<ProductModel> products { get; set; }

    }
}
