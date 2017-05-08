import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { UsersComponent } from './components/list.component';
import { UsersAddComponent } from './components/add.component';
import { UserService } from './user.service';
import { UserRoutesModule } from './user.routes.module';
import { UsersEditComponent } from './components/edit.component';

/**
 * Do not specify providers for modules that might be imported by a lazy loaded module.
 */

@NgModule({
    imports: [SharedModule,UserRoutesModule],
    declarations: [UsersComponent, UsersAddComponent,UsersEditComponent],
    exports: [UsersComponent, UsersAddComponent, UsersEditComponent],
    providers:[UserService]
})
export class UsersModule { }
