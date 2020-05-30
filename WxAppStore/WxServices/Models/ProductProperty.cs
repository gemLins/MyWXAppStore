using System;
using System.Collections.Generic;
using System.Text;

namespace WxServices.Models
{
   public class ProductProperty
    {
        public int id { get; set; }// int (11) NOT NULL AUTO_INCREMENT,
        public string name { get; set; }//varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT '' COMMENT '详情属性名称',
        public string detail { get; set; }// varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT '详情属性',
        public int product_id { get; set; }//int (11) NOT NULL COMMENT '商品id，外键',
        public DateTime delete_time { get; set; }// datetime NULL DEFAULT NULL,
        public DateTime update_time { get; set; }// datetime NULL DEFAULT NULL,
    }
}
