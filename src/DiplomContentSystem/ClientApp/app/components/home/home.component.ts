import { Component, OnInit } from '@angular/core';
import { DiplomWorksService } from '../../diplomWorks/diplom-works.service';

@Component({
    selector: 'home',
    templateUrl: './home.component.html'
})
export class HomeComponent implements OnInit {
  private isLoading:boolean = true;
    // Doughnut
  public doughnutChartLabels:string[] = ['Написание', 'Нормконтроль', 'Предзащита', "Рецензирование"];
  public barChartLabels:string[] = ['Написание', 'Нормконтроль', 'Предзащита', "Рецензирование"];
  public doughnutChartData:number[] = [10, 7, 7,3];
  public doughnutChartType:string = 'doughnut';
  public barChartData:any[] = [
    {data: [10,7,7,3], label: 'Число работ'},
  ];
  public barChartType:string='line';

  constructor(private service: DiplomWorksService)
  {

  }
  ngOnInit()
  {
    this.service.getDiagramData().subscribe(result=>{
     this.isLoading = false;
     console.log(result);

     this.doughnutChartData = result.data.map(d=>d.count);
     this.doughnutChartLabels = result.data.map(d=>d.barLabel);
    });
  }
  // events
  public chartClicked(e:any):void {
   // console.log(e);
  }
 
  public chartHovered(e:any):void {
    //console.log(e);
  }
}
