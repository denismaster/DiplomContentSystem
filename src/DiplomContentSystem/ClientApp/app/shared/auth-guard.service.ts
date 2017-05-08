import { Injectable } from '@angular/core';
import { Router, CanActivate } from '@angular/router';
import { JwtHelper } from './services/jwt-helper';
import { UserAuthModel } from './data-service';

@Injectable()
export class AuthGuard implements CanActivate {

    constructor(private router: Router, private jwtService: JwtHelper) { }

    canActivate() {
        let authStr = localStorage.getItem("currentUser");
        let authData: UserAuthModel = authStr ? JSON.parse(authStr) : null;

        if (!authData || this.jwtService.isTokenExpired(authData.Token)) {
            // not logged in so redirect to login page
            this.router.navigate(['/login']);
            return false;
        }

        let roles = this.jwtService.getRoles(authData.Token);
        return true;
    }
}