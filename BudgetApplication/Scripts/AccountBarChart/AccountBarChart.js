// purple -> checkings, savings
var purple = 'rgba(167, 138, 212, 1)';
// yellow -> credit cards
var yellow = 'rgba(222, 189, 82, 1)';

// green -> postive net total
var green = 'rgba(95, 221, 125, 1)';
// gray -> negative net total
var gray = 'rgba(183, 189, 184, 1)';

var myAccounts = [];
var myAmounts = [];
var myColors = [];

var shownAccountIds = new Set();

function getAccounts() {

    for (var i = 0; i < accounts.length; i++) {
        myAccounts[i] = accounts[i].AccountName;
        shownAccountIds.add(accounts[i].AccountId);
    }
    myAccounts[accounts.length] = 'Total';
}

function getAmounts() {

    var net = 0.0;
    for (var i = 0; i < accounts.length; i++) {
        myAmounts[i] = accounts[i].Balance;
        if (accounts[i].AccountTypeId == accountTypeIds[2]) {
            net -= accounts[i].Balance;
        } else {
            net += accounts[i].Balance;
        }
    }
    
    myAmounts[accounts.length] = net;
}

function getColors() {

    for (var i = 0; i < accounts.length; i++) {
        if (accounts[i].AccountTypeId == accountTypeIds[2]) {
            myColors[i] = yellow;
        } else {
            myColors[i] = purple;
        }
    }
    if (myAmounts[accounts.length] >= 0) {
        myColors[accounts.length] = green;
    } else {
        myColors[accounts.length] = gray;
    }
}

var config = {
    type: 'bar',
    data: {
        labels: myAccounts,
        datasets: [{
            data: myAmounts,
            backgroundColor: myColors,
            borderColor: myColors,
            borderWidth: 1
        }]
    },
    options: {
        legend: {
            display: false
        },
        title: {
            display: true,
            text: 'My Accounts'
        },
        scales: {
            yAxes: [{
                ticks: {
                    beginAtZero: true,
                    callback: function (value, index, values) {
                        return '$ ' + value;
                    }
                }
            }], xAxes: [{
                gridLines: {
                    color: 'white'
                },
                barPercentage: 0.5
            }]
        }, tooltips: {
            callbacks: {
                label: function (tooltipItem, data) {
                    return "$ " + tooltipItem.yLabel.toFixed(2);
                }
            }
        }
    }
}

window.onload = function () {
    //Get and organize data
    getAccounts();
    getAmounts();
    getColors();

    handleToggle();

    var ctx = document.getElementById('myChart').getContext('2d');
    window.myChart = new Chart(ctx, config);
}

function handleToggle() {
    for (var i = 0; i < accounts.length; i++) {
        var id = '#' + accounts[i].AccountId;
        $(id).click(function () {
            var isChecked = $('#' + this.id).is(":checked");
            console.log(shownAccountIds);
            if (!isChecked) {
                var hideId = parseInt(this.id);
                shownAccountIds.delete(hideId);
            } else {
                var showId = parseInt(this.id);
                shownAccountIds.add(showId);
            }

            console.log(shownAccountIds);

            filterBarChart();


            window.myChart.update();
        })
    }
}

function filterBarChart() {

    myAccounts.splice(0, myAccounts.length);
    var index = 0;

    for (var i = 0; i < accounts.length; i++) {
        if (shownAccountIds.has(accounts[i].AccountId)) {
            myAccounts[index++] = accounts[i].AccountName;
        }
    }
    myAccounts[index] = 'Total';

    getFilteredAmounts();
    getFilteredColors();
}

function getFilteredAmounts() {
    myAmounts.splice(0, myAmounts.length);
    var index = 0;

    var net = 0.0;
    for (var i = 0; i < accounts.length; i++) {
        if (shownAccountIds.has(accounts[i].AccountId)) {
            myAmounts[index++] = accounts[i].Balance;
            if (accounts[i].AccountTypeId == accountTypeIds[2]) {
                net -= accounts[i].Balance;
            } else {
                net += accounts[i].Balance;
            }
        }
    }

    myAmounts[index] = net;
}

function getFilteredColors() {
    myColors.splice(0, myColors.length);
    var index = 0;

    for (var i = 0; i < accounts.length; i++) {
        if (shownAccountIds.has(accounts[i].AccountId)) {
            if (accounts[i].AccountTypeId == accountTypeIds[2]) {
                myColors[index++] = yellow;
            } else {
                myColors[index++] = purple;
            }
        }
    }

    if (myAmounts[myAmounts.length - 1] >= 0) {
        myColors[index] = green;
    } else {
        myColors[index] = gray;
    }
}