const monthNames = [
    "", "January", "February", "March", "April", "May", "June",
    "July", "August", "September", "October", "November", "December"
];

$(document).ready(function () {
    handleLeftArrow();
    handleRightArrow();
    handleCheckBox();
});

function handleCheckBox() {
    $('input').click(function () {
        var id = $(this).attr('id');
        var isChecked = $(this).is(":checked");
        if (isChecked) {
            payBill(id);
        } else {

        }
    });
}

function payBill(id) {
    var paidBillsMap = {};

    paidBillsMap.MonthlyBillId = id;
    paidBillsMap.Month = currentMonth;
    paidBillsMap.Year = currentYear;
    console.log(paidBillsMap);
    $.ajax({
        type: 'POST',
        url: '/api/bills',
        data: paidBillsMap,
        success: function () {
            console.log("YAY!");
        }
    });
}


function handleLeftArrow() {
    $('#back').click(function () {
        var newMonth = (currentMonth - 1) % 13;
        if (newMonth == 0) {
            newMonth++;
            currentYear--;
        } 
        currentMonth = newMonth;
        $('#monthYear').text(monthNames[currentMonth] + ' ' + currentYear);
    });
}

function handleRightArrow() {
    $('#forward').click(function () {
        var newMonth = (currentMonth + 1) % 13;
        if (newMonth == 0) {
            newMonth++;
            currentYear++
        }
        currentMonth = newMonth;
        $('#monthYear').text(monthNames[currentMonth] + ' ' + currentYear);
    });
}