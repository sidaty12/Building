import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, NgForm } from '@angular/forms';
import { User } from 'src/app/model/user';
import { AuthService } from 'src/app/services/auth.service';
@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.scss']
})
export class UserLoginComponent implements OnInit {

  constructor(private authService: AuthService) { }

  ngOnInit() {

    }

    onLogin(loginForm: NgForm){
    console.log('loginForm.value', loginForm.value);

    const user = this.authService.authUser(loginForm.value);
    console.log(' user ', user);
    // user indefined !!
    if (user) {
      console.log('login Successuful');
     }
      else {
       console.log('login not Successful');
      }
     }
    }

