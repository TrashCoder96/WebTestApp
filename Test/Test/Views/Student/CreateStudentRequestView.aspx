<%@ Page Title="" Language="C#" MasterPageFile="~/Views/WebTestSite.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Test.Models.Group>>" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Web.Mvc.Html" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="server">

<h2>CreateStudentRequest</h2>
                Выберете группу
    <table>
        <tr>
            <td>
                Название группы
            </td>

            <td>

            </td>
        </tr>

                <%foreach(Test.Models.Group g in Model) { %>
        <tr>
            <td>
                <%=g.GroupName %>
            </td>
            <td>
                <%=Html.ActionLink("Выбрать", "CreateStudentRequest", "Student", new { GroupName = g.GroupName }, null) %>
            </td>
        </tr>         
               <%} %>               
          
    </table>
</asp:Content>
