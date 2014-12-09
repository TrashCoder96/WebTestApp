<%@ Page Title="" Language="C#" MasterPageFile="~/Views/WebTestSite.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Web.Mvc.Html" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="server">

<h2>Варианты для этого вопроса</h2>
    
    <table style="border: thin" border="1">
       
<% foreach (Test.Models.Variant item in (Model as object[])[0] as IEnumerable<Test.Models.Variant>) { %>
    <tr>
        <td>
            <%: item.Text %>
        </td>
        <td>
            <form method="get" action="/Lector/UpdateVariant" >
            <%:Html.Hidden("VariantId", item.VariantId) %>
            <input type="text" name="Text" />
            Валидность
            <%:Html.CheckBox("isValid", item.IsValid) %>
            <input type="submit" value="Изменить вариант" />
            </form>
        </td>
        <td>
            <form method="get" action="/Lector/DeleteVariant" >
            <%:Html.Hidden("VariantId", item.VariantId) %>
            <input type="submit" value="Удалить вариант" />
            </form>
        </td>

    </tr>
<% } %>

</table>

    <form method="get" action="/Lector/CreateVariant" >
         <%:Html.Hidden("QuastionId", ((Model as object[])[1] as Test.Models.Quastion).QuastionId.ToString()) %>
        <input type="text" name="VariantText" />
        <input type="submit" value="Создать вариант" />
    </form>

</asp:Content>
