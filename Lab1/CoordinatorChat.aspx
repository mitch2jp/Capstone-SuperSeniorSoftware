<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="CoordinatorChat.aspx.cs" Inherits="Lab1.CoordinatorChat" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        .container {
            background-color: #99CCFF;
            border: thick solid #808080;
            padding: 20px;
            margin: 20px;
        }
    </style>


    <div class="container">
        <input type="text" id="message" />
        <input type="button" id="sendmessage" value="Send" />
        <input type="hidden" id="displayname" />
        <ul id="discussion">
        </ul>
    </div>
    <script src="Scripts/jquery-3.5.1.min.js"></script>
    <script src="Scripts/jquery.signalR-2.4.1.min.js"></script>
    <script src="signalr/hubs"></script>
    <script type="text/javascript">
        $(function () {
            var chat = $.connection.chatHub;
            chat.client.broadcastMessage = function (name, message) {
                var encodedName = $('<div />').text(name).html();
                var encodedMsg = $('<div />').text(message).html();
                $('#discussion').append('<li><strong>' + encodedName
                    + '</strong>:&nbsp;&nbsp;' + encodedMsg + '</li>');
            };
            $('#displayname').val(prompt('Enter your name:', ''));
            $('#message').focus();
            $.connection.hub.start().done(function () {
                $('#sendmessage').click(function () {
                    chat.server.send($('#displayname').val(), $('#message').val());
                    $('#message').val('').focus();
                });
            });
        });
    </script>
    <br />
    <br />

    <div>
        <center>
            <asp:Button ID="Button1" CssClass="btn btn-success btn-block btn-lg" runat="server" PostBackUrl="~/CoordinatorDashboard.aspx" Width="400" Text="Back to Dashboard" />
        </center>
    </div>
    <br />
     <br />
    <br />


</asp:Content>
