/*** DIV CENTER LOGIN ***/
if(window.addEventListener)
{
window.addEventListener("load", function() { centraliza(); }, false);
} else
if(window.attachEvent)
{
 window.attachEvent("onload", function() { centraliza(); });
}
function centraliza(){
 tam=document.documentElement.clientHeight;
 divisao=document.getElementById('wraplogin').style.height;
 tamstr=(divisao.length)-2;
 divisao=divisao.substr(0,tamstr);
 margem=(tam-divisao)/3;
 document.getElementById('wraplogin').style.marginTop=margem+"px";
 setTimeout("centraliza()", 10);
}