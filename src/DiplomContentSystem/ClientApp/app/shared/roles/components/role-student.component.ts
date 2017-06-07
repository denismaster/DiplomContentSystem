import { Component, KeyValueDiffers } from '@angular/core';
import { RoleComponentBase } from './role.component.base';
import { RoleService } from '../role-service';
import { Role } from '../roles';

@Component({
    selector: 'role-student',
    template: `<ng-content *ngIf="isVisible"></ng-content>`
})
export class RoleStudentComponent extends RoleComponentBase {
    constructor(service:RoleService) {
        super(service, Role.Student);
    }
}