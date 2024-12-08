// import { ReactiveFormsModule } from '@angular/forms';
// import { RouterModule } from '@angular/router';
// import { CommonModule } from '@angular/common';
// import { provideHttpClient} from '@angular/common/http';
// import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

// import { appRoutes } from './app.routes';
// import { EstateService } from '../app/services/estate.service';
// import { NgModule } from '@angular/core';
// import { BrowserModule } from '@angular/platform-browser';

// @NgModule({
//   declarations: [
   
//   ],
//   imports: [
//     BrowserModule,
//     CommonModule,
//     BrowserAnimationsModule,
//     ReactiveFormsModule,
//     RouterModule.forRoot(appRoutes),
//   ],
//   providers: [provideHttpClient(),EstateService],
// })
// export class AppModule { }

import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { provideHttpClient, withInterceptorsFromDi } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { appRoutes } from './app.routes';
import { EstateService } from '../app/services/estate.service';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AuthInterceptor } from './services/interceptors/auth.interceptor'; // Importă interceptorul
import { HTTP_INTERCEPTORS } from '@angular/common/http'; // Importă HTTP_INTERCEPTORS

@NgModule({
  declarations: [],
  imports: [
    BrowserModule,
    CommonModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    RouterModule.forRoot(appRoutes),
  ],
  providers: [
    provideHttpClient(withInterceptorsFromDi()), // Activează suportul pentru interceptori
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true }, // Adaugă interceptorul
    EstateService,
  ],
})
export class AppModule {}
