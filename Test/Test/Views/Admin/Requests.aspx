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
                <%=r.aspnet_Users.UserName %>
            </td>
            <td>
                <%=r.aspnet_Roles.RoleName %>
            </td>
            <td>
                <%=r.Message %>
            </td>
             <td>
                <%=Html.ActionLink("Принять запрос", "Accept", "Admin", new { UserLogin = r.aspnet_Users.UserName, Role = r.aspnet_Roles.RoleName }, null) %>
            </td>
            <td>
                <%=Html.ActionLink("Отклонить запрос", "Reject", "Admin", new { UserLogin = r.aspnet_Users.UserName, Role = r.aspnet_Roles.RoleName }, null) %>
            </td>
        </tr>
        <% } %>
    </table>
   </form>

</asp:Content>
