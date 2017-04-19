import { Injectable } from "@angular/core";
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Teacher } from './models/teacher';
import { ServiceBase } from '../shared/service-base';
import { OperationResult } from '../shared/operation-result';
import { ApiService, ApiRoutes } from '../shared/api-service';
import { DataService } from '../shared/data-service';
import { SelectListItem } from '../shared/select-list-item';

@Injectable()
export class TeacherService extends ApiService<Teacher>{
    protected static routes:ApiRoutes = 
    {
        getUrl:"/api/teachers",
        getOneUrl:"/api/teachers/",
        addUrl:"api/teachers/add",
        updateUrl:"/api/teachers/update/",
        deleteUrl:"/api/teachers/delete/"
    }

    constructor(http: DataService)
    {
        super(TeacherService.routes,http);
    }

    public getPositions():Observable<SelectListItem[]>
    {
        return this.http.get("/api/teachers/positions").map(this.extractData);
    }
    public getSpecialities():Observable<SelectListItem[]>
    {
        return this.http.get("/api/specialities").map(this.extractData);
    }
}