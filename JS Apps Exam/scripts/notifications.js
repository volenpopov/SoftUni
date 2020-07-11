
export function successNotification(message){
    let notificationRef = document.querySelector('#infoBox')
    notificationRef.innerHTML = `<div id="successBox" class="alert alert-success" role="alert">${message}</div>`


    // setTimeout(() => {
    //     notificationContainer.remove();
    // }, 4000);

}

export function loadingNotification(){
    let notificationRef = document.querySelector('#infoBox')
    notificationRef.innerHTML = '<div id="loadingBox" class="alert alert-info" role="alert">Loading...</div>';

}

export function errorNotification(message){
    let notificationRef = document.querySelector('#infoBox')
    notificationRef.innerHTML = `<div id="errorBox" class="alert alert-danger" role="alert">${message}</div>`

}