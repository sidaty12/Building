import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { User } from 'src/app/model/user';
import { UserServiceService } from 'src/app/services/user-service.service';
import * as alertyfy from 'alertifyjs';
import { AlertifyService } from 'src/app/services/alertify.service';


@Component({
  selector: 'app-user-register',
  templateUrl: './user-register.component.html',
  styleUrls: ['./user-register.component.scss']
})
export class UserRegisterComponent implements OnInit {

  registerationForm: FormGroup;
  user : User;
  userSubmitted: boolean;

  constructor(private fb: FormBuilder, private userService: UserServiceService,
              private alertify: AlertifyService) { }

  ngOnInit() {

     /* this.registerationForm = new FormGroup({
       userName: new FormControl(null, Validators.required),
       email: new FormControl(null, [Validators.required, Validators.email]),
       password: new FormControl(null, [Validators.required, Validators.minLength(8)]),
       confirmPassword: new FormControl(null, [Validators.required]),
       mobile: new FormControl(null, [Validators.required, Validators.maxLength(10)])
      }, this.passwordMatchingValidatior); */

       //this.registerationForm.controls['userName'].setValue('Default Value')

       this.createRegisterationForm();
    }

    createRegisterationForm() {
      this.registerationForm =  this.fb.group({
          userName: [null, Validators.required],
          email: [null, [Validators.required, Validators.email]],
          password: [null, [Validators.required, Validators.minLength(8)]],
          confirmPassword: [null, Validators.required],
          mobile: [null, [Validators.required, Validators.maxLength(10)]]
      }, {validators: this.passwordMatchingValidatior});
  }


 /* onSubmit(){
    console.log(this.registerationForm);
  }  */

  passwordMatchingValidatior(fg: FormGroup): Validators {
    return fg.get('password').value === fg.get('confirmPassword').value ? null :
        {notmatched: true};
}
  // Getter methods for all form controls
    // ------------------------------------
    get userName() {
      return this.registerationForm.get('userName') as FormControl;
  }

  get email() {
      return this.registerationForm.get('email') as FormControl;
  }
  get password() {
      return this.registerationForm.get('password') as FormControl;
  }
  get confirmPassword() {
      return this.registerationForm.get('confirmPassword') as FormControl;
  }
  get mobile() {
      return this.registerationForm.get('mobile') as FormControl;
  }
  // ------------------------

  onSubmit(){
    console.log(this.registerationForm.value);
    this.userSubmitted = true;
    // if we d'ont put anythig in the forms, our list still the same
if (this.registerationForm.valid){

  //this.user = Object.assign(this.user, this.registerationForm.value);
  this.userService.addUser(this.userData());
    // remove value putting in forms after submit it
  this.registerationForm.reset();
  this.userSubmitted = false;
  this.alertify.success('Congrats, you are successfully registered');

} else {
  this.alertify.error('Kindly provide the required fields');
}


  }


  userData(): User {
    return this.user = {
        userName: this.userName.value,
        email: this.email.value,
        password: this.password.value,
        mobile: this.mobile.value
    };
}

}
