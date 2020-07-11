const Play = require("../../models/play");

module.exports = {
    get: {
        home(req, res, next) { 
            Play.find({ isPublic: true })
                .lean()
                .then((plays) => { 
                    let sortedPlays = [];

                    if (res.locals.isAuthenticated) {
                        sortedPlays = plays.sort((currentPlay, nextPlay) => {
                            return nextPlay.createdAt - currentPlay.createdAt;
                        });                        
                    } else {
                        sortedPlays = plays.sort((currentPlay, nextPlay) => {
                            return nextPlay.usersLiked.length - currentPlay.usersLiked.length;
                        })
                        .slice(0, 3);
                    }

                    res.render('home.hbs', { plays: sortedPlays });
                })
                .catch(err => {
                    console.log(err);
                });
        },
        // homeByDate(req, res, next) {
        //     const { url }
        //     res.redirect("/");
        // },
        // homeByLikes(req, res, next) {
        //     console.log(req);
        //     res.redirect("/");
        // }
    },  
    post: {

    }
};
