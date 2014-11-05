<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<string>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    
</head>
<body>
 <form action="/Lector/UpdateDiscipline" method="post">
     <input type="text" name="NewName" value="<%=Model %>" />
     <input type="hidden" name="OldName" value="<%=Model %>" />
     <input type="submit" value="Переименовать" />
 </form>
</body>
</html>
