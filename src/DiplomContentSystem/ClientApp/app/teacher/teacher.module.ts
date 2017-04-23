import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { TeachersComponent } from './components/list.component';
import { TeachersAddComponent } from './components/add.component';
import { TeacherService } from './teacher.service';
import { TeacherRoutesModule } from './teacher.routes.module';
import { TeachersEditComponent } from './components/edit.component';

/**
 * Do not specify providers for modules that might be imported by a lazy loaded module.
 */

@NgModule({
    imports: [SharedModule,TeacherRoutesModule],
    declarations: [TeachersComponent, TeachersAddComponent,TeachersEditComponent],
    exports: [TeachersComponent, TeachersAddComponent, TeachersEditComponent],
    providers:[TeacherService]
})
export class TeachersModule { }
