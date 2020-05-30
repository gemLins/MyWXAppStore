// pages/category/category.js
import { Category } from 'category-model.js';
var category = new Category();
Page({

  /**
   * 页面的初始数据
   */
  data: {
    transClassArr:['tanslate0','tanslate1','tanslate2','tanslate3','tanslate4','tanslate5'],
    currentMenuIndex:0,
    loadingHidden:false
  },

  /**
   * 生命周期函数--监听页面加载
   */
  onLoad: function (options) {
    this._loadData();
  },

   _loadData:function(callBack){
      category.getCategoryType((catedata)=>{
        //console.log(data);
        this.setData({
          categroyArr:catedata
        });
        category.getProductsByCategory(catedata[0].id,(prodata)=>{
          //console.log(data);
          var dataObj={
            products:prodata,
            title:catedata[0].name,
            topImgUrl:catedata[0].img_url,
          };

          this.setData({
            categoryInfo0:dataObj
          });
        });
      });
     
   },

   /*切换分类*/
  changeCategory:function(event){
    var index=category.getDatasSet(event,'index'),
        id=category.getDatasSet(event,'id')//获取data-set
    this.setData({
      currentMenuIndex:index
    });

    //如果数据是第一次请求
    if(!this.isLoadedData(index)) {
      var that=this;
      this.getProductsByCategory(id, (data)=> {
      
        that.setData(that.getDataObjForBind(index,data));
      
      });
    }
  },
  isLoadedData:function(index){
    if(this.data['categoryInfo'+index]){
      return true;
    }
    return false;
  },
  getDataObjForBind:function(index,data){
    var obj={},
        arr=[0,1,2,3,4,5],
        baseData=this.data.categroyArr[index];
       
    for(var item in arr){
      if(item==arr[index]) {
       
        obj['categoryInfo' + item]={
          products:data,
          topImgUrl:baseData.img_url,
          title:baseData.name
        };

        return obj;
      }
    }
  },
  getProductsByCategory:function(id,callBack){
    
    category.getProductsByCategory(id,(data)=> {
      callBack&&callBack(data);
    });
  },

  /*跳转到商品详情*/
  onProductsItemTap: function (event) {
    var id = category.getDatasSet(event, 'id');
    wx.navigateTo({
      url: '../product/product?id=' + id
    })
  },
  /**
   * 页面上拉触底事件的处理函数
   */
  onReachBottom: function () {

  },

  /**
   * 用户点击右上角分享
   */
  onShareAppMessage: function () {

  }
})