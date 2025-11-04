import { NgModule, provideBrowserGlobalErrorListeners } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing-module';
import { App } from './app';
import { Profile } from './features/profile/profile';
import { Header } from './header/header/header';

@NgModule({
  // array of components
  declarations: [
    App,
    Profile,
    Header,
  ],
  // array of modules
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [
    provideBrowserGlobalErrorListeners()
  ],
  // DI
  bootstrap: [App]
})
export class AppModule { }
