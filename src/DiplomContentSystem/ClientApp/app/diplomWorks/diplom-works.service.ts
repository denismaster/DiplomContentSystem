import { Injectable } from "@angular/core";
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { ServiceBase } from '../shared/service-base';
import { OperationResult } from '../shared/operation-result';
import { ApiService, ApiRoutes } from '../shared/api-service';
import { Diplom } from './models/diplom';
import { DataService } from '../shared/data-service';

@Injectable()
export class DiplomWorksService extends ApiService<Diplom>{
    protected static routes:ApiRoutes = 
    {
        getUrl:"/api/diploms",
        getOneUrl:"/api/diploms/",
        addUrl:"api/diploms/add",
        updateUrl:"/api/diploms/update/",
        deleteUrl:"/api/diploms/delete/"
    }
    constructor(http: DataService)
    {
        super(DiplomWorksService.routes,http);
    }
}