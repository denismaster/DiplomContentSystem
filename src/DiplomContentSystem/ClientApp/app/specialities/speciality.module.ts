import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { SpecialitiesComponent } from './components/list.component';
import { SpecialityAddComponent } from './components/add.component';
import { SpecialityService } from './speciality.service';
import { SpecialityRoutesModule } from './speciality.routes.module';
import { SpecialityEditComponent } from './components/edit.component';

/**
 * Do not specify providers for modules that might be imported by a lazy loaded module.
 */

@NgModule({
    imports: [SharedModule,SpecialityRoutesModule],
    declarations: [SpecialitiesComponent, SpecialityAddComponent,SpecialityEditComponent],
    exports: [SpecialitiesComponent, SpecialityAddComponent, SpecialityEditComponent],
    providers:[SpecialityService]
})
export class SpecialityModule { }
