import { Routes } from '@angular/router';
import { ExaminationPage } from './pages/examination/examination';
import { QuestionPage } from './pages/question/question';

export const routes: Routes = [
  {
    path: 'question',
    component: QuestionPage,
  },
  {
    path: 'examination',
    component: ExaminationPage,
  },
  {
    path: '',
    redirectTo: 'examination',
    pathMatch: 'full',
  },
  {
    path: '**',
    redirectTo: 'examination',
  },
];