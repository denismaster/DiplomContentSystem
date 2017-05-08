import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { Validators, FormGroup, FormBuilder } from '@angular/forms';
import { Router,ActivatedRoute } from '@angular/router';
import { UserService } from '../user.service';
import { User } from '../models/user';
import { CustomValidators } from '../../shared/custom-validators';
import { OperationResult } from '../../shared/operation-result';
import { SelectListItem } from '../../shared/select-list-item';

@Component({
    selector: 'users-edit',
    templateUrl: './edit.component.html'
})
export class UsersEditComponent implements OnInit {
    private form: FormGroup;
    private errors: string[] = [];

    private positionOptions:SelectListItem[];
    private departmentOptions:SelectListItem[];
    private id:number;
    private user: User;
    private isLoading:boolean=true;

    constructor(private service: UserService, private router: Router, private activatedRoute:ActivatedRoute, private formBuilder: FormBuilder) {
        this.id = activatedRoute.snapshot.params['id'];
        if(!this.id){
            router.navigateByUrl("['/404']");
        }
        this.service.getOne(this.id)
            .subscribe(result=>{
                this.isLoading=false;
                this.form = this.formBuilder.group({
                    "login": [result.login, Validators.compose([Validators.required, CustomValidators.notEmpty()])],
                    "password":[null, Validators.required]
                });        
            })
    }

    ngOnInit()
    {
        this.form = this.formBuilder.group({
                    "login": [undefined],
                });   
        this.service.getPositions().subscribe(r=>this.positionOptions = r);
        this.service.getDepartments().subscribe(r=>this.departmentOptions = r);
    }

    private submit(value: any): void {
        event.preventDefault();

        const user = new User();
        user.id = this.id;
        user.login = value.login;
        
        this.service.update(user).subscribe(result=>this.checkResult(result));
    }

    public goBack(): void {
        this.router.navigate(['/users']);
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
