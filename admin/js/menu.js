// JavaScript Document
function chengstate(menuid,save)
{											//�л��ڵ�Ŀ���/�ر�
	menuobj	= eval("item"+menuid);
	obj		= eval("pr"+menuid);
	
	if(menuobj.style.display == '')
	{
		menuobj.style.display	= 'none';
	}else{
		menuobj.style.display	= '';
	}//end if	
}//end funciton chengstaut