import { Injectable } from "@angular/core";
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Department } from './models/department';
import { ServiceBase } from '../shared/service-base';
import { OperationResult } from '../shared/operation-result';
import { ApiService, ApiRoutes } from '../shared/api-service';
import { DataService } from '../shared/data-service';
import { SelectListItem } from '../shared/select-list-item';

@Injectable()
export class DepartmentService extends ApiService<Department>{
    protected static routes:ApiRoutes = 
    {
        getUrl:"/api/departments",
        getOneUrl:"/api/departments/",
        addUrl:"api/departments/add",
        updateUrl:"/api/departments/update/",
        deleteUrl:"/api/departments/delete/"
    }

    constructor(http: DataService)
    {
        super(DepartmentService.routes,http);
    }

    public getSpecialities():Observable<SelectListItem[]>
    {
        return this.http.get("/api/specialities/select-list").map(this.extractData);
    }
}