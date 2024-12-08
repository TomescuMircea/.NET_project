import { Routes } from '@angular/router';
import { EstateListComponent } from './components/estate-list/estate-list.component';
import { EstateCreateComponent } from './components/estate-create/estate-create.component';
import { EstateUpdateComponent } from './components/estate-update/estate-update.component';
import { EstateDetailComponent } from './components/estate-detail/estate-detail.component';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';

export const appRoutes: Routes = [
    {path : '', component: HomeComponent},
    {path : 'login', component: LoginComponent},
    {path : 'register', component: RegisterComponent},
    {path : 'estates/filter/paginated', component: EstateListComponent},
    {path : 'estates/create', component: EstateCreateComponent},
    {path : 'estates/update/:id', component: EstateUpdateComponent},
    {path : 'estates/detail/:id', component: EstateDetailComponent}

];
