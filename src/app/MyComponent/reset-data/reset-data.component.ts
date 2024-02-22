

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

  constructor(private http: HttpClient) {}

  submitForm() {
    if (this.resetData.newPassword !== this.resetData.confirmPassword) {
      alert('Passwords do not match. Please enter the same password in both fields.');
    
    }
else{
    this.http.post<any>('https://localhost:7266/api/resetpassword', this.resetData)
      .subscribe(
        response => {
          console.log('Password reset email sent successfully:', response);
          alert('Password reset email sent successfully.');
        },
        
      );
}
  }
}
