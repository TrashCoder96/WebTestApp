<%@ Page Title="" Language="C#" MasterPageFile="~/Views/WebTestSite.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Test.Models.User>>" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Web.Mvc.Html" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="server">

<h2>Students</h2>

<p>
    <%: Html.ActionLink("Create New", "Create") %>
</p>
<table style="border: thin" border="1">
    <tr>
        <th>
            Имя
        </th>
        <th>
            Фамилия
        </th>
        <th>
            Почта
        </th>
        <th>
            Логин
        </th>
        <th>

        </th>
          <th>

        </th>
          <th>

        </th>
    </tr>

<% foreach (Test.Models.User item in Model)
   { %>
    <tr>
        <td>
            <%: item.FirstName %>
        </td>
        <td>
            <%: item.LastName %>
        </td>
        <td>
            <%: item.EMail %>
        </td>
        <td>
            <%: item.Login %>
        </td>
        <td>
           
        </td>
        <td>
           
        </td>
        <td>

        </td>
    </tr>
<% } %>

</table>

</asp:Content>
