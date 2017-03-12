import { Injectable } from "@angular/core";
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Stage } from './models/stage';
import { ServiceBase } from '../shared/service-base';
import { OperationResult } from '../shared/operation-result';
import { ApiService, ApiRoutes } from '../shared/api-service';

@Injectable()
export class StageService extends ApiService<Stage>{
    protected static routes: ApiRoutes =
    {
        getUrl: "/api/stages",
        getOneUrl: "/api/stages/",
        addUrl: "api/stages/add",
        updateUrl: "/api/stages/update/",
        deleteUrl: "/api/stages/delete/"
    }
    constructor(http: Http) {
        super(StageService.routes, http);
    }
}