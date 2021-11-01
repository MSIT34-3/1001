/*<input type="checkbox" id="chkPasw" onClick="ShowHidePasw()">*/
function ShowHidePasw() {
    var txtPasw = $("#Pasw");

    if (txtPasw.attr("type") == "text") {
        txtPasw.attr("type", "password");
    }
    else {
        txtPasw.attr("type", "text");
    }
}