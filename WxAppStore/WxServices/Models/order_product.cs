using System;
using System.Collections.Generic;
using System.Text;

namespace WxServices.Models
{
    class order_product
    {
        public int order_id { get; set; }// int (11) NOT NULL COMMENT '联合主键，订单id',
        public int product_id { get; set; }//int (11) NOT NULL COMMENT '联合主键，商品id',
        public int count { get; set; }// int (11) NOT NULL COMMENT '商品数量',
        public DateTime delete_time { get; set; }// datetime NULL DEFAULT NULL,
        public DateTime update_time { get; set; }//datetime NULL DEFAULT NULL,
    }
}
