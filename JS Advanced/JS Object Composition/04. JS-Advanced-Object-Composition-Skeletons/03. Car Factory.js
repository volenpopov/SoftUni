function carFactory(order) {
    const engines = {
        small: {
            power: 90,
            volume: 1800
        },

        normal: {
            power: 120,
            volume: 2400 
        },

        monster: {
            power: 200,
            volume: 3500 
        }
    };

    return {
        model: order.model,
        engine: getEngine(order),
        carriage: {
            type: `${order.carriage}`,
            color: `${order.color}`
        },

        wheels: getWheels(order)
    };
    
    function getEngine(order) {
        if (order.power > engines['normal']['power']) {
            return engines['monster'];
        } else if (order.power > engines['small']['power']) {
            return engines['normal'];
        } else {
            return engines['small'];
        }
    };

    function getWheels(order) {
        let size = order.wheelsize;

        if (size % 2 == 0) {
            let correctSize = size - 1;
            return [correctSize, correctSize, correctSize, correctSize];
        } else {
            return [size, size, size, size];
        }
    };
}

console.log(carFactory(
    { model: 'VW Golf II',
power: 90,
color: 'blue',
  carriage: 'hatchback',
  wheelsize: 14 
}
));
