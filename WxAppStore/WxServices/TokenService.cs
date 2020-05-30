using CommonUtils;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using Umbraco.Core.Cache;
using WxServices.Enums;
using ZergDB;

namespace WxServices
{
    public class TokenService : BaseService
    {
        UserService _userService;
        Microsoft.Extensions.Caching.Memory.IMemoryCache _memoryCache;
        public TokenService(IConfiguration config, UserService userService, Microsoft.Extensions.Caching.Memory.IMemoryCache memoryCache) : base(config)
        {
            _userService = userService;
            _memoryCache = memoryCache;
        }
        public static string UserID { get; set; }

        public string getToken(string js_code)
        {
            string context = string.Format("appid={0}&secret={1}&js_code={2}&grant_type=authorization_code", base.WxAppId, base.WxSecret, js_code);
            string url = base.WxTokenApiUrl;
            string res = HttpHelper.RequestUrl(url, context);

            //判断返回值
            Jscode2sessionResult j2sRes = createResult(res);

            //如果返回值正常，更新OpenID
            if (j2sRes != null)
            {
                user u = _userService.grantToken(j2sRes);
                UserID = u.id.ToString();
                res = prepareCachedValue(res, u.id.ToString(), ScopeEnums.User);
            }
            return res;
        }
        /// <summary>
        /// 如果OpenId存在不处理，不存在新增，生成令牌写入缓存，返回到客户端
        /// </summary>
        public Jscode2sessionResult createResult(string result)
        {
            var obj = JObject.Parse(result);
            Jscode2sessionResult j2sRes = new Jscode2sessionResult();
            if (obj["openid"] == null) return null;
            j2sRes.openid = obj["openid"] == null ? "" : obj["openid"].ToString();
            j2sRes.session_key = obj["session_key"] == null ? "" : obj["session_key"].ToString();
            j2sRes.unionid = obj["unionid"] == null ? "" : obj["unionid"].ToString();
            j2sRes.errcode = obj["errcode"] == null ? "" : obj["errcode"].ToString();
            j2sRes.errmsg = obj["errmsg"] == null ? "" : obj["errmsg"].ToString();
            return j2sRes;
        }

        public string prepareCachedValue(string res, string uid, ScopeEnums scope)
        {
            //scope=16代表app用户的权限数值   32表示后台用户的权限数值
            TokenCache tcache = new TokenCache() { WxResult = res, UID = uid, Scope = scope };

            string key = generateToken();
            // var mca = _memoryCache.CreateEntry(key);
            setCatch(key,tcache);
           
           
            return key;
        } 

        public void setCatch(string key,object value) {

            if (!_memoryCache.TryGetValue(key, out var cacheEntry))
            {
                // Key not in cache, so get data.
                cacheEntry = DateTime.Now;

                // Set cache options.
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    // Keep in cache for this time, reset time if accessed.
                    .SetSlidingExpiration(TimeSpan.FromSeconds(30000000));

                // Save data in cache.
                _memoryCache.Set(key, value, cacheEntryOptions);
            }

        }

        public bool verifyToken(string token)
        {
            bool isExist = _memoryCache.TryGetValue(token, out var obj);
            return isExist;
        }

    }
}
