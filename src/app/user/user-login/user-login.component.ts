import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { UserForLogin } from 'src/app/model/user';
import { AlertifyService } from 'src/app/services/alertify.service';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.scss']
})
export class UserLoginComponent implements OnInit {

  constructor(private authService: AuthService,
              private alertify: AlertifyService,
              private router: Router ) { }

  ngOnInit() {

    }

    onLogin(loginForm: NgForm){
    console.log('loginForm.value', loginForm.value);
   // const.log(loginForm.value)

    this.authService.authUser(loginForm.value).subscribe(
      (response : UserForLogin) => {
        console.log(response);
        const user = response;
        localStorage.setItem('token', user.token);
        localStorage.setItem('userName', user.userName);

        this.alertify.success('Login Successful');
        this.router.navigate(['/']);

      }
    )
   // console.log(' user ', token);
    // user indefined !!
   /* if (token) {
      localStorage.setItem('token', token.userName);
      this.alertify.success('Login Successful');
      console.log('login Successuful');
      this.router.navigate(['/']);
     }
      else {
       console.log('login not Successful');
       this.alertify.error('User id or password is wrong');

      }
     }*/
    }
  }
