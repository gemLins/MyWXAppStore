using System;
using System.Collections.Generic;
using System.Text;

namespace WxServices.Models
{
    public class CategoryModel
    {
        public int id { get; set; }//int (11) NOT NULL AUTO_INCREMENT,
        public string name { get; set; }//varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT '分类名称',
        public int topic_img_id { get; set; }//int (11) NULL DEFAULT NULL COMMENT '外键，关联image表',
        public DateTime delete_time { get; set; }// datetime NULL DEFAULT NULL,
        public string description { get; set; }//varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL COMMENT '描述',
        public DateTime update_time { get; set; }//datetime NULL DEFAULT NULL,
        public string img_url { get; set; }
    }
}
