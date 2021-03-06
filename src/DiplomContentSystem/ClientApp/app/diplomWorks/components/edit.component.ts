import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { Validators, FormGroup, FormBuilder } from '@angular/forms';
import { Router,ActivatedRoute } from '@angular/router';
import { Diplom } from '../models/diplom';
import { CustomValidators } from '../../shared/custom-validators';
import { OperationResult } from '../../shared/operation-result';
import { SelectListItem } from '../../shared/select-list-item';
import { DiplomWorksService } from '../diplom-works.service';
import { File, FileList } from '../../shared/file-list/file-list';
import { AntiPlagiatResult } from './plagiat.component';

@Component({
    selector: 'diplom-view',
    templateUrl: './edit.component.html'
})
export class DiplomWorkViewComponent implements OnInit {
    private form: FormGroup;
    private errors: string[] = [];

    private specialityOptions:SelectListItem[];
    private id:number;
    private work: any = null;
    private isLoading:boolean=true;
    
    private files: FileList;

    private antiplagiatResults: AntiPlagiatResult[];

    constructor(private service: DiplomWorksService, private router: Router, private activatedRoute:ActivatedRoute, private formBuilder: FormBuilder) {
        this.id = activatedRoute.snapshot.params['id'];
        if(this.id==2)
        {
            this.files = {
                files:[
                    {
                        name:"Титульная страница.pdf",
                        size:"1"
                    }
                ]
            };
            this.antiplagiatResults = [
                {
                    date: new Date(2017,5,24,16,48),
                    result: 72
                },
                {
                    date: new Date(2017,5,29,20,45),
                    result: 97.3
                }
            ]
        }
        if(!this.id){
            router.navigateByUrl("['/404']");
        }
        this.service.getOne(this.id)
            .subscribe(result=>{
                this.isLoading=false;
                console.log(result);
                this.work = result;    
            })
    }

    ngOnInit()
    {
  
    }

    public goBack(): void {
        this.router.navigate(['diploms']);
    }

    public checkResult(result:OperationResult):void{
        if(!result.hasErrors)
        {
            this.goBack();
        }
        else
        {
            this.errors = result.errors;
        }
    }
}
