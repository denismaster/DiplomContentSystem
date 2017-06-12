import { Component, Input } from '@angular/core';
import { AuthService } from '../../login/authentication-service';

export class AntiPlagiatResult
{
    date: Date;
    result: number;
}

@Component({
    selector: 'anti-plagiat',
    templateUrl: './plagiat.component.html'
})
export class PlagiatComponent {
    @Input() public results: AntiPlagiatResult[] = [];
    constructor(private authService: AuthService) { }
}