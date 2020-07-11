const router = require("express").Router();
const handler = require("../handlers/home");

router.get("/", handler.get.home);

// router.get("/byDate", handler.get.homeByDate);

// router.get("/byLikes", handler.get.homeByLikes);

module.exports = router;