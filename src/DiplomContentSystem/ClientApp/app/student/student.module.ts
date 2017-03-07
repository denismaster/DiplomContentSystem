import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { StudentService } from './student.service';
import { StudentComponent } from './components/student.component';
import { StudentsRoutesModule } from './student.routes.module';

/**
 * Do not specify providers for modules that might be imported by a lazy loaded module.
 */

@NgModule({
    imports: [SharedModule,StudentsRoutesModule],
    declarations: [StudentComponent],
    exports: [StudentComponent],
    providers:[StudentService]
})
export class StudentsModule { }