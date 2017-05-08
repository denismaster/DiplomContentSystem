import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { Validators, FormGroup, FormBuilder } from '@angular/forms';
import { Router,ActivatedRoute } from '@angular/router';
import { Diplom } from '../models/diplom';
import { CustomValidators } from '../../shared/custom-validators';
import { OperationResult } from '../../shared/operation-result';
import { SelectListItem } from '../../shared/select-list-item';
import { DiplomWorksService } from '../diplom-works.service';

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

    constructor(private service: DiplomWorksService, private router: Router, private activatedRoute:ActivatedRoute, private formBuilder: FormBuilder) {
        this.id = activatedRoute.snapshot.params['id'];
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
