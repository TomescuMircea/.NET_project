import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { EstateService } from '../../services/estate.service';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-estate-create',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './estate-create.component.html',
  styleUrl: './estate-create.component.css'
})
export class EstateCreateComponent implements OnInit{

  estateForm: FormGroup;
  errorMessage: string = '';


 constructor(private readonly fb:FormBuilder,
             private readonly estateService: EstateService,
             private readonly router: Router,
             private readonly userService: UserService
 ) {
    this.estateForm= this.fb.group(
      {
        name:[ '', [Validators.required, Validators.maxLength(100)]],
        description:['', [Validators.required, Validators.maxLength(500)]],
        price: ['', [Validators.required, Validators.min(1)]],
        address:['', [Validators.required, Validators.maxLength(200)]],
        size: ['', [Validators.required, Validators.min(1)]],
        type: ['', [Validators.required, Validators.maxLength(1)]],
        status: ['', [Validators.required, Validators.maxLength(100)]],
     });
 }

 ngOnInit(): void {
  this.estateForm.reset();
 }


 onSubmit(): void {
  if (this.estateForm.valid) {
    const formValue = this.estateForm.value;

  
   const userId=this.userService.getUserId();

    // Verifică dacă UserId este extras
    if (userId) {
      formValue.userId = userId;
    } else {
      this.errorMessage = 'You must log in.';
      console.error(this.errorMessage);
      return;
    }

    // Adaugă data curentă
    formValue.listingData = new Date().toISOString();

    console.log('Form data:', formValue);

    // Trimite cererea la API
    this.estateService.createEstate(formValue).subscribe(() => {
      this.router.navigate(['/estates/paginated']);
    });
  }
}

 
}

