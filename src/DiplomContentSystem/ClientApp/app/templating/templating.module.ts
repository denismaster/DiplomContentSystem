import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { NewTemplateComponent } from './components/new-template.component';
import { TemplatingRoutesModule } from './templating.routes.module';

/**
 * Do not specify providers for modules that might be imported by a lazy loaded module.
 */

@NgModule({
    imports: [SharedModule,TemplatingRoutesModule],
    declarations: [NewTemplateComponent],
    exports: [NewTemplateComponent]
})
export class TemplatingModule { }