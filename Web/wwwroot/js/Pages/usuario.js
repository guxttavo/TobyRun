var usuario = (function () {
    var configs = {
        urls: {
            viewCadastrar: '',
            viewListar: '',
            viewEditar: '',
            cadastrarUsuario: '',
            deletarUsuario: '',
            editarUsuario: '',
            realizarLogin: ''
        },
    };

    var init = function ($configs) {
        configs = $configs;
    };

    var viewCadastrar = function () {
        $.get(configs.urls.viewCadastrar).done(function (html) {
            $(".container-listar").hide();
            $(".container-cadastrar").html(html);
            $(".container-cadastrar").show();
            // window.location.href = configs.urls.viewCadastrar;
        })
    };

    var viewEditar = function (id) {
        console.log(id);
        $.get(configs.urls.viewEditar, { id: id }).done(function (html) {
            $(".container-listar").hide();
            $(".container-editar").html(html);
            $(".container-editar").show();
        })
    };

    var viewListar = function () {
        $.get(configs.urls.viewListar).done(function (html) {
            location.href = configs.urls.viewListar;
        })
    }

    var cadastrarUsuario = function () {
        var model = $('#cadastroUsuario').serializeObject();

        console.log(model);

        // var cpflimpo = model.cpf.replace(/[^0-9]/g, '');
        // var ceplimpo = model.cep.replace(/[^0-9]/g, '');

        // model.cpf = cpflimpo;
        // model.cep = ceplimpo;

        $.post(configs.urls.cadastrarUsuario, model).done(function (html) {
            location.href = configs.urls.viewListar;
        })
    };

    var excluir = function (id) {
        var model = { Id: id };

        $.post(configs.urls.deletarUsuario, model).done(() => {
            viewListar();
        })
    }

    var editarUsuario = function () {
        var model = $("#editarUsuario").serializeObject();

        $.post(configs.urls.editarUsuario, model).done(() => {
            location.href = configs.urls.viewListar;
        }).fail(function () {
            console.log("deu ruim");
        })
    }

    var logar = function () {
        console.log("Hello there!");
    }

    return {
        init: init,
        viewCadastrar: viewCadastrar,
        cadastrarUsuario: cadastrarUsuario,
        viewListar: viewListar,
        excluir: excluir,
        editarUsuario: editarUsuario,
        viewEditar: viewEditar,
        logar: logar
    }
})()