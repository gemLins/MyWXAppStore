// pages/theme/theme.js
import { Theme } from 'theme-model.js';
var theme = new Theme();
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
      var id = options.id;
      var name =options.name;
      this.data.id = id;
      this.data.name=name;
   
  },

  _loadData:function(){
    theme.getProductsData(this.data.id,(data)=>{
      console.log(data);
      this.setData({
        themeInfo:data
      });
    });

  },
   onReady:function(){
    wx.setNavigationBarTitle({
      title: this.data.name,
    })
    this._loadData();
   },
  /**
   * 用户点击右上角分享
   */
  onShareAppMessage: function () {

  }
})