using System;
using System.Collections.Generic;
using System.Text;

namespace WxServices.Models
{
    class user_address
    {
        public int id { get; set; }//int (11) NOT NULL AUTO_INCREMENT,
        public string name { get; set; }// varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT '收获人姓名',
        public string mobile { get; set; }// varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT '手机号',
        public string province { get; set; }// varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL COMMENT '省',
        public string city { get; set; }// varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL COMMENT '市',
        public string country { get; set; }// varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL COMMENT '区',
        public string detail { get; set; }// varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL COMMENT '详细地址',
        public DateTime delete_time { get; set; }// datetime NULL DEFAULT NULL,
        public int user_id { get; set; }// int (11) NOT NULL COMMENT '外键',
        public DateTime update_time { get; set; }// datetime NULL DEFAULT NULL,
    }
}
