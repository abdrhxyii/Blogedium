import { Routes } from '@angular/router';
import { RegistrationComponent } from './registration/registration.component';
import { HomeComponent } from './home/home.component';

export const routes: Routes = [
    {path: '', redirectTo: "", pathMatch: 'full'},
    {path: "login", component: RegistrationComponent},
    {path: "", component: HomeComponent},
];
