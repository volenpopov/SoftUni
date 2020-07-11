const jwt = require("../utils/jwt");
const { cookie } = require("../config/config");

module.exports = (req, res, next) => {
    const token = req.cookies[cookie];
    
    if (token) {
        const { id, username } = jwt.verifyToken(token);
        
        res.locals.userId = id;
        res.locals.username = username;
        res.locals.isAuthenticated = true;
    }    
    
    next();
};