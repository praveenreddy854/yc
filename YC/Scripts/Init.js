var divs = document.querySelectorAll("[data-context]");
var functioname = "";
var currentDomain = window.location.hash;
$.each(divs, function (index, div) {
    var functioname = div.getAttribute("data-context");
    if (functioname) {
        var self = eval(functioname);

        var children = div.getElementsByTagName("*");
        var targetChildren = [];
        Object.assign(targetChildren, children);
        $.each(targetChildren, function (index, child) {
            var customAttr = child.getAttribute("data-bind");
            var role = child.getAttribute("data-role");
            CustomBind(customAttr, child, role, self);

            //});

            return;
        });
    }
    //ko.applyBindings(data);
});

function CustomBind(customAttr, child, role, self) {

    if (customAttr) {
        var attrs = customAttr.split(',');
        $.each(attrs, function (index2, attr) {
            if (attr) {
                var fullAttr = attr.split(':');
                switch (role) {
                    case 'input':
                        child.setAttribute(fullAttr[0].trim(), eval(fullAttr[1].trim().replace('$data', 'self')));
                        AddInputChangedEvent(fullAttr[1].trim(), child);
                        break;
                    case 'dropdown':
                        var items = eval(fullAttr[0].trim().replace('$data', 'self'));

                        $.each(items, function (index3, item) {
                            var option = '<option value="' + item + '">' + item + '</option>';
                            $(child).append(option);
                        });
                        break;
                    case 'submit':
                        child.setAttribute(fullAttr[0].trim(), eval(fullAttr[1].trim().replace('$data', 'self')));
                        break;
                    default:
                        break;

                }
            }

        });
    }

}

function AddInputChangedEvent(name, element) {
    var isOnChnagedExists = element.getAttribute('onchange');
    if (!isOnChnagedExists)
        return;
    element.setAttribute('onchange', 'InputChanged(this)');
}

function InputChanged(elemenet) {
    elemenet.getAttribute("data-bind");
    var attrs = customAttr.split(',');
    $.each(attrs, function (index2, attr) {
        if (!attr.contains('value')) {
            continue;
        }
        var fullAttr = attr.split(':');
        var functionNameOnly = fullAttr[1].trim().split('(');
        var functionNameWithData = functionNameOnly + '(' + elemenet.getAttribute('value') + ')';
        eval(functionNameWithData.replace('$data', 'self'));
        console.log(elemenet);

    })
}