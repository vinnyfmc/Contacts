$(document).ready(function () {

    $("#btnSave").on("click", function () {
        $("#_formSave").submit();
    });

    $("#cnpjInput").mask("99.999.999/9999-99");
});

function onSaveLegalPersonSucess(data) {

    if (data.success) {
        Swal.fire(
            'Legal Person',
            'Saved!',
            'success'
        ).then((result) => {
            window.location.href = "/LegalPerson/List";  
        })

    } else {
        Swal.fire(
            'Legal Person',
            data.msg,
            'warning'
        )
    }
}

function Edit(id) {
    window.location.href = "/LegalPerson?id=" + id; 
}

function onSaveLegalPersonFailure() {
    Swal.fire(
        'Legal Person',
        'Ops, sorry!',
        'error'
    )
}