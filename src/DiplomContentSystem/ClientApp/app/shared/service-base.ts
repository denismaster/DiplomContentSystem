﻿import {Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import '../operators.ts';

//Абстрактный класс для любого сервиса. Предоставляет функцию извлечения данных и базовую обработку ошибок(see Angular Guide)
export class ServiceBase
{
    //извлечение данных
    protected extractData(res: Response) {
        let body = res.json();
        return body || {};
    }

    //базовая обработка ошибок.
    protected handleError(error: Response | any) {
        // In a real world app, we might use a remote logging infrastructure
        let errMsg: string;
        if (error instanceof Response) {
            const body = error.json() || '';
            const err = body.error || JSON.stringify(body);
            errMsg = `${error.status} - ${error.statusText || ''} ${err}`;
        } else {
            errMsg = error.message ? error.message : error.toString();
        }
        console.error(errMsg);
        return Observable.throw(errMsg);
    }
}