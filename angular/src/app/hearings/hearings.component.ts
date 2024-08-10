// src/app/hearings/hearings.component.ts
import { Component, OnInit, ViewChild } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { CaseDto } from '@proxy/cases/models';
import { CaseService } from '@proxy/cases/case.service';
import { HearingDto } from '@proxy/hearings/models';
import { HearingService } from '@proxy/hearings/hearing.service';

@Component({
  selector: 'app-hearing',
  templateUrl: './hearings.component.html',
  styleUrls: ['./hearings.component.scss'],
})
export class HearingComponent implements OnInit {
  isModalOpen = false;
  selectedHearing: HearingDto = {} as HearingDto;
  form: FormGroup;
  hearings$: Observable<HearingDto[]>;
  cases$: Observable<CaseDto[]>;
  totalCount = 0;
  page = 1;
  pageSize = 10;
  isLoading = false;

  @ViewChild('modalContent') modalContent: any;

  constructor(
    private modalService: NgbModal,
    private hearingService: HearingService,
    private caseService: CaseService,
    private fb: FormBuilder
  ) {}

  ngOnInit() {
    this.loadHearings();
    this.loadCases();
  }

  loadHearings() {
    this.isLoading = true;
    this.hearings$ = this.hearingService.getList();
    this.hearings$.subscribe((response) => {
      this.totalCount = response.length;
      this.isLoading = false;
    });
  }

  loadCases() {
    this.cases$ = this.caseService.getList() as Observable<CaseDto[]>;  }

  createHearing() {
    this.selectedHearing = {} as HearingDto;
    this.buildForm();
    this.isModalOpen = true;
    this.modalService.open(this.modalContent, { size: 'lg' });
  }

  editHearing(id: string) {
    this.hearingService.get(id).subscribe((hearingData) => {
      this.selectedHearing = hearingData;
      this.buildForm();
      this.isModalOpen = true;
      this.modalService.open(this.modalContent, { size: 'lg' });
    });
  }

  delete(id: string) {
    this.hearingService.delete(id).subscribe(() => this.loadHearings());
  }

  buildForm() {
    this.form = this.fb.group({
      date: [this.selectedHearing.date || '', Validators.required],
      decision: [this.selectedHearing.decision || '', Validators.required],
      caseId: [this.selectedHearing.caseId || '', Validators.required],
    });
  }

  save() {
    if (this.form.invalid) {
      return;
    }

    const request = this.selectedHearing.id
      ? this.hearingService.update(this.selectedHearing.id, this.form.value)
      : this.hearingService.create(this.form.value);

    request.subscribe(() => {
      this.isModalOpen = false;
      this.form.reset();
      this.loadHearings();
    });
  }

  onPageChange(page: number) {
    this.page = page;
    this.loadHearings();
  }
}
