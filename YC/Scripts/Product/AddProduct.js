$(document).ready(function () {
    var self = this;

    self.ProductName = "";
    self.Categories = [];
    $.ajax({
        url: "/Category/GetAllCategories", success: function (result) {
            console.log(result);
            var data = JSON.parse(result).Data;
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
        self.ProductName = $("#productname").val();
        self.SelectedCategory = $("#categories option:selected")[0].id;
        self.ImgUrl = $("#imgurl").val();
        self.AmazonUrl = $("#amzurl").val();
        self.AmazonPrice = $("#amzprice").val();
        self.PaytmUrl = $("#paytmurl").val();
        self.PaytmPrice = $("#paytmprice").val();

        var paramObject = JSON.stringify(self);

        $.ajax("Product/CreateNewProduct", {
            data: { prod: paramObject },
            success: function (data) {
                if (data == true) {
                    alert('Succesfully added product');
                }
                else {
                    alert('Something went wrong. Try again.');
                }

            }
        });
    });

});
