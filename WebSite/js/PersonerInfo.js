// JScript 文件
// JScript 文件
var user=
{
    rules:
    [
        {
            id:"tbUser",//必填字段
            method:Require, //
            //message:"用户名不能为空！{2}{3}",
            message:"请检查用户名输入！",
            showstyle:"div"
        },
        {
            id:"tbOldPwd",
            method:NeedAlphaNum,
            message:"请检查密码输入！",
            minlength:6,
            maxlength:20,
            showstyle:"div",
            boolnull:true
        },
        {
            id:"tbNewPwd",
            method:NeedAlphaNum,
            message:"请检查密码输入！",
            minlengh:6,
            maxlength:20,
            showstyle:"div",
            boolnull:true
        },
        {
            id:"tbAgainPwd",
            method:NeedAlphaNum,
            message:"密码不一致，请重新输入！",
            minlength:6,
            maxlength:20,
            showstyle:"div",
            boolnull:true
        },
      
        
        {
            id:"tbEmail",
            method:NeedEmail,
            showstyle:"div",
            boolnull:true
        }
    ]
}

var v=new Validation();
v.validRules=user;
v.AutoBind();


