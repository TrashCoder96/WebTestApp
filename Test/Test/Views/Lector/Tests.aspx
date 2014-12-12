<%@ Page Title="" Language="C#" MasterPageFile="~/Views/WebTestSite.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Web.Mvc.Html" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="server">

<h2>Tests</h2>
    
<table style="border: thin" border="1">
<% foreach (Test.Models.Test item in (Model as object[])[0] as IEnumerable<Test.Models.Test>) { %>
    <tr>
        <td>
            <%:item.Name %>
        </td>

        <td>
            <%:Html.ActionLink("Редактировать", "Test", "Lector", new { TestId = item.TestId.ToString() }, null ) %>
        </td>
        <td>
            <%:Html.ActionLink("Удалить", "DeleteTest", "Lector",new { TestId = item.TestId.ToString() },  null) %>
        </td>

    </tr>
<% } %>

</table>

Создать тест
<form method="get" action="/Lector/CreateTest">
1) Название теста:
<%:Html.TextBox("TestName") %>
<br />
2) Выберете дисциплину
<table style="border: thin" border="1">
<% foreach (Test.Models.Discipline item in (Model as object[])[1] as IEnumerable<Test.Models.Discipline>)
   { %>
    <tr>
        <td>
            <%: item.DisciplineName %>
        </td>
        <td>
             <%: Html.RadioButton("DisciplineId", item.DisciplineId.ToString()) %>
        </td>

    </tr>
<% } %>

</table>

<input type="submit" value="Создать" />
</form>



</asp:Content>
