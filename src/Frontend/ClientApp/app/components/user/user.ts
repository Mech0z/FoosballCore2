import { HttpClient } from 'aurelia-fetch-client';
import { json } from 'aurelia-fetch-client';
import { inject } from 'aurelia-framework';
import { Router } from 'aurelia-router';

@inject(HttpClient)
export class User{
    public loggedIn: boolean;
    public Loginuser: Loginuser;

    constructor(){

    }

    Login(){
        console.log("login");
    }
}

interface Loginuser {
    Email: string;
    Password: string;
}