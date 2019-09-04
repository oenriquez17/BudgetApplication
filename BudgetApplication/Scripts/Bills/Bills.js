const monthNames = [
    "", "January", "February", "March", "April", "May", "June",
    "July", "August", "September", "October", "November", "December"
];

var paidMonthlyBillIds = [];
var allMonthlyBillIds = [];

$(document).ready(function () {
    for (var i = 0; i < allBills.length; i++) {
        allMonthlyBillIds[i] = allBills[i].MonthlyBillId;
    }

    handleLeftArrow();
    handleRightArrow();
    handleCheckBox();
});

//handles clicking on checkbox
function handleCheckBox() {
    $('input').click(function () {
        var id = $(this).attr('id');
        var isChecked = $(this).is(":checked");
        if (isChecked) {
            payBill(id);
        } else {
            unpayBill(id);
        }
    });
}

//api call to add bill from paid bill map
function payBill(id) {
    var paidBillsMap = {};

    paidBillsMap.MonthlyBillId = id;
    paidBillsMap.Month = currentMonth;
    paidBillsMap.Year = currentYear;

    $.ajax({
        type: 'POST',
        url: '/api/bills',
        data: paidBillsMap,
        success: function () {
            console.log("YAY!");
        }
    });
}

//api call to remove bill from paid bill map
function unpayBill(id) {
    var paidBillsMap = {};

    paidBillsMap.MonthlyBillId = id;
    paidBillsMap.Month = currentMonth;
    paidBillsMap.Year = currentYear;

    $.ajax({
        type: 'DELETE',
        url: '/api/bills',
        data: paidBillsMap,
        success: function () {
            console.log("YAY!");
        }
    });
}

//handles clicking on left arrow
function handleLeftArrow() {
    $('#back').click(function () {
        var newMonth = (currentMonth - 1) % 13;
        if (newMonth == 0) {
            newMonth = 12;
            currentYear--;
        } 

        var req = {};
        req.userId = uId;
        req.month = newMonth;
        req.year = currentYear;

        $.ajax({
            type: 'GET',
            url: '/api/bills',
            data: req,
            success: function (data) {
                updateList(data);
                updateView();
            }
        });

        currentMonth = newMonth;
        $('#monthYear').text(monthNames[currentMonth] + ' ' + currentYear);
    });
}

//handles clicking on right arrow
function handleRightArrow() {
    $('#forward').click(function () {
        var newMonth = (currentMonth + 1) % 13;
        if (newMonth == 0) {
            newMonth++;
            currentYear++
        }

        var req = {};
        req.userId = uId;
        req.month = newMonth;
        req.year = currentYear;

        $.ajax({
            type: 'GET',
            url: '/api/bills',
            data: req,
            success: function (data) {
                updateList(data);
                updateView();
            }
        });

        currentMonth = newMonth;
        $('#monthYear').text(monthNames[currentMonth] + ' ' + currentYear);
    });
}

//updates view
function updateView() {
    for (var i = 0; i < allMonthlyBillIds.length; i++) {

        var bid = allMonthlyBillIds[i];

        if (paidMonthlyBillIds.includes(bid)) {
            $('#' + allMonthlyBillIds[i]).prop("checked", true);
        } else {
            $('#' + allMonthlyBillIds[i]).prop("checked", false);
        }
    }
}

//updates list used to update view
function updateList(data) {
    paidMonthlyBillIds = [];
    for (var i = 0; i < data.length; i++) {
        paidMonthlyBillIds[i] = data[i].monthlyBillId;
    }
}