
// Matching the password and then register
import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent {

  constructor(private http: HttpClient, private router:Router) {}
resetData() {
this.router.navigate(['/ResetPassword']);
}
  formData: any = {};
  passwordMatchError: boolean = false;


  submitForm() {
    // Check if passwords match
    if (this.formData.password !== this.formData.confirmPassword) {
      // Passwords do not match, set error flag and return
      alert("Passwords do not match. Please enter the same password in both fields.");
      return; // Exit the method
    }

    // Passwords match, proceed with registration
    this.http.post<any>('https://localhost:7266/api/Email/sendConfirmation', this.formData)
      .subscribe(
        response => {
          console.log('Registration successful:', response);
          // Optionally, you can show a success message or redirect the user to another page
        },
        error => {
          console.error('Registration failed:', error);
          // Handle registration failure, show error message, etc.
        }
      );

      alert("Successfully Registered");
  }
}
