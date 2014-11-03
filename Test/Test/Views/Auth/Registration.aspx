<%@ Page Title="" Language="C#" MasterPageFile="~/Views/WebTestSite.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="server">

<h2>Бастрая регистрация</h2>
    <form id="form1" action="/Auth/Registration" method="post">
                <input type="text" name="firstname" id="firstname" />Имя<br /> 
                <input type="text" name="lastname" id="lastname" />Фамилия<br /> 

                <input type="text" name="login" id="login" />Логин<br /> 
                <input type="text" name="email" id="email" />E-Mail<br /> 

                <input type="password" name="password" id="password" />Пароль<br /> 
                <input type="password" name="repeat" id="repeat" />Повтор пароля<br /> 
                
                <input type="submit" value="Зарегистрироваться" />            
     </form>

</asp:Content>
