import { Base } from '../../utils/base.js';
class Category extends Base{
  constructor(){
    super();
  }
  
  getCategoryType(callBack){
    var params={
      url:'/CategoryApi/getCategoryType',
     
     sCallBack:function(res){
       callBack && callBack(res);
     }
    }
    this.request(params);
   }

   getProductsByCategory(id,callBack){
    var params={
      url:'/CategoryApi/getProductsByCategory?id='+id,
     sCallBack:function(res){
       callBack && callBack(res);
     }
    }
    this.request(params);
   }



}

export { Category }