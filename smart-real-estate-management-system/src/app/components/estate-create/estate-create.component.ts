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


 constructor(private fb:FormBuilder,
             private estateService: EstateService,
             private router: Router
 ) {
  
    this.estateForm= this.fb.group(
      {
        userId: ['', [Validators.required, Validators.pattern('^(?:\\{{0,1}(?:[0-9a-fA-F]){8}-(?:[0-9a-fA-F]){4}-(?:[0-9a-fA-F]){4}-(?:[0-9a-fA-F]){4}-(?:[0-9a-fA-F]){12}\\}{0,1})$')]],
        name:[ '', [Validators.required, Validators.maxLength(100)]],
        description:['', [Validators.required, Validators.maxLength(500)]],
        price: ['', [Validators.required, Validators.min(1)]],
        address:['', [Validators.required, Validators.maxLength(200)]],
        size: ['', [Validators.required, Validators.min(1)]],
        type: ['', [Validators.required, Validators.maxLength(1)]],
        status: ['', [Validators.required, Validators.maxLength(200)]],
        listingData: ['', Validators.required],
     });
 }

 ngOnInit(): void {}

 onSubmit(): void {
   if(this.estateForm.valid){
      const formValue = this.estateForm.value;
      formValue.listingData = new Date(formValue.listingData).toISOString();

      this.estateService.createEstate(formValue).subscribe(()=>{
      this.router.navigate(['/estates/paginated']);
     });
   }

 }

}
