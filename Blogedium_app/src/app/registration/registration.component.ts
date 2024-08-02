import { Component } from '@angular/core';
import { FormGroup, ReactiveFormsModule, FormControl, Validators, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-registration',
  standalone: true,
  imports: [
    ReactiveFormsModule,
  ],
  templateUrl: './registration.component.html',
  styleUrl: './registration.component.css'
})
export class RegistrationComponent  {
  formHandle: FormGroup

  isLogin: boolean = false;
  constructor(private fb: FormBuilder){
    this.formHandle = this.fb.group({
      emailaddress: ["", [Validators.required, Validators.email]],
      password: ["", [Validators.required]]
    })
  }

  handleSubmit() {
    if (this.isLogin) {

      // Handle sign-in logic
      console.log('Signing in...');
    } else {
      // Handle sign-up logic
      console.log('Creating account...');
    }
  }

  toggleSignupLogin() {
    this.isLogin = !this.isLogin;
  }

}
