$(function () {
    console.log("fn");
    var PlaceHolderElement = $('#PlaceHolderHere');
    $('button[data-toggle="ajax-modal"]').click(function (event) {
        var url = $(this).data('url');
        var decodedUrl = decodeURIComponent(url);
        $.get(decodedUrl).done(function (data) {
            PlaceHolderElement.html(data);
            PlaceHolderElement.find('.modal').modal('show');
            console.log("clicked");
        })
    })

    PlaceHolderElement.on('click', '[data-save="modal"]', function (event) {
        var form = $(this).parents('.modal').find('form');
        var actionUrl = form.attr('action');
        var sendData = form.serialize();
        console.log(sendData);
        $.post(actionUrl, sendData).done(function (data) {
            //alert('posted');
            PlaceHolderElement.find('.modal').modal('hide');
            location.reload(true);
        })
    })
})

