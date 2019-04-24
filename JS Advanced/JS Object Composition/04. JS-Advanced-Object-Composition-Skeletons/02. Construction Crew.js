function constructionCrew (worker) {
    if (worker.handsShaking) {
        if (worker.experience == 0) {

            worker.bloodAlcoholLevel 
                += worker.weight * 0.1;
    
        } else {            
            worker.bloodAlcoholLevel 
                += worker.weight * worker.experience * 0.1;
        }

        worker.handsShaking = false;
    }

    return worker;
};

let worker = { weight: 80,
    experience: 1,
    bloodAlcoholLevel: 0,
    handsShaking: true };
  
console.log(constructionCrew(worker));

    