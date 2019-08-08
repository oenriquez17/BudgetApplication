// blue -> checkings, savings
var blue = 'rgba(54, 162, 235, 1)';
// green -> postive net total
var green = 'rgba(63, 191, 63, 1)';
// red -> negative net total
var red = 'rgba(224, 30, 30, 1)';

function getAccounts() {
    var accounts = [];
    for (var i = 0; i < accs.length; i++) {
        accounts[i] = accs[i].AccountName;
    }
    accounts[accs.length] = 'Total';
    return accounts;
}

function getAmmounts() {
    var ammounts = [];
    var net = 0.0;
    for (var i = 0; i < accs.length; i++) {
        ammounts[i] = accs[i].Balance;
        net += accs[i].Balance;
    }
    ammounts[accs.length] = net;
    return ammounts;
}

var config = {
    type: 'bar',
    data: {
        labels: getAccounts(),
        datasets: [{
            data: getAmmounts(),
            backgroundColor: [
                blue,
                green
            ],
            borderColor: [
                blue,
                green
            ],
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
    console.log(accs);
    var ctx = document.getElementById('myChart').getContext('2d');
    var myChart = new Chart(ctx, config);
}