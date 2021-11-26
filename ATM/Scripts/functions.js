function getValues(id) {
    $.ajax({
        type: "GET",
        traditional: true,
        async: false,
        cache: false,
        // url: '@Url.Action("getValues","Home")',
        url: '/Home/getValues',
        context: document.body,
        data: {id:id},
        success: function (result) {
            var sreturn = result;
            $("#txbEditDesc").val(sreturn['descripcion']);
            $("#txbEditCantidad").val(sreturn['cantidad']);
            $("#txbEditIMEI").val(sreturn['emei']);
            $("#txbEditMarca").val(sreturn['Marca']);
            $("#txbEditid").val(sreturn['Id'])

            $("#ModalEdit").modal('show');
        },
        error: function (xhr) {
            //debugger;
            console.log(xhr.responseText);
            alert("Ocurrio un error");
        }
    });
}
function modalDelete(id) {
    $("#txbDeleatetid").val(id)
    $("#ModalDelete").modal('show');
}

function modalDeleteUser(id) {
    $("#id").val(id)
    $("#modalDeleteUser").modal('show');
}

function modaldeleateEditRol(id) {
    $.ajax({
        type: "GET",
        traditional: true,
        async: false,
        cache: false,
        // url: '@Url.Action("getValues","Home")',
        url: '/Usuarios/deleteRol',
        context: document.body,
        data: { id: id },
        success: function (result) {
            var sreturn = result;
            $("#txbEditRol").val(sreturn['rol1']);
            $("#Id").val(sreturn['Id']);
           
            $("#ModalEditTipo").modal('show');
        },
        error: function (xhr) {
            //debugger;
            console.log(xhr.responseText);
            alert("Ocurrio un error");
        }
    });
}

function modalEditRol(id) {
    $.ajax({
        type: "GET",
        traditional: true,
        async: false,
        cache: false,
        // url: '@Url.Action("getValues","Home")',
        url: '/Usuarios/getValues',
        context: document.body,
        data: { id: id },
        success: function (result) {
            var sreturn = result;
            $("#txbEditRol").val(sreturn['rol1']);
            $("#IdRolEdit").val(sreturn['Id']);

            $("#ModalEditTipo").modal('show');
        },
        error: function (xhr) {
            //debugger;
            console.log(xhr.responseText);
            alert("Ocurrio un error");
        }
    });
}

function modalRol(id) {
    $.ajax({
        type: "GET",
        traditional: true,
        async: false,
        cache: false,
        // url: '@Url.Action("getValues","Home")',
        url: '/Usuarios/getValues',
        context: document.body,
        data: { id: id },
        success: function (result) {
            var sreturn = result;
            $("#txbEditRol").val(sreturn['rol1']);

            $("#ModalEditTipo").modal('show');
        },
        error: function (xhr) {
            //debugger;
            console.log(xhr.responseText);
            alert("Ocurrio un error");
        }
    });
}

function getValueUser(id) {
    $.ajax({
        type: "GET",
        traditional: true,
        async: false,
        cache: false,
        // url: '@Url.Action("getValues","Home")',
        url: '/Usuarios/getValuesUser',
        context: document.body,
        data: { id: id },
        success: function (result) {
            var sreturn = result;
            $("#txbEditDesc").val(sreturn['nombre']);
            $("#txbEditApellidos").val(sreturn['apellidos']);
            $("#txbEditTel").val(sreturn['telefono']);
            $("#Id").val(sreturn['Id'])

            $("#ModalEditUser").modal('show');
        },
        error: function (xhr) {
            //debugger;
            console.log(xhr.responseText);
            alert("Ocurrio un error");
        }
    });
}
function validPhone() {
    var select = document.getElementById('tipo');
    var text = select.options[select.selectedIndex].text;
    if (text == "MOVIL") {
        if ($("#divEmei").is(":visible")){
            $("#divEmei").hide();
        }else {

            $("#divEmei").show();
        }
    } else {
        $("#divEmei").hide();
    }
}
function validPhoneEdit() {
    var select = document.getElementsByName('tipo')[2];
    var text = select.options[select.selectedIndex].text;
    if (text == "MOVIL") {
        if ($("#divImei").is(":visible")) {
            $("#divImei").hide();
        } else {

            $("#divImei").show();
        }
    } else {
        $("#divImei").hide();
    }
}
