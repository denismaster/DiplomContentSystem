import { Injectable } from '@angular/core';
import { ApiService, ApiRoutes } from '../api-service';
import { DataService } from '../data-service';
import { Observable } from 'rxjs/Observable';
import { Comment } from './comment';

@Injectable()
export class CommentService extends ApiService<Comment>{
    protected static routes:ApiRoutes = 
    {
        getUrl:"/api/comments",
        addUrl:"api/comments/add",
    }
    constructor(http: DataService)
    {
        super(CommentService.routes,http);
    }
}