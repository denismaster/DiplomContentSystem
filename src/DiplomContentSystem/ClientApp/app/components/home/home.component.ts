import { Component } from '@angular/core';

@Component({
    selector: 'home',
    templateUrl: './home.component.html'
})
export class HomeComponent {
    // Doughnut
  public doughnutChartLabels:string[] = ['Написание', 'Нормконтроль', 'Предзащита', "Рецензирование"];
  public barChartLabels:string[] = ['Написание', 'Нормконтроль', 'Предзащита', "Рецензирование"];
  public doughnutChartData:number[] = [10, 7, 7,3];
  public doughnutChartType:string = 'doughnut';
  public barChartData:any[] = [
    {data: [10,7,7,3], label: 'Число работ'},
  ];
  public barChartType:string='line';
  // events
  public chartClicked(e:any):void {
    console.log(e);
  }
 
  public chartHovered(e:any):void {
    console.log(e);
  }
}
