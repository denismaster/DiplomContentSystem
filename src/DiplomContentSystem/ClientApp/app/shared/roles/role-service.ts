import { Injectable } from '@angular/core';
import { Role } from './roles';
import { UserAuthModel } from '../data-service';
import { JwtHelper } from '../services/jwt-helper';

@Injectable()
export class RoleService {
    constructor(private jwtService:JwtHelper) { }

    private matchRole(role: string): Role {
        switch (role) {
            case "Admin": return Role.Admin;
            case "Student": return Role.Student;
            case "Teacher": return Role.Teacher;
            case "Owner": return Role.Owner;
            default: return undefined;
        }
    }

    public getRole(): Role {
        let authStr = localStorage.getItem("currentUser");
        let authData: UserAuthModel = authStr ? JSON.parse(authStr) : null;

        if(!authData) return undefined;

        return this.matchRole(this.jwtService.getRoles(authData.Token)[0])
    }
}