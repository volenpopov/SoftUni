const router = require("express").Router();
const { check, body } = require('express-validator');
const handler = require("../handlers/theaters");
const isAuth = require("../middleware/isAuth");

router.get("/create", isAuth, handler.get.create);

router.get("/details/:id", isAuth, handler.get.details);

router.get("/edit/:id", isAuth, handler.get.edit);

router.get("/delete/:id", isAuth, handler.get.delete);

router.get("/like/:id", isAuth, handler.get.like);

router.post(
    "/create",
    [
        check("title")
            .custom((value, { req }) => {
                if (!value) {
                    throw new Error("Title is required.")
                }

                return true;
            }),
        check("description")
            .custom((value, { req }) => {
                if (!value) {
                    throw new Error("Description is required.")
                }

                return true;
            }),
        body('description')
          .isString()
          .isLength({ max: 50 })
          .withMessage('Description max length is 50 characters.')
          .trim(),
        check("imageUrl")
            .custom((value, { req }) => {
                if (!value) {
                    throw new Error("Image url is required.")
                }

                return true;
            })
    ],
    isAuth,
    handler.post.create
);

router.post(
    "/edit/:id",
    [
        check("title")
            .custom((value, { req }) => {
                if (!value) {
                    throw new Error("Title is required.")
                }

                return true;
            }),
        check("description")
            .custom((value, { req }) => {
                if (!value) {
                    throw new Error("Description is required.")
                }

                return true;
            }),
        body('description')
          .isString()
          .isLength({ max: 50 })
          .withMessage('Description max length is 50 characters.')
          .trim(),
        check("imageUrl")
            .custom((value, { req }) => {
                if (!value) {
                    throw new Error("Image url is required.")
                }

                return true;
            })
    ],
    isAuth,
    handler.post.edit
);

module.exports = router;