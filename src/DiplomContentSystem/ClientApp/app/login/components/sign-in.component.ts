import { Component, Input, OnInit } from '@angular/core';
import { Authentication } from '../models/authentication';
import { Router } from '@angular/router';
import { AuthService } from '../authentication-service';
@Component({
    selector: 'sign-in',
    templateUrl: './sign-in.component.html'
})
export class SignInComponent implements OnInit {
    model: Authentication = new Authentication('', '', false);
    loading = false;
    error = '';

    constructor(
        private router: Router,
        private authenticationService: AuthService) { }

    ngOnInit() {
        this.authenticationService.logout();
    }

    login() {
        this.loading = true;
        this.authenticationService.login(this.model)
            .subscribe(result => {
                if (result === true) {
                    this.router.navigate(['/']);
                } else {
                    this.error = result;
                    this.loading = false;
                }
            });
    }
}