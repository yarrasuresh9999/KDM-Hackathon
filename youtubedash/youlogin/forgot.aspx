<%@ Page Language="C#" MasterPageFile="~/youlogin/PopUpMasterPage.master" AutoEventWireup="true" CodeFile="forgot.aspx.cs" Inherits="youlogin_forgot" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">


<style>
    select
    {
        width: 211px !important;
        }

</style>
<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.7/jquery.min.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>
   
<script src="../js/jquery.timepicker.js"></script> 
   <script>
       $(function () {
           $('.time').timepicker();
       });
		</script>

  
   <div class="row">
        <form class="form-horizontal" style="margin-top:15px;" id="form" runat="server">
            <h3 style="color:#317E9A">Forgot Password</h3>
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
             </div>
             <div class="form-group">
              <div class="input-group col-xs-10 col-xs-offset-1 col-sm-10 col-sm-offset-1 col-md-8 col-md-offset-2 col-lg-6 col-lg-offset-3">
                <div class="input-group-addon"><span class="glyphicon glyphicon-inbox"></span></div>
                <input type="text" class="form-control disable" id="txtEmail" placeholder="Email" runat="server" required/>
              </div>
            </div>
              <div class="form-group">
              <div class="input-group col-xs-offset-1 col-sm-offset-1 col-sm-11 col-md-10 col-md-offset-0">
                 <div class="pull_right">&nbsp; &nbsp;</div><asp:Button ID="Submit" class="btn btn-primary" data-loading-text="Searching ..." autocomplete="off" runat="server" Text=" &nbsp;&nbsp;&nbsp;&nbsp;Submit&nbsp;&nbsp;&nbsp;&nbsp; " onclick="Register_Click"></asp:Button>
              </div>
            </div>
               </form>
      </div>


</asp:Content>
