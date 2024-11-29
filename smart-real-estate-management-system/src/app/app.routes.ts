import { Routes } from '@angular/router';
import { EstateListComponent } from './components/estate-list/estate-list.component';
import { EstateCreateComponent } from './components/estate-create/estate-create.component';
import { EstateUpdateComponent } from './components/estate-update/estate-update.component';

export const appRoutes: Routes = [
    {path : '', redirectTo: '/estates', pathMatch: 'full'},
    {path : 'estates', component: EstateListComponent},
    {path : 'estates/create', component: EstateCreateComponent},
    {path : 'estates/update/:id', component: EstateUpdateComponent}
];
