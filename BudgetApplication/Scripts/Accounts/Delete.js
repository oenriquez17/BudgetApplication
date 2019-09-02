$(document).ready(function () {
    $("#accountsTable .js-delete").on("click", function () {
        var button = $(this);
        if (confirm("Are you sure you want to delete this account?")) {
            $.ajax({
                url: "/api/accounts/" + button.attr("data-account-id"),
                method: "DELETE",
                success: function () {
                    button.parents("tr").remove();
                }
            })
        } else {
            button.blur();
        }
    });
});