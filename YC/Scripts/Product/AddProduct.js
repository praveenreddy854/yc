$.ready(function () {
    debugger;
    var self = this;

    self.ProductName = "";
    self.Categories = [];
    $.ajax({
        url: currentDomain + "/Category/GetAllCategories", async: false, complete: function (data) {

            $.each(data, function (t, d) {
                self.Categories.push(d);
                var optionHtml = "<option id='" + d.Id + "'>" + d.Name + "</option>";
                $("#categories").append(optionHtml);
            });
        }
    });
    self.SelectedCategory = "";
    self.ImgUrl = "";
    self.AmazonUrl = "";
    self.AmazonPrice = "";
    self.PaytmUrl = "";
    self.PaytmPrice = "";

    $("#submit").click(function () {
        self.ProductName = $("#productname").text();
        self.SelectedCategory = $("#categories option:selected").Id;
        self.ImgUrl = $("#imgurl").text();
        self.AmazonUrl = $("#amzurl").text();
        self.AmazonPrice = $("#amzprice").text();
        self.PaytmUrl = $("#paytmurl").text();
        self.PaytmPrice = $("#paytmprice").text();

        $.post("Product/CreateNewProduct", { self }, function (data) {
            if (data == true) {
                alert('Succesfully added product');
            }
            else {
                alert('Something went wrong. Try again.');
            }
            
        });
    });

});
