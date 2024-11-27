import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { environment } from "../../../../environments/environment";

// Entities
import { DocumentType } from "src/app/entities/documenttype";

@Injectable({
	providedIn: "root",
})
export class DocumentTypeService {
	constructor(private http: HttpClient) { }
	GetAll(): Observable<DocumentType[]> {
		const uri = `${environment.pathLibeyTechnicalTest}DocumentType`;
		return this.http.get<DocumentType[]>(uri);
	}
}