var app = angular.module('app', []);

app.controller('stateController', ['$scope', '$http', stateController]);

function stateController($scope, $http) {

    $scope.loading = true;
    $scope.showAdd = false;
    //get all states
    $scope.load = function () {
        $http.get('/api/State/')
        .success(function (data) {
            $scope.states = data;
            $scope.loading = false;
        })
        .error(function () {
            $scope.error = "An Error has occured while loading posts!";
            $scope.loading = false;
        });
    };

    $scope.toggleEdit = function () {
        this.state.editMode = !this.state.editMode;
    };

    $scope.toggleAdd = function () {
        $scope.showAdd = !$scope.showAdd;
    };

    //Insert state
    $scope.add = function () {
        $scope.loading = true;
        $http.post('/api/state/', this.newState).success(function (data) {
            $scope.showAdd = false;
            $scope.newState.Name = "";
            $scope.load();
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occured while Adding state! " + data;
            $scope.loading = false;
        });
    };

    $scope.save = function () {
        $scope.loading = true;
        var frien = this.state;
        $http.put('/api/state/' + frien.Id, frien).success(function (data) {
            frien.editMode = false;
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occured while Saving state! " + data;
            $scope.loading = false;
        });
    };

    //Delete state
    $scope.deletestate = function () {
        $scope.loading = true;
        var Id = this.state.Id;
        $http.delete('/api/state/' + Id).success(function (data) {
            $.each($scope.states, function (i) {
                if ($scope.states[i].Id === Id) {
                    $scope.states.splice(i, 1);
                    return false;
                }
            });
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occured while Saving state! " + data;
            $scope.loading = false;
        });
    };
    $scope.load();
}

app.controller('cityController', ['$scope', '$http', cityController]);

function cityController($scope, $http) {



    //get all cities
    $scope.load = function () {
        $http.get('/api/City/')
        .success(function (data) {
            $scope.cities = data;
            $scope.loading = false;
        })
        .error(function () {
            $scope.error = "An Error has occured while loading posts!";
            $scope.loading = false;
        });
    };

    $scope.loadStates = function () {
        $http.get('/api/State/')
        .success(function (data) {
            $scope.states = data;
            $scope.loading = false;
        })
        .error(function () {
            $scope.error = "An Error has occured while loading posts!";
            $scope.loading = false;
        });
    };

    $scope.toggleEdit = function () {
        this.city.editMode = !this.city.editMode;
    };

    $scope.toggleAdd = function () {
        $scope.showAdd = !$scope.showAdd;
    };

    //Insert state
    $scope.add = function () {
        $scope.loading = true;
        $http.post('/api/city/', this.newCity).success(function (data) {
            $scope.showAdd = false;
            $scope.newCity.Name = "";
            $scope.load();
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occured while Adding state! " + data;
            $scope.loading = false;
        });
    };

    $scope.save = function () {
        $scope.loading = true;
        var frien = this.city;
        $http.put('/api/city/' + frien.Id, frien).success(function (data) {
            frien.editMode = false;
            $scope.loading = false;
            $scope.load();
        }).error(function (data) {
            $scope.error = "An Error has occured while Saving state! " + data;
            $scope.loading = false;
        });
    };

    //Delete state
    $scope.delete = function () {
        $scope.loading = true;
        var Id = this.city.Id;
        $http.delete('/api/city/' + Id).success(function (data) {
            $.each($scope.cities, function (i) {
                if ($scope.cities[i].Id === Id) {
                    $scope.cities.splice(i, 1);
                    return false;
                }
            });
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occured while Saving state! " + data;
            $scope.loading = false;
        });
    };
    $scope.loading = true;
    $scope.showAdd = false;
    $scope.load();
    $scope.loadStates();
}

app.controller('weatherController', ['$scope', '$http', weatherController]);

function weatherController($scope, $http) {

    $scope.weather = {
        stateId: 0,
        cityId: 0,
        date: new Date(),
        stationCode: '',
        predictedSpeed: 0,
        actualSpeed: 0,
        variance: 0
    };
    //get all cities
    $scope.loadCities = function () {
        $http.get('/api/State/City/' + this.weather.stateId)
        .success(function (data) {
            $scope.cities = data;
            if (data.length > 0) {
                $scope.weather.cityId = data[0].Id;
                $scope.loadCity();
            }
            $scope.loading = false;
        })
        .error(function () {
            $scope.error = "An Error has occured while loading posts!";
            $scope.loading = false;
        });
    };

    $scope.loadStates = function () {
        $http.get('/api/State/')
        .success(function (data) {
            $scope.states = data;
            $scope.weather.stateId = data[0].Id;
            $scope.loadCities();
            $scope.loading = false;
        })
        .error(function () {
            $scope.error = "An Error has occured while loading posts!";
            $scope.loading = false;
        });
    };

    $scope.loadCity = function () {
        $scope.loading = true;
        $http.get('/api/City/' + this.weather.cityId)
        .success(function (data) {
            $scope.weather.stationCode = data.StationCode;
            $scope.loading = false;
        })
        .error(function () {
            $scope.error = "An Error has occured while loading posts!";
            $scope.loading = false;
        });
    };

    $scope.toggleEdit = function () {
        this.city.editMode = !this.city.editMode;
    };

    $scope.toggleAdd = function () {
        $scope.showAdd = !$scope.showAdd;
    };

    $scope.save = function () {
        $scope.loading = true;
        var frien = this.weather;
        $http.post('/api/weather/', frien).success(function (data) {
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occured while Saving state! " + data;
            $scope.loading = false;
        });
    };

    $scope.getVariance = function () {
        var diff = $scope.weather.predictedSpeed - $scope.weather.actualSpeed;
        $scope.weather.variance = diff;
        if (diff < 0)
            diff = diff * -1;
        if (diff > 0 && diff <= 1)
            $("#txtvariance").css('color', 'black');
        else if (diff > 1 && diff <= 3)
            $("#txtvariance").css('color', 'purple');
        else if (diff > 3 && diff <= 5)
            $("#txtvariance").css('color', 'red');
        else
            $("#txtvariance").css('color', "black");
    }
    $scope.loading = true;
    $scope.loadStates();
}