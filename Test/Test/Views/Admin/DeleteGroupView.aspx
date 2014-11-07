<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<string>" %>

<!DOCTYPE html>

<html>
<head>

</head>
<body>
     <form action="/Admin/DeleteGroup" method="post">
     <input type="hidden" name="GroupName" value="<%=Model %>" />
     <input type="submit" value="Удалить" />
 </form>
</body>
</html>
