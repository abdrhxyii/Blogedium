import { Routes } from '@angular/router';
import { RegistrationComponent } from './registration/registration.component';
import { HomeComponent } from './home/home.component';
import { AdminformComponent } from './adminform/adminform.component';

export const routes: Routes = [
    {path: '', redirectTo: "", pathMatch: 'full'},
    {path: "login", component: RegistrationComponent},
    {path: "admin", component: AdminformComponent},
    {path: "", component: HomeComponent},

];
