import { Injectable } from "@angular/core";
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Template } from './models/template';
import { ServiceBase } from '../shared/service-base';
import { OperationResult } from '../shared/operation-result';
import { ApiService, ApiRoutes } from '../shared/api-service';
import { DataService } from '../shared/data-service';
import { SelectListItem } from '../shared/select-list-item';

@Injectable()
export class TemplateService extends ApiService<Template>{
    protected static routes:ApiRoutes = 
    {
        getUrl:"/api/templates",
        getOneUrl:"/api/templates/",
        addUrl:"api/templates/add",
        updateUrl:"/api/templates/update/",
        deleteUrl:"/api/templates/delete/"
    }

    constructor(http: DataService)
    {
        super(TemplateService.routes,http);
    }

    public getPositions():Observable<SelectListItem[]>
    {
        return this.http.get("/api/templates/positions").map(this.extractData);
    }
    public getDepartments():Observable<SelectListItem[]>
    {
        return this.http.get("/api/departments/select-list").map(this.extractData);
    }
}