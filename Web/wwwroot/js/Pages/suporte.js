var suporte = (function () {
    var configs = {
        urls: {
            realizarSuporte: '',
            viewHome: ''
        },
    };

    var init = function ($configs) {
        configs = $configs;
    };

    var realizarSuporte = function () {
        model = $('#suporteForm').serializeObject();

        $.post(configs.urls.realizarSuporte, model).done(function () {
            location.href = configs.urls.viewHome;
        }).fail(function (msg) {
            console.log(msg);
        });
    };

    return {
        init: init,
        realizarSuporte: realizarSuporte
    }
})()