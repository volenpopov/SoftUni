import { requester } from './services/app-service.js';
import {
    homeViewHandler,
    registerViewHandler,
    loginViewHandler,
    logoutHandler,
    createHandler,
    detailsHandler,
    editHandler,
    deleteHandler
} from './handlers/index.js';

const apiKey = 'https://exam-f4552.firebaseio.com/';
requester.init(apiKey, localStorage.getItem('token'));

const app = Sammy("#main", function() {
    this.use("Handlebars", "hbs");

    this.get("#/", homeViewHandler);
    this.get("#/home", homeViewHandler);

    this.get("#/login", loginViewHandler);
    this.post("#/login", () => false);

    this.get("#/logout", logoutHandler);

    this.get("#/register", registerViewHandler);
    this.post("#/register", () => false);

    this.get("#/create", createHandler);
    this.post("#/create", () => false);

    this.get("#/details/:id", detailsHandler);

    this.get("#/edit/:id", editHandler);
    this.post("#/edit/:id", () => false);

    this.get("#/delete/:id", deleteHandler);
})

app.run("#/");
