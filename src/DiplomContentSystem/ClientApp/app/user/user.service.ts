import { Injectable } from "@angular/core";
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { User } from './models/user';
import { ServiceBase } from '../shared/service-base';
import { OperationResult } from '../shared/operation-result';
import { ApiService, ApiRoutes } from '../shared/api-service';
import { DataService } from '../shared/data-service';
import { SelectListItem } from '../shared/select-list-item';

@Injectable()
export class UserService extends ApiService<User>{
    protected static routes:ApiRoutes = 
    {
        getUrl:"/api/users",
        getOneUrl:"/api/users/",
        addUrl:"api/users/add",
        updateUrl:"/api/users/update/",
        deleteUrl:"/api/users/delete/"
    }

    constructor(http: DataService)
    {
        super(UserService.routes,http);
    }

    public getPositions():Observable<SelectListItem[]>
    {
        return this.http.get("/api/users/positions").map(this.extractData);
    }
    public getDepartments():Observable<SelectListItem[]>
    {
        return this.http.get("/api/departments/select-list").map(this.extractData);
    }
}