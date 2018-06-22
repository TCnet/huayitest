<%@ Page Title="" Language="C#" MasterPageFile="~/root.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HuaYimo.Default" %>
<%@ Register Src="~/uc/uc_slider.ascx" TagName="uc_slider" TagPrefix="uc_slider" %>
<%@ Register Src="~/uc/uc_menu.ascx" TagName="uc_menu" TagPrefix="uc_menu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="menu" runat="server">
    <uc_menu:uc_menu id="uc_menu" runat="server" CssType="0"></uc_menu:uc_menu>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <uc_slider:uc_slider ID="uc_slider" runat="server"></uc_slider:uc_slider>
     <div id="howitworks" class="bg-white-only">
    <div class="container">
        <div class="m-t-xl m-b-xl text-center wrapper">
            <h3 class="text-u-c text-dark">8年经验 华一检测为您提供 <span class="b-b b-light">最专业的</span> 服务
            </h3>
            <p class="text-muted">从事外贸出口检测多年，为您的产品提供最权威的检测报告.</p>
        </div>
        <div class="row m-t-xl m-b-xl text-center">
            <div class="col-sm-4" data-ride="animated" data-animation="fadeInLeft" data-delay="300">
                <p class="h3 m-b-lg">
                    <i class="i i-cloud i-2x b b-dark rounded wrapper-lg"></i>
                </p>
                <div class="">
                    <h4 class="m-t-none">服务范围</h4>
                    <p class="text-muted m-t-lg">轻工业检测报告，和技术咨询</p>
                </div>
            </div>
            <div class="col-sm-4" data-ride="animated" data-animation="fadeInLeft" data-delay="600">
                <p class="h3 m-b-lg">
                    <i class="i i-stats i-2x b b-dark rounded wrapper-lg"></i>
                </p>
                <div class="">
                    <h4 class="m-t-none">学习园地</h4>
                    <p class="text-muted m-t-lg">了解各国的法律法规，熟悉产品出口报告的详细要求</p>
                </div>
            </div>
            <div class="col-sm-4" data-ride="animated" data-animation="fadeInLeft" data-delay="900">
                <p class="h3 m-b-lg">
                    <i class="i i-screen i-2x b b-dark rounded wrapper-lg"></i>
                </p>
                <div class="">
                    <h4 class="m-t-none">活动咨询</h4>
                    <p class="text-muted m-t-lg">检测技术服务培训指导讲座和会谈</p>
                </div>
            </div>
        </div>
    </div>
        </div>
   
</asp:Content>
