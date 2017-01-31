import { Injectable } from "@angular/core";
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Teacher } from './models/teacher';
import { ServiceBase } from '../shared/service-base';
import { OperationResult } from '../shared/operation-result';

@Injectable()
export class TeacherService extends ServiceBase{
    constructor(private http: Http)
    {
        super();
    }

    public addTeacher(teacher:Teacher):Observable<OperationResult>
    {
        console.log(teacher);
        return this.http.post('/api/teachers/add',teacher).map(this.extractData);
    }

    public getTeachers():Observable<Teacher[]>
    {
        return this.http.get('/api/teachers').map(this.extractData);
    }
}