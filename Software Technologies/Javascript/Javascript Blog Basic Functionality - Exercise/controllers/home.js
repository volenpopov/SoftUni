const User = require('../models').User;
const Article = require('../models').Article;

module.exports = {

    index: (req, res) => {
        Article.findAll({limit: 6, include: [{
            model: User
            }]}).then(articles =>{
                res.render('home/index', {articles: articles});
        });
    },
};




