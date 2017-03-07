import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { SignInComponent } from './login/components/sign-in.component';
const appRoutes: Routes = [
    {
        path: '',
        redirectTo: '/home',
        pathMatch: 'full'
    },
    {
        path: 'home',
        component: HomeComponent,
    },
    {
        path: 'login',
        component: SignInComponent,
    },
    {
        path: '**',
        redirectTo: 'home'
    }
];

export const AppRoutesModule: ModuleWithProviders = RouterModule.forRoot(appRoutes);
