
function   initclass()   
{   
   var   a   =   document.getElementsByTagName("INPUT");   
   for   (var   i=0;   i<a.length;   i++) 
   {  
      if(a[i].type=="text") 
          a[i].className="textorgclass";  
      if(a[i].type=="button") 
          a[i].className="btnorgclass"; 
      if(a[i].type=="dropdownlist")
          a[i].className="dropdownlistorgclass"
   } 
}   
initclass();