using System;
using System.Collections.Generic;
using System.Text;

namespace WxServices.Models
{
    class order
    {
        public int id { get; set; }//int (11) NOT NULL AUTO_INCREMENT,
        public string order_no { get; set; }//varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT '订单号',
        public int user_id { get; set; }//int (11) NOT NULL COMMENT '外键，用户id，注意并不是openid',
        public DateTime delete_time { get; set; }//datetime NULL DEFAULT NULL,
        public DateTime create_time { get; set; }//datetime NULL DEFAULT NULL,
        public decimal total_price { get; set; }//decimal (6, 2) NOT NULL,
        public int status { get; set; }//tinyint(4) NOT NULL DEFAULT 1 COMMENT '1:未支付， 2：已支付，3：已发货 , 4: 已支付，但库存不足',
        public string snap_img { get; set; }//varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL COMMENT '订单快照图片',
        public string snap_name { get; set; }//varchar(80) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL COMMENT '订单快照名称',
        public int total_count { get; set; }//int (11) NOT NULL DEFAULT 0,
        public DateTime update_time { get; set; }//datetime NULL DEFAULT NULL,
        public string snap_items { get; set; }//text CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL COMMENT '订单其他信息快照（json)',
        public string snap_address { get; set; }// varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL COMMENT '地址快照',
        public string prepay_id { get; set; }//varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL COMMENT '订单微信支付的预订单id（用于发送模板消息）',

    }
}
