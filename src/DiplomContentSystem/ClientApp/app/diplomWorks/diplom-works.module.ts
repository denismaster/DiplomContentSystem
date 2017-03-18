import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { DiplomWorksService } from './diplom-works.service';
import { DiplomWorksListComponent } from './components/list.component';
import { DiplomWorksRoutesModule } from './diplom-works.routes.module';


/**
 * Do not specify providers for modules that might be imported by a lazy loaded module.
 */

@NgModule({
    imports: [SharedModule,DiplomWorksRoutesModule],
    declarations: [DiplomWorksListComponent],
    exports: [DiplomWorksListComponent],
    providers:[DiplomWorksService]
})
export class DiplomWorksModule { }