// JScript 文件

function ChooseState()
{
    var source;
    var sourceName="City.xml";
    var source=new ActiveXObject('Microsoft.XMLDOM');
    source.async=false;
    source.load(sourceName);
    root=source.documentElement;
    sortField=root.selectNodes("//@brandname");
    for(var i=0;i<sortField.length;i++)
    {
        var oOption=document.createElement('OPTION');
        oOption.text=""+sortField[i].text+"";
        oOption.value=sortField[i].text;
        NewOpus.brand_id.options.add(oOption);
    }
}

function ChooseBrand()
{
    x=NewOpus.brand_id.selectedIndex;
    y=NewOpus.brand_id.options[x].value;
    sortField=root.selectNodes("//brand[@brandname='"+y+"']/name");
    for(var i=NewOpus.model_id.options.length-1;i>=0;--i)
    {
        NewOpus.model_id.options.remove(i)
    }
    for(var i=0;i<sortField.length;++i)
    {
        var oOption = document.createElement('OPTION');
        oOption.text = " "+sortField[i].text+" ";
        oOption.value = sortField[i].text;
        NewOpus.model_id.options.add(oOption);    
    }
}