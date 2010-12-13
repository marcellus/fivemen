// JScript 文件
// JScript 文件
var user=
{
    rules:
    [
        {
            id:"ctl00_ContentPlaceHolder1_tbUser",//必填字段
            method:Require, //
            //message:"用户名不能为空！{2}{3}",
            message:"请检查用户名输入！",
            showstyle:"div"
        },
        {
            id:"ctl00_ContentPlaceHolder1_tbPwd",
            method:NeedAlphaNum,
            message:"请检查密码输入！",
            minlength:6,
            maxlength:20,
            showstyle:"div"
        },
        {
            id:"ctl00_ContentPlaceHolder1_tbDPwd",
            method:NeedAlphaNum,
            message:"密码不一致，请检查输入！",
            minlengh:6,
            maxlength:20,
            showstyle:"div"
        },
       
        
        {
            id:"ctl00$ContentPlaceHolder1$tbEmail",
            method:NeedEmail,
            showstyle:"div",
            boolnull:true
        }
    ]
}

var v=new Validation();
v.validRules=user;
v.AutoBind();


