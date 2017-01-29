import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { StudentComponent } from './components/student/student.component';
import { StundentsAddComponent} from './student/components/students-add.component'
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
        path: 'students',
        component: StudentComponent,
    },
    {
        path: 'students/new',
        component: StundentsAddComponent,
    },
    {
        path: '**',
        redirectTo: 'home'
    }
];

export const AppRoutesModule: ModuleWithProviders = RouterModule.forRoot(appRoutes);
