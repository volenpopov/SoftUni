const mongoose = require("mongoose");
const { Schema } = mongoose;
const { String, Boolean, ObjectId } = Schema.Types;

const playSchema = new Schema({
    title: {
        type: String,
        required: true,
        unique: true
    },
    description: {
        type: String,
        required: true,
        maxlength: 50
    },
    imageUrl: {
        type: String,
        required: true
    },
    isPublic: {
        type: Boolean,
        default: false
    },
    createdAt: {
        type: String,
        required: true
    },
    creator: {
        type: ObjectId,
        required: true,
        ref: "User"
    },
    usersLiked: [{
        type: ObjectId,
        ref: "User"
    }]
});

module.exports = mongoose.model("Play", playSchema);