import {Config} from 'config.js';
class Token{
  constructor(){
    this.verifyUrl = Config.restUrl + '/TokenApi/verifyToken';
    this.tokenUrl = Config.restUrl + '/TokenApi/GetToken';
  }
  verify(){
    var token =wx.getStorageSync('token');
    if(!token){
      this.getTokenFromServer();
    }else{
      this._veirfyFromServer(token);
    }
  }
  getTokenFromServer(callBack){
    var that = this;
    wx.login({
      success:function(res){
        wx.request({
          url: that.tokenUrl+"?code="+res.code,
          method:'POST',
          data:{
            code:res.code
          },
          success:function(res){
            
            wx.setStorageSync('token', res.data);
            callBack &&callBack(res.data);
          }
        })
      }  
    })
  }
  _veirfyFromServer(token){
    var that=this;
    wx.request({
      url: that.verifyUrl+"?token="+token,
      method:'post',
      data:{
        token:token
      },
      success:function(res){
        var valid = res.data.isValid;
        if(!valid){
          that.getTokenFromServer();
        }
      }
    })

  }
}
 export { Token}