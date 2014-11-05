<%@ Page Title="" Language="C#" MasterPageFile="~/Views/WebTestSite.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Test.Models.Discipline>>" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Web.Mvc.Html" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="server">

<h2>Управление дисциплинами</h2>
<%: Html.Action("CreateDisciplineView", "Lector") %>
<table style="border: thin" border="1">
<% foreach (Test.Models.Discipline item in Model) { %>
    <tr>
        <td>
            <%: item.Name %>
        </td>
        <td>
             <%: Html.Action("UpdateDisciplineView", "Lector", new { Name=item.Name }) %>
        </td>
        <td>
             <%: Html.Action("DeleteDisciplineView", "Lector", new { Name=item.Name }) %>
        </td>

    </tr>
<% } %>

</table>

</asp:Content>
