import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DiplomWorksListComponent } from './components/list.component';

const routes: Routes = [
    {
        path: 'diploms',
        component: DiplomWorksListComponent,
    },
    /*{
        path: 'students/new',
        component: TeachersAddComponent,
    },
    {
        path: 'students/edit/:id',
        component: TeachersEditComponent,
    }*/
];

export const DiplomWorksRoutesModule: ModuleWithProviders = RouterModule.forRoot(routes);