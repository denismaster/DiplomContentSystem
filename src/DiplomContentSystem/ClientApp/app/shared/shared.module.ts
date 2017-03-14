import { NgModule, ModuleWithProviders } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RTModule } from 'right-angled';
import { RouterModule } from '@angular/router';
import { NavMenuComponent } from './navmenu/navmenu.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { LoaderComponent } from './loader/loader.component';
import { ErrorListComponent } from './error-list/error-list.component';
import { TableStateComponent } from './table-state/table-state.component';
import { TablePaginationComponent } from './table-pagination/table-pagination.component';
import { DataService } from './data-service';
import { AuthGuard } from './auth-guard.service';
import { AuthenticationService } from '../login/authentication-service';
/**
 * Do not specify providers for modules that might be imported by a lazy loaded module.
 */

@NgModule({
    imports: [CommonModule, RouterModule, RTModule, ReactiveFormsModule],
    declarations: [NavMenuComponent, SidebarComponent,LoaderComponent,TableStateComponent,TablePaginationComponent, ErrorListComponent],
    exports: [NavMenuComponent, SidebarComponent,TablePaginationComponent,
        CommonModule, FormsModule,RTModule, RouterModule,LoaderComponent,TableStateComponent,
        ErrorListComponent,ReactiveFormsModule],
    providers:[DataService, AuthGuard, AuthenticationService]
})
export class SharedModule {
    static forRoot(): ModuleWithProviders {
        return {
            ngModule: SharedModule,
            providers: []
        };
    }
}