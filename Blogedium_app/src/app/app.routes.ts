import { Routes } from '@angular/router';
import { RegistrationComponent } from './registration/registration.component';

export const routes: Routes = [
    {path: '', redirectTo: "/login", pathMatch: 'full'},
    {path: "login", component: RegistrationComponent}
];
