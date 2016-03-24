angular.module('ngFileInfo', []).controller('fileInfoList', function ($scope) {

    $scope.data = [];

    $scope.initList = function () {
        $.XGoAjax({
            isExclusive:true,
            id: "getFileList",
            ajax: { url: AppConfig.RootUrl + "FileInfo/GetFileList" },
            success: function (ops, data) {
                $scope.data = data.CustomObject || [];
                $scope.$apply();
            }
        });
    };
    $scope.initList();

});