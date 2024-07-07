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

  handleSignup(){
    console.log("clicked")
  }

}
