
var Uri = '/api/cities/';
$(document).ready(function () {
    ajaxHelper(Uri, 'GET').done(function (data) {
        
        $(data).each(function (i, item) {
            $('#contacts').append('<li>' + item.Name + '</li>');
        });
    })
})

function ajaxHelper(uri, method, data) {
    
    return $.ajax({
        type: method,
        url: uri,
        dataType: 'json',
        contentType: 'application/json',
        data: data ? JSON.stringify(data) : null
    }).fail(function (jqXHR, textStatus, errorThrown) {
        alert(errorThrown);
    });
}

$('#saveContact').click(function () {
    debugger;
    
    ajaxHelper(Uri, 'POST', $("#saveContactForm").serialize()).done(function (data)
    { })
})
    //$.post(Uri,
    //      $("#saveContactForm").serialize(),
    //      function (value) {
    //          $('#contacts').append('<li>' + value.Name + '</li>');
    //      },
    //      "json"
    //);


