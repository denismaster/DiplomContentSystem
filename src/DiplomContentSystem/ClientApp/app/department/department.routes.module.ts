import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DepartmentsComponent } from './components/list.component';
import { DepartmentAddComponent } from './components/add.component';
import { DepartmentEditComponent } from './components/edit.component';
import { AuthGuard } from '../shared/auth-guard.service';
const routes: Routes = [
    {
        path: 'departments',
        component: DepartmentsComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'departments/new',
        component: DepartmentAddComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'departments/edit/:id',
        component: DepartmentEditComponent,
        canActivate: [AuthGuard]
    }
];

export const DepartmentRoutesModule: ModuleWithProviders = RouterModule.forRoot(routes);
