(function () {

    const add = (v1, v2) => {
        return [v1[0] + v2[0], v1[1] + v2[1]];
    }
    
    const multiply = (vector, multiplier) => {
        return [vector[0] * multiplier, vector[1] * multiplier];
    }

    const length = (vector) => {
        return (Math.sqrt((vector[0] ** 2) + (vector[1] ** 2)));
    }

    const dot = (v1, v2) => {
        return ((v1[0] * v2[0]) + (v1[1] * v2[1]));
    }

    const cross = (v1, v2) => {
        return ((v1[0] * v2[1]) - (v1[1] * v2[0]));
    }

    return {
        add,
        multiply,
        length,
        dot,
        cross
    };
})();