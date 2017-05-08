import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UsersComponent } from './components/list.component';
import { UsersAddComponent } from './components/add.component';
import { UsersEditComponent } from './components/edit.component';
import { AuthGuard } from '../shared/auth-guard.service';
const routes: Routes = [
    {
        path: 'users',
        component: UsersComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'users/new',
        component: UsersAddComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'users/edit/:id',
        component: UsersEditComponent,
         canActivate: [AuthGuard]
    }
];

export const UserRoutesModule: ModuleWithProviders = RouterModule.forRoot(routes);
