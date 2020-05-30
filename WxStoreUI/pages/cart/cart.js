// pages/cart/cart.js
import { Cart } from 'cart-model.js';
var cart = new Cart();
Page({

  /**
   * 页面的初始数据
   */
  data: {

  },

  /**
   * 生命周期函数--监听页面加载
   */
  onLoad: function (options) {

  },
 

  /**
   * 生命周期函数--监听页面初次渲染完成
   */
  onReady: function () {

  },
  
  /**
   * 生命周期函数--监听页面显示
   */
  onShow: function () {
    this._loadData();
  },
  _loadData:function(){
    var cartdata=  cart.getCartDataFromLocal();
   // var countsInfo = cart.getCartTotalCounts(true);
    var cal = this._calcTotalAccountAndCounts(cartdata);
  
    this.setData({
        selectedCounts:cal.selectedCounts,
        selectTypeCounts:cal.selectTypeCounts,
        account:cal.account,
        cartData:cartdata
    });
  },
  _calcTotalAccountAndCounts:function(data){
    var len =  data.length;
    var account = 0;
    //购买商品个数
    var selectedCounts = 0;
    //购买商品种类个数
    var selectTypeCounts=0;
    let multiple=100;
    for(let i=0;i<len;i++){
      if(data[i].selectStatus){
        account+=data[i].counts*multiple*Number(data[i].price)*multiple;
        selectedCounts+=data[i].counts;
        selectTypeCounts++;
      }
    }
    return{
        selectedCounts:selectedCounts,
        selectTypeCounts:selectTypeCounts,
        account:account/(multiple*multiple)

    }
  },
  toggleSelect:function(event){
    var id = cart.getDatasSet(event,"id");
    var status = cart.getDatasSet(event,"status");
    var index = this._getProductIndexById(id);
  
    this.data.cartData[index].selectStatus=!status;

    this._resetCartData();

  },
  _resetCartData:function(){
    var newData=this._calcTotalAccountAndCounts(this.data.cartData);
   
    this.setData({
      selectedCounts:newData.selectedCounts,
      selectTypeCounts:newData.selectTypeCounts,
      account:newData.account,
      cartData:this.data.cartData
  });

  },
  toggleSelectAll:function(event){
    var status = cart.getDatasSet(event,"status")=='true';
    var data =this.data.cartData;
    var len = data.length;
    
    for(let i =0;i<len;i++){
     
      data[i].selectStatus=!status;
    }
    this._resetCartData();
  },
  _getProductIndexById:function(id){
    var data = this.data.cartData;
    var len = data.length;
   
    for(let i =0;i<len;i++){
      if(data[i].id==id){
        return i;
      }
    }

  },
  changeCounts:function(event){
    var id = cart.getDatasSet(event,'id');
    var type = cart.getDatasSet(event,'type');
    var index = this._getProductIndexById(id);;
    var counts = 1;
    if(type=='cut'){
      counts=-1;
      cart.cutCounts(id);
    }else if(type=='add'){
      cart.addCounts(id);
    }
     this.data.cartData[index].counts+=counts;
     this._resetCartData();
  },
  delete:function(event){
    var id = cart.getDatasSet(event,'id');
    var index=this._getProductIndexById(id);
 
    this.data.cartData.splice(index,1);
    this._resetCartData();
  
    cart.delete(id);

  },
  submitOrder:function(event){
      wx.navigateTo({
        url: '../order/order?account='+this.data.account+'&from=cart',
      })
  },
  /**
   * 生命周期函数--监听页面隐藏
   */
  onHide: function () {
    cart.execSetStorageSysnc( this.data.cartData)
  },

  /**
   * 生命周期函数--监听页面卸载
   */
  onUnload: function () {

  },

  /**
   * 页面相关事件处理函数--监听用户下拉动作
   */
  onPullDownRefresh: function () {

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