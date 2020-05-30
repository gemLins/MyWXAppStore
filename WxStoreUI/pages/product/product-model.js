import { Base } from '../../utils/base.js';
class Product extends Base{
  constructor(){
    super();
  }

  getDetailInfo(id,sCallBack){
    var param={
      url:'/ProductApi/getDetailInfo?id='+id,
      sCallBack:function(data){
        sCallBack&&sCallBack(data);
      }
    } ;
    this.request(param);
  }


}
export{Product}
