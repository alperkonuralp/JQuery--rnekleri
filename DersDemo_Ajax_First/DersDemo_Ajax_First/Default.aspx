<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DersDemo_Ajax_First._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" method="get" runat="server">
    <div>
        <img src="menuback.png" />
        <img src="QuestionMark.png" />
        İstek Tipi :
        <%= Request.HttpMethod %>
        <br />
        Adınız :
        <input type="text" name="tbName" id="tbName" />
        <br />
        Soyadınız :
        <input type="text" name="tbSurname" id="tbSurname" />
        <br />
        <select name="ddlGender" id="ddlGender">
            <option>Erkek</option>
            <option>Kadın</option>
        </select>
        <input type="submit" value='Gönder' />
    </div>
    </form>
</body>
</html>
