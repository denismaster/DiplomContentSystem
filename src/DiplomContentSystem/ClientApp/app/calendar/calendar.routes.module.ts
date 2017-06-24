import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CalendarsComponent } from './components/list.component';
import { CalendarAddComponent } from './components/add.component';
import { CalendarEditComponent } from './components/edit.component';
import { AuthGuard } from '../shared/auth-guard.service';
const routes: Routes = [
    {
        path: 'calendar/:id',
        component: CalendarsComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'calendar/new',
        component: CalendarAddComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'calendar/edit/:id',
        component: CalendarEditComponent,
        canActivate: [AuthGuard]
    }
];

export const CalendarRoutesModule: ModuleWithProviders = RouterModule.forRoot(routes);
