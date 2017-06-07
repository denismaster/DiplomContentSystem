import { Component, OnChanges } from '@angular/core';
import { AuthService } from '../../login/authentication-service';
import { Router } from '@angular/router';

@Component({
    selector: 'nav-menu',
    templateUrl: './navmenu.component.html'
})
export class NavMenuComponent {
    private username: string;

    constructor(private router: Router, private authService: AuthService) { 
        this.checkAuth();
    }

    checkAuth() {
        if (this.authService.isUserAuthenticated()) {
            let user = this.authService.getCurrentUser();
            this.username = user.Username || "";
        }
        else {
            this.username = undefined;
            this.router.navigate(['/login']);
        }
    }

    logout() {
        this.authService.logout();
        this.router.navigate(['/login']);
    }
    
    ngDoCheck() {
        this.checkAuth();
    }
}
