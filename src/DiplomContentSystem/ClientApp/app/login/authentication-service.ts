import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import "../operators.ts"
import { Authentication } from './models/authentication';
import { UserAuthModel } from '../shared/data-service';


@Injectable()
export class AuthenticationService {

    constructor(private http: Http) { }

    login(model: Authentication): Observable<any> {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        return this.http.post("api/account/login", JSON.stringify({ Username: model.login, Password: model.password, RememberMe: model.remember }), options)
            .map((response: Response) => {
                let token = response.json() && response.json().token;              
                if (token) {
                    localStorage.setItem('currentUser', JSON.stringify(new UserAuthModel(model.login, token)));
                    return true;
                } else {
                    return response.json().message;
                }
            });
    }

    getCurrentUser(): UserAuthModel {
        return <UserAuthModel>JSON.parse(localStorage.getItem('currentUser'));
    }

    logout() {
        localStorage.removeItem('currentUser');
    }

    isUserAuthenticated(): boolean {
        let user = this.getCurrentUser();
        if (user != null)
            return true;
        else
            return false;
    }
}