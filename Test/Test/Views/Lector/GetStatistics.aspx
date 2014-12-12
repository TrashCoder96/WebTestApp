<%@ Page Title="" Language="C#" MasterPageFile="~/Views/WebTestSite.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Test.Models.Result>>" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Web.Mvc.Html" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="server">

<h2>Статистика</h2>

<table style="border: thin" border="1">
<% foreach (Test.Models.Result item in Model) { %>
    <tr>
        <td>
            Имя студента
            <%: item.aspnet_Users.UserName %>
        </td>
        <td>
            Название теста
            <%: item.Test.Name %>
        </td>
        <td>
            Результат
            <%: item.Result1 %>
        </td>

    </tr>
<% } %>

</table>

</asp:Content>
