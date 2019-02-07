function Main(steps, footprintSizeMeters, speedKmH) {
    let distanceInMeters = (steps * footprintSizeMeters);
    let distanceInKm =  distanceInMeters / 1000;
    let breaksMin = 0;

     while (distanceInMeters > 500) {
         distanceInMeters -= 500;
         breaksMin++;
     }

    let totalTimeMin = (((distanceInKm / speedKmH) * 60) + breaksMin);

    let hours = 0;

    while (totalTimeMin >= 60) {
        hours++;
        totalTimeMin -= 60;
    }

    let minutes = Math.floor(totalTimeMin);
    let seconds = (60 * ((totalTimeMin % 1))).toFixed();

    let hoursStr = hours.toString().length < 2 ? '0' + hours : hours;
    let minutesStr = minutes.toString().length < 2 ? '0' + minutes : minutes;
    let secondStr = seconds.toString().length < 2 ? '0' + seconds : seconds;

    console.log(`${hoursStr}:${minutesStr}:${secondStr}`)
}

Main(4000, 0.1, 5);