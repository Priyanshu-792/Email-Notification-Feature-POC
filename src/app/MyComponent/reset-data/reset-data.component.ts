
// trying new code
import { Component } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-reset-data',
  templateUrl: './reset-data.component.html',
  styleUrls: ['./reset-data.component.css']
})
export class ResetDataComponent {
  resetData = {
    email: '',
    newPassword: '',
    confirmPassword: ''
  };
  error: string = '';

  constructor(private http: HttpClient) {}

  submitForm() {
    if (this.resetData.newPassword !== this.resetData.confirmPassword) {
      this.error = 'Passwords do not match. Please enter the same password in both fields.';
    } else {
      // this.error = ''; // Clear error message if passwords match
      this.http.post<any>('https://localhost:7266/api/ResetPassword', this.resetData)
        .subscribe(
          response => {
            console.log('Password reset email sent successfully:', response);
            
          },
          error => {
            console.error('Password-reset failed:', error);
            // Handle registration failure, show error message, etc.
          }
    
        );
        alert('Password reset email sent successfully.');
    }
  }

}
