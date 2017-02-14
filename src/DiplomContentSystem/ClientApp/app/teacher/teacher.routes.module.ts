import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TeachersComponent } from './components/teacher.component';
import { TeachersAddComponent } from './components/teacher-add.component';
import { TeachersEditComponent } from './components/teacher-edit.component';
const routes: Routes = [
    {
        path: 'teachers',
        component: TeachersComponent,
    },
    {
        path: 'teachers/new',
        component: TeachersAddComponent,
    },
    {
        path: 'teachers/edit/:id',
        component: TeachersEditComponent,
    }
];

export const TeacherRoutesModule: ModuleWithProviders = RouterModule.forRoot(routes);
