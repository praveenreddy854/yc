$.ready(function () {
    var divs = document.getElementsByTagName("div");
    var functioname = "";

    $.each(divs, function (index, div) {
        var functioname = div.getAttribute("data-context");

        eval(functioname);
    })
})