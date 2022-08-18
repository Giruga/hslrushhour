import { Component } from '@angular/core';
import { DisruptionDto } from 'src/app/models/Disruption';
import { DisruptionService } from 'src/app/services/disruptions.service';

@Component({
  selector: 'disruptions',
  templateUrl: './disruptions.component.html',
})
export class DisruptionsComponent {
  disruptions: DisruptionDto[] = [];
  displayedColumns: string[] = [
    'header',
    'description',
    'start',
    'end',
    'routeProvider',
    'routeNumber',
  ];

  constructor(private readonly disruptionService: DisruptionService) {
    console.log("disruptionComponent")
    this.disruptionService.disruptions$.subscribe((x) => {
      this.disruptions = x ?? [];
    });
  }
}
