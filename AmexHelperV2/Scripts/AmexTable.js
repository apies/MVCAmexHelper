//$("#main #jtable tbody tr").click(function () {
 //   $(this).toggleClass('hoverHighlight');
//});

//$(function () { alert($('#jtable tbody tr').length); });

$(document).ready(function () {
    
    // this function highlights rows in table by clicking
    $('#main #jtable tbody tr').click(function () {
        $(this).toggleClass('hoverHighlight');
    });

    
    //these two functions are important for the expense report admin list
    $('#reportsListAll > div').hide();

    $('#reportsListAll h3').next().hide();

    $('#reportsListAll h3').click(function () {
        $(this).next().animate(
	    { 'height': 'toggle' }, 'slow', 'easeOutBounce'
    );
    });



   // $('#reportsListAll > div').hide();



  


});


//$(document).ready(function () {
//    $('#main #jtable tbody tr:even').css('background-color', '#dddddd');
//});

//$(document).ready(function () {
//    $('#main h1').css('background-color', '#dddddd');
//});