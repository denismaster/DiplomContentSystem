import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DiplomWorksListComponent } from './components/list.component';
import { DiplomWorkViewComponent } from './components/edit.component';

const routes: Routes = [
    {
        path: 'diploms',
        component: DiplomWorksListComponent,
    },
    {
        path: 'diploms/view/:id',
        component: DiplomWorkViewComponent,
    },
    /*
    {
        path: 'students/edit/:id',
        component: TeachersEditComponent,
    }*/
];

export const DiplomWorksRoutesModule: ModuleWithProviders = RouterModule.forRoot(routes);