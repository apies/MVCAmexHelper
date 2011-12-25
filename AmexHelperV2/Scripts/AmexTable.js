//$("#main #jtable tbody tr").click(function () {
 //   $(this).toggleClass('hoverHighlight');
//});

//$(function () { alert($('#jtable tbody tr').length); });

$(document).ready(function () {
    $('#main #jtable tbody tr').click(function () {
        $(this).toggleClass('hoverHighlight');
    });

    $('#reportsListAll > div').hide();

    $('#reportsListAll h3').click(function () {
        $(this).next().animate(
	    { 'height': 'toggle' }, 'slow', 'easeOutBounce'
    );
    });



});


//$(document).ready(function () {
//    $('#main #jtable tbody tr:even').css('background-color', '#dddddd');
//});

//$(document).ready(function () {
//    $('#main h1').css('background-color', '#dddddd');
//});