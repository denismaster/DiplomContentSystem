import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { StudentComponent } from './components/student.component';
import { StudentAddComponent } from './components/add.component';

const routes: Routes = [
    {
        path: 'students',
        component: StudentComponent,
    },
    {
        path: 'students/new',
        component: StudentAddComponent,
    },
    /*{
        path: 'students/edit/:id',
        component: TeachersEditComponent,
    }*/
];

export const StudentsRoutesModule: ModuleWithProviders = RouterModule.forRoot(routes);