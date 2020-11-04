    function disableEmptyInputs(form)
    {
        var controls = form.elements;
        for (var i = 0, iLen = controls.length; i < iLen; i++)
        {
                controls[i].disabled = controls[i].value == '';
        }
}

function enableEmptyInputs(form) {
    var controls = form.elements;
    for (var i = 0, iLen = controls.length; i < iLen; i++) {
        controls[i].disabled = controls[i].value == 'false';
    }
}