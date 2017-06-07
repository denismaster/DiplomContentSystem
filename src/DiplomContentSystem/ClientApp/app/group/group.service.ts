import { Injectable } from "@angular/core";
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Group } from './models/group';
import { ServiceBase } from '../shared/service-base';
import { OperationResult } from '../shared/operation-result';
import { ApiService, ApiRoutes } from '../shared/api-service';
import { DataService } from '../shared/data-service';
import { SelectListItem } from '../shared/select-list-item';

@Injectable()
export class GroupService extends ApiService<Group>{
    protected static routes:ApiRoutes = 
    {
        getUrl:"/api/groups",
        getOneUrl:"/api/groups/",
        addUrl:"api/groups/add",
        updateUrl:"/api/groups/update/",
        deleteUrl:"/api/groups/delete/"
    }

    constructor(http: DataService)
    {
        super(GroupService.routes,http);
    }

    public getSpecialities():Observable<SelectListItem[]>
    {
        return this.http.get("/api/specialities/select-list").map(this.extractData);
    }
}