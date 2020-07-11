const router = require("../routes");

module.exports = (app) => {

    app.get("/", (req, res, next) => {
        res.redirect("/home");
    });

    app.use("/home", router.home);

    app.use("/user", router.users);

    app.use("/theater", router.theaters);
};