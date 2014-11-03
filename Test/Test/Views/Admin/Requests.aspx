<%@ Page Title="" Language="C#" MasterPageFile="~/Views/WebTestSite.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Web.Mvc.Html" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="server">

<h2>Запросы от пользователей</h2>
    <form>
    <table style="border: thin" border="1" >

        <tr>
            <td>
                Логин пользователя
            </td>
                
            <td>
                Запрашиваемая роль
            </td>
            <td>
                Сообщение
            </td>
            <td>

            </td>
            <td>

            </td>

        </tr>

        <% 
        List<Test.Models.Request> requests = (List<Test.Models.Request>)ViewData["requests"];
        for (int i = 0; i < requests.Count; i++) { %>
        <tr>
            <td>
                <%=requests[i].User.Login %>
            </td>
            <td>
                <%=requests[i].Role %>
            </td>
            <td>
                <%=requests[i].Message %>
            </td>
             <td>
                <%=Html.ActionLink("Принять запрос", "Accept", "Admin", new { User = requests[i].User.Login, Role = requests[i].Role }, null) %>
            </td>
            <td>
                <%=Html.ActionLink("Отклонить запрос", "Reject", "Admin", new { User = requests[i].User.Login, Role = requests[i].Role }, null) %>
            </td>
        </tr>
        <% } %>
    </table>
   </form>

</asp:Content>
