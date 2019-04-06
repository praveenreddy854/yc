$(document).ready(function () {
    var self = this;

    self.ProductName = "";
    self.Categories = [];
    $.ajax({
        url: currentDomain+"/Category/GetAllCategories", success: function (result) {
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

        $.post(currentDomain + "/Product/CreateNewProduct",
            {
                ProductName: self.ProductName,
                ImgUrl: self.ImgUrl,
                SelectedCategory: self.SelectedCategory,
                AmazonUrl: self.AmazonUrl,
                AmazonPrice: self.AmazonPrice,
                PaytmUrl: self.PaytmUrl,
                PaytmPrice: self.PaytmPrice
            },
            function (data) {
                if (data == true) {
                    alert('Succesfully added product');
                }
                else {
                    alert('Something went wrong. Try again.');
                }
        }, );
    });

});
