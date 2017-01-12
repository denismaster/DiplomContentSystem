import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { TeachersComponent } from './teacher/components/teacher.component';
import { StudentComponent } from './components/student/student.component';

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
        path: 'teachers',
        component: TeachersComponent,
    },
    {
        path: 'students',
        component: StudentComponent,
    },
    {
        path: '**',
        redirectTo: 'home'
    }
];

export const AppRoutesModule: ModuleWithProviders = RouterModule.forRoot(appRoutes);
