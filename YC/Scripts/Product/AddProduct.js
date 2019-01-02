(function (AddProduct, undefined) {
    'use strict';

    AddProduct.BaseForm = function () {
        
        var self = this;

        self.ProductName = ko.observable("ABCD");
        self.Categories = ko.observableArray([]);

        $.get(currentDomain+"/Category/GetAllCategories", function (data) {

            self.Categories = data;
        });
        self.ImgUrl = ko.observable("cjncsakjd");
        self.AmazonUrl = ko.observable("");
        self.AmazonPrice = ko.observable("");
        self.PaytmUrl = ko.observable("");
        self.PaytmPrice = ko.observable("");

        ko.cleanNode(self);
        ko.applyBindings(self);

    };

    window.AddProduct = AddProduct;
})(window.AddProduct || {});