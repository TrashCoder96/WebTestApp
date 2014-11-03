<%@ Page Title="" Language="C#" MasterPageFile="~/Views/WebTestSite.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ Import Namespace="System.Web.Mvc.Html" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="server">
 <h2>Вход в систему</h2>          
<form id="form1" action="/Auth/Login" method="post">
                <input type="text" name="username" id="username" /><br />
                <input type="password" name="password" id="password" /><br />              
                <input type="submit" value="Войти" />            
 </form>

</asp:Content>
