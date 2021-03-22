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
        )
    } else {
        Swal.fire(
            'Natural Person',
            'You can not save this person!',
            'warning'
        )
    }
}

function onSaveNaturalPersonFailure() {
    Swal.fire(
        'Natural Person',
        'Ops, sorry!',
        'error'
    )
}