using System;
using System.Collections.Generic;
using System.Text;

namespace WxServices.Models
{
   public class ProductImage
    {
        public int id { get; set; }//int (11) NOT NULL AUTO_INCREMENT,
        public int img_id { get; set; }//int (11) NOT NULL COMMENT '外键，关联图片表',
        public DateTime delete_time { get; set; }//datetime NULL DEFAULT NULL COMMENT '状态，主要表示是否删除，也可以扩展其他状态',
        public int order { get; set; }//int (11) NOT NULL DEFAULT 0 COMMENT '图片排序序号',
        public int product_id { get; set; }//int (11) NOT NULL COMMENT '商品id，外键',
        public string url { get; set; }
    }
}
