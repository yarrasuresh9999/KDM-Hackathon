<%@ Page Language="C#" MasterPageFile="~/youlogin/PopUpMasterPage.master" AutoEventWireup="true" CodeFile="RecentVideos.aspx.cs" Inherits="youlogin_RecentVideos" %>


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
            <h3 style="color:#317E9A">Your Recent Viewed Videos</h3>
           
           <div class="panel-body">
                    <div id="list1" runat="server"></div>
                </div>   
                
                 </form>
      </div>
  </asp:Content>