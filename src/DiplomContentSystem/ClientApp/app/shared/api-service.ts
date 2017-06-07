import { ServiceBase } from './service-base';
import { Observable } from 'rxjs/Observable';
import { Http } from '@angular/http';
import { OperationResult } from './operation-result';
import { DataService } from './data-service';

export interface ApiRoutes {
    getUrl: string;
    getOneUrl?: string
    addUrl?: string
    updateUrl?: string
    deleteUrl?: string
}

export interface ListResponse<T> {
    items: T[];
    totalCount: number;
    loadedCount?: number;
}
export let NotSupportedException :string = "Not Supported";

export class ApiService<T> extends ServiceBase {
    constructor(protected routes: ApiRoutes, protected http:DataService) {
        super();
    }

    public get(): Observable<T[]> {
        if (!this.routes.getUrl) {
            throw NotSupportedException;
        }
        return this.http.get(this.routes.getUrl)
            .map(this.extractData)
            .catch(this.handleError)
    }

    public getList(request): Observable<ListResponse<T>> {
        if (!this.routes.getUrl) {
            throw NotSupportedException;
        }
        return this.http.post(this.routes.getUrl,request)
            .map(this.extractData)
            .catch(this.handleError);
    }

    public getOne(id:number|string): Observable<T> {
        if (!this.routes.getOneUrl) {
            throw NotSupportedException;
        }

        let url = this.routes.getOneUrl+id;

        return this.http.get(url)
            .map(this.extractData)
            .catch(this.handleError);
    }

    public add(value:any): Observable<OperationResult> {
        if (!this.routes.addUrl) {
            throw NotSupportedException;
        }
        return this.http.post(this.routes.addUrl, value)
            .map(this.extractData)
            .catch(this.handleError);
    }

    public update(value:any): Observable<OperationResult> {
        if (!this.routes.updateUrl) {
            throw NotSupportedException;
        }
        return this.http.post(this.routes.updateUrl, value)
            .map(this.extractData)
            .catch(this.handleError);
    }
}