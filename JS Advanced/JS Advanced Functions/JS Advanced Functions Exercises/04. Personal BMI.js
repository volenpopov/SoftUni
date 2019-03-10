function Main(name, age, weight, height) {
    
    let BMI = Math.round(weight / Math.pow((height/100), 2));

    let status = '';

    if (BMI < 18) {
        status = 'underweight';
    } else if (BMI < 25) {
        status = 'normal';
    } else if (BMI < 30) {
        status = 'overweight';
    } else {
        status = 'obese';
    }

    let patientChart = 
    {
        name: name,
        personalInfo: 
            {
                age: age,
                weight: weight,
                height: height
            },
        BMI: BMI,
        status: status
    }

    if (status === 'obese') {
        patientChart.recommendation = 'admission required';
    }

    return patientChart;    
}