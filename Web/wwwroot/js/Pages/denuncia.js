var denuncia = (function () {
    var configs = {
        urls: {
            cadastrarDenuncia: '',
            viewGraficos: '',
            fecharDenuncia: '',
            viewEditarDenuncia: ''
        },
    };

    var init = function ($configs) {
        configs = $configs;
    };

    var cadastrarDenuncia = function () {
        var model = {
            idCategoria: $('#categorias').val(),
            // idSubcategoria: $('#subcategorias').val(),
            idBairro: $('#bairros').val(),
            data: $('#cadastrarDenuncia input[name="data"]').val(),
            descricao: $('#cadastrarDenuncia textarea[name="Descricao"]').val()
        };
        $.post(configs.urls.cadastrarDenuncia, model).done(() => {
            window.location.href = '/Grafico/Index';
        });
        console.log(model);
    };

    var fecharDenuncia = function (id) {
        var model = { Id: id };

        $.post(configs.urls.fecharDenuncia, model).done(() => {
            window.location.href = '/Home/Index';
        })
    }

    var viewEditar = function () {
        $.get(configs.urls.viewEditarDenuncia).done(function () {
            location.href = configs.urls.viewEditarDenuncia;
        })
    };

    $("#categorias").on('change', function () {
        // armazena o id da categoria atual
        var idCategoria = $(this).val();
        // armazena o id da da subcategoria atual
        var idCategoriaPai = $("#subcategorias").val();

        // $("#subcategorias option").hide();
        // $("#subcategorias option[data-categoria='" + idCategoria + "']").show();

        $("#subcategorias option").each(function () {
            if (idCategoria == idCategoriaPai) {
                console.log("teste");
            }
            // var id = $(this).val();
            // var nome = $(this).text();
            // idSubCategorias.push({
            //     id: id,
            //     nome: nome
            // });
        })

        // console.log(idCategoriaPai);

        // $.each(subCategorias, function () {
        //     if (idSubCategorias == this.id) {
        //         $("#subcategorias").append('<option value="' + this.id + '">' + this.nome + '</option>');
        //     } else {

        //     }
        // })
    });

    return {
        init: init,
        cadastrarDenuncia: cadastrarDenuncia,
        fecharDenuncia: fecharDenuncia,
        viewEditar: viewEditar
    }
})()