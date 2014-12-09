<%@ Page Title="" Language="C#" MasterPageFile="~/Views/WebTestSite.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Test.Models.Test>>" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Web.Mvc.Html" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="server">

<h2>Tests</h2>
    <table style="border: thin" border="1">
<% foreach (Test.Models.Test item in Model) { %>
    <tr>
        <td>
            <%: item.Name %>
        </td>
        <td>
            <form method="get" action="/Lector/TakeTest" >
            <%: Html.Hidden("TestId", item.TestId.ToString()) %>
            <input type="submit" value="Пройти тест" />
            </form>
           
        </td>

    </tr>
<% } %>

</table>
</asp:Content>
