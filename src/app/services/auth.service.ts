import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment'
import { UserForLogin, UserForRegister } from '../model/user';

@Injectable({
    providedIn: 'root'
})
export class AuthService {

     baseUrl = environment.baseUrl;
    constructor(private http : HttpClient) { }

    authUser(user: UserForLogin ) {

      return this.http.post(this.baseUrl + '/account/login', user )
     // let UserArray = [];
     // if (localStorage.getItem('Users')) {

        //UserArray = JSON.parse(localStorage.getItem('Users'));
}

    registerUser(user: UserForRegister){
      return this.http.post(this.baseUrl + '/account/register', user )

    }

//console.log(UserArray);
      // tslint:disable-next-line: triple-equals
      //return UserArray.find(p => p.userName === user.userName && p.password === user.password);
      //  return this.http.post(this.baseUrl + '/account/login', user);

    }






