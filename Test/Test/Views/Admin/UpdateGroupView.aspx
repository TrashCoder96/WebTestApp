<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<string>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    
</head>
<body>
 <form action="/Admin/UpdateGroup" method="post">
     <input type="text" name="NewGroupName" value="<%=Model %>" />
     <input type="hidden" name="OldGroupName" value="<%=Model %>" />
     <input type="submit" value="Переименовать" />
 </form>
</body>
</html>
