import { Routes } from '@angular/router';
import { EstateListComponent } from './components/estate-list/estate-list.component';
import { EstateCreateComponent } from './components/estate-create/estate-create.component';

export const appRoutes: Routes = [
    {path : '', redirectTo: '/estates', pathMatch: 'full'},
    {path : 'estates', component: EstateListComponent},
    {path : 'estates/create', component: EstateCreateComponent}
];
