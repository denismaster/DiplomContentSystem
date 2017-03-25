import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions, ResponseContentType } from '@angular/http';
import { Router } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import '../operators.ts';
export class UserAuthModel {
    public Username: string;
    public Token: string;

    constructor(username: string, token: string) {
        this.Username = username;
        this.Token = token;
    }
}
@Injectable()
export class DataService {

    private refreshTokenUrl: string = "api/account/refresh-identity";

    constructor(private http: Http, private router: Router) { }

    public get(uri, headers?: Headers, responseType: ResponseContentType = null) {
        //this.refreshToken();
        return this._get(uri, headers, responseType);
    }

    public post(uri, body: any, headers?: Headers, responseType: ResponseContentType = null) 
    {
      //  this.refreshToken();
        return this._post(uri, body, headers, responseType);
    }

    private _post(uri, body: any, headers?: Headers, responseType?: ResponseContentType) 
    {
        let user: UserAuthModel = this._getCurrentUser();
        if (!user) return Observable.empty();
        headers = headers == null ? new Headers() : headers;
        headers.append('Authorization', 'Bearer ' + user.Token);
        let options = new RequestOptions({ headers: headers });
        if (responseType != null) {
            options.responseType = responseType;
        }

        return this.http.post(uri, body, options)
            .catch(initialError => {
                if (initialError && initialError.status === 403) {
                    this.router.navigate(['/noAccess']);
                }
                if (initialError && initialError.status === 401) {
                    this.router.navigate(['/login']);
                }
                return Observable.throw(initialError);
            });
    }
    private _get(uri, headers?: Headers, responseType?: ResponseContentType) 
    {
        let user: UserAuthModel = this._getCurrentUser();
        if (!user) return Observable.empty();
        headers = headers == null ? new Headers() : headers;
        headers.append('Authorization', 'Bearer ' + user.Token);
        let options = new RequestOptions({ headers: headers });
        if (responseType != null) {
            options.responseType = responseType;
        }

        return this.http.get(uri, options)
            .catch(initialError => {
                if (initialError && initialError.status === 403) {
                    this.router.navigate(['/noAccess']);
                }
                if (initialError && initialError.status === 401) {
                    this.router.navigate(['/login']);
                }
                return Observable.throw(initialError);
            });
    }

    private refreshToken() 
    {
        let user: UserAuthModel = this._getCurrentUser();
        let token = user.Token;
        let headers = new Headers({ 'Content-Type': 'application/json' });
        this._post(this.refreshTokenUrl, JSON.stringify(token), headers, null).
            subscribe(res => {
                user.Token = res.json() && res.json().token;
                localStorage.setItem('currentUser', JSON.stringify(user));
            });
    }

    private _getCurrentUser(): UserAuthModel 
    {
        return <UserAuthModel>JSON.parse(localStorage.getItem('currentUser'));
    }
}