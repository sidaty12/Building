import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from '../model/user';
import { environment } from '../../environments/environment';

@Injectable({
    providedIn: 'root'
})
export class AuthService {

    // baseUrl = environment.baseUrl;
    constructor() { }

    authUser(user: User) {

      let UserArray = [];
      if (localStorage.getItem('Users')) {

        UserArray = JSON.parse(localStorage.getItem('Users'));
}

//console.log(UserArray);
      // tslint:disable-next-line: triple-equals
      return UserArray.find(p => p?.userName === user.userName && p.password === user.password);
      //  return this.http.post(this.baseUrl + '/account/login', user);

    }





}
