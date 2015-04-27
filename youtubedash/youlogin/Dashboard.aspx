<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="youlogin_Dashboard" MasterPageFile="~/youlogin/MasterPage.master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript" src="https://code.jquery.com/jquery-1.11.1.min.js" ></script>
		<link rel="shortcut icon" type="image/ico" href="http://www.datatables.net/favicon.ico">

		<link rel="stylesheet" type="text/css" href="DT_bootstrap.css">

		
		<script type="text/javascript" charset="utf-8" language="javascript" src="jquery.dataTables.js"></script>
		<script type="text/javascript" charset="utf-8" language="javascript" src="DT_bootstrap.js"></script>
    
    <script type="text/javascript">
        $(document).ready(function () {
            $("#myTable").DataTable();
        });

</script>

    <%--<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.7/jquery.min.js"></script>--%>

<link rel="stylesheet" href="<%=ResolveUrl("~/fancybox/source/jquery.fancybox.css?v=2.1.3") %>" type="text/css" media="screen" />
<script type="text/javascript" src="<%=ResolveUrl("~/fancybox/source/jquery.fancybox.pack.js?v=2.1.3") %>"></script>

<link rel="stylesheet" href="<%=ResolveUrl("~/fancybox/source/helpers/jquery.fancybox-buttons.css?v=1.0.5") %>" type="text/css" media="screen" />
<script type="text/javascript" src="<%=ResolveUrl("~/fancybox/source/helpers/jquery.fancybox-buttons.js?v=1.0.5") %>"></script>
<script type="text/javascript" src="<%=ResolveUrl("~/fancybox/source/helpers/jquery.fancybox-media.js?v=1.0.5") %>"></script>

<link rel="stylesheet" href="<%=ResolveUrl("~/fancybox/source/helpers/jquery.fancybox-thumbs.css?v=1.0.7") %>" type="text/css" media="screen" />
<script type="text/javascript" src="<%=ResolveUrl("~/fancybox/source/helpers/jquery.fancybox-thumbs.js?v=1.0.7") %>"></script>

 
<script type="text/javascript">
    $(".more").fancybox({
            'padding': 0,
            'autoScale': false,
            'transitionIn': 'none',
            'transitionOut': 'none',
            'title': this.title,
            'width': 680,
            'height': 495,
            'href': this.href.replace(new RegExp("watch\\?v=", "i"), 'v/'),
            'type': 'swf',
            'swf': {
                'wmode': 'transparent',
                'allowfullscreen': 'true'
            }
        });

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
        <div class="col-sm-6 col-sm-offset-3">
                <div class="input-group stylish-input-group">
                    <asp:TextBox ID="txt_Search"  class="form-control" placeholder="Search" runat="server"></asp:TextBox>
                    <span class="input-group-addon">
                        <button type="submit" runat="server">
                            <span class="glyphicon glyphicon-search"></span>
                        </button>
                    </span>
            </div>
        </div>
        <div style = "width:100px" class="col-sm-6 col-sm-offset-3">
        <asp:DropDownList
                        ID="ddl_maxcount" runat="server" class = "form-control">
                        <asp:ListItem Selected="True">10</asp:ListItem>
                        <asp:ListItem>20</asp:ListItem>
                        <asp:ListItem>30</asp:ListItem>
                    </asp:DropDownList>
                    <label>Max Count</label>
                    </div>
    </div>
    <div class="row">
        <div class="login-panel center-block" style="max-width: 1100px;">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <div class="panel-title">
                        Dashboard
                    </div>
                    
                </div>
                <div class="panel-body">
                    <div id="list" runat="server" visible="false"></div>
                </div>
            </div>
        </div>
    </div>

    

</asp:Content>
