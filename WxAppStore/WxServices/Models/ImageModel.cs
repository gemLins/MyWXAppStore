using System;
using System.Collections.Generic;
using System.Text;

namespace WxServices.Models
{
    public class ImageModel
    {
        public int id { get; set; }//int (11) NOT NULL AUTO_INCREMENT,
        public string url { get; set; }//varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT '分类名称',
        public int from { get; set; }//int (11) NULL DEFAULT NULL COMMENT '外键，关联image表',
        public DateTime delete_time { get; set; }//datetime NULL DEFAULT NULL,
        public DateTime update_time { get; set; }//datetime NULL DEFAULT NULL,
    }
}
