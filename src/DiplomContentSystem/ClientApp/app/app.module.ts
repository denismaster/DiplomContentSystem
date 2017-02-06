import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { UniversalModule } from 'angular2-universal';
import { AppComponent } from './app.component'
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { StudentComponent } from './components/student/student.component';
import { AppRoutesModule } from './app-route.module';
import { SharedModule } from './shared/shared.module';
import { TeacherService } from './teacher/teacher.service';
import { TeachersModule } from './teacher/teacher.module';
import { StundentsAddComponent} from './student/components/students-add.component'
@NgModule({
    bootstrap: [ AppComponent ],
    declarations: [
        AppComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        StudentComponent,
        StundentsAddComponent
    ],
    imports: [
        UniversalModule, // Must be first import. This automatically imports BrowserModule, HttpModule, and JsonpModule too.
        AppRoutesModule,
        SharedModule,
        TeachersModule
    ],
})
export class AppModule {
}
