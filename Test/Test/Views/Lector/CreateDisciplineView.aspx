<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<string>" %>

<!DOCTYPE html>

<html>
<head>

</head>
<body>
 <form action="/Lector/CreateDiscipline" method="post">
     <table>
         <tr>
             <td>
                 <input type="text" name="Name" />
             </td>
             <td>
                 <input type="submit" value="Создать" />
             </td>
         </tr>
     </table>
 </form>
</body>
</html>
