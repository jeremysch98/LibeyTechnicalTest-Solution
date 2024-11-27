import { NgModule } from "@angular/core";
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { BrowserModule } from "@angular/platform-browser";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { RouterModule } from "@angular/router";
import { UserModule } from "./User/user/user.module";
import { HanlderErrorsInterceptor } from "./core/interceptors/handlerErrors.interceptor";
@NgModule({
	declarations: [AppComponent],
	imports: [BrowserModule, AppRoutingModule, BrowserAnimationsModule, RouterModule, HttpClientModule, UserModule],
	providers: [{
		provide: HTTP_INTERCEPTORS,
		useClass: HanlderErrorsInterceptor,
		multi: true
	},
	],
	bootstrap: [AppComponent],
})
export class AppModule { }