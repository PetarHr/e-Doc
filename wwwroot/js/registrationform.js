jQuery(document).ready(function ($) {
    //hide all the optional fields upon document load
    $('#UIN > .input_field > input').prop('disabled', true)
    $('#UIN').hide()
    $('#MedicalCenter > .input_field > input').prop('disabled', true)
    $('#MedicalCenter').hide()
    $('#SpecialtyCode > .input_field > input').prop('disabled', true)
    $('#SpecialtyCode').hide()
    $('#Workplace > .input_field > input').prop('disabled', true)
    $('#Workplace').hide()
    $('#Occupation > .input_field > input').prop('disabled', true)
    $('#Occupation').hide()

    $('#Input_Role').change(function () {
        //upon change of the role hide the fields and enable the ones that need to be populated
        $('#UIN > .input_field > input').prop('disabled', true)
        $('#UIN').hide()
        $('#MedicalCenter > .input_field > input').prop('disabled', true)
        $('#MedicalCenter').hide()
        $('#SpecialtyCode > .input_field > input').prop('disabled', true)
        $('#SpecialtyCode').hide()
        $('#Workplace > .input_field > input').prop('disabled', true)
        $('#Workplace').hide()
        $('#Occupation > .input_field > input').prop('disabled', true)
        $('#Occupation').hide()
        $('#Workplace > .input_field > input').prop('placeholder', "Работодател")

        $("#Input_Role option:selected").each(function () {
            var value = $(this).val();
            if (value == "eDoctor") {
                $('#UIN > .input_field > input').prop('disabled', false)
                $('#UIN').show()
                $('#MedicalCenter > .input_field > input').prop('disabled', false)
                $('#MedicalCenter').show()
                $('#SpecialtyCode > .input_field > input').prop('disabled', false)
                $('#SpecialtyCode').show()
                $('#Occupation > .input_field > input').prop('disabled', true)
                $('#Occupation').hide()

            } else if (value == "ePharmacist") {
                $('#Workplace > .input_field > input').prop('disabled', false)
                $('#Workplace').show()
                $('#Occupation > .input_field > input').prop('disabled', true)
                $('#Occupation').hide()
            } else if (value == "eEmployer") {
                $('#Workplace > .input_field > input').prop('disabled', false)
                $('#Workplace').show()
                $('#Workplace > .input_field > input').prop('placeholder', "Име на компанията")
                $('#Occupation > .input_field > input').prop('disabled', true)
                $('#Occupation').hide()
                
            } else {
                $('#Workplace > .input_field > input').prop('disabled', false)
                $('#Workplace').show()
                $('#Occupation > .input_field > input').prop('disabled', false)
                $('#Occupation').show()
            }

        });
    });
});