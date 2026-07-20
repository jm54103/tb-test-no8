import { ComponentFixture, TestBed } from '@angular/core/testing';

import { QuestionPage } from './question';

describe('Question', () => {
  let component: QuestionPage;
  let fixture: ComponentFixture<QuestionPage>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [QuestionPage],
    }).compileComponents();

    fixture = TestBed.createComponent(QuestionPage);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
