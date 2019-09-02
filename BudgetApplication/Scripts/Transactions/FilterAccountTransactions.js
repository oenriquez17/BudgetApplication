$(document).ready(function () {
    handleDropdownFilter();
});

function handleDropdownFilter() {
    $('#selectAccountDropdown').change(function () {
        $('table').addClass('hidden');

        var selected = $('#selectAccountDropdown option:selected').val();

        $('#' + selected).removeClass('hidden');

    });
}