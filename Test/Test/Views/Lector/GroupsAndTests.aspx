<%@ Page Title="" Language="C#" MasterPageFile="~/Views/WebTestSite.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Web.Mvc.Html" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="server">

<h2>GroupsAndTests</h2>

<form method="get" action="/Lector/BindGroupAndTest">
Тесты:
<table style="border: thin" border="1">
<% foreach (Test.Models.Test item in (Model as object[])[0] as IEnumerable<Test.Models.Test>) { %>
    <tr>
        <td>
            <%:item.Name %>            
        </td>
        <td>
            <%:item.Discipline.DisciplineName %>
        </td>
        <td>
            <%:Html.RadioButton("TestId", item.TestId.ToString()) %>
        </td>

    </tr>
<% } %>

</table>

Группы:
<table style="border: thin" border="1">
<% foreach (Test.Models.Group item in (Model as object[])[1] as IEnumerable<Test.Models.Group>) { %>
    <tr>
        <td>
            <%:item.GroupName %>
        </td>      
        <td>
           <%:Html.RadioButton("GroupId", item.GroupId.ToString()) %>
        </td>

    </tr>
<% } %>

</table>

<input type="submit" value="Связать" />

</form>

</asp:Content>
