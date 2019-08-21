// purple -> checkings, savings
var purple = 'rgba(167, 138, 212, 1)';
// yellow -> credit cards
var yellow = 'rgba(222, 189, 82, 1)';

// green -> postive net total
var green = 'rgba(95, 221, 125, 1)';
// gray -> negative net total
var gray = 'rgba(183, 189, 184, 1)';

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
            colors[i] = yellow;
        } else {
            colors[i] = purple;
        }
    }
    if (amounts[accs.length] >= 0) {
        colors[accs.length] = green;
    } else {
        colors[accs.length] = gray;
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
    for (var i = 0; i < accs.length; i++) {
        var id = '#' + accs[i].AccountId;
        $(id).click(function () {
            var isChecked = $('#' + this.id).is(":checked");

            if (!isChecked) {
                var index = findIndex(this.id);

                filterAccounts(index);

                window.myChart.update();
            } else {
                
                getAccounts();
                getAmounts();
                getColors();

                console.log(amounts);

                window.myChart.update();
            }
            //window.myChart.update();
        })
    }
}

function findIndex(id) {
    for (var i = 0; i < accs.length; i++) {
        if (accs[i].AccountId == id) {
            return i;
        }
    }
    return -1;
}

function filterAccounts(index) {
    accounts.splice(index, 1);
    amounts.splice(index, 1); //recalculate
    colors.splice(index, 1); //recalculate
}