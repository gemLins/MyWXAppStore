using System;
using System.Collections.Generic;
using System.Text;
using WxServices.Enums;

namespace WxServices
{
    public class Jscode2sessionParam
    {
        public string appid { get; set; }// string 是   小程序 appId
        public string secret { get; set; }//string 是   小程序 appSecret
        public string js_code { get; set; }//string 是   登录时获取的 code
        public string grant_type { get; set; }// string 是   授权类型，此处只需填写 authorization_code
        
    }

    public class Jscode2sessionResult
    {
        public string openid { get; set; }// string 用户唯一标识
        public string session_key { get; set; }// string 会话密钥
        public string unionid { get; set; }// string 用户在开放平台的唯一标识符，在满足 UnionID 下发条件的情况下会返回，详见 UnionID 机制说明。
        public string errcode { get; set; }//  number  错误码
        public string errmsg { get; set; }// string 错误信息
    }

    public class TokenCache { 
        public string WxResult { get; set; }
        public string UID { get; set; }
        public ScopeEnums Scope { get; set; }
    }
}
