<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<Test.Models.Quastion>" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Web.Mvc.Html" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
</head>
<body>
    <div>
Ответы:
<table style="border: thin" border="1">
<% foreach (Test.Models.Variant item in Model.Variants)
   { %>
    <tr>
        <td>
            Ответ:
        </td>
        <td>
            <%: item.Text %>
        </td>
        <td>
            Валидность: <%:item.IsValid.ToString() %>
        </td>
        <td>
            <%:Html.ActionLink("Удалить","DeleteVariant", "Lector", new { VariantId = item.VariantId.ToString() } , null) %>
        </td>

    </tr>
<% } %>

</table>
        Создать ответ:
        <form method="get" action="/Lector/CreateVariant" >
            <%:Html.Hidden("QuestionId", Model.QuastionId.ToString()) %>
            <input type="text" name="VariantText" />
            <%:Html.CheckBox("isValid") %>
            <input type="submit"value="Создать вариант" />
        </form>


    </div>
</body>
</html>
