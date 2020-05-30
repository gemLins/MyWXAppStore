import { Base } from '../../utils/base.js';
class Home extends Base{
  constructor(){
    super();
  }
  getBannerData(id,callBack){
   var params={
     url:'/bannerapi/GetAllBannerItems',
     data:{
      id:1
     },
    sCallBack:function(res){
      callBack && callBack(res);
    }
   }
   this.request(params);
  }
  getThemeData(callBack){
    var params={
      url:'/ThemeApi/getThemes',
      sCallBack:function(data){
        callBack&&callBack(data);
      }
    };
    this.request(params);
  }

  getProductsData(callBack){
    var params={
      url:'/ProductApi/getRecents',
      sCallBack:function(data){
        callBack&&callBack(data);
      }
    };
    this.request(params);
  }


}
export {Home};