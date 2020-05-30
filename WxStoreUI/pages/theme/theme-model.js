import { Base } from '../../utils/base.js';
class Theme extends Base{
  constructor(){
    super();
  }

  getProductsData(id,sCallBack){
    var param={
      url:'/ProductApi/getThemeProducts?id='+id,
      sCallBack:function(data){
        sCallBack&&sCallBack(data);
      }
    } ;
    this.request(param);
  }


}
export{Theme}
