const router = require("express").Router();
const { check, body } = require('express-validator');
const handler = require("../handlers/users");
const User = require("../models/user");

router.get("/login", handler.get.login);

router.get("/register", handler.get.register);

router.get("/logout", handler.get.logout);

router.post(
    "/login",
    [
        body('username')
          .isString()
          .isLength({ min: 3 })
          .withMessage('Username must be at least 3 characters long.')
          .trim(),
        body('password', 'Password must have a length of at least 1 character.')
          .isLength({ min: 3 })
          .trim()
    ],
    handler.post.login
);

router.post(
    "/register",
    [
      body('username')
        .isString()
        .isLength({ min: 3 })
        .withMessage('Username must be at least 3 characters long.')
        .trim(),
      check('username')                
        .custom((value, { req }) => {
          return User.findOne({ username: value }).then(userDoc => {
            if (userDoc) {
              return Promise.reject(
                'Username exists already, please pick a different one.'
              );
            }
          });
        }),
      body(
        'password',
        'Please enter a password with at minimum length of 1 character.'
      )
        .isLength({ min: 3 })
        .trim(),
      body('repeatPassword')
        .trim()
        .custom((value, { req }) => {
          if (value !== req.body.password) {
            throw new Error('Passwords have to match!');
          }
          return true;
        })
    ],
    handler.post.register
);

module.exports = router;