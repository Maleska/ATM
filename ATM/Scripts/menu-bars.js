$("#menu-toggle").click(function (e) {
    e.preventDefault();
    $("#wrapper").toggleClass("active");
});

$("#linkInv").click(function (e) {
    e.preventDefault();
    if ($("#ContInv").is(":visible")) {
        //$("#ContInv")
        document.getElementById("ContInv").hidden = true;
    } else {
        document.getElementById("ContInv").hidden = false;
    }

});
function cliclInv() {
    if ($("#ContInv").is(":visible")) {
        //$("#ContInv")
        document.getElementById("ContInv").hidden = true;
    } else {
        document.getElementById("ContInv").hidden = false;
    }
}
function valid(id) {
    if (id == 1) {
        document.getElementById("ContInv").hidden = false;
        document.getElementById("ContInvList").hidden = true;
    } else if (id == 2) {
        document.getElementById("ContInv").hidden = true;
        document.getElementById("ContInvList").hidden = false;
    }
}