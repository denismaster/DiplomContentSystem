import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { StagesComponent } from './components/stage.component';
import { StagesAddComponent } from './components/stage-add.component';
import { StagesEditComponent } from './components/stage-edit.component';

const routes: Routes = [
    {
        path: 'stages',
        component: StagesComponent,
    },
    {
        path: 'stages/new',
        component: StagesAddComponent,
    },
    {
        path: 'stages/edit/:id',
        component: StagesEditComponent,
    }
];

export const StagesRoutesModule: ModuleWithProviders = RouterModule.forRoot(routes);