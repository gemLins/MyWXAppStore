using System;
using System.Collections.Generic;
using System.Text;

namespace WxServices.Models
{
  public  class Banneritem
    {
        public int id { get; set; }//int (11) NOT NULL AUTO_INCREMENT,
        public int img_id { get; set; }// int (11) NOT NULL COMMENT '外键，关联image表',
        public string key_word { get; set; }// varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT '执行关键字，根据不同的type含义不同',
        public int type { get; set; }// tinyint(4) NOT NULL DEFAULT 1 COMMENT '跳转类型，可能导向商品，可能导向专题，可能导向其他。0，无导向；1：导向商品;2:导向专题',
        public DateTime delete_time { get; set; }// datetime NULL DEFAULT NULL,
        public int banner_id { get; set; }//int (11) NOT NULL COMMENT '外键，关联banner表',
        public DateTime update_time { get; set; }//datetime NULL DEFAULT NULL,
        public  ImageModel  banImage { get; set; }
        public string tempUrl { get; set; }
    }
}
