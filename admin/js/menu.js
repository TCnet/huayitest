// JavaScript Document
function chengstate(menuid,save)
{											//切换节点的开放/关闭
	menuobj	= eval("item"+menuid);
	obj		= eval("pr"+menuid);
	
	if(menuobj.style.display == '')
	{
		menuobj.style.display	= 'none';
	}else{
		menuobj.style.display	= '';
	}//end if	
}//end funciton chengstaut