import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NzNotificationService } from 'ng-zorro-antd/notification';
import { ApiDataService } from '../api-data.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm!: FormGroup;

  submitForm() {
    if (this.loginForm.valid) {
        this.apiService.login(this.loginForm.controls['email'].value, this.loginForm.controls['password'].value).subscribe((response:any) => {
          if(response.Status == 400){
            this.notification.create(
              'error',
              'Error',
              'Invalid Username/Password'
            )
          } else {
            localStorage.setItem('accessToken', JSON.stringify(response.access_token))
            this.notification.create(
              'success',
              'Success',
              'Logged in Successfully!'
            )
            this.router.navigate(['/dashboard'])
          }
        })
    } else {
      Object.values(this.loginForm.controls).forEach(control => {
        if (control.invalid) {
          control.markAsDirty();
          control.updateValueAndValidity({ onlySelf: true });
        }
      });
    }
  }
  
  constructor(private fb: FormBuilder, private apiService: ApiDataService, private notification: NzNotificationService, private router: Router) { }

  ngOnInit(): void {
    this.loginForm = this.fb.group({
      email: [null, [Validators.email ,Validators.required]],
      password: [null, [Validators.required]],
    });
  }

}
