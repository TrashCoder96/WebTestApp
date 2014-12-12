<%@ Page Title="" Language="C#" MasterPageFile="~/Views/WebTestSite.Master" Inherits="System.Web.Mvc.ViewPage<Test.Models.Test>" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Web.Mvc.Html" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="server">

<h2>Тест: <%:(Model as Test.Models.Test).Name %></h2>
<table style="border: thin" border="1">
<% foreach (Test.Models.Quastion item in Model.Quastions) { %>
    <tr>
        <td>
           <%:item.Text %>
        </td>
        <td>



       <table style="border: thin" border="1">
       <% foreach (Test.Models.Variant itemj in item.Variants)
       { %>
       <tr>
        <td>
            Ответ:
        </td>
        <td>
            <%: itemj.Text %>
        </td>
           <td>
               <form method="get" action="/Student/ChangeVariant">
                   <%:Html.Hidden("VariantId", itemj.VariantId.ToString()) %>
                   <%:Html.Label("Правильность - " + (itemj.IsValid?"Правильно":"Неправильно")) %>
                   <%:Html.Hidden("newisValid", itemj.IsValid) %>
                   <input type="submit" value="Изменить" />
               </form>

           </td>
        <td>
         
        </td>

        </tr>
        <% } %>

        </table>
        </td>
        <td>

        </td>

    </tr>
<% } %>
</table>
<%:Html.ActionLink("Отослать тест", "SendTest", "Student") %>


</asp:Content>
