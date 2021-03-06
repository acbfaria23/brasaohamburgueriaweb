﻿var brasaoWebApp = angular.module('brasaoWebApp', ['ngBootbox', 'cgBusy', 'timer', 'smart-table']);

brasaoWebApp.config(['$httpProvider', function ($httpProvider) {
    //$httpProvider.defaults.headers.common['X-Requested-With'] = 'XMLHttpRequest';
}]);

brasaoWebApp.value('$', $);

var urlBase = 'http://10.84.124.128:57919/';
var urlWebAPIBase = 'http://localhost:62993/api/';

brasaoWebApp.factory('noteService', ['$', '$rootScope',
function ($, $rootScope) {
    var proxy;
    var connection;
    return {
        connect: function () {
            connection = $.hubConnection(urlBase + 'signalr');
            proxy = connection.createHubProxy('HubMessage');
            connection.start();
            proxy.on('messageAdded', function (codPedido, situacao) {
                $rootScope.$broadcast('messageAdded', codPedido, situacao);
            });
        },
        isConnecting: function () {
            return connection.state === 0;
        },
        isConnected: function () {
            return connection.state === 1;
        },
        connectionState: function () {
            return connection.state;
        },
        sendMessage: function (usuario, codPedido, situacao) {
            proxy.invoke('SendMessage', usuario, codPedido, situacao);
        },
    }
}]);



brasaoWebApp.value('cgBusyDefaults', {
    templateUrl: urlBase + 'Content/templates/_Loading.html'
});