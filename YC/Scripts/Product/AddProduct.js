(function (AddProduct, undefined) {
    'use strict';

    AddProduct.BaseForm = function () {

        var self = this;

        self.ProductName = ko.observable("");
        self.Categories = ko.observableArray([]);
        $.ajax({
            url: currentDomain + "/Category/GetAllCategories", async: false, complete: function (data) {

                self.Categories(JSON.parse(data.responseText));
                console.log(data);
            }
        });

        self.ImgUrl = ko.observable("");
        self.AmazonUrl = ko.observable("");
        self.AmazonPrice = ko.observable("");
        self.PaytmUrl = ko.observable("");
        self.PaytmPrice = ko.observable("");

        self.AddProduct = function () {
            var x = self.ProductName();
            var y = self.Categories();
        };

        return self;

    };
    window.AddProduct = AddProduct;
})(window.AddProduct || {});