function getReportHTML() {
    var objEmbedRb = vwgContext.provider.getComponentByClientId("rbEmbebido");
    var objForm = vwgContext.provider.getComponentByClientId("frmReport");

    if (objEmbedRb.checked() == "1") {
        
        this.printReport("ctrl1_RV");

        var objExportReportEvent = vwgContext.events.createEvent(objForm.id(), "exportReportHTML");
        //Set event attributes
        vwgContext.events.setEventAttribute(objExportReportEvent, "htmlreportbody", strHTMLReportBody);
        vwgContext.events.raiseEvents();
    }
    else {
        var objExportReportEvent = vwgContext.events.createEvent(objForm.id(), "exportReport");
        vwgContext.events.raiseEvents();
    }
    
    

}

function printPDF(url, titulo) {
    
    //PopupCenter('http://localhost:43552/Resources/UserData/BERKE/gagaleanod/Reportes-636137997257853975.pdf', titulo, '750', '600');
}


function verDatos() {
    alert(window.location.protocol);
    alert(window.location.host);
}

function uploadFile(filename) {
    alert(filename);
}

function PopupCenter(url, title, w, h) {
    // Fixes dual-screen position                         Most browsers      Firefox
    var dualScreenLeft = window.screenLeft != undefined ? window.screenLeft : screen.left;
    var dualScreenTop = window.screenTop != undefined ? window.screenTop : screen.top;

    var width = window.innerWidth ? window.innerWidth : document.documentElement.clientWidth ? document.documentElement.clientWidth : screen.width;
    var height = window.innerHeight ? window.innerHeight : document.documentElement.clientHeight ? document.documentElement.clientHeight : screen.height;

    var left = ((width / 2) - (w / 2)) + dualScreenLeft;
    var top = ((height / 2) - (h / 2)) + dualScreenTop;
    var newWindow = window.open(url, title, 'scrollbars=yes, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);

    // Puts focus on the newWindow
    if (window.focus) {
        newWindow.focus();
    }
}

function PopupCenterCustom(url, title, w, h, formId, elmntId) {
    console.log(url);
    // Fixes dual-screen position                         Most browsers      Firefox
    var dualScreenLeft = window.screenLeft != undefined ? window.screenLeft : screen.left;
    var dualScreenTop = window.screenTop != undefined ? window.screenTop : screen.top;

    var width = window.innerWidth ? window.innerWidth : document.documentElement.clientWidth ? document.documentElement.clientWidth : screen.width;
    var height = window.innerHeight ? window.innerHeight : document.documentElement.clientHeight ? document.documentElement.clientHeight : screen.height;

    var left = ((width / 2) - (w / 2)) + dualScreenLeft;
    var top = ((height / 2) - (h / 2)) + dualScreenTop;
    var newWindow = window.open(url, title, 'scrollbars=yes, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);
    //var newWindow = window.open(url, title);
    //var newWindow = window.open(url, title, 'directories=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no,scrollbars=no,resizable=no, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);


    window.CallParentFunction = function (path) {
        getDocPath(formId, elmntId, path);
    }

    window.DoNothing = function () {
        var objEvent = vwgContext.events.createEvent(formId, "doNothing");
        //vwgContext.events.setEventAttribute(objEvent, "docPathValue", path);
        vwgContext.events.raiseEvents();
    }

    // Puts focus on the newWindow
    if (window.focus) {
        newWindow.focus();
    }
}

function frmPickBaseEnter() {
    var objTxtID = vwgContext.provider.getComponentByClientId("txtClientID");
    alert(objTxtID);
}

function getDocPath(formId, elmntId, path) {
    var objEvent = vwgContext.events.createEvent(formId, "docPathEvent");
    //var docPathVal = document.getElementById("TRG_" + elmntId).value;

    vwgContext.events.setEventAttribute(objEvent, "docPathValue", path);
    vwgContext.events.raiseEvents();
}


// Print function (require the reportviewer client ID)
function printReport(report_ID) {
    //alert("inside printReport " + report_ID);
    //var rv1 = $('#' + report_ID);
    alert('hola mundo');
    var rv1 = vwgContext.provider.getComponentByClientId("frmReport");
    alert(rv1);
    var iDoc = rv1.parents('html');
    alert(iDoc);
    // Reading the report styles
    var styles = iDoc.find("head style[id$='ReportControl_styles']").html();
    if ((styles == undefined) || (styles == '')) {
        iDoc.find('head script').each(function () {
            var cnt = $(this).html();
            var p1 = cnt.indexOf('ReportStyles":"');
            if (p1 > 0) {
                p1 += 15;
                var p2 = cnt.indexOf('"', p1);
                styles = cnt.substr(p1, p2 - p1);
            }
        });
    }
    if (styles == '') { alert("Cannot generate styles, Displaying without styles.."); }
    styles = '<style type="text/css">' + styles + "</style>";

    // Reading the report html
    var table = rv1.find("div[id$='_oReportDiv']");
    if (table == undefined) {
        alert("Report source not found.");
        return;
    }

    // Generating a copy of the report in a new window
    var docType = '<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01//EN" "http://www.w3.org/TR/html4/loose.dtd">';
    var docCnt = styles + table.parent().html();
    var docHead = '<head><title>Printing ...</title><style>body{margin:5;padding:0;}</style></head>';
    var winAttr = "location=yes, statusbar=no, directories=no, menubar=no, titlebar=no, toolbar=no, dependent=no, width=720, height=600, resizable=yes, screenX=200, screenY=200, personalbar=no, scrollbars=yes";;
    var newWin = window.open("", "_blank", winAttr);

    alert(docCnt);

    writeDoc = newWin.document;
    writeDoc.open();
    writeDoc.write(docType + '<html>' + docHead + '<body onload="window.print();">' + docCnt + '</body></html>');
    writeDoc.close();

    // The print event will fire as soon as the window loads
    newWin.focus();
    // uncomment to autoclose the preview window when printing is confirmed or canceled.
    // newWin.close();
};

    function printHTMLBox(elementID, formID){
        var objEle = document.getElementById('TRG_' + elementID, window);
        if (!objEle) {    
            var objFrm = Forms_GetWindowByDataId(formID);     
            objEle = Web_GetElementById('TRG_' + elementID, objFrm);
        } 
        objEle.contentWindow.focus(); 
        objEle.contentWindow.print();
    }

    function NewMaximizeWindowTab(url)
    {
        window.open(url);
        window.moveTo(0,0);
        window.resizeTo(screen.width,screen.height);
    }

    function getPrinterStatus() {
        alert('getPrinterStatus');
        var objForm = VWG.Services.GetApplication().vwgContext.provider.getComponentByClientId("ucImprimirDocumentos");
        var objEvent = VWG.Events.CreateEvent(objForm.id(), "printerStatus");
        VWG.Events.SetEventAttribute(objEvent, "statusValue", objTextBox.value);
        VWG.Events.RaiseEvents();
    }

    function getHTMLBox(controlID) {
        alert(obj1);
        var obj = document.getElementById(controlID);
        alert(obj);
    }

    function deployQZ(deployJavaStr) {
        alert('deployQZ()');
        var attributes = {
            id: "qz", code: 'qz.PrintApplet.class',
            archive: deployJavaStr + '/qz-print.jar', width: 1, height: 1
        };
        var parameters = {
            jnlp_href: deployJavaStr + '/qz-print_jnlp.jnlp',
            cache_option: 'plugin', disable_logging: 'false',
            initial_focus: 'false'
        };
        if (deployJava.versionCheck("1.7+") == true) { }
        else if (deployJava.versionCheck("1.6+") == true) {
            delete parameters['jnlp_href'];
        }
        deployJava.runApplet(attributes, parameters, '1.5');

    }
    
    function getHeaderCheckBoxVal(formId, elmntId) {
        var chk = document.getElementById("TRG_" + elmntId)
        var chkVal = chk.currentStyle.backgroundImage.indexOf('CheckBox1.gif.wgx') > 0;
        var objEvent = vwgContext.events.createEvent(formId, "headerCheckBoxValEvent");

        vwgContext.events.setEventAttribute(objEvent, "headerCheckBoxVal", chkVal);
        vwgContext.events.raiseEvents();
    }

    function showKude(cdc) {
        //fetch("https://facte.siga.com.py/FacturaE/printDE?ruc=80016875-5&cdc=" + cdc).then(function (response) {
        //    // Convert the response to a blob object
        //    return response.blob();
        //}).then(function (blob) {
        //    // Create a URL for the blob object
        //    var url = URL.createObjectURL(blob);

        //    // Open the PDF in a new browser tab
        //    window.open(url);
        //});
        window.open("https://www.abc.com.py");
    }