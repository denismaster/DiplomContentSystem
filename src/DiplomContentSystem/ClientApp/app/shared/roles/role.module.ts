import { NgModule, ModuleWithProviders } from '@angular/core';
import { RoleService } from './role-service';
import { RoleAdminComponent } from './components/role-admin.component';
import { CommonModule } from '@angular/common';
import { RoleStudentComponent } from './components/role-student.component';
/**
 * Do not specify providers for modules that might be imported by a lazy loaded module.
 */

@NgModule({
    imports:[CommonModule],
    declarations: [RoleAdminComponent,RoleStudentComponent],
    exports: [RoleAdminComponent,RoleStudentComponent],
    providers: [RoleService]
})
export class RoleModule {
    static forRoot(): ModuleWithProviders {
        return {
            ngModule: RoleModule,
            providers: []
        };
    }
}