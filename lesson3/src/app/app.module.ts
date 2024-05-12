import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CursComponent } from './components/curs/curs.component';
import { LoginCursComponent } from './components/login-curs/login-curs.component';

@NgModule({
  declarations: [
    AppComponent,
    CursComponent,
    LoginCursComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [
    provideClientHydration()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
