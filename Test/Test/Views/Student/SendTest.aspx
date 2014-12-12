<%@ Page Title="" Language="C#" MasterPageFile="~/Views/WebTestSite.Master" Inherits="System.Web.Mvc.ViewPage<int>" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Web.Mvc.Html" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="server">

<h2>Ваш результат</h2>

    <%:Model.ToString() %>
</asp:Content>
