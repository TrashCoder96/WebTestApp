<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<string>" %>

<!DOCTYPE html>

<html>
<head>

</head>
<body>
     <form action="/Lector/DeleteDiscipline" method="post">
     <input type="hidden" name="Name" value="<%=Model %>" />
     <input type="submit" value="Удалить" />
 </form>
</body>
</html>
