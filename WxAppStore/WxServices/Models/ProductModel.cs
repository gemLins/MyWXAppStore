using System;
using System.Collections.Generic;
using System.Text;

namespace WxServices.Models
{
    public class ProductModel
    {
        public int id { get; set; } // (11) NOT NULL AUTO_INCREMENT,
        public string name { get; set; } //  varchar(80) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT '商品名称',
        public decimal price { get; set; } //  decimal (6, 2) NOT NULL COMMENT '价格,单位：分',
        public int stock { get; set; } // int (11) NOT NULL DEFAULT 0 COMMENT '库存量',
        public DateTime delete_time { get; set; } // int (11) NULL DEFAULT NULL,
        public int category_id { get; set; } // int (11) NULL DEFAULT NULL,
        public string main_img_url { get; set; } // varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL COMMENT '主图ID号，这是一个反范式设计，有一定的冗余',
        public int from { get; set; } // tinyint(4) NOT NULL DEFAULT 1 COMMENT '图片来自 1 本地 ，2公网',
        public DateTime create_time { get; set; } // int (11) NULL DEFAULT NULL COMMENT '创建时间',
        public DateTime update_time { get; set; } // int (11) NULL DEFAULT NULL,
        public string summary { get; set; } // varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL COMMENT '摘要',
        public int img_id { get; set; } // int (11) NULL DEFAULT NULL COMMENT '图片外键',

        public List<ProductImage> images { get; set; }
        public List<ProductProperty> properties { get; set; }
        
    }
}
