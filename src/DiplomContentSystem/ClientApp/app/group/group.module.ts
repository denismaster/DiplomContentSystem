import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { GroupsComponent } from './components/list.component';
import { GroupAddComponent } from './components/add.component';
import { GroupService } from './group.service';
import { GroupRoutesModule } from './group.routes.module';
import { GroupEditComponent } from './components/edit.component';

/**
 * Do not specify providers for modules that might be imported by a lazy loaded module.
 */

@NgModule({
    imports: [SharedModule,GroupRoutesModule],
    declarations: [GroupsComponent, GroupAddComponent,GroupEditComponent],
    exports: [GroupsComponent, GroupAddComponent, GroupEditComponent],
    providers:[GroupService]
})
export class GroupModule { }
