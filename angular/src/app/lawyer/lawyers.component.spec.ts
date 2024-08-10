import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LawyerComponent } from './lawyers.component';

describe('LawyerComponent', () => {
  let component: LawyerComponent;
  let fixture: ComponentFixture<LawyerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [LawyerComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LawyerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
