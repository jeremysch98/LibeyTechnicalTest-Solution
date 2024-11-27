import swal from 'sweetalert2';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

// Entities
import { LibeyUser } from 'src/app/entities/libeyuser';

// Services
import { LibeyUserService } from 'src/app/core/service/libeyuser/libeyuser.service';

@Component({
  selector: 'app-usermaintenance',
  templateUrl: './userlist.component.html',
  styleUrls: ['./userlist.component.css']
})
export class UserlistComponent implements OnInit {
  LibeyUsers: LibeyUser[] = [];

  constructor(
    private _router: Router,
    private _libeyUserService: LibeyUserService,
  ) { }
  ngOnInit(): void {
    this.GetLibeyUsers();
  }

  GetLibeyUsers() {
    this._libeyUserService.GetAll().subscribe(r => {
      this.LibeyUsers = r;
    });
  }

  onRedirectToCard() {
    this._router.navigate(['user']);
  }

  onRedirectToMaintenance(documentNumber: string) {
    this._router.navigate([`user/maintenance/${documentNumber}`]);
  }
}