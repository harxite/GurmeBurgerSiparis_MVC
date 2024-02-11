    if (typeof console === "undefined" || typeof console.log === "undefined") {
        console = { log: function(){} };
    }

    $('#full-width-slider').fullWidth({
        minHeight:1040,
        maxHeight:1040,
    })
    
    $('#full-width-header').fullWidth({
        minHeight:560,
        maxHeight:560
    })


