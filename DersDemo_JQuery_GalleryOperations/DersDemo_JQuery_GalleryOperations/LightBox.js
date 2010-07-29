
function LightBox(selector) {
    $('<div id="lbBack" title="çıkış için tıklayınız"></div><div id="lbContainer"><div id="lbImage"><img id="iImage" /></div></div>')
            .appendTo(document.body);
    $("#lbBack").css({ display: 'none',
        position: 'fixed',
        left: 0,
        top: 0,
        right: 0,
        bottom: 0,
        background: 'black',
        zIndex: 10,
        opacity: 0.7
    });
    $("#lbContainer").css({
        display: 'none',
        position: 'fixed',
        left: 0,
        top: 0,
        right: 0,
        bottom: 0,
        zIndex: 20,
        background: 'transparent'
    });
    $("#lbContainer #lbImage").css({
        width: 400,
        padding: 10,
        margin: '50px auto 0 auto',
        background: 'white'
    });

    $(selector).click(function() {
        $("#lbBack,#lbContainer").show();
        $("#lbContainer #lbImage #iImage")
                    .attr("src", $(this).attr("src"))
                    .width($("#lbContainer #lbImage #iImage").width() / 2)
                    .click(function() { window.location = $(this).attr("src"); });
        $("#lbContainer #lbImage").width($("#lbContainer #lbImage #iImage").width());
    });
    $("#lbBack, #lbContainer")
        .click(function() {
            $("#lbBack,#lbContainer").hide();
            $("#lbContainer #lbImage #iImage").width("auto");
        });

}
