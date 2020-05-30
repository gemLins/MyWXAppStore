import{Config} from '../utils/config.js';
import { Token } from './token.js';
class Base{

  constructor(){
    this.baseRequestUrl=Config.restUrl;
  }
  request(params,noRefetch){
    var url = this.baseRequestUrl+params.url;
    var that = this;
    if(!params.type){
      params.type='GET';
    }
    wx.request({
      url:  url ,
      data:params.data,
      method:params.type,
      header:{
        'content-type':'application/json',
        'token':wx.getStorageSync('token')
      },
      success(res){
        var code = res.statusCode.toString();
        var startChar = code.charAt(0);
        if(startChar=='2'){
          params.sCallBack&&params.sCallBack(res.data);
        } else{
          if(code=='401'){
             if(!noRefetch){
              that._refetch(params);
            }
          }
          params.eCallBack&&params.eCallBack(res.data);
        }
      },
      fail(err){
        console.log(err);
      }

    })

  }

  _refetch(params){
    var token=new Token();
    token.getTokenFromServer((token)=>{
      this.request(params,true);
    });
  }


  getDatasSet(event,key){
    return event.currentTarget.dataset[key];

  };
}
export {Base}