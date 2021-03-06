$(document).ready(function () {

    $("#btnSave").on("click", function () {
        $("#_formSave").submit();
    });

    $("#cpfInput").mask("999.999.999-99");
});

function onSaveNaturalPersonSucess(data) {

    if (data.success) {
        Swal.fire(
            'Natural Person',
            'Saved!',
            'success'
        ).then((result) => {
            window.location.href = "/NaturalPerson/List";  
        })

    } else {
        Swal.fire(
            'Natural Person',
            data.msg,
            'warning'
        )
    }
}

function Edit(id) {
    window.location.href = "/NaturalPerson?id=" + id; 
}

function onSaveNaturalPersonFailure() {
    Swal.fire(
        'Natural Person',
        'Ops, sorry!',
        'error'
    )
}