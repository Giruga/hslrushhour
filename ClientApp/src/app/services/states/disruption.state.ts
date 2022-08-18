import { Injectable } from "@angular/core";
import { BehaviorSubject, Observable } from "rxjs";
import { DisruptionDto } from "src/app/models/Disruption";

@Injectable({
  providedIn: 'root',
})
export class DisruptionState {
    private disruptions = new BehaviorSubject<DisruptionDto[] | undefined>(undefined);
    disruptions$ = new Observable<DisruptionDto[] | undefined>();

    constructor() {        
        this.disruptions$ = this.disruptions.asObservable();
    }

    saveDisruptions(data: DisruptionDto[]) {
        this.disruptions.next(data);
    }
}
