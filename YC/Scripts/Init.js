
var divs = document.getElementsByTagName("div");
var functioname = "";
var currentDomain = window.location.hash;
$.each(divs, function (index, div) {
    var functioname = div.getAttribute("data-context");
    if (functioname) {
      eval(functioname);

        //var children = div.getElementsByTagName("*");
        //$.each(children, function (index, child) {
        //    var attr = child.getAttribute("data-bind").split(':');
        //    if (attr) {
        //        child.setAttribute(attr[0].trim(), eval(attr[1].trim()));
        //    }
            
        //});
        
        return;
    }
    //ko.applyBindings(data);
});
