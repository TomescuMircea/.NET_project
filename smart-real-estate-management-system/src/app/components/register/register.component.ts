import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { UserService } from '../../services/user.service';
import { Router } from '@angular/router';
import { PasswordMatchValidator } from './password-match.validator';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit 
{
  registerForm: FormGroup;

  constructor(private fb: FormBuilder, private readonly userService: UserService,
    private readonly router: Router,) 
    {
      this.registerForm = this.fb.group({
        firstName: ['', [Validators.required, Validators.maxLength(100)]],
        lastName: ['', [Validators.required, Validators.maxLength(100)]],
        userName: ['', [Validators.required, Validators.maxLength(100)]],
        email: ['', [Validators.required, Validators.email]],
        password: ['', [Validators.required, Validators.minLength(6)]],
        confirmPassword: ['', [Validators.required, Validators.minLength(6)]]
      }, {
        validator: PasswordMatchValidator('password', 'confirmPassword')
      });
    }

  ngOnInit(): void {
    
  }

  onSubmit(): void {
    if (this.registerForm.valid) {
      console.log(this.registerForm.value);
      this.userService.register(this.registerForm.value).subscribe((response) => {
        console.log(response);
        localStorage.setItem('userId', JSON.stringify(response));
        this.router.navigate(['']);
      });

      // this.userService.register(this.registerForm.value).subscribe(() => {
      //   this.router.navigate(['']);
      // });
    }
  }
}