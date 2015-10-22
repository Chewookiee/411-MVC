$(document).ready(function () {
    var trigger = $('.hamburger'),
        overlay = $('.overlay'),
        isClosed = false;

    trigger.click(function () {
        hamburger_cross();
    });

    function hamburger_cross() {

        if (isClosed == true) {
            overlay.hide();
            trigger.removeClass('is-open');
            trigger.addClass('is-closed');
            isClosed = false;
        } else {
            overlay.show();
            trigger.removeClass('is-closed');
            trigger.addClass('is-open');
            isClosed = true;
        }
    }

    $('[data-toggle="offcanvas"]').click(function () {
        $('#wrapper').toggleClass('toggled');
    });


    /* Individual Beer Palate Sliders */
    $('#flat-slider1').slider({
        orientation: 'horizontal',
        min: 0,
        max: 100,
        value: 30,
        disabled: true,

    });
    var sliderValue = $('#flat-slider1').slider('value');
    $('#slider-value1').val(sliderValue);

    $('#flat-slider2').slider({
        orientation: 'horizontal',
        min: 0,
        max: 100,
        value: 40,
        disabled: true,

    });
    var sliderValue = $('#flat-slider2').slider('value');
    $('#slider-value2').val(sliderValue);

    var numReviewSlider = $('.review-slider').length;

    for (var i = 0; i < numReviewSlider; i++) {
        $('#review-slider' + i).slider({
            min: 0,
            max: 100,
            slide: function (event, ui) {
                $('#review-slider-value' + i).val(ui.value);
            }
        });
    }




    /* Like and Dislike Buttons*/
    if ($('#btn-like').data('active') == 1) {
        $('#btn-like').children('i').removeClass('fa-thumbs-o-up');
        $('#btn-like').children('i').addClass('fa-thumbs-up');
    }

    if ($('#btn-dislike').data('active') == 1) {
        $('#btn-dislike').children('i').removeClass('fa-thumbs-o-down');
        $('#btn-dislike').children('i').addClass('fa-thumbs-down');
    }

    /* Review Modal */
    /*$('.review-btn').on('click', function () {
        ('#review-modal').modal('show');    
    });*/
});

$('#btn-dislike').on('click', function () {
    DislikeBeer();
});
$('#btn-like').on('click', function () {
    LikeBeer();

});






function LikeBeer() {
    var btnLikeData = $('#btn-like').data('active');
    var btnDislikeData = $('#btn-dislike').data('active');


    if (btnLikeData == 1) {
        $('#btn-like').attr('data-active', 0);
        $('#btn-like').children('i').removeClass('fa-thumbs-up');
        $('#btn-like').children('i').addClass('fa-thumbs-o-up');
        btnLikeData = 0;
    }
    else {
        $('#btn-dislike').children('i').removeClass('fa-thumbs-down');
        $('#btn-dislike').children('i').addClass('fa-thumbs-o-down');
        $('#btn-dislike').attr('data-active', 0);
        btnDislikeData = 0;

        $('#btn-like').attr('data-active', 1);
        $('#btn-like').children('i').removeClass('fa-thumbs-o-up');
        $('#btn-like').children('i').addClass('fa-thumbs-up');
        btnLikeData = 1;
    }
}

function DislikeBeer() {
    var btnLikeData = $('#btn-like').data('active');
    var btnDislikeData = $('#btn-dislike').data('active');

    if (btnDislikeData == 1) {
        $('#btn-dislike').attr('data-active', 0);
        $('#btn-dislike').children('i').removeClass('fa-thumbs-down');
        $('#btn-dislike').children('i').addClass('fa-thumbs-o-down');
    }
    else {
        $('#btn-like').children('i').removeClass('fa-thumbs-up');
        $('#btn-like').children('i').addClass('fa-thumbs-o-up');
        $('#btn-like').attr('data-active', 0);

        $('#btn-dislike').attr('data-active', 1);
        $('#btn-dislike').children('i').removeClass('fa-thumbs-o-down');
        $('#btn-dislike').children('i').addClass('fa-thumbs-down');
    }
}