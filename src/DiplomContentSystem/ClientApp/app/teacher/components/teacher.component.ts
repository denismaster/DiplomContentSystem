import { Component } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'teachers',
    templateUrl: './teacher.component.html'
})
export class TeachersComponent {
    public teachers: Teacher[];

    constructor(http: Http) {
        http.get('/api/teachers').subscribe(result => {
            let teachers = result.json() as Teacher[];
            this.teachers = teachers;
        });
    }
   /* sendRequest() {
        let object = {
            "id": 1,
            "data": [
                "\\documentclass{article}\n\\begin{document}\nHello,Denismaster!\n\\end{document}\n"]
        };
        this.http.post("http://localhost:1337/api/convert",object).subscribe(data => this.downloadFile(data));
    }
    downloadFile(data: Response) {
        let blob = new Blob([data], { type: 'application/pdf' });
        let url = window.URL.createObjectURL(blob);
        FileSaver.saveAs(blob,"sample.pdf");
}*/
}

interface Teacher {
    id: number;
    fio: string;
    position: string;
    maxWorkCount: string;
}
