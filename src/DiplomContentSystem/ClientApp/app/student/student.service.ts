import { Injectable } from "@angular/core";
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { ServiceBase } from '../shared/service-base';
import { OperationResult } from '../shared/operation-result';
import { ApiService, ApiRoutes } from '../shared/api-service';
import { Student } from './models/student';

@Injectable()
export class StudentService extends ApiService<Student>{
    protected static routes:ApiRoutes = 
    {
        getUrl:"/api/students",
        getOneUrl:"/api/students/",
        addUrl:"api/students/add",
        updateUrl:"/api/students/update/",
        deleteUrl:"/api/students/delete/"
    }
    constructor(http: Http)
    {
        super(StudentService.routes,http);
    }
}