	if (mtDropDown.isSupported()) {

		var ms = new mtDropDownSet(mtDropDown.direction.down, 1, -1, mtDropDown.reference.bottomLeft);

		var menu1 = ms.addMenu(document.getElementById("menu1"));
		menu1.addItem("  &nbsp;&nbsp;公司简介&nbsp;&nbsp;  ", "news_list.aspx?type=11");
		menu1.addItem("  &nbsp;&nbsp;资格认证&nbsp;&nbsp;  ", "news_list.aspx?type=12");
		menu1.addItem("  &nbsp;&nbsp;服务简介&nbsp;&nbsp;  ", "news_list.aspx?type=13");
		menu1.addItem("  &nbsp;&nbsp;品牌优势&nbsp;&nbsp;  ", "news_list.aspx?type=14");
		menu1.addItem("  &nbsp;&nbsp;资质荣誉&nbsp;&nbsp;  ", "news_list.aspx?type=15");
		
		
		
		var menu2 = ms.addMenu(document.getElementById("menu2"));
		menu2.addItem("  &nbsp;&nbsp;新闻动态&nbsp;&nbsp;  ", "news_list.aspx?type=21");
		menu2.addItem("  &nbsp;&nbsp;相关新闻&nbsp;&nbsp;  ", "news_list.aspx?type=22");
		menu2.addItem("  &nbsp;&nbsp;视频新闻&nbsp;&nbsp;  ", "news_list.aspx?type=23");
		menu2.addItem("  &nbsp;&nbsp;宣传栏&nbsp;&nbsp;  ", "news_list.aspx?type=83");
		
		
		var menu3 = ms.addMenu(document.getElementById("menu3"));
		menu3.addItem("  &nbsp;&nbsp;甲醛系列&nbsp;&nbsp;  ", "product_list.aspx?type=1");
		menu3.addItem("  &nbsp;&nbsp;VOC系列&nbsp;&nbsp;  ", "product_list.aspx?type=2");
		menu3.addItem("  &nbsp;&nbsp;苯系列&nbsp;&nbsp;  ", "product_list.aspx?type=3");
		menu3.addItem("  &nbsp;&nbsp;氨系列&nbsp;&nbsp;  ", "product_list.aspx?type=4");
		menu3.addItem("  &nbsp;&nbsp;除味系列&nbsp;&nbsp;  ", "product_list.aspx?type=5");
		menu3.addItem("  &nbsp;&nbsp;设备系列&nbsp;&nbsp;  ", "product_list.aspx?type=6");
		menu3.addItem("  &nbsp;&nbsp;Z'Able工法&nbsp;&nbsp;  ", "product_list.aspx?type=7");
		
		var menu4 = ms.addMenu(document.getElementById("menu4"));
		menu4.addItem("  &nbsp;&nbsp;环保小贴士&nbsp;&nbsp;  ", "news_list.aspx?type=41");
		menu4.addItem("  &nbsp;&nbsp;环保知识&nbsp;&nbsp;  ", "news_list.aspx?type=42");
		
		
		
		var menu5 = ms.addMenu(document.getElementById("menu5"));
		menu5.addItem("  &nbsp;&nbsp;专业检测&nbsp;&nbsp;  ", "news_list.aspx?type=51");
		menu5.addItem("  &nbsp;&nbsp;专业治理&nbsp;&nbsp;  ", "news_list.aspx?type=52");
		
		var menu6 = ms.addMenu(document.getElementById("menu6"));
		menu6.addItem("  &nbsp;&nbsp;企业风采&nbsp;&nbsp;  ", "news_list.aspx?type=61");
		menu6.addItem("  &nbsp;&nbsp;成功案例&nbsp;&nbsp;  ", "news_list.aspx?type=82");

		
		var menu7 = ms.addMenu(document.getElementById("menu7"));
		menu7.addItem("  &nbsp;&nbsp;在线招聘&nbsp;&nbsp;  ", "news_list.aspx?type=71");
		
		
		var menu8 = ms.addMenu(document.getElementById("menu8"));
	
		var menu9 = ms.addMenu(document.getElementById("menu9"));
		
		
		mtDropDown.renderAll();
	}