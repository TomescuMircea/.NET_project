import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { EstateService } from '../../services/estate.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-estate-update',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './estate-update.component.html',
  styleUrl: './estate-update.component.css'
})
export class EstateUpdateComponent implements OnInit 
{
  estateForm: FormGroup;

  constructor(
    private readonly fb: FormBuilder,
    private readonly estateService: EstateService,
    private readonly router: Router,
    private readonly route: ActivatedRoute

  ) {
    this.estateForm = this.fb.group({
      userId: ['', [Validators.required, Validators.pattern('^(?:\\{{0,1}(?:[0-9a-fA-F]){8}-(?:[0-9a-fA-F]){4}-(?:[0-9a-fA-F]){4}-(?:[0-9a-fA-F]){4}-(?:[0-9a-fA-F]){12}\\}{0,1})$')]],
      name: ['', [Validators.required, Validators.maxLength(100)]],
      description: ['', [Validators.required, Validators.maxLength(500)]],
      price: ['', [Validators.required, Validators.min(1)]],
      address: ['', [Validators.required, Validators.maxLength(200)]],
      size: ['', [Validators.required, Validators.min(1)]],
      type: ['', [Validators.required, Validators.maxLength(1)]],
      status: ['', [Validators.required, Validators.maxLength(100)]],
      id: ['', [Validators.required, Validators.pattern('^(?:\\{{0,1}(?:[0-9a-fA-F]){8}-(?:[0-9a-fA-F]){4}-(?:[0-9a-fA-F]){4}-(?:[0-9a-fA-F]){4}-(?:[0-9a-fA-F]){12}\\}{0,1})$')]]
    });
  }

  ngOnInit(): void {
    const estateId = this.route.snapshot.paramMap.get('id');
  if (estateId) {
    this.estateService.getEstateById(estateId).subscribe(data => {
      console.log("Update: ", data);
      this.estateForm.patchValue(data);
    });
  }
  }

  onSubmit(): void {
    if (this.estateForm.valid) {
      const formValue = this.estateForm.value;
      formValue.listingData = new Date().toISOString();

      this.estateService.updateEstate(formValue).subscribe(() => {
        this.router.navigate(['/estates/paginated']);
      });
    }
  }
}
