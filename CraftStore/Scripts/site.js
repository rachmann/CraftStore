// document ready
$(function () {

    var ajaxPriceFilter = function () {

        var $form = $(this);

        var options = {
            url: $form.attr("action"),
            type: $form.attr("method"),
            data: { filterCategory: this.elements.filterCategory.value, filterLowPrice: this.elements.filterLowPrice.value, filterHighPrice: this.elements.filterHighPrice.value }
        };

        $.ajax(options).done(function (data) {
            var $target = $($form.attr("data-filter-target"));
            var $newHtml = $(data);
            $target.replaceWith($newHtml);
            $newHtml.effect("highlight");
        });

        return false;
    };

      // Menu settings
    $('#menuToggle, .menu-close').on('click', function() {
        $('#menuToggle').toggleClass('active');
        $('body').toggleClass('body-push-toleft');
        $('#theMenu').toggleClass('menu-open');
    });

    $("form[data-pf-ajax='true']").submit(ajaxPriceFilter);

 
});