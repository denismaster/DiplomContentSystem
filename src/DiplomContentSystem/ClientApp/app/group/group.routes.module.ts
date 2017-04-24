import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { GroupsComponent } from './components/list.component';
import { GroupAddComponent } from './components/add.component';
import { GroupEditComponent } from './components/edit.component';
import { AuthGuard } from '../shared/auth-guard.service';
const routes: Routes = [
    {
        path: 'groups',
        component: GroupsComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'groups/new',
        component: GroupAddComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'groups/edit/:id',
        component: GroupEditComponent,
         canActivate: [AuthGuard]
    }
];

export const GroupRoutesModule: ModuleWithProviders = RouterModule.forRoot(routes);
