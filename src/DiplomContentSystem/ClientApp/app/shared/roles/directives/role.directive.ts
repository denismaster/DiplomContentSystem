import {Inject, OnInit, Directive, ElementRef, Renderer, Input, ViewContainerRef, TemplateRef} from '@angular/core';
import { AuthService } from '../../../login/authentication-service';


@Directive({
    selector: '[user-role]',
    inputs: ['userRole']
})

export class HasRole {
    private roles: string[];
    private authorizationService: AuthService;

    private viewContainerRef: ViewContainerRef;
    private templateRef: TemplateRef<any>;
    
    constructor( @Inject(ViewContainerRef) viewContainerRef: ViewContainerRef, @Inject(TemplateRef) templateRef: TemplateRef<any>, @Inject(AuthService) authorizationService: AuthService)
    {
        this.viewContainerRef = viewContainerRef;
        this.templateRef = templateRef;
        this.authorizationService = authorizationService;
    }

    set unityHasrole(roles) {
        this.roles = roles;
        
        /*this.authorizationService.getUserRoles().subscribe(
            userRoles => {
                this.checkRoles(userRoles);
            })*/
    }

    checkRoles(userRoles) {
       /* if (this.authorizationService.hasRole(userRoles, this.roles)) {
            this.viewContainerRef.createEmbeddedView(this.templateRef);
        }
        else {
            this.viewContainerRef.clear();
        }*/
    }
}