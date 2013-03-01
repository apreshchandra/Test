$(document).ready(function () {

    $("#tos").fancybox({
    	'titlePosition': 'inside',
    	'modal': 'true',
    	'transitionIn': 'none',
    	'transitionOut': 'none'
    });
});

function ToS_Agree() {
    $('#SubmitButton').removeAttr('disabled');
    $.fancybox.close();
}

function ToS_NotAgree() {
    $('#SubmitButton').attr('disabled', 'disabled');
    $.fancybox.close();
}		