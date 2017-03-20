import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { NewTemplateComponent } from './components/new-template.component';
const routes: Routes = [
    {
        path: 'templates/new',
        component: NewTemplateComponent,
    }
];

export const TemplatingRoutesModule: ModuleWithProviders = RouterModule.forRoot(routes);