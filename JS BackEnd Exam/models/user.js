const mongoose = require("mongoose");
const { Schema } = mongoose;
const { String, ObjectId } = Schema.Types;

const userSchema = new Schema({
    username: {
        type: String,
        required: true,
        unique: true
    },

    password: {
        type: String,
        required: true
    },

    likedPlays: [{
        type: ObjectId,
        ref: "Play"
    }]
});

module.exports = mongoose.model("User", userSchema);