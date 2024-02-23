
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RegistrationComponent } from './MyComponent/registration/registration.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { ResetDataComponent } from './MyComponent/reset-data/reset-data.component';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {path: '',component: RegistrationComponent},
  {path:'ResetPassword', component: ResetDataComponent}
  
]

@NgModule({
  declarations: [
    AppComponent,
    RegistrationComponent,
    ResetDataComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot(routes)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }