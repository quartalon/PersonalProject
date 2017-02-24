namespace HarmonyInTheHome.Controllers {

    export class HomeController {
        public message = 'Hello from the home page!';
    }


    export class SecretController {
        public secrets;

        constructor($http: ng.IHttpService) {
            $http.get('/api/secrets').then((results) => {
                this.secrets = results.data;
            });
        }
    }

    export class RestaurantsController {
        public rests;

        public deleteRestaurant(id: number) {
            this.$http.delete(`/api/restaurants/` + id).then((response) => {
                this.$state.reload();
            })
        }

        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService) {
            this.$http.get("/api/restaurants").then((response) => {
                if (response.status == 200) {
                    this.rests = response.data;
                } else {
                    console.error(`There was a problem connecting to the API, Please contact your system Administrator.`);
                }
            });
            //console.log(response.data);
        }
    }
    export class CategoriesController {
        //public message = `hello, world!`;
        public cats;

        //constructor(categoryService: HarmonyInTheHome.Services.CategoryService) {
        //    this.cats = categoryService.listCats();
        //}

        public deleteCategory(id: number) {
            this.$http.delete(`/api/categories/` + id).then((response) => {
                this.$state.reload();
            })
        }

        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService) {
            this.$http.get("/api/categories").then((response) => {
                if (response.status == 200) {
                    this.cats = response.data;
                } else {
                    console.error(`There was a problem connecting to the API, Please contact your system Administrator.`);
                }
            });
        }
    }
    export class RestaurantDetailsController {
        public rest;

        constructor(private $stateParams: ng.ui.IStateParamsService, private $http: ng.IHttpService) {
            this.$http.get("/api/restaurants/" + this.$stateParams["id"]).then((response) => {
                this.rest = response.data;
            });
            //console.log(response.data);
        }
    }

    export class CategoryDetailsController {
        public cat;

        constructor(private $stateParams: ng.ui.IStateParamsService, private $http: ng.IHttpService) {
            this.$http.get("/api/categories/" + this.$stateParams["id"]).then((response) => {
                this.cat = response.data;
            });
        }
    }

    export class AddRestaurantController {
        //public message = 'hello, world!';
        public rest1;
        public cats;

        public addRestaurant() {
            this.$http.post('/api/restaurants', this.rest1).then((response) => {
                this.$state.go(`restaurants`);
                //this.$state.reload();
            })
        }
        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService) {
            this.$http.get(`/api/categories`).then((response) => {
                this.cats = response.data;
            });
        }
    }

    export class EditRestaurantController {
        //public message = `hello, world!`;
        public rest;

        public editRestaurant() {
            this.$http.post('/api/restaurants', this.rest).then((response) => {
                this.$state.go(`restaurants`);
            })
        }
        constructor(private $stateParams: ng.ui.IStateParamsService, private $http: ng.IHttpService, private $state: ng.ui.IStateService) {
            let restId = this.$stateParams[`id`];
            this.$http.get(`/api/restaurants/` + restId).then((response) => {
                this.rest = response.data;
            })
        }
    }

    export class AddCategoryController {
        //public message = 'hello, world!';
        public cat1;

        public addCategory() {
            this.$http.post('/api/categories', this.cat1).then((response) => {
                this.$state.go(`categories`);
            })
        }
        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService) {

        }
    }

    export class EditCategoryController {
        //public message = `hello, world!`;
        public cat;

        public editCategory() {
            this.$http.post('/api/categories', this.cat).then((response) => {
                this.$state.go(`categories`);
            })
        }
        constructor(private $stateParams: ng.ui.IStateParamsService, private $http: ng.IHttpService, private $state: ng.ui.IStateService) {
            let catId = this.$stateParams[`id`];
            this.$http.get(`/api/categories/` + catId).then((response) => {
                this.cat = response.data;
            })
        }
    }
    export class DecisionController {

        //public rid;

        //public getRids() {
        //    this.$http.get("/api/restaurants/rids").then((response) => {
        //        this.rid = response.data;
        //        this.$state.go(`result`);
        //    }); console.log(this.rid);
        //}


        

        public rest;
        

        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService, private $stateParams: ng.ui.IStateParamsService) {
            this.$http.get("/api/restaurants"/* + this.$stateParams["id"]*/).then((response) => {
                if (response.status == 200) {
                    this.rest = response.data;
                } else {
                    console.error(`There was a problem connecting to the API, Please contact your system Administrator.`);
                }
            });

        }
    }
    export class ResultController {
        public rid;

        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService) {
            this.$http.get("/api/restaurants/rids").then((response) => {
                this.rid = response.data;
            }); console.log(this.rid);
        }
    };

    export class AboutController {
        public message = 'Hello from the about page!';
    }

}
