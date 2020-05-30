using System;
using System.Collections.Generic;
using System.Text;

namespace WxServices.Models
{
    class third_app
    {
        public int id { get; set; }// int (11) NOT NULL AUTO_INCREMENT,
        public string app_id { get; set; }// varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT '应用app_id',
        public string app_secret { get; set; }// varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT '应用secret',
        public string app_description { get; set; }// varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL COMMENT '应用程序描述',
        public string scope { get; set; }// varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT '应用权限',
        public string scope_description { get; set; }// varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL COMMENT '权限描述',
        public DateTime delete_time { get; set; }//datetime NULL DEFAULT NULL,
        public DateTime update_time { get; set; }//datetime NULL DEFAULT NULL,
    }
}
