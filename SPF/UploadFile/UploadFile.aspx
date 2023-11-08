<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UploadFile.aspx.cs" Inherits="UploadFile.UploadFile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<title>Subir archivo</title>
<script>
    //window.onbeforeunload = function () {
    //    window.opener.DoNothing();
    //}

    function onCloseWindow() {
        alert('OK');
        var uploadedFilePathVal = document.getElementById("uploadedFilePath").value;
        console.log(uploadedFilePathVal);
        if (uploadedFilePathVal != '') {
            var parentElementIdVal = document.getElementById("parentElementId").value;
            window.opener.document.getElementById(parentElementIdVal).value = uploadedFilePathVal;
            window.opener.CallParentFunction();
        }
    }

    function closeWindow() {
        //document.getElementById("isCloseButton").value = false;
        //console.log(document.getElementById("isCloseButton").value);
        window.opener.DoNothing();
        window.close();
    }

    function processFile() {

        var uploadedFilePathVal = document.getElementById("uploadedFilePath").value;

        if (uploadedFilePathVal != '') {
            window.opener.CallParentFunction(uploadedFilePathVal);
            //window.close();
        }
    }

    function myFunction() {
        var isCloseButton = document.getElementById("isCloseButton").value;
        console.log(isCloseButton);
        
        //if (isCloseButton) {
        //    window.opener.DoNothing();
        //}
    }

    <%--function btnCloseClick() {
        document.getElementById("<%= btnClose.ClientID %>").click();
    }--%>
</script>
</head>
<body>
    <form id="Form1" method="post" enctype="multipart/form-data" runat="server">
        <div style="padding: 5px;">
            <hr/>
            <input type="file" id="File1" name="File1" runat="server" style="width: 100%;" />
            <hr/>
            <input type="submit" id="Submit1" value="Subir" runat="server" onserverclick="Submit1_ServerClick"/>
			&nbsp;<asp:Button ID="btnClose" runat="server" Text="Cerrar" OnClientClick="closeWindow();"/>
            <hr />
            <p runat="server" id="okParagraph" visible="false" style="color: green; font-weight: bold;">Operaci&oacute;n terminada con &eacute;xito. Puede cerrar esta ventana.</p>
            <p runat="server" id="errorParagraph" visible="false" style="color: red; font-weight: bold;">Debe seleccionar un archivo para procesar.</p>
            <input type="hidden" id="parentElementId" value="" runat="server" />
            <input type="hidden" id="uploadedFilePath" value="" runat="server"/>
            <input type="hidden" id="action" value="" runat="server"/>
            <input type="hidden" id="isCloseButton" value="true" runat="server"/>
        </div>
    </form>
</body>
</html>
