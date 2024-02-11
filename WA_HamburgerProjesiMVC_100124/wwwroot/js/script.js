
function ListDesserts() {
    $.ajax({
        url: "/Home/GetDesserts",
        type: "get",
        success: function (response) {
            $("#mainContainer").html(response);
            $("#error").html("");
        },
        error: function () {
            $("#error").html("<h2>Something went wrong</h3>");
        }
    });

}

function ListMenus() {
    $.ajax({
        url: "/Home/GetMenus",
        type: "get",
        success: function (response) {
            $("#mainContainer").html(response);
            $("#error").html("");

        },
        error: function () {
            $("#error").html("<h2>Something went wrong</h3>");
        }

    });
}
function ListSnacks() {
    $.ajax({
        url: "/Home/GetSnacks",
        type: "get",
        success: function (response) {
            $("#mainContainer").html(response);
            $("#error").html("");

        },
        error: function () {
            $("#error").html("<h2>Something went wrong</h3>");
        }

    });
}

function ListDrinks() {
    $.ajax({
        url: "/Home/GetDrinks",
        type: "get",
        success: function (response) {
            $("#mainContainer").html(response);
            $("#error").html("");

        },
        error: function () {
            $("#error").html("<h2>Something went wrong</h3>");
        }

    });

}

function GetProducts() {
    $.ajax({
        url: "/Home/AddProductToCard",
        type: "get",
        success: function (response) {
            $("#mainContainer").html(response);
            $("#error").html("");

        },
        error: function () {
            $("#error").html("<h2>Something went wrong</h3>");
        }

    });

}

