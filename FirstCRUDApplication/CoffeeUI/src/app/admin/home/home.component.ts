import { Component } from '@angular/core';
import { Chart, ChartData, Point } from "chart.js";
import { OnInit } from "@angular/core";

@Component({
    selector: 'home-admin',
    templateUrl: './home.component.html'
})

export class HomeAdminComponent  {
  chartOptions = {
    responsive: true
  };

  chartData = [
    { data: [330, 600, 260, 700], label: 'New users' },
    { data: [120, 455, 100, 340], label: 'New posts' }
  ];

  chartLabels = ['January', 'February', 'Mars', 'April'];

}
