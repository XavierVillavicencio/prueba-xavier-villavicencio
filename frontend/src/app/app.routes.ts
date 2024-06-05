import { Routes } from '@angular/router';
import { AnswersListComponent } from './answers-list/answers-list.component';
import { AnswersDetailsComponent } from './answers-details/answers-details.component';
import { ShowFormComponent } from './show-form/show-form.component';
import { AddFormComponent } from './add-form/add-form.component';
import { FormsComponent } from './forms/forms.component';

export const routes: Routes = [
    { path: 'addForm', component: AddFormComponent },
    { path: 'updateForm/:id', component: AddFormComponent },
    { path: 'show/:id', component: ShowFormComponent },
    { path: 'listForms/:id', component: FormsComponent },
    { path: 'listAnswers/:id', component: AnswersListComponent },
    { path: 'answers/:id', component: AnswersDetailsComponent },
    { path: 'personas/:1', component: AnswersDetailsComponent },
    { path: 'mascotas/:2', component: AnswersDetailsComponent },
];
