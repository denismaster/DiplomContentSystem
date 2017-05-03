import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { DepartmentsComponent } from './components/list.component';
import { DepartmentAddComponent } from './components/add.component';
import { DepartmentService } from './department.service';
import { DepartmentRoutesModule } from './department.routes.module';
import { DepartmentEditComponent } from './components/edit.component';

/**
 * Do not specify providers for modules that might be imported by a lazy loaded module.
 */

@NgModule({
    imports: [SharedModule,DepartmentRoutesModule],
    declarations: [DepartmentsComponent, DepartmentAddComponent,DepartmentEditComponent],
    exports: [DepartmentsComponent, DepartmentAddComponent, DepartmentEditComponent],
    providers:[DepartmentService]
})
export class DepartmentModule { }
