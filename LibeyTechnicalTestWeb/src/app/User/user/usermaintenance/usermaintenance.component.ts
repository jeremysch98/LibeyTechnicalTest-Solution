import swal from 'sweetalert2';
import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  Validators
} from '@angular/forms'
import {
  Router,
  ActivatedRoute
} from '@angular/router';

// Entities
import { DocumentType } from 'src/app/entities/documenttype';
import { Region } from 'src/app/entities/region';
import { Province } from 'src/app/entities/province';
import { Ubigeo } from 'src/app/entities/ubigeo';
import { LibeyUser } from 'src/app/entities/libeyuser';

// Services
import { DocumentTypeService } from 'src/app/core/service/documenttype/documenttype.service';
import { RegionService } from 'src/app/core/service/region/region.service';
import { ProvinceService } from 'src/app/core/service/province/province.service';
import { UbigeoService } from 'src/app/core/service/ubigeo/ubigeo.service';
import { LibeyUserService } from 'src/app/core/service/libeyuser/libeyuser.service';

@Component({
  selector: 'app-usermaintenance',
  templateUrl: './usermaintenance.component.html',
  styleUrls: ['./usermaintenance.component.css']
})
export class UsermaintenanceComponent implements OnInit {
  submitted: boolean = false;
  userForm: FormGroup;

  documentNumber: string = "";

  DocumentTypes: DocumentType[] = [];
  Regions: Region[] = [];
  Provinces: Province[] = [];
  Ubigeos: Ubigeo[] = [];

  constructor(
    private _formBuilder: FormBuilder,
    private _router: Router,
    private _activatedRoute: ActivatedRoute,
    private _documentTypeService: DocumentTypeService,
    private _regionService: RegionService,
    private _provinceService: ProvinceService,
    private _ubigeoService: UbigeoService,
    private _libeyUserService: LibeyUserService,
  ) { }
  ngOnInit(): void {
    this._activatedRoute.params.subscribe(p => {
      this.documentNumber = p['documentNumber'] || "";

      this.userForm = this._formBuilder.group({
        documentNumber: ['', [Validators.required, Validators.maxLength(20)]],
        documentTypeId: [undefined, [Validators.required]],
        name: ['', [Validators.maxLength(100)]],
        fathersLastName: ['', [Validators.maxLength(100)]],
        mothersLastName: ['', [Validators.maxLength(100)]],
        address: ['', [Validators.maxLength(100)]],
        regionCode: [undefined],
        provinceCode: [undefined],
        ubigeoCode: [undefined],
        phone: ['', [Validators.maxLength(20)]],
        email: ['', [Validators.email, Validators.maxLength(20)]],
        password: ['', [Validators.maxLength(20)]],
        active: [true]
      });

      this.uf['documentNumber'].enable();
      this.uf['documentTypeId'].enable();

      if (this.documentNumber)
        this.InitializeForm();
    });



    this.GetDocumentTypes();
    this.GetRegions();
  }

  get uf() {
    return this.userForm.controls;
  }

  InitializeForm() {
    this._libeyUserService.Find(this.documentNumber).subscribe(r => {
      this.uf['documentNumber'].disable();
      this.uf['documentTypeId'].disable();

      const action = r.active ? 'enable' : 'disable';
      this.uf['name'][action]();
      this.uf['fathersLastName'][action]();
      this.uf['mothersLastName'][action]();
      this.uf['address'][action]();
      this.uf['regionCode'][action]();
      this.uf['provinceCode'][action]();
      this.uf['ubigeoCode'][action]();
      this.uf['phone'][action]();
      this.uf['email'][action]();
      this.uf['password'][action]();

      if (r) {
        this.userForm.patchValue({
          documentNumber: r.documentNumber,
          documentTypeId: r.documentTypeId,
          name: r.name,
          fathersLastName: r.fathersLastName,
          mothersLastName: r.mothersLastName,
          address: r.address,
          regionCode: r.regionCode,
          provinceCode: r.provinceCode,
          ubigeoCode: r.ubigeoCode,
          phone: r.phone,
          email: r.email,
          password: r.password,
          active: r.active,
        });

        this.GetProvincesByRegion(r.regionCode);
        this.GetUbigeosByRegionProvince(r.regionCode, r.provinceCode);

        return
      }

      swal.fire("Oops!", "Usuario no encontrado", "warning");
    });
  }

  GetDocumentTypes() {
    this._documentTypeService.GetAll().subscribe(r => {
      this.DocumentTypes = r;
    });
  }

  GetRegions() {
    this._regionService.GetAll().subscribe(r => {
      this.Regions = r;
    });
  }

  GetProvincesByRegion(regionCode: string) {
    this._provinceService.GetByRegion(regionCode).subscribe(r => {
      this.Provinces = r;
    });
  }

  GetUbigeosByRegionProvince(regionCode: string, provinceCode: string) {
    this._ubigeoService.GetByRegionProvince(regionCode, provinceCode).subscribe(r => {
      this.Ubigeos = r;
    });
  }

  onChangeRegion(regionCode: string) {
    this.Provinces = [];
    this.userForm.get('provinceCode').setValue(undefined);

    this.Ubigeos = [];
    this.userForm.get('ubigeoCode').setValue(undefined);

    if (!regionCode) return;

    this.GetProvincesByRegion(regionCode);
  }

  onChangeProvince(provinceCode: string) {
    this.Ubigeos = [];
    this.userForm.get('ubigeoCode').setValue(undefined);

    if (!provinceCode) return;

    const regionCode = this.userForm.get('regionCode').value;

    this.GetUbigeosByRegionProvince(regionCode, provinceCode);
  }

  onClearForm() {
    this.userForm.reset();
    this.submitted = false;
  }

  Submit() {
    this.submitted = true;

    if (this.userForm.invalid) return;

    const userFormValue = this.userForm.getRawValue();
    const row: LibeyUser = {
      documentNumber: userFormValue.documentNumber,
      documentTypeId: userFormValue.documentTypeId,
      name: userFormValue.name,
      fathersLastName: userFormValue.fathersLastName,
      mothersLastName: userFormValue.mothersLastName,
      address: userFormValue.address,
      ubigeoCode: userFormValue.ubigeoCode,
      phone: userFormValue.phone,
      email: userFormValue.email,
      password: userFormValue.password
    }


    if (!this.documentNumber)
      this.Create(row);
    else {
      row.active = userFormValue.active;
      this.Update(row);
    }
  }

  Create(row: LibeyUser) {
    this._libeyUserService.Create(row).subscribe(r => {
      if (r) {
        swal.fire("Éxito", "Usuario creado exitosamente.", "success");

        this.onClearForm();

        return
      }

      swal.fire("Oops!", "No se pudo crear el usuario.", "error");
    });
  }

  Update(row: LibeyUser) {
    this._libeyUserService.Update(row).subscribe(r => {
      if (r) {
        swal.fire("Éxito", "Usuario actualizado exitosamente.", "success");

        this.InitializeForm();

        return
      }

      swal.fire("Oops!", "No se pudo actualizar el usuario.", "error");
    });
  }

  onRedirectToCard() {
    if (this.documentNumber) {
      this._router.navigate(['user/list']);
      return
    }

    this._router.navigate(['user']);
  }
}