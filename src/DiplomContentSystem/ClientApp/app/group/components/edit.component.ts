import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { Validators, FormGroup, FormBuilder } from '@angular/forms';
import { Router,ActivatedRoute } from '@angular/router';
import { Group } from '../models/group';
import { CustomValidators } from '../../shared/custom-validators';
import { OperationResult } from '../../shared/operation-result';
import { SelectListItem } from '../../shared/select-list-item';
import { GroupService } from '../group.service';

@Component({
    selector: 'group-edit',
    templateUrl: './edit.component.html'
})
export class GroupEditComponent implements OnInit {
    private form: FormGroup;
    private errors: string[] = [];

    private specialityOptions:SelectListItem[];
    private id:number;
    private group: Group;
    private isLoading:boolean=true;

    constructor(private service: GroupService, private router: Router, private activatedRoute:ActivatedRoute, private formBuilder: FormBuilder) {
        this.id = activatedRoute.snapshot.params['id'];
        if(!this.id){
            router.navigateByUrl("['/404']");
        }
        this.service.getOne(this.id)
            .subscribe(result=>{
                this.isLoading=false;
                this.form = this.formBuilder.group({
                    "name": [result.name, Validators.compose([Validators.required, CustomValidators.notEmpty()])],
                    "speciality": [result.specialityId, Validators.required],
                });        
            })
    }

    ngOnInit()
    {
        this.form = this.formBuilder.group({
                    "name": [undefined],
                    "speciality": [undefined],
                });   
        this.service.getSpecialities().subscribe(r=>this.specialityOptions = r);
    }

    private submit(value: any): void {
        event.preventDefault();

        const group = new Group();
        group.id = this.id;
        group.name = value.name;
        group.specialityId = value.speciality;
        
        this.service.update(group).subscribe(result=>this.checkResult(result));
    }

    public goBack(): void {
        this.router.navigate(['/group']);
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
