<%@ Page Title="" Language="C#" MasterPageFile="~/Views/WebTestSite.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Web.Mvc.Html" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="server">

<h2>Tests</h2>
    
<table style="border: thin" border="1">
<% foreach (Test.Models.Test item in (Model as object[])[0] as IEnumerable<Test.Models.Test>) { %>
    <tr>
        <td>
            <%: item.Name %>
        </td>
        <td>
            <form method="post" action="/Lector/DeleteTest" >
            <%: Html.Hidden("TestId", item.TestId.ToString()) %>
            <input type="submit" value="Удалить" />
            </form>
             <form method="get" action="/Lector/Test" >
            <%: Html.Hidden("TestId", item.TestId.ToString()) %>
            <input type="submit" value="Редактировать вопросы" />
            </form>
           
        </td>

    </tr>
<% } %>

</table>

 Создать тест
<%: Html.BeginForm("CreateTest", "Lector", System.Web.Mvc.FormMethod.Post) %>
<%: Html.TextBox("TestName") %>
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

Для каких групп:

    <table style="border: thin" border="1">
<% foreach (Test.Models.Group item in (Model as object[])[2] as IEnumerable<Test.Models.Group>)
   { %>
    <tr>
        <td>
            <%: item.GroupName %>
        </td>
        <td>
             <%: Html.RadioButton("GroupId", item.GroupId.ToString()) %>
        </td>

    </tr>
<% } %>




     <input type="submit" value="Создать" />
     <% Html.EndForm(); %>



</asp:Content>
