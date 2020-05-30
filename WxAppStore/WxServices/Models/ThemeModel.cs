using System;
using System.Collections.Generic;
using System.Text;

namespace WxServices.Models
{
    public class ThemeModel
    {
        public int id { get; set; }//int (11) NOT NULL AUTO_INCREMENT,
        public string name { get; set; }// varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT '专题名称',
        public string description { get; set; }// varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL COMMENT '专题描述',
        public int topic_img_id { get; set; }// int (11) NOT NULL COMMENT '主题图，外键',
        public DateTime delete_time { get; set; }// datetime NULL DEFAULT NULL,
        public int head_img_id { get; set; }// int (11) NOT NULL COMMENT '专题列表页，头图',
        public DateTime update_time { get; set; }// datetime NULL DEFAULT NULL,
        public ImageModel banImage { get; set; }
        public string tempUrl { get; set; }
    }
}
