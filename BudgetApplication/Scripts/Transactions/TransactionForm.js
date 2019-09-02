$(document).ready(function () {

    //Add this line to a onSubmit code
    $('#transactionForm').trigger("reset");

    $('#primaryAccountDropdown').change(function () {
        var selected = $('#primaryAccountDropdown option:selected').val();
        var selectedAccount = accounts.find(function (acc) {
            return acc.AccountId == selected;
        });
        if (selectedAccount != null) {
            // show balance on selection
            $('#balanceContainer').removeClass('hidden');

            //show comment
            $('#commentField').removeClass('hidden');

            //show date
            $('#dateField').removeClass('hidden');

            //show debit/credit dropdown
            $('#balanceText').empty();
            $('#balanceText').append('$ ' + selectedAccount.Balance.toFixed(2));

            if (selectedAccount.AccountType.AccountTypeId == creditCard) {
                $('#creditActionForm').removeClass('hidden');
                $('#debitActionForm').addClass('hidden');
            } else {
                $('#debitActionForm').removeClass('hidden');
                $('#creditActionForm').addClass('hidden');
            }

            $('#amountField').removeClass('hidden');
        } else {
            $('#balanceContainer').addClass('hidden');
            $('#commentField').addClass('hidden');
            $('#dateField').addClass('hidden');
            $('#amountField').addClass('hidden');
            $('#creditActionForm').addClass('hidden');
            $('#debitActionForm').addClass('hidden');
        }
    });

    $('#debitTransactionDropdown').change(function () {
        var selected = $('#debitTransactionDropdown option:selected').val();
        if (selected == transferId) {
            // show balance on selection
            $('#targetAccountTransfer').removeClass('hidden');
        } else {
            $('#targetAccountTransfer').addClass('hidden');
        }
    });

});