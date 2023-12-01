var home = (function () {
    var configs = {
        urls: {
            viewEditarDenuncia: '',
            fecharDenuncia: '',
            viewHome: '',
            editarDenuncia: '',
            viewConfirmacaoFecharDenuncia: ''
        },
    };

    var init = function ($configs) {
        configs = $configs;
    };

    var fecharDenuncia = function (id) {
        var model = { Id: id };

        $.post(configs.urls.fecharDenuncia, model).done(() => {
            window.location.href = '/Home/Index';
        })
    }
    var viewConfirmacaoFecharDenuncia = function (id) {

        $.get(configs.urls.viewConfirmacaoFecharDenuncia).done(function (html) {
            $(".container-geral").hide();
            $(".container-batata").html(html);
            $(".container-batata").show();
        })
    }

    var viewEditarDenuncia = function (id) {
        $.get(configs.urls.viewEditarDenuncia, { id: id }).done(function (html) {
            $(".container-geral").hide();
            $(".confirmacao-fechar-denuncia").html(html);
            $(".confirmacao-fechar-denuncia").show();
        })
    };

    var editarDenuncia = function () {
        var model = $("#editarDenuncia").serializeObject();

        $.post(configs.urls.editarDenuncia, model).done(() => {
            location.href = configs.urls.viewHome;
        }).fail(function () {
            console.log("deu ruim");
        })
    }


    return {
        init: init,
        fecharDenuncia: fecharDenuncia,
        viewEditarDenuncia: viewEditarDenuncia,
        editarDenuncia: editarDenuncia,
        viewConfirmacaoFecharDenuncia: viewConfirmacaoFecharDenuncia
    }
})()

