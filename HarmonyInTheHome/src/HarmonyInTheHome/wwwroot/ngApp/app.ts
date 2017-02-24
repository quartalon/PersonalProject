namespace HarmonyInTheHome {

    angular.module('HarmonyInTheHome', ['ui.router', 'ngResource', 'ui.bootstrap']).config((
        $stateProvider: ng.ui.IStateProvider,
        $urlRouterProvider: ng.ui.IUrlRouterProvider,
        $locationProvider: ng.ILocationProvider
    ) => {
        // Define routes
        $stateProvider
            .state('home', {
                url: '/',
                templateUrl: '/ngApp/views/home.html',
                controller: HarmonyInTheHome.Controllers.HomeController,
                controllerAs: 'controller'
            })
            .state('secret', {
                url: '/secret',
                templateUrl: '/ngApp/views/secret.html',
                controller: HarmonyInTheHome.Controllers.SecretController,
                controllerAs: 'controller'
            })
            .state('login', {
                url: '/login',
                templateUrl: '/ngApp/views/login.html',
                controller: HarmonyInTheHome.Controllers.LoginController,
                controllerAs: 'controller'
            })
            .state('register', {
                url: '/register',
                templateUrl: '/ngApp/views/register.html',
                controller: HarmonyInTheHome.Controllers.RegisterController,
                controllerAs: 'controller'
            })
            .state('externalRegister', {
                url: '/externalRegister',
                templateUrl: '/ngApp/views/externalRegister.html',
                controller: HarmonyInTheHome.Controllers.ExternalRegisterController,
                controllerAs: 'controller'
            }) 
            .state(`decision`, {
                url: `/decision`,
                templateUrl: `/ngApp/views/decision.html`,
                controller: HarmonyInTheHome.Controllers.DecisionController,
                controllerAs: `controller`
            })
            .state(`result`, {
                url: `/result`,
                templateUrl: `/ngApp/views/result.html`,
                controller: HarmonyInTheHome.Controllers.ResultController,
                controllerAs: `controller`
            })
            .state('restaurants', {
                url: '/restaurants',
                templateUrl: '/ngApp/views/restaurants.html',
                controller: HarmonyInTheHome.Controllers.RestaurantsController,
                controllerAs: 'controller'
            })
            .state(`categories`, {
                url: `/categories`,
                templateUrl: `/ngApp/views/categories.html`,
                controller: HarmonyInTheHome.Controllers.CategoriesController,
                controllerAs: `controller`
            })
            .state('restaurantdetails', {
                url: '/restaurantdetails/:id',
                templateUrl: '/ngApp/views/restaurantdetails.html',
                controller: HarmonyInTheHome.Controllers.RestaurantDetailsController,
                controllerAs: 'controller'
            })
            .state('categorydetails', {
                url: `/categorydetails/:id`,
                templateUrl: `/ngApp/views/categorydetails.html`,
                controller: HarmonyInTheHome.Controllers.CategoryDetailsController,
                controllerAs: `controller`
            })
            .state('addRestaurant', {
                url: '/addRestaurant',
                templateUrl: '/ngApp/views/addRestaurant.html',
                controller: HarmonyInTheHome.Controllers.AddRestaurantController,
                controllerAs: 'controller'
            })
            .state(`editRestaurant`, {
                url: `/editRestaurant/:id`,
                templateUrl: `/ngApp/views/editRestaurant.html`,
                controller: HarmonyInTheHome.Controllers.EditRestaurantController,
                controllerAs: `controller`

            })
            .state('addCategory', {
                url: '/addCategory',
                templateUrl: '/ngApp/views/addCategory.html',
                controller: HarmonyInTheHome.Controllers.AddCategoryController,
                controllerAs: 'controller'
            })
            .state(`editCategory`, {
                url: `/editCategory/:id`,
                templateUrl: `/ngApp/views/editCategory.html`,
                controller: HarmonyInTheHome.Controllers.EditCategoryController,
                controllerAs: `controller`

            })
            .state('about', {
                url: '/about',
                templateUrl: '/ngApp/views/about.html',
                controller: HarmonyInTheHome.Controllers.AboutController,
                controllerAs: 'controller'
            })
            .state('notFound', {
                url: '/notFound',
                templateUrl: '/ngApp/views/notFound.html'
            });

        // Handle request for non-existent route
        $urlRouterProvider.otherwise('/notFound');

        // Enable HTML5 navigation
        $locationProvider.html5Mode(true);
    });

    
    angular.module('HarmonyInTheHome').factory('authInterceptor', (
        $q: ng.IQService,
        $window: ng.IWindowService,
        $location: ng.ILocationService
    ) =>
        ({
            request: function (config) {
                config.headers = config.headers || {};
                config.headers['X-Requested-With'] = 'XMLHttpRequest';
                return config;
            },
            responseError: function (rejection) {
                if (rejection.status === 401 || rejection.status === 403) {
                    $location.path('/login');
                }
                return $q.reject(rejection);
            }
        })
    );

    angular.module('HarmonyInTheHome').config(function ($httpProvider) {
        $httpProvider.interceptors.push('authInterceptor');
    });

    

}
