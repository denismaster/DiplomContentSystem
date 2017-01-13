﻿import { NgModule, ModuleWithProviders } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RTModule } from 'right-angled';
import { RouterModule } from '@angular/router';
import { NavMenuComponent } from './navmenu/navmenu.component';
import { SidebarComponent } from './sidebar/sidebar.component';
/**
 * Do not specify providers for modules that might be imported by a lazy loaded module.
 */

@NgModule({
    imports: [CommonModule, RouterModule, RTModule, ReactiveFormsModule],
    declarations: [NavMenuComponent, SidebarComponent],
    exports: [NavMenuComponent, SidebarComponent,
        CommonModule, FormsModule,RTModule, RouterModule, ReactiveFormsModule]
})
export class SharedModule {
    static forRoot(): ModuleWithProviders {
        return {
            ngModule: SharedModule,
            providers: []
        };
    }
}