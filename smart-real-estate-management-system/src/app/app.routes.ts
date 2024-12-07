import { Routes } from '@angular/router';
import { EstateListComponent } from './components/estate-list/estate-list.component';
import { EstateCreateComponent } from './components/estate-create/estate-create.component';
import { EstateUpdateComponent } from './components/estate-update/estate-update.component';
import { EstateDetailComponent } from './components/estate-detail/estate-detail.component';

export const appRoutes: Routes = [
    {path : '', redirectTo: '/estates/paginated', pathMatch: 'full'},
    {path : 'estates/paginated', component: EstateListComponent},
    {path : 'estates/create', component: EstateCreateComponent},
    {path : 'estates/update/:id', component: EstateUpdateComponent},
    {path : 'estates/detail/:id', component: EstateDetailComponent}
];
