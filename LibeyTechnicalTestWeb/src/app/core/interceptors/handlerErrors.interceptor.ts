import { Injectable } from '@angular/core';
import {
    HttpRequest,
    HttpHandler,
    HttpEvent,
    HttpInterceptor
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

import Swal from 'sweetalert2';

@Injectable()
export class HanlderErrorsInterceptor implements HttpInterceptor {

    constructor() { }

    intercept(
        request: HttpRequest<any>,
        next: HttpHandler
    ): Observable<HttpEvent<any>> {
        return next.handle(request).pipe(catchError(err => {
            const error = err.error || err.error.message || err.statusText;

            Swal.fire({
                title: '!Oops! !Algo salió mal!',
                text: error,
                icon: 'warning',
                showCancelButton: false,
                confirmButtonColor: '#4f46bb',
                confirmButtonText: 'Aceptar',
            });

            return throwError(error);
        }))
    }
}
