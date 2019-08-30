for (var i = 0; i < transactions.length; i++) {
    console.log(ToJavaScriptDate(transactions[i].DateOfTransaction));
}

function ToJavaScriptDate(value) {
    var pattern = /Date\(([^)]+)\)/;
    var results = pattern.exec(value);
    var dt = new Date(parseFloat(results[1]));
    return (dt.getMonth() + 1) + "/" + dt.getDate() + "/" + dt.getFullYear();
}