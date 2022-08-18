import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AppEditPolicyComponent } from './app-edit-policy.component';

describe('AppEditPolicyComponent', () => {
  let component: AppEditPolicyComponent;
  let fixture: ComponentFixture<AppEditPolicyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AppEditPolicyComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AppEditPolicyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
