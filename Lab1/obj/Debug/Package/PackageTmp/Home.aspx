<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Lab1.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section>

    
    </section>

    <section>
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <center>
                    <h2 style="border:1px groove #000000">Choose an option to begin: </h2>
                    <p><b></b></p>
                    </center>
                </div>
            </div>
            <br />
            <br />


            <div class="row">

                <div class="col-md-4">
                    <center>
                        <h2>Teachers</h2>
                        <br />
                        <%--<img width="150px" height="150px" src="Images/list.jpg" />--%>
                        <img width="150px" height="150px" src="../Images/teachers.png" />
                        <br />
                        <br />
                    <h4>
                        <asp:Button ID="btnTeacher" CssClass="btn btn-primary btn-block" runat="server" PostBackUrl="~/TeacherLogin.aspx" Text="Get Started" OnClick="btnTeacher_Click" />
                    </h4>
                    <p class="text-justify"> Click here to begin registering your schools and students for CyberDay!
                    </p>
                    </center>
                </div>
                <div class="col-md-4">
                    <center>
                        <h2>Parents</h2>
                        <br />
                        <%--<img width="150px" height="150px" src="Images/sign-up.png" />--%>
                        <img width="150px" height="150px" src="../Images/register.png" />
                        <br />
                        <br />
                    <h4>
                        <asp:Button ID="btnRegisterChild" CssClass="btn btn-primary btn-block" runat="server" Text="Register Student" OnClick="btnRegisterChild_Click" />
                    </h4>
                    <p class="text-justify">Register your child for CyberDay Events! Click here to begin signing
                        up your child for CyberDay events and activities.
                    </p>
                    </center>
                </div>
                <div class="col-md-4">
                    <center>
                        <h2>Students</h2>
                        <br />
                        <%--<img width="220px" height="150px" src="Images/computer.png" />--%>
                        <img width="150px" height="150px" src="../Images/computer2.png" />
                        <br />
                        <br />
                    <h4>
                        <asp:Button ID="btnStudentStart" CssClass="btn btn-primary btn-block" runat="server" Text="Get Started" PostBackUrl="~/StudentDashboard.aspx" OnClick="btnStudentStart_Click" />
                    </h4>
                    <p class="text-justify">Get started with you CyberDay activities! View activties, Upload your projects, 
                        and chat with volunteers!
                    </p>
                    </center>
                </div>
            </div>



        </div>
    </section>
    <br />
    <br />


</asp:Content>
