function Main(day, service, time) {

    let dayOfWeek = function (day) {
        return ['Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday', 'Sunday']
            .indexOf(day);
    };

    let weekDayService = {
      'Fitness': 5,
        'Sauna': 4,
        'Instructor': 10
    };

    let weekEndService = {
        'Fitness': 8,
        'Sauna': 7,
        'Instructor': 15
    };

    if (dayOfWeek(day) <= 4) {
        if (time <= 15.00) {
            console.log(weekDayService[service]);
        }
        else {
            console.log(weekDayService[service] + 2.5);
        }
    }
    else {
        console.log(weekEndService[service]);
    }

}

Main('Sunday', 'Fitness', 15.30);