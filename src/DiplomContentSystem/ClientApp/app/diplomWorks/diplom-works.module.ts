import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { DiplomWorksService } from './diplom-works.service';
import { DiplomWorksListComponent } from './components/list.component';
import { DiplomWorksRoutesModule } from './diplom-works.routes.module';
import { DiplomWorkViewComponent } from './components/edit.component';
import { PlagiatComponent } from './components/plagiat.component';


/**
 * Do not specify providers for modules that might be imported by a lazy loaded module.
 */

@NgModule({
    imports: [SharedModule,DiplomWorksRoutesModule],
    declarations: [DiplomWorksListComponent,DiplomWorkViewComponent, PlagiatComponent],
    exports: [DiplomWorksListComponent, DiplomWorkViewComponent, PlagiatComponent],
    providers:[DiplomWorksService]
})
export class DiplomWorksModule { }