<%@ Page Language="C#" MasterPageFile="~/youlogin/PopUpMasterPage.master" AutoEventWireup="true" CodeFile="mostused.aspx.cs" Inherits="youlogin_mostused" %>

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
            <h3 style="color:#317E9A">Most Frequent Logins</h3>
           
           <div class="panel-body">
                    <div id="list" runat="server"></div>
                </div>   
                
                 </form>
      </div>


    


</asp:Content>
