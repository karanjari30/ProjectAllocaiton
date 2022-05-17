import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NzNotificationService } from 'ng-zorro-antd/notification';
import { ApiDataService } from '../api-data.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  validateForm!: FormGroup;
  passwordVisible = false;
  submitForm(): void {
    if (this.validateForm.valid) {
      this.apiService.registerUser.Email = this.validateForm.controls['email'].value;
      this.apiService.registerUser.Password = this.validateForm.controls['password'].value;
      this.apiService.registerUser.ConfirmPassword = this.validateForm.controls['checkPassword'].value;
      this.apiService.register().subscribe((response: any) => {
        if (response == null) {
          this.notification.create(
            'success',
            'Success',
            'Register successfully!'
          )
          this.router.navigate(['/login'])
        }
      })
    } else {
      Object.values(this.validateForm.controls).forEach(control => {
        if (control.invalid) {
          control.markAsDirty();
          control.updateValueAndValidity({ onlySelf: true });
        }
      });
    }
  }

  updateConfirmValidator(): void {
    /** wait for refresh value */
    Promise.resolve().then(() => this.validateForm.controls['checkPassword'].updateValueAndValidity());
  }

  confirmationValidator = (control: FormControl): { [s: string]: boolean } => {
    if (!control.value) {
      return { required: true };
    } else if (control.value !== this.validateForm.controls['password'].value) {
      return { confirm: true, error: true };
    }
    return {};
  };

  constructor(private fb: FormBuilder, private apiService: ApiDataService, private notification: NzNotificationService, private router: Router) { }

  ngOnInit(): void {
    this.validateForm = this.fb.group({
      email: [null, [Validators.email, Validators.required]],
      password: [null, [Validators.required, Validators.pattern('^[A-Z]{1,}[a-z]{5,}[0-9]{1,}[@#$%^&*()!]{1,}')]],
      checkPassword: [null, [Validators.required, this.confirmationValidator]],
    });
  }
}
