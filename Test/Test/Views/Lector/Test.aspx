<%@ Page Title="" Language="C#" MasterPageFile="~/Views/WebTestSite.Master" Inherits="System.Web.Mvc.ViewPage<Test.Models.Test>" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Web.Mvc.Html" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="server">

<h2>Редактирование теста</h2>
    Вопросы:
   <table style="border: thin" border="1">
<% foreach (Test.Models.Quastion item in Model.Quastions) { %>
    <tr>
        <td>
            <%: item.Text %>
        </td>
        <td>
            <form method="get" action="/Lector/Variants">
                  <%: Html.Hidden("QuastionId", item.QuastionId.ToString()) %>
                  <%: Html.Hidden("TestId", Model.TestId.ToString()) %>
                <input type="submit" value="Редактировать варианты" />
            </form>
        </td>
    </tr>
<% } %>
       </table>
       <form method="post" action="/Lector/CreateQuastion">
                <input type="text" name="QuastionText"/>
                <%: Html.Hidden("TestId", Model.TestId.ToString()) %>
                <input type="submit" value="Создать вопрос" />
       </form>


</asp:Content>
