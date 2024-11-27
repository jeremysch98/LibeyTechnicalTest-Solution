import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { environment } from "../../../../environments/environment";

// Entities
import { Ubigeo } from "src/app/entities/ubigeo";

@Injectable({
	providedIn: "root",
})
export class UbigeoService {
	constructor(private http: HttpClient) { }
	GetByRegionProvince(regionCode: string, provinceCode: string): Observable<Ubigeo[]> {
		const uri = `${environment.pathLibeyTechnicalTest}Ubigeo/GetByRegionProvince/${regionCode}/${provinceCode}`;
		return this.http.get<Ubigeo[]>(uri);
	}
}