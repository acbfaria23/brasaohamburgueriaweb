﻿brasaoWebApp.controller('prController', function ($scope, $http, $filter) {

    $scope.rowCollection = [];
    $scope.promisesLoader = [];
    $scope.mensagem = {
        erro: '',
        sucesso: '',
        informacao: ''
    }

    $scope.getPedidosRealizados = function () {

        var row = {
            codPedido: 1,
            dataHora: '05/10/2017 17:00',
            cliente: 'Samuel Jão',
            formaPagamento: 'Cartão / VISA',
            valorTotal: 52.90
        };

        $scope.rowCollection.push(row);

        //$scope.promiseGetPedidosRealizados = $http({
        //    method: 'GET',
        //    headers: {
        //        //'Authorization': 'Bearer ' + accesstoken,
        //        'RequestVerificationToken': 'XMLHttpRequest',
        //        'X-Requested-With': 'XMLHttpRequest',
        //    },
        //    url: urlBase + 'Pedido/GetUltimosPedidos?loginUsuario=' + loginUsuario
        //})
        //.then(function (response) {

        //    var retorno = genericSuccess(response);

        //    if (retorno.succeeded) {

                

        //    }
        //    else {
        //        $scope.mensagem.erro = 'Ocorreu uma falha durante a execução da operação com a seguinte mensagem: ' + (retorno.errors[0] ? retorno.errors[0] : 'erro desconhecido');
        //        $window.scrollTo(0, 0);
        //    }



        //}, function (error) {
        //    $scope.mensagem.erro = 'Ocorreu uma falha no processamento da requisição. ' + (error.statusText != '' ? error.statusText : 'Erro desconhecido.');
        //    $window.scrollTo(0, 0);
        //});

        //$scope.promisesLoader.push($scope.promiseGetPedidosRealizados);


    };

    $scope.init = function (loginUsuario, antiForgeryToken) {
        
        

    }

});