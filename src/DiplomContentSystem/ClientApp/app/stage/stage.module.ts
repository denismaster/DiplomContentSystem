import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { StageService } from './stage.service';
import { StagesComponent } from './components/stage.component';
import { StagesAddComponent } from './components/stage-add.component';
import { StagesEditComponent } from './components/stage-edit.component';
import { StagesRoutesModule } from './stage.routes.module';

@NgModule({
    imports: [SharedModule, StagesRoutesModule],
    declarations: [StagesComponent, StagesAddComponent, StagesEditComponent],
    exports: [StagesComponent, StagesAddComponent, StagesEditComponent],
    providers: [StageService]
})
export class StagesModule { }