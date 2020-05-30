using System;
using System.Collections.Generic;
using System.Text;

namespace WxServices.Models
{
    public class BannerModel
    {
        public int id { get; set; }//  int (11) NOT NULL AUTO_INCREMENT,
        public string name { get; set; }//` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL COMMENT 'Banner名称，通常作为标识',
        public string description { get; set; }//` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL COMMENT 'Banner描述',
        public DateTime delete_time { get; set; }//` datetime NULL DEFAULT NULL,
        public DateTime update_time { get; set; }//` datetime NULL DEFAULT NULL,

        public List<Banneritem> item { get; set; }
    }
}
