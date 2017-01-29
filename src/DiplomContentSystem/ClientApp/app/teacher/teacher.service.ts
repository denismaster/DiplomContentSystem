import { Injectable } from "@angular/core";
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Teacher } from './components/teacher.component';
import { ServiceBase } from '../shared/service-base';

@Injectable()
export class TeacherService extends ServiceBase{
    constructor(private http: Http)
    {
        super();
    }

    public getTeachers():Observable<Teacher[]>
    {
        return this.http.get('/api/teachers').map(this.extractData);
    }
}