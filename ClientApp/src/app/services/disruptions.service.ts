import { Injectable, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { DisruptionApi } from './api/disruption.api';
import { DisruptionDto } from '../models/Disruption';
import { DisruptionState } from './states/disruption.state';

@Injectable({
  providedIn: 'root',
})
export class DisruptionService {
  disruptions$: Observable<DisruptionDto[] | undefined>;

  constructor(
    private readonly disruptionApi: DisruptionApi,
    private readonly disruptionState: DisruptionState
  ) {
    console.log("disruptionService")

    this.disruptions$ = this.disruptionState.disruptions$;

    this.disruptionApi.getDisruptions().subscribe((x) => {
      console.log(x);
      this.disruptionState.saveDisruptions(x);
    });
  }
}
