import { Component } from '@angular/core';

@Component({
  selector: 'app-registration',
  standalone: true,
  imports: [],
  templateUrl: './registration.component.html',
  styleUrl: './registration.component.css'
})
export class RegistrationComponent {

  isLogin: boolean = false;

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
