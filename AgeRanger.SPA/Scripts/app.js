// Defining angularjs module
var app = angular.module('appModule', []);

// Defining angularjs Controller and inject PersonsService
app.controller('appControl', function ($scope, $http, PersonsService) {

    // Init 
    $scope.personsData = null;

    // Get all Persons with Age Group, from Factory
    PersonsService.GetAllRecords().then(function (d) {
        $scope.personsData = d.data; // Success
    }, function () {
        alert('Something\'s Wrong!'); // Failed
    });

    // Constructor
    $scope.Person = {
        Id: '',
        FirstName: '',
        LastName: '',
        Age: ''
    };

    // Reset Person details
    $scope.clear = function () {
        $scope.Person.Id = '';
        $scope.Person.FirstName = '';
        $scope.Person.LastName = '';
        $scope.Person.Age = '';
    }

    // Create New Person
    $scope.save = function () {
        if ($scope.Person.FirstName != "" &&
            $scope.Person.LastName != "" &&
            $scope.Person.Age != "") {
            $http({
                method: 'POST',
                url: 'api/Person/PostPerson/',
                data: $scope.Person
            }).then(function successCallback(response) {
                // this callback will be called asynchronously
                // when the response is available
                $scope.personsData = response.data;
                $scope.clear();
                alert("Person has been added successfully.");
            }, function errorCallback(response) {
                // called asynchronously if an error occurs
                // or server returns response with an error status.
                alert("Error : " + response.data.ExceptionMessage);
            });
        }
        else {
            alert('Please Enter All the Values!');
        }
    };

    // Load Person Details for Display
    $scope.edit = function (data) {
        $scope.Person = { Id: data.Id, FirstName: data.FirstName, LastName: data.LastName, Age: data.Age };
    }

    // Cancel
    $scope.cancel = function () {
        $scope.clear();
    }

    // Update Person
    $scope.update = function () {
        if ($scope.Person.FirstName != "" &&
            $scope.Person.LastName != "" &&
            $scope.Person.Age != "") {
            $http({
                method: 'PUT',
                url: 'api/Person/PutPerson/' + $scope.Person.Id,
                data: $scope.Person
            }).then(function successCallback(response) {
                $scope.personsData = response.data;
                $scope.clear();
                alert("Person has been updated successfully.");
            }, function errorCallback(response) {
                alert("Error : " + response.data.ExceptionMessage);
            });
        }
        else {
            alert('Please Enter All the Values!');
        }
    };

    // Delete person details
    $scope.delete = function (index) {
        $http({
            method: 'DELETE',
            url: 'api/Person/DeletePerson/' + $scope.personsData[index].Id,
        }).then(function successCallback(response) {
            $scope.personsData.splice(index, 1);
            alert("Person has been deleted successfully.");
        }, function errorCallback(response) {
            alert("Error : " + response.data.ExceptionMessage);
        });
    };

});

// PersonsService Factory
app.factory('PersonsService', function ($http) {
    var f = {};
    f.GetAllRecords = function () {
        return $http.get('api/Person/GetAllPersons');
    }
    return f;
});

// Directive for confirmation pop-up
app.directive('ngReallyClick', [function () {
    return {
        restrict: 'A',
        link: function (scope, element, attrs) {
            element.bind('click', function () {
                var message = attrs.ngReallyMessage;
                if (message && confirm(message)) {
                    scope.$apply(attrs.ngReallyClick);
                }
            });
        }
    }
}]);


