// JScript 文件
var user=
{
    rules:
    [
        
        {
            id:"tbPwd",
            method:NeedAlphaNum,
            message:"请检查密码输入！",
            minlength:6,
            maxlength:20,
            showstyle:"div"
        },
        {
            id:"tbDPwd",
            method:NeedAlphaNum,
            message:"密码不一致，请检查输入！",
            minlengh:6,
            maxlength:20,
            showstyle:"div"
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

