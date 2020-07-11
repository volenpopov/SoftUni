require("./config/database")()
    .then(() =>{
        const config = require("./config/config");
        const app = require("express")();
        const appString = `Server is ready and listening on port: ${config.port}...`;
        const auth = require("./middleware/auth");

        require("./config/express")(app);

        app.use(auth);

        require("./config/routes")(app);

        app.listen(config.port, console.log(appString));
    });