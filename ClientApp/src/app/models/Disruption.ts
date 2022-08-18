export interface DisruptionDto {
  id: string;
  header: string;
  description: string;
  start: Date;
  end: Date;
  routeProvider: string | null;
  routeNumber: string | null;
}
