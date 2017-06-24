import { Component, Input } from '@angular/core';
import { File, FileList } from './file-list';
import { AuthService } from '../../login/authentication-service';
@Component({
    selector: 'file-list',
    templateUrl: './file-list.component.html',
    styleUrls: ['./file-list.component.css']
})
export class FileListComponent {
    @Input() public files: File[] = [];

    @Input() public title:string = "Файлы"
    constructor(private authService: AuthService) { }

    public get count(): number {
        return this.files ? this.files.length : 0;
    }

    public typedText: string;

}