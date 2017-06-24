import { Injectable } from "@angular/core";
import { Http, ResponseContentType } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { CalendarEvent } from './models/calendar';
import { ServiceBase } from '../shared/service-base';
import { OperationResult } from '../shared/operation-result';
import { ApiService, ApiRoutes } from '../shared/api-service';
import { DataService } from '../shared/data-service';
import { SelectListItem } from '../shared/select-list-item';

@Injectable()
export class CalendarService extends ApiService<CalendarEvent>{
    protected static routes:ApiRoutes = 
    {
        getUrl:"/api/calendar",
        getOneUrl:"/api/calendars/",
        addUrl:"api/calendars/add",
        updateUrl:"/api/calendars/update/",
        deleteUrl:"/api/calendars/delete/"
    }
    
    constructor(http: DataService)
    {
        super(CalendarService.routes,http);
    }

     public getStages(id:number):Observable<any>
    {
        return this.http.get("/api/calendar/"+id).map(this.extractData);
    }

    public getCalendarFile(id:number)
    {
        return this.http.post("/api/documents/calendar/"+id,true,null, ResponseContentType.Blob);
    }

    public getSpecialities():Observable<SelectListItem[]>
    {
        return this.http.get("/api/specialities/select-list").map(this.extractData);
    }
}