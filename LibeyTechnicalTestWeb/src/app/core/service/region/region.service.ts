import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { environment } from "../../../../environments/environment";

// Entities
import { Region } from "src/app/entities/region"; 

@Injectable({
	providedIn: "root",
})
export class RegionService {
	constructor(private http: HttpClient) { }
	GetAll(): Observable<Region[]> {
		const uri = `${environment.pathLibeyTechnicalTest}Region`;
		return this.http.get<Region[]>(uri);
	}
}