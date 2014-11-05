<%@ Page Title="" Language="C#" MasterPageFile="~/Views/WebTestSite.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Test.Models.Request>>" %>
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
        foreach (Test.Models.Request r in this.Model)
        { %>
        <tr>
            <td>
                <%=r.User.Login %>
            </td>
            <td>
                <%=r.Role %>
            </td>
            <td>
                <%=r.Message %>
            </td>
             <td>
                <%=Html.ActionLink("Принять запрос", "Accept", "Admin", new { User = r.User.Login, Role = r.Role }, null) %>
            </td>
            <td>
                <%=Html.ActionLink("Отклонить запрос", "Reject", "Admin", new { User = r.User.Login, Role = r.Role }, null) %>
            </td>
        </tr>
        <% } %>
    </table>
   </form>

</asp:Content>
