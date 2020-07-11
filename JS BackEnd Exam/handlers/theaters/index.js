const { validationResult } = require("express-validator");
const Play = require("../../models/play");
const { ObjectId } = require("mongodb");

module.exports = {
    get: {
        create(req, res, next) {
            res.render("createPlay.hbs");
        },
        details(req, res, next) {
            const { id } = req.params;

            Play.findById(id)
                .then((play) => {
                    const {
                        _id,
                        title,
                        description,
                        imageUrl
                    } = play;

                    const isCreator = play.creator.equals(res.locals.userId);

                    const alreadyLiked = play.usersLiked
                        .some((userId) => userId.equals(res.locals.userId));

                    res.render("details.hbs", {
                        _id,
                        title,
                        description,
                        imageUrl,
                        isCreator,
                        alreadyLiked 
                    });
                })
                .catch((error) => console.log(error));
        },
        edit(req, res, next) {
            const { id } = req.params;

            Play.findById(id)
                .then((play) => {
                    const {
                        _id,
                        title,
                        description,
                        imageUrl,
                        isPublic
                    } = play;
                    
                    res.render("edit.hbs", {
                        _id,
                        title,
                        description,
                        imageUrl,
                        isPublic
                    });
                })
                .catch((error) => console.log(error));
        },
        delete(req, res, next) {
            const { id } = req.params;

            Play
                .deleteOne({
                    _id: id,
                    creator: new ObjectId(res.locals.userId)
                })
                .then(() => {                    
                    res.redirect('/');
                })
                .catch(err => console.log(err));
        },
        like(req, res, next) {
            const { id } = req.params;

            Play.findById(id)
                .then((play) => {                    
                    play.usersLiked.push(new ObjectId(res.locals.userId));

                    play.save()
                        .then((reslut) => {
                            res.redirect("/");
                        })
                        .catch((error) => console.log(error));
                })
                .catch((error) => console.log(error));
        }
    },  
    post: {
        create(req, res, next) {            
            const {
                title,
                description,
                imageUrl,
                isPublic
            } = req.body;
                            
            const errors = validationResult(req);            
            
            if (!errors.isEmpty()) {
                return res.status(422).render("createPlay.hbs", {
                  path: "/theater/create",
                  message: errors.array()[0].msg,
                  oldBody: {
                    title,
                    description,
                    imageUrl
                  }
                });
            }

            const play = new Play({
                title,
                description,
                imageUrl,
                isPublic: isPublic === "on" ? true : false,
                createdAt: new Date().toUTCString(),
                creator: res.locals.userId,
                usersLiked: []
            });
            
            play
                .save()
                .then(() => {
                    res.redirect('/');
                })
                .catch((error) => console.log(error));
        },
        edit(req, res, next) {
            const { id } = req.params;

            const {
                title,
                description,
                imageUrl,
                isPublic
            } = req.body;
                            
            const errors = validationResult(req);            
            
            if (!errors.isEmpty()) {
                return res.status(422).render("edit.hbs", {
                  path: "/theater/edit",
                  message: errors.array()[0].msg,
                  title,
                  description,
                  imageUrl
                });
            }
            
            Play.findById(id)
                .then((play) => {                                                        
                    play.title = title;
                    play.description = description;
                    play.imageUrl = imageUrl;
                    play.isPublic = isPublic === "on" ? true : false;

                    play.save()
                        .then(() => {
                            res.redirect("/");
                        })
                        .catch((error) => console.log(error));
                })
                .catch((error) => console.log(error));
        }
    }
};
