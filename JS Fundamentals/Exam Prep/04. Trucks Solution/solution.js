function solve() {
    let btns = document.getElementsByTagName('button');
    btns[0].addEventListener('click', registerTruck);
    btns[1].addEventListener('click', addTire);
    btns[2].addEventListener('click', work);
    btns[3].addEventListener('click', endShift);

    let trucks = [];

    let fieldSets = Array.from(document.getElementsByTagName('fieldset'));

    let backupTires = fieldSets
        .find(f => f.children[0].textContent === 'Backup tires sets');

    let trucksFieldset = fieldSets
        .find(f => f.children[0].textContent === 'Trucks');

    let output = document.getElementsByTagName('textarea')[0];

    function registerTruck() {
        let plateNum = document.getElementById('newTruckPlateNumber').value;
        let tires = document.getElementById('newTruckTiresCondition').value;

        if (trucks.filter(t => t.PlateNumber === plateNum).length === 0) {
            trucks.push(
                {
                    PlateNumber: plateNum,
                    Tires: Array.from(tires.split(' ').map(Number)),
                    DistanceTraveled: 0
                });

            let newTruckDiv = document.createElement('div');
            newTruckDiv.classList.add('truck');
            newTruckDiv.textContent = plateNum;

            trucksFieldset.appendChild(newTruckDiv);
        }
    }

    function addTire() {
        let newTireSetDiv = document.createElement('div');
        newTireSetDiv.classList.add('tireSet');

        let tireSet = document.getElementById('newTiresCondition').value;

        newTireSetDiv.textContent = tireSet;
        backupTires.appendChild(newTireSetDiv);
    }

    function work() {
        
        let plateNum = document.getElementById('workPlateNumber').value;
        let distance = Number(document.getElementById('distance').value);

        let currentTruck = trucks.find(t => t.PlateNumber === plateNum);
        let truckIndex = trucks.indexOf(currentTruck);

        if (currentTruck) {            

            if (distance > getWeakestTire(currentTruck.Tires) * 1000) {

                if (backupTires.children.length > 2) {
                    currentTruck.Tires =
                        Array.from(backupTires.children[2].textContent.split(' ').map(Number));                                          
                    
                    backupTires.removeChild(backupTires.children[2]);                    

                    if (distance < getWeakestTire(currentTruck.Tires) * 1000) {
                        travelDistance(currentTruck, distance, truckIndex);
                    }                 
                }
            } else {
                travelDistance(currentTruck, distance, truckIndex);
            }           
        }
    }

    function endShift() {
        for (let t of trucks) {
            output.textContent += `Truck ${t.PlateNumber} has traveled ${t.DistanceTraveled}.\n`;
        }

        let backupTireSetsLeft = backupTires.children.length - 2 > 0 
            ? backupTires.children.length - 2
            : 0;

        output.textContent += `You have ${backupTireSetsLeft} sets of tires left.\n`;
    }

    function getWeakestTire(arr) {
        return Math.min.apply(Math, arr);        
   }

   function travelDistance(currentTruck, distance, truckIndex) {
        currentTruck.DistanceTraveled += distance;

        let tireUsage = Math.round(distance / 1000);                        
        currentTruck.Tires = currentTruck.Tires.map(tire => tire - tireUsage);

        trucks[truckIndex] = currentTruck;
   }
}