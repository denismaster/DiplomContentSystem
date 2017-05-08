import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SpecialitiesComponent } from './components/list.component';
import { SpecialityAddComponent } from './components/add.component';
import { SpecialityEditComponent } from './components/edit.component';
import { AuthGuard } from '../shared/auth-guard.service';
const routes: Routes = [
    {
        path: 'specialities',
        component: SpecialitiesComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'specialities/new',
        component: SpecialityAddComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'specialities/edit/:id',
        component: SpecialityEditComponent,
        canActivate: [AuthGuard]
    }
];

export const SpecialityRoutesModule: ModuleWithProviders = RouterModule.forRoot(routes);
