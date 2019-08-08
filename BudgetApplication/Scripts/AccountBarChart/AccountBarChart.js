﻿function getAccounts() {
    var accounts = [];
    for (var i = 0; i < accs.length; i++) {
        accounts[i] = accs[i].AccountName;
    }
    return accounts;
}

function getAmmounts() {
    var ammounts = [];
    for (var i = 0; i < accs.length; i++) {
        ammounts[i] = accs[i].Balance;
    }
    return ammounts;
}

var config = {
    type: 'bar',
    data: {
        labels: getAccounts(),
        datasets: [{
            data: getAmmounts(),
            backgroundColor: [
                'rgba(255, 99, 132, 0.2)',
                'rgba(54, 162, 235, 0.2)',
                'rgba(255, 206, 86, 0.2)',
                'rgba(75, 192, 192, 0.2)',
                'rgba(153, 102, 255, 0.2)',
                'rgba(255, 159, 64, 0.2)'
            ],
            borderColor: [
                'rgba(255, 99, 132, 1)',
                'rgba(54, 162, 235, 1)',
                'rgba(255, 206, 86, 1)',
                'rgba(75, 192, 192, 1)',
                'rgba(153, 102, 255, 1)',
                'rgba(255, 159, 64, 1)'
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
                barPercentage: 0.4
            }]
        }, tooltips: {
            callbacks: {
                label: function (tooltipItem, data) {
                    var label = 'Trying something';
                    var add = data.labels[tooltipItem.datasetIndex];
                    return label + ' ' + add;
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