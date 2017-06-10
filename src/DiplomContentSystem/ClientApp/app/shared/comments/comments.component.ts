import { Component, Input } from '@angular/core';
import { Comment } from './comment';
import { AuthService } from '../../login/authentication-service';
@Component({
    selector: 'comments',
    templateUrl: './comments.component.html'
})
export class CommentsComponent  {
    @Input() public comments: Comment[]=[];

    @Input() public isFolded: boolean = true;

    constructor(private authService:AuthService ) {}

    public get count():number
    {
        return this.comments?this.comments.length : 0;
    }

    public typedText:string;

    public addComment():void
    {
        if(!this.typedText||!this.typedText.trim()) return;
        const user = this.authService.getCurrentUser();
        if(!user) return;
        
        const comment = {
            text:this.typedText,
            user: user.Username,
            date: new Date()
        }
        this.comments.push(comment);
        this.typedText = null;

    }

}