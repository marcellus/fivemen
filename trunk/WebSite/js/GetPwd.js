// JScript 文件

// JScript 文件
// JScript 文件
var user=
{
    rules:
    [
        {
            id:"ctl00_ContentPlaceHolder1_tbUserName",//必填字段
            method:NeedAlphaNum, //
            //message:"用户名不能为空！{2}{3}",
            message:"用户名不能为空，请检查输入！",
            minlength:4,
            maxlength:20,
            showstyle:"div"
        },
        {
            id:"ctl00_ContentPlaceHolder1_tbEmail",
            method:NeedEmail,
            showstyle:"div"
        }
    ]
}

var v=new Validation();
v.validRules=user;
v.AutoBind();


