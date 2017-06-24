import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { TemplatesComponent } from './components/list.component';
import { TemplatesAddComponent } from './components/add.component';
import { TemplateService } from './templates.service';
import { TemplateRoutesModule } from './templates.routes.module';
import { TemplatesEditComponent } from './components/edit.component';

/**
 * Do not specify providers for modules that might be imported by a lazy loaded module.
 */

@NgModule({
    imports: [SharedModule,TemplateRoutesModule],
    declarations: [TemplatesComponent, TemplatesAddComponent,TemplatesEditComponent],
    exports: [TemplatesComponent, TemplatesAddComponent, TemplatesEditComponent],
    providers:[TemplateService]
})
export class TemplatesModule { }
