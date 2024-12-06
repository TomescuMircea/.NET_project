import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { EstateService } from '../../services/estate.service';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-estate-create',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './estate-create.component.html',
  styleUrl: './estate-create.component.css'
})
export class EstateCreateComponent implements OnInit{

  estateForm: FormGroup;


 constructor(private readonly fb:FormBuilder,
             private readonly estateService: EstateService,
             private readonly router: Router
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
   if(this.estateForm.valid){
      const formValue = this.estateForm.value;
      formValue.userId = '18079d7f-3f19-4b9f-b7ea-c4c7bd2b8e37';
      formValue.listingData = new Date().toISOString();

      this.estateService.createEstate(formValue).subscribe(()=>{
      this.router.navigate(['/estates/paginated']);
     });
   }

 }

}
