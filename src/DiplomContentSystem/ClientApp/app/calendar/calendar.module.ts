import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { CalendarsComponent } from './components/list.component';
import { CalendarAddComponent } from './components/add.component';
import { CalendarService } from './calendar.service';
import { CalendarRoutesModule } from './calendar.routes.module';
import { CalendarEditComponent } from './components/edit.component';

/**
 * Do not specify providers for modules that might be imported by a lazy loaded module.
 */

@NgModule({
    imports: [SharedModule,CalendarRoutesModule],
    declarations: [CalendarsComponent, CalendarAddComponent,CalendarEditComponent],
    exports: [CalendarsComponent, CalendarAddComponent, CalendarEditComponent],
    providers:[CalendarService]
})
export class CalendarModule { }
