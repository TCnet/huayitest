<%@ Control Language="C#" Inherits="HuaYimo.uc.uc_footer" %>

<!-- footer -->
<footer id="footer" class="bg-dark">
    <div class="dk">
        <div class="container">
            <div class="row m-t-xl m-b-xl">

                <div class="col-sm-4">
                    <h4 class="text-u-c m-b font-thin text-lt"><span class="b-b b-dark">
                            <asp:Label id="lbWebName" runat="server" />
                    </span></h4>

                    <p class="text-sm">
                        <asp:Label id="lbAddress" runat="server" />
                    </p>

                    <p>
                        电话: <asp:Label id="lbMobilePhone" runat="server" /> <br>
                        手机:<asp:Label id="lbTePhone" runat="server" /> <br>
                        传真: <asp:Label id="lbFax" runat="server" /> <br>
                    </p>


                </div>
                <div class="col-sm-4">
                    <h4 class="text-u-c m-b font-thin text-lt"><span class="b-b b-dark">网站信息</span></h4>
                    <p>
                        <asp:Repeater runat="server" Id="rpZD">
                            <ItemTemplate>
                                  <a href="news_list.aspx?type=<%#Eval("id") %>"><%#Eval("typename") %></a><br>
                            </ItemTemplate>
                        </asp:Repeater>
                        
                    </p>
                </div>
                <div class="col-sm-4">
                    <h4 class="text-u-c m-b font-thin text-lt"><span class="b-b b-dark">友情连接</span></h4>
                    <p>
                        <asp:Repeater runat="server" ID="rpLink">
                            <ItemTemplate><a target="_blank" href="<%#Eval("url") %>"><%#Eval("title") %></a><br>
                            </ItemTemplate>

                        </asp:Repeater>

                    </p>

                </div>
            </div>
        </div>
    </div>
    <div class="dker">
        <div class="container">
            <div class="row m-t-xl m-b-xl">
                <div class="col-sm-6">
                   
                </div>
                <div class="col-sm-6 text-right text-left-xs">
                    <span>关注我们 </span>
                    <a target="_blank" href="weixin://contacts/profile/<%=WeiXin%>" class="btn btn-icon btn-rounded btn-primary m-l m-r"><i class="fa fa-weixin"></i></a>
                    <a target="_blank" href="tencent://message/?Menu=yes&uin=<%=QQ%>" class="btn btn-icon btn-rounded btn-info"><i class="fa fa-qq"></i></a>
                </div>
            </div>
        </div>
    </div>
</footer>
<!-- / footer -->
