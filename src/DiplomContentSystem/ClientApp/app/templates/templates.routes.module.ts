import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TemplatesComponent } from './components/list.component';
import { TemplatesAddComponent } from './components/add.component';
import { TemplatesEditComponent } from './components/edit.component';
import { AuthGuard } from '../shared/auth-guard.service';
const routes: Routes = [
    {
        path: 'templates',
        component: TemplatesComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'templates/new',
        component: TemplatesAddComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'templates/edit/:id',
        component: TemplatesEditComponent,
         canActivate: [AuthGuard]
    }
];

export const TemplateRoutesModule: ModuleWithProviders = RouterModule.forRoot(routes);
