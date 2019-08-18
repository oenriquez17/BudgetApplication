// blue -> checkings, savings
var blue = 'rgba(54, 162, 235, 1)';
// red -> credit cards
var red = 'rgba(224, 30, 30, 1)';

// green -> postive net total
var green = 'rgba(63, 191, 63, 1)';
// black -> negative net total
var black = 'rgba(0, 0, 0, 1)';

var accounts = [];
var amounts = [];
var colors = [];

function getAccounts() {

    for (var i = 0; i < accs.length; i++) {
        accounts[i] = accs[i].AccountName;
    }
    accounts[accs.length] = 'Total';
}

function getAmounts() {

    var net = 0.0;
    for (var i = 0; i < accs.length; i++) {
        amounts[i] = accs[i].Balance;
        if (accs[i].AccountTypeId == accTypesId[2]) {
            net -= accs[i].Balance;
        } else {
            net += accs[i].Balance;
        }
    }
    
    amounts[accs.length] = net;
}

function getColors() {

    for (var i = 0; i < accs.length; i++) {
        if (accs[i].AccountTypeId == accTypesId[2]) {
            colors[i] = red;
        } else {
            colors[i] = blue;
        }
    }
    if (amounts[accs.length] >= 0) {
        colors[accs.length] = green;
    } else {
        colors[accs.length] = black;
    }
}

var config = {
    type: 'bar',
    data: {
        labels: accounts,
        datasets: [{
            data: amounts,
            backgroundColor: colors,
            borderColor: colors,
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
                    beginAtZero: true
                }
            }], xAxes: [{
                gridLines: {
                    color: 'white'
                },
                barPercentage: 0.4
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

    var ctx = document.getElementById('myChart').getContext('2d');
    var myChart = new Chart(ctx, config);
}