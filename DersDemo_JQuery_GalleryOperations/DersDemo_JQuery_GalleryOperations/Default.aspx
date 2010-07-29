<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DersDemo_JQuery_GalleryOperations._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script src="jquery-1.4.2.min.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(function() {
            //            var a = $("img");
            //            for (var i = 0; i < a.length; i++) {
            //                
            //            }
            $("img").each(function(i, item) {
                if ($(item).width() > 200) {
                    $(item).width(200)
                        .click(function() {
                            if ($(this).width() == 200) {
                                $(this).width('auto');
                                $("img").not(this).hide();
                            }
                            else {
                                $(this).width(200);
                                $("img").not(this).show();
                            }
                        });
                }
            });
        });
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <img src="m1.jpg" />
        <img src="m6.jpg" />
        <img src="m2.jpg" />
        <img src="m3.jpg" />
        <img src="m4.jpg" />
        <img src="m5.jpg" />
        <img src="a01.jpg" />
        <img src="a04.png" />
        <img src="a02.jpg" />
        <img src="a03.png" />
    </div>
    </form>
</body>
</html>
