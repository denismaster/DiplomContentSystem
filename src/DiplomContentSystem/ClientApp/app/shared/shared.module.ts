import { NgModule, ModuleWithProviders } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RTModule } from 'right-angled';
import { ChartsModule } from 'ng2-charts';
import { RouterModule } from '@angular/router';
import { NavMenuComponent } from './navmenu/navmenu.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { LoaderComponent } from './loader/loader.component';
import { ErrorListComponent } from './error-list/error-list.component';
import { TableStateComponent } from './table-state/table-state.component';
import { TablePaginationComponent } from './table-pagination/table-pagination.component';
import { DataService } from './data-service';
import { AuthGuard } from './auth-guard.service';
import { AuthService } from '../login/authentication-service';
import { JwtHelper } from './services/jwt-helper';
import { RoleModule } from './roles/role.module';
import { CommentsComponent } from './comments/comments.component';
/**
 * Do not specify providers for modules that might be imported by a lazy loaded module.
 */

@NgModule({
    imports: [CommonModule, RouterModule, RTModule, ChartsModule, FormsModule, ReactiveFormsModule, RoleModule],
    declarations: [NavMenuComponent, SidebarComponent, LoaderComponent, TableStateComponent, TablePaginationComponent, ErrorListComponent, CommentsComponent,],
    exports: [NavMenuComponent, SidebarComponent, TablePaginationComponent,
        CommonModule, FormsModule, RTModule, ChartsModule, RouterModule, RoleModule, LoaderComponent, TableStateComponent,
        ErrorListComponent, CommentsComponent, ReactiveFormsModule],
    providers: [DataService, AuthGuard, AuthService, JwtHelper]
})
export class SharedModule {
    static forRoot(): ModuleWithProviders {
        return {
            ngModule: SharedModule,
            providers: []
        };
    }
}