<%@ Page Title="" Language="C#" MasterPageFile="~/Views/WebTestSite.Master" Inherits="System.Web.Mvc.ViewPage<Test.Models.Test>" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Web.Mvc.Html" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="server">

<table style="border: thin" border="1">
<% foreach (Test.Models.Quastion item in Model.Quastions) { %>
    <tr>
        <td>
           <%:item.Text %>
        </td>
        <td>
            <%:Html.Action("Question", "Lector", new { QuestionId = item.QuastionId.ToString()}) %>
        </td>
        <td>
            <%:Html.ActionLink("Удалить","DeleteQuestion", "Lector", new { QuestionId = item.QuastionId.ToString() }, null) %>
        </td>

    </tr>
<% } %>
</table>

Создать новый вопрос:
<form method="get" action="/Lector/CreateQuestion">
<%:Html.Hidden("TestId", Model.TestId.ToString()) %>
<input type="text" name="QuestionText" /> Текст вопроса
<br />
<input type="submit" value="Создать" />
</form>

</asp:Content>
