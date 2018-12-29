const userController = require('./../controllers/user');
const homeController = require('./../controllers/home');

// a moje i po dolniq nachin s tochka nakraq koito idva ot controllers/index kudeto sa spomenati sukrashteniqta!
const articleController = require('../controllers').article;

module.exports = (app) => {
    app.get('/', homeController.index);

    app.get('/article/create', articleController.createGet);
    app.post('/article/create', articleController.createPost);

    app.get('/user/register', userController.registerGet);
    app.post('/user/register', userController.registerPost);

    app.get('/user/login', userController.loginGet);
    app.post('/user/login', userController.loginPost);

    app.get('/user/logout', userController.logout);

    app.get('/user/details/:id', userController.userDetails);

    app.get('/article/details/:id', articleController.articleDetails);
};