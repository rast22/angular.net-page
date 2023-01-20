import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {BaseComponent} from "./components/base/base.component";
import {MainPageComponent} from "./components/main-page/main-page.component";

const routes: Routes = [{
  path: '', component: BaseComponent, children: [
    { path: 'main',component:MainPageComponent },
    { path: '', redirectTo: 'main', pathMatch: 'full' }
  ]
}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
