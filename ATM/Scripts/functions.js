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
            $("#txbEditCant").val(sreturn['cantidad']);
            $("#txbEditCB").val(sreturn['CB']);
            $("#id").val(sreturn['Id'])

            $("#ModalEdit").modal('show');
        },
        error: function (xhr) {
            //debugger;
            console.log(xhr.responseText);
            alert("Error has occurred..");
        }
    });
}