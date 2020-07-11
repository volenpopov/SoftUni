import { applyCommon } from "./common.js";
import { createFormEntity } from "../form-helpers.js";
import { requester } from "../services/app-service.js";

export async function logoutHandler() {
    localStorage.clear();
    await firebase.auth().signOut();
    this.redirect(['#/home']);
}

export async function loginViewHandler() {    
    await applyCommon.call(this);

    await this.partial("../templates/login/loginPage.hbs");

    const formRef = document.querySelector("form"); 
    const form = createFormEntity(formRef,  ["email", "password"]);

    formRef.addEventListener("submit", async (event) => {
        event.preventDefault();

        const formValue = form.getValue();

        const loggedInUser = await firebase.auth().signInWithEmailAndPassword(formValue.email, formValue.password);
        const userToken = await firebase.auth().currentUser.getIdToken();
        
        localStorage.setItem('email', loggedInUser.user.email);
        localStorage.setItem('userId', firebase.auth().currentUser.uid);
        
        localStorage.setItem('token', userToken);
        requester.setAuthToken(userToken);

        form.clear();

        this.redirect(['#/home']);
    })
};

export async function registerViewHandler() {
    await applyCommon.call(this);

    await this.partial("../templates/register/registerPage.hbs");

    const formRef = document.querySelector("form");    
    
    const form = createFormEntity(formRef,  ["email", "password", "rep-pass"]);

    formRef.addEventListener("submit", async (event) => {
        event.preventDefault();

        const formValue = form.getValue();        
        
        if (formValue.password !== formValue["rep-pass"]) {
            throw new Error('Password and repeat password must match');
        }        

        const newUser = await firebase.auth().createUserWithEmailAndPassword(formValue.email, formValue.password);

        const userToken = await firebase.auth().currentUser.getIdToken();
        localStorage.setItem('email', newUser.user.email);
        localStorage.setItem('userId', firebase.auth().currentUser.uid);

        localStorage.setItem('token', userToken);
        
        requester.setAuthToken(userToken);

        form.clear();
        
        this.redirect(['#/home']);
    });
};