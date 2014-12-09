<%@ Page Title="" Language="C#" MasterPageFile="~/Views/WebTestSite.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Test.Models.StudentRequest>>" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Web.Mvc.Html" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="server">

<h2>StudentRequests</h2>
    <form>
    <table style="border: thin" border="1" >

        <tr>
            <td>
                Логин пользователя
            </td>
                
            <td>
                Запрашиваемая группа
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
        foreach (Test.Models.StudentRequest r in this.Model)
        { %>
        <tr>
            <td>
                <%=r.aspnet_Users.UserName %>
            </td>
            <td>
                <%=r.Group.GroupName %>
            </td>
            <td>
                <%=r.Message %>
            </td>
             <td>
                <%=Html.ActionLink("Принять запрос", "AcceptStudentRequest", "Admin", new { UserLogin = r.aspnet_Users.UserName, GroupName = r.Group.GroupName }, null) %>
            </td>
            <td>
                <%=Html.ActionLink("Отклонить запрос", "RejectStudentRequest", "Admin", new { UserLogin = r.aspnet_Users.UserName, GroupName = r.Group.GroupName }, null) %>
            </td>
        </tr>
        <% } %>
    </table>
   </form>
    
</asp:Content>
