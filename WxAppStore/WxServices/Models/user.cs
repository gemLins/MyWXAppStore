using System;
using System.Collections.Generic;
using System.Text;

namespace WxServices.Models
{
    public class user
    {
        public int id { get; set; }//int (11) NOT NULL AUTO_INCREMENT,
        public string openid { get; set; }// varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
        public string nickname { get; set; }// varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
        public string extend { get; set; }// varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
        public DateTime delete_time { get; set; }// datetime NULL DEFAULT NULL,
        public DateTime create_time { get; set; }// datetime NULL DEFAULT NULL COMMENT '注册时间',
        public DateTime update_time { get; set; }// datetime NULL DEFAULT NULL,
    }
}
