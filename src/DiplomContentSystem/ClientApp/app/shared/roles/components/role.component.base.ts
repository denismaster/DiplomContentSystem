import { OnInit } from '@angular/core';
import { Role } from '../roles';
import { RoleService } from '../role-service';
export abstract class RoleComponentBase implements OnInit {
    public isVisible: boolean;
    private role: Role
    constructor(protected service: RoleService, role: Role) {
        this.role = role;
    }
    public ngOnInit(): void {
        this.setVisibility();
    }

    protected setVisibility(): void {
        this.isVisible = this.service.getRole()===this.role;
    }
}