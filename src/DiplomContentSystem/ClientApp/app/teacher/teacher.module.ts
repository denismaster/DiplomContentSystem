import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { TeachersComponent } from './components/teacher.component';
import { TeachersAddComponent } from './components/teacher-add.component';
import { TeacherService } from './teacher.service';
import { TeacherRoutesModule } from './teacher.routes.module';

/**
 * Do not specify providers for modules that might be imported by a lazy loaded module.
 */

@NgModule({
    imports: [SharedModule,TeacherRoutesModule],
    declarations: [TeachersComponent, TeachersAddComponent],
    exports: [TeachersComponent, TeachersAddComponent],
    providers:[TeacherService]
})
export class TeachersModule { }
