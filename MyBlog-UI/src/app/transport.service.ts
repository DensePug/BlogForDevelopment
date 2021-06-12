import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpParams } from '@angular/common/http';
import { ApiRequest } from './models/ApiRequest';
import { throwError } from 'rxjs';
import { environment } from '../environments/environment';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class TransportService {

  constructor(private httpClient: HttpClient) { }

  post(route: string, request: ApiRequest) {
    return this.httpClient.post(`${environment.apiUrl}${route}`, request).pipe(catchError(this.handleError));
  }

  get(route: string, params: any = null) {
    return this.httpClient.get(`${environment.apiUrl}${route}`, { params: params }).pipe(catchError(this.handleError));
  }

  patch(route: string, body: ApiRequest, params: any = null) {
    return this.httpClient.patch(`${environment.apiUrl}${route}`, body, { params: params }).pipe(catchError(this.handleError));
  }

  handleError(error: HttpErrorResponse) {
    console.error(error.error);
    return throwError(error);
  }
}
