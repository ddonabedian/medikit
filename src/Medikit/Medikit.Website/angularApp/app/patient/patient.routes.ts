import { RouterModule, Routes } from '@angular/router';
import { ListPatientComponent } from './list//list-patient.component';
import { AddPatientComponent } from './add/add-patient.component';
import { ViewPatientComponent } from './view/view-patient.component';

const routes: Routes = [
    { path: '', component: ListPatientComponent },
    { path: 'add', component: AddPatientComponent },
    { path: ':id', component: ViewPatientComponent }
];

export const PatientRoutes = RouterModule.forChild(routes);