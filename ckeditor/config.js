/*
Copyright (c) 2003-2011, CKSource - Frederico Knabben. All rights reserved.
For licensing, see LICENSE.html or http://ckeditor.com/license
*/

CKEDITOR.editorConfig = function (config) {
    // Define changes to default configuration here. For example:
    // config.language = 'fr';
    // config.uiColor = '#AADC6E';
    //填写以下内容，图片，flash路径
    config.uiColor = '#F7F8F9';
    config.toolbar = 'SimpleStyle';
    config.scayt_autoStartup = true;
    config.language = 'zh-cn'; //中文
    config.font_defaultLabel = '宋体';
    config.fontSize_defaultLabel = '18px';
    config.font_names = '宋体/宋体;黑体/黑体;仿宋/仿宋_GB2312;楷体/楷体_GB2312;隶书/隶书;幼圆/幼圆;微软雅黑/微软雅黑;'+ config.font_names;
    CKEDITOR.config.pasteFromWordPromptCleanup = true;
    
    config.toolbar_SimpleStyle =
    [

        { name: 'toolbar1', items: ["Bold", "Italic", "Underline", "Strike", "-", "Subscript", "Superscript"] },
        { name: 'toolbar2', items: ["NumberedList", "BulletedList", "-", "JustifyLeft", "JustifyCenter", "JustifyRight", "JustifyBlock"] },
        { name: 'toolbar3', items: ["BidiLtr", "BidiRtl"] },
        { name: 'toolbar4', items: ["Link", "Unlink", "Anchor"] },
        { name: 'toolbar5', items: ["Cut", "Copy", "Paste", "PasteText", "PasteFromWord", "-", "Print"] },
        { name: 'toolbar6', items: ["Preview", "-", "Templates", "-", "helloworld"] },
         "/",
        { name: 'toolbar7', items: ["Styles", "Format", "Font", "FontSize"] },
        { name: 'toolbar8', items: ["TextColor", "Image", "Table"] },
        { name: 'toolbar9', items: ["Undo", "Redo", "-", "Find", "Replace", "-", "SelectAll", "RemoveFormat"] },
        { name: 'toolbar10', items: ["Maximize", "-", "Source"] }
    ];
    config.extraPlugins += (config.extraPlugins ? ',helloworld' : 'helloworld');
    
    config.filebrowserBrowseUrl = '/ckfinder/ckfinder.html';
    config.filebrowserImageBrowseUrl = '/ckfinder/ckfinder.html?Type=Images';
    config.filebrowserFlashBrowseUrl = '/ckfinder/ckfinder.html?Type=Flash';
    config.filebrowserUploadUrl = '/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files';
    config.filebrowserImageUploadUrl = '/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images';
    config.filebrowserFlashUploadUrl = '/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash';
};
