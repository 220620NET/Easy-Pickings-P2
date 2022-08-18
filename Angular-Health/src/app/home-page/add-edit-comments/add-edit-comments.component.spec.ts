import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditCommentsComponent } from './add-edit-comments.component';

describe('AddEditCommentsComponent', () => {
  let component: AddEditCommentsComponent;
  let fixture: ComponentFixture<AddEditCommentsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEditCommentsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddEditCommentsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
