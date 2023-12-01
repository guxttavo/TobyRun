var graficos = (function () {
  var configs = {
    urls: {
      QtdDenunciasPorBairro: '',
      QtdDenunciasPorCategoria: '',
      QtdDenunciasPorCategoriaPorBairro: ''
    },
  };

  var init = function ($configs) {
    configs = $configs;

    // QTD DENUNCIA x BAIRRO
    $.get(configs.urls.QtdDenunciasPorBairro).done(function (data) {
      var bairros = [];
      data.forEach(function (data) {
        bairros.push(data.nome);
      });

      var denuncias = [];
      data.forEach(function (data) {
        denuncias.push(data.denuncias);
      })

      var qtdDenuncias = [];
      denuncias.forEach(function (subArray) {
        qtdDenuncias.push(subArray.length)
      });

      var colors = ['#138de9', '#138de9', '#138de9', '#138de9', '#138de9', '#138de9', '#138de9', '#138de9', '#138de9', '#138de9', '#138de9', '#138de9', '#138de9', '#138de9', '#138de9', '#138de9', '#138de9', '#138de9', '#138de9', 'transparent'];
      // bairrosBrabos = ["Mangabeira", "Valentina", "Bancários", "Cristo", "Manaíra", "Cruz das Armas", "Brisamar", "Altiplano", "Geisel", "José Américo", "Miramar", "Bessa", "Cabo Branco", "Bairro Das Industrias", "Castelo Branco", "Mandacaru", "Jaguaribe", "Centro", "Alto do Matheus"]
      var dados = {
        series: [{
          data: qtdDenuncias
        }],
        chart: {
          height: 550,
          width: 750,
          type: 'bar'
        },
        colors: colors,
        plotOptions: {
          bar: {
            columnWidth: '65%',
            distributed: true,
          }
        },
        dataLabels: {
          enabled: false
        },
        legend: {
          show: false
        },
        xaxis: {
          categories: bairros,
          labels: {
            style: {
              fontSize: '17px'
            }
          }
        },
        yaxis: {
          labels: {
            style: {
              fontSize: '15px'
            }
          },
          title: {
            text: "Quantidade de Denúncias",
            style: {
              fontSize: '16px'
            }
          },
          max: 100,
        },
      };

      var chart = new ApexCharts(document.querySelector("#qtdDenuncia-bairro"), dados);
      chart.render();
    })

    // QTD DENUNCIA x CATEGORIA
    $.get(configs.urls.QtdDenunciasPorCategoria).done(function (data) {
      console.log(data);
      var denuncias = [];
      data.forEach(function (data) {
        if (data.idCategoriaPai == null) {
          denuncias.push(data.denuncias);
        }
      })
      console.log(denuncias);

      var qtdDenuncias = [];
      denuncias.forEach(function (subArray) {
        qtdDenuncias.push(subArray.length)
      });

      var categorias = [];
      data.forEach(function (data) {
        if (data.idCategoriaPai == null) {
          categorias.push(data.nome)
        }
      });

      var colors = ['#26dfec', '#13d493', '#eba928', '#ec4e65', '#7862c4', 'transparent'];
      var jooj2 = ["Iluminação Pública", "Saneamento Básico", "Mobilidade Urbana", "Gestão de Resíduos", "Espaços Públicos"]
      var dados = {
        series: [{
          data: qtdDenuncias
          // data: jooj
        }],
        chart: {
          height: 550,
          width: 450,
          type: 'bar'
        },
        colors: colors,
        plotOptions: {
          bar: {
            columnWidth: '75%',
            barHeight: '100%',
            distributed: true,
            dataLabels: {
              position: "left",
              offsetX: 100, // Ajuste o valor de deslocamento para a direita
            }
          }
        },
        dataLabels: {
          enabled: false
        },
        legend: {
          show: false
        },
        xaxis: {
          categories: categorias,
          labels: {
            style: {
              fontSize: '17px'
            }
          }
        },
        yaxis: {
          labels: {
            style: {
              fontSize: '15px'
            }
          },
          title: {
            text: "Quantidade de Denúncias",
            style: {
              fontSize: '16px'
            }
          },
          max: 150,
        },
      };

      var chart = new ApexCharts(document.querySelector("#qtdDenuncia-categoria"), dados);
      chart.render();

    })

    // QTD DENUNCIA x CATEGORIA x BAIRRO
    $.get(configs.urls.QtdDenunciasPorCategoriaPorBairro).done(function (data) {
      var bairros = [];
      data.forEach(function (data) {
        bairros.push(data.nome);
      });

      var denuncias = [];
      data.forEach(function (data) {
        denuncias.push(data.denuncias);
      })

      var qtdDenuncias = [];
      denuncias.forEach(function (subArray) {
        qtdDenuncias.push(subArray.length)
      });

      var denunciasPorIluminacaoPublica = [];
      denuncias.forEach(function (elementoAtual, index, array) {
        elementoAtual.forEach(function (item) {
          if (item.categoria.nome == "Iluminação Pública" && item.idBairro == 1) {
            denunciasPorIluminacaoPublica.push(item.categoria);
          }
        });
      });

      var colors = ['#138de9', '#26dfec', '#13d493', '#eba928', '#ec4e65', '#7862c4', 'transparent'];
      var options = {
        series: [
          {
            name: 'Quantidade de Denuncias',
            data: qtdDenuncias
          },
          {
            name: 'Iluminação Pública',
            data: [5, 10, 12, 5, 4, 3, 4, 2, 3, 6, 2, 12, 23, 6, 7, 11]
          },
          {
            name: 'Saneamento Básico',
            data: [13, 3, 8, 6, 4, 3, 6, 4, 7, 4, 2, 13, 15, 7, 6, 11]
          },
          {
            name: 'Mobilidade Urbana',
            data: [3, 3, 3, 8, 3, 2, 5, 5, 15, 3, 3, 5, 4, 10, 4, 3]
          },
          {
            name: 'Gestão de Resíduos',
            data: [3, 2, 2, 5, 5, 2, 5, 3, 5, 3, 1, 7, 9, 6, 5, 1]
          },
          {
            name: 'Espaços Públicos',
            data: [2, 2, 5, 7, 5, 1, 2, 2, 10, 1, 2, 3, 12, 10, 5, 1]
          }
        ],
        chart: {
          type: 'bar',
          height: 500,
          width: 1200
        },
        colors: colors,
        plotOptions: {
          bar: {
            horizontal: false,
            columnWidth: '85%',
            endingShape: 'rounded',
            // colors: colors
          },
        },
        dataLabels: {
          enabled: false
        },
        stroke: {
          show: true,
          width: 2,
          colors: ['transparent'],
        },
        xaxis: {
          categories: bairros,
          labels: {
            style: {
              fontSize: '17px'
            }
          }
        },
        yaxis: {
          title: {
            text: 'Quantidade de denúncias',
            style: {
              fontSize: '16px'
            }
          },
          min: 0,
          max: 70,
          labels: {
            style: {
              fontSize: '15px'
            }
          }
        },
        fill: {
          opacity: 1
        },
        tooltip: {
          y: {
            formatter: function (val) {
              return + val + " " + "denúncias realizadas"
            }
          }
        }
      };

      var chart = new ApexCharts(document.querySelector("#qtdDenuncia-categoria-bairro"), options);
      chart.render();
    })


  };

  return {
    init: init,
  }
})()

