import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AnswersDetailsComponent } from './answers-details.component';

describe('AnswersDetailsComponent', () => {
  let component: AnswersDetailsComponent;
  let fixture: ComponentFixture<AnswersDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AnswersDetailsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AnswersDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
