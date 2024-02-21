
import { Component } from '@angular/core';
@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent {
  email: string | undefined;
  password: string="";
  constructor() { }
  register() {
    
    console.log('Registration submitted:', this.email, this.password);
  }
}

