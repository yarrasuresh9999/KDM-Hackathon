<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="youlogin_Default" %>

<!doctype html>
<html>
<head>
<meta name="viewport" content="width=device-width, initial-scale=1.0">
<title>YouDash Login</title> 

<link rel="stylesheet" type="text/css" href="<%=ResolveUrl("~/css/bootstrap.min.css")%>" />
<link rel="stylesheet" type="text/css" href="<%=ResolveUrl("~/css/styles.css")%>" />


<style>
@media all and (min-width: 768px){body{background:#F5F5F5;}
</style>
<!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
<!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->


<style>
.field input
{
    background: none !important;
    border: 0px solid !important;
    height: 34px;
    }
</style>

    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.7/jquery.min.js"></script>

<link rel="stylesheet" href="<%=ResolveUrl("~/fancybox/source/jquery.fancybox.css?v=2.1.3") %>" type="text/css" media="screen" />
<script type="text/javascript" src="<%=ResolveUrl("~/fancybox/source/jquery.fancybox.pack.js?v=2.1.3") %>"></script>

<link rel="stylesheet" href="<%=ResolveUrl("~/fancybox/source/helpers/jquery.fancybox-buttons.css?v=1.0.5") %>" type="text/css" media="screen" />
<script type="text/javascript" src="<%=ResolveUrl("~/fancybox/source/helpers/jquery.fancybox-buttons.js?v=1.0.5") %>"></script>
<script type="text/javascript" src="<%=ResolveUrl("~/fancybox/source/helpers/jquery.fancybox-media.js?v=1.0.5") %>"></script>

<link rel="stylesheet" href="<%=ResolveUrl("~/fancybox/source/helpers/jquery.fancybox-thumbs.css?v=1.0.7") %>" type="text/css" media="screen" />
<script type="text/javascript" src="<%=ResolveUrl("~/fancybox/source/helpers/jquery.fancybox-thumbs.js?v=1.0.7") %>"></script>

 
<script type="text/javascript">
    $(".details").fancybox({
        maxWidth: 500,
        maxHeight: 400,
        fitToView: false,
        width: '70%',
        height: '70%',
        autoSize: true,
        closeClick: false,
        openEffect: 'elastic',
        closeEffect: 'elastic'
    });


    $(".details1").fancybox({
        maxWidth: 700,
        maxHeight: 400,
        fitToView: false,
        width: '70%',
        height: '70%',
        autoSize: true,
        closeClick: false,
        openEffect: 'elastic',
        closeEffect: 'elastic'
    });
</script>
</head>

<body style="background-image:url('../images/Plain_Background_05.jpg');background-repeat:no-repeat;background-attachment:fixed;background-size:cover; background-color:#73EEFE;">

<!-- Fixed navbar -->
<nav class="navbar navbar-default navbar-fixed-top">
  <div class="container">
  <div class="pull-right"><a href="mostused.aspx" data-fancybox-type='iframe' class="details1" style="text-decoration:none;"> Most Frequent Users</a></div>
    <div class="navbar-header">
      <div class="navbar-brand umkc-brand"><a href="#" target="_blank"><img src=<%=ResolveUrl("~/images/YouTube-logo-light.png")%>></img></a></div>
      <div class="navbar-brand app-brand">Youtube Dashboard Application</div> 
    </div>
  </div>
</nav>
<div class="container">
  <div class="row">
    <div class="login-panel center-block" style="max-width:500px;">
      <div class="panel panel-default">
        <form class="form-horizontal" style="margin-top:15px;" id="form" runat="server">
          <div class="panel-body">
              <div class="pull-right">
                    <a data-fancybox-type='iframe' href="register.aspx" class="btn btn-primary btn-sm details" runat="server" onclick="modify()"><span class="glyphicon glyphicon-plus"></span><span class="glyphicon glyphicon-user"></span>&nbsp;New User</a>
                </div>
            <h3 style="color:#317E9A">Login</h3>
            <hr>
            <div class="form-group col-md-12">
                 <asp:Label ID="errorLabel" class="text-danger" runat="server" Text="Label" Visible="False"></asp:Label>
            </div>
            <div class="form-group">
              <div class="input-group col-xs-10 col-xs-offset-1 col-sm-10 col-sm-offset-1 col-md-8 col-md-offset-2 col-lg-6 col-lg-offset-3">
                <div class="input-group-addon"><span class="glyphicon glyphicon-user"></span></div>
                <input type="text" class="form-control disable" id="txtUsername" placeholder="Username" runat="server" required/>
              </div>
            </div>
            <div class="form-group">
              <div class="input-group input-group col-xs-10 col-xs-offset-1 col-sm-10 col-sm-offset-1 col-md-8 col-md-offset-2 col-lg-6 col-lg-offset-3">
                <div class="input-group-addon"><span class="glyphicon glyphicon-lock"></span></div>
                <input type="password" class="form-control" id="txtPassword" placeholder="Password" runat="server" required/>
              </div>
            </div>
              <div class="form-group">
              <div class="input-group col-xs-offset-1 col-sm-offset-1 col-sm-11 col-md-offset-2 col-md-10">
                <div class="checkbox">
                  <label>
                    <asp:CheckBox ID="chkRememberMe" runat="server" />
                    Remember me on this computer </label>
                </div>
              </div>
            </div>
            <div class="form-group">
              <div class="input-group col-xs-offset-1 col-sm-offset-1 col-sm-11 col-md-offset-2 col-md-10">
                <div class="checkbox">
                  <label>
                   <a data-fancybox-type='iframe' class="details"  runat="server" href="forgot.aspx">Forgot Password?</a></label>
                </div>
              </div>
            </div>
            <div class="form-group">
              <div class="input-group col-xs-offset-1 col-sm-offset-1 col-sm-11 col-md-10 col-md-offset-0">
                   <asp:Button ID="btnLogin" class="btn btn-primary pull-right" data-loading-text="Signing in..." autocomplete="off" runat="server" Text=" &nbsp;&nbsp;&nbsp;&nbsp;Sign in&nbsp;&nbsp;&nbsp;&nbsp; " onclick="Login_Click"></asp:Button>
              </div>
            </div>
          </div>
            <asp:CheckBox ID="chkPersist" runat="server" Text="Persist Cookie" Visible="false" />
            <asp:HiddenField ID="failId" runat="server" Visible="false" />
        </form>
      </div>
    </div>
  </div>
  <!-- /container --> 
</div>
<footer class="footer">
  <div class="container footer-container"><u>YouDash Application</u></a> <span class="pull-right">&copy; Fantastic 4 Team</span> </div>
</footer>
<!--Alert-->
<div class="alert alert-danger login-alert" role="alert"> <i class="glyphicon glyphicon-alert"></i>&nbsp;&nbsp;Invalid Username/ Password </div>

<!-- Bootstrap core JavaScript
    ================================================== --> 
<!-- Placed at the end of the document so the pages load faster --> 
<script src="<%=ResolveUrl("~/js/jquery.min.js")%>"></script> 
<script src="<%=ResolveUrl("~/js/bootstrap.min.js")%>"></script> 
<!-- IE10 viewport hack for Surface/desktop Windows 8 bug --> 
<script src="<%=ResolveUrl("~/js/ie10-viewport-bug-workaround.js")%>"></script> 
<script src="<%=ResolveUrl("~/js/site.js")%>"></script>
</body>
</html>
