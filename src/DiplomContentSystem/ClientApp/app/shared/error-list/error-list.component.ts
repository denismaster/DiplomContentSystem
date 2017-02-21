import { Component, Input } from '@angular/core';
@Component({
    selector: 'error-list',
    templateUrl: './error-list.component.html'
})
export class ErrorListComponent  {
    @Input() public errors: string[];
}