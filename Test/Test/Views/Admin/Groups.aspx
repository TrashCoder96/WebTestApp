<%@ Page Title="" Language="C#" MasterPageFile="~/Views/WebTestSite.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Test.Models.Group>>" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Web.Mvc.Html" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="server">

<h2>Groups</h2>
<%: Html.Action("CreateGroup", "Admin") %>
<table style="border: thin" border="1">
<% foreach (Test.Models.Group item in Model) { %>
    <tr>
        <td>
            <%: item.GroupName %>
        </td>
        <td>
             <%: Html.Action("UpdateGroupView", "Admin", new { GroupName=item.GroupName }) %>
        </td>
        <td>
             <%: Html.Action("DeleteGroupView", "Admin", new { GroupName=item.GroupName }) %>
        </td>

    </tr>
<% } %>

</table>

</asp:Content>
