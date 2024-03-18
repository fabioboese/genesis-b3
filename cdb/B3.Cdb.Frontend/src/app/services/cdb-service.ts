import { HttpClient, HttpErrorResponse, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, catchError, throwError } from "rxjs";
import { Operation } from "../model/operation";
import { Position } from "../model/position";

@Injectable({
  providedIn: 'root'
})
export class CdbService {

  constructor(private http: HttpClient) {

  }

  calculatePosition(operation : Operation) : Observable<Position> {
    const calculatePositionUrl = 'http://localhost:5236/Invest'

    return this.http.post<Position>(calculatePositionUrl, operation)
        //.pipe(catchError(this.handleError))
  }

  private handleError(error: HttpErrorResponse){
    let errorMessage = 'An unknown error occurred!';
    if (error.error instanceof ErrorEvent) {
      // Client-side error
      errorMessage = `Error: ${error.error.message}`;
    } else {
      // Server-side error
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    return throwError(errorMessage);
  }
}