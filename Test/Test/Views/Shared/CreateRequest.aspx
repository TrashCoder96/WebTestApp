<%@ Page Title="" Language="C#" MasterPageFile="~/Views/WebTestSite.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ Import Namespace="Test.Models" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="server">

<h2>Create Request</h2>

<form id="form1" action="/Shared/CreateRequest" method="post">
                <input type="text" name="message" id="message" /> Сообщение<br />
                Выберете роль
                <p style="border-color: blue; border-width: 3px">
                <input type="radio" name="role" value="Admin" /> Админ <br />  
                <input type="radio" name="role" value="Student" /> Студент <br />  
                <input type="radio" name="role" value="Lector" /> Лектор <br />  
                </p>
               
                <input type="submit" value="Запросить" />            
 </form>

</asp:Content>
