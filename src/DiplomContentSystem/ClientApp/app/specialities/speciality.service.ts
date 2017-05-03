import { Injectable } from "@angular/core";
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Speciality } from './models/speciality';
import { ServiceBase } from '../shared/service-base';
import { OperationResult } from '../shared/operation-result';
import { ApiService, ApiRoutes } from '../shared/api-service';
import { DataService } from '../shared/data-service';
import { SelectListItem } from '../shared/select-list-item';

@Injectable()
export class SpecialityService extends ApiService<Speciality>{
    protected static routes:ApiRoutes = 
    {
        getUrl:"/api/specialities",
        getOneUrl:"/api/specialities/",
        addUrl:"api/specialities/add",
        updateUrl:"/api/specialities/update/",
        deleteUrl:"/api/specialities/delete/"
    }

    constructor(http: DataService)
    {
        super(SpecialityService.routes,http);
    }

    public getSpecialities():Observable<SelectListItem[]>
    {
        return this.http.get("/api/specialities/select-list").map(this.extractData);
    }
}