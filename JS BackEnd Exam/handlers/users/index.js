const bcrypt = require("bcryptjs");
const { validationResult } = require("express-validator");
const User = require("../../models/user");
const jwt = require("../../utils/jwt");
const { cookie } = require("../../config/config");

module.exports = {
  get: {
    login(req, res, next) {
      res.render("login.hbs");
    },

    register(req, res, next) {
      res.render("register.hbs");
    },

    logout(req, res, next) {
        res.clearCookie(cookie);        
        
        res.locals.userId = null;
        res.locals.username = null;
        res.locals.isAuthenticated = false;

        res.redirect('/');
    }
  },
  post: {
    login(req, res, next) {
      const { username, password } = req.body;

      const errors = validationResult(req);

      if (!errors.isEmpty()) {
        return res.status(422).render("login.hbs", {
          path: "/user/login",
          message: errors.array()[0].msg,
          oldBody: {
            username, 
            password
          }
        });
      }

      User.findOne({ username })
        .then((user) => {            
          if (!user) {
            return res.status(422).render("login.hbs", {
              path: "/user/login",
              message: "Invalid username or password.",
              oldBody: {
                username,
                password
              }
            });
          }

          bcrypt
            .compare(password, user.password)
            .then((doMatch) => {
                
              if (doMatch) {
                const jwtToken = jwt.create({
                    id: user.id,
                    username: user.username
                });
                
                res.cookie(cookie, jwtToken);
                res.redirect('/');
                return;
              }

              return res.status(422).render("login.hbs", {
                path: "/user/login",
                message: "Invalid username or password.",
                oldBody: {
                  username,
                  password
                }
              });
            })
            .catch((err) => {
              console.log(err);
            });
        })
        .catch((err) => console.log(err));
    },

    register(req, res, next) {
      const { username, password } = req.body;

      const errors = validationResult(req);

      console.log(errors);
      
      if (!errors.isEmpty()) {
        return res.status(422).render("register.hbs", {
          path: "/user/register",
          pageTitle: "Register",
          message: errors.array()[0].msg,
          oldBody: req.body
        });
      }

      bcrypt
        .hash(password, 12)
        .then((hashedPassword) => {
          const user = new User({
            username,
            password: hashedPassword,
            likedPlays: []
          });
          return user.save();
        })
        .then(() => {
          res.redirect("/user/login");
        })
        .catch((error) => {
          console.log(error);
        });
    },
  },
};
