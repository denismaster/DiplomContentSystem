import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TeachersComponent } from './components/list.component';
import { TeachersAddComponent } from './components/add.component';
import { TeachersEditComponent } from './components/edit.component';
import { AuthGuard } from '../shared/auth-guard.service';
const routes: Routes = [
    {
        path: 'teachers',
        component: TeachersComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'teachers/new',
        component: TeachersAddComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'teachers/edit/:id',
        component: TeachersEditComponent,
         canActivate: [AuthGuard]
    }
];

export const TeacherRoutesModule: ModuleWithProviders = RouterModule.forRoot(routes);
