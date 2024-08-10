import { Component, OnInit, ViewChild } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { switchMap } from 'rxjs/operators';
import { LawyerDto } from '@proxy/lawyers/models';
import { LawyerService } from '@proxy/lawyers/lawyer.service';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { CaseDto } from '@proxy/cases/models';
import { CaseService } from '@proxy/cases/case.service';

@Component({
  selector: 'app-case',
  templateUrl: './cases.component.html',
  styleUrls: ['./cases.component.scss'],
})
export class CaseComponent implements OnInit {
  isModalOpen = false;
  selectedCase: CaseDto = {} as CaseDto;
  form: FormGroup;
  cases$: Observable<CaseDto[]>;
  lawyers$: Observable<LawyerDto[]>;
  totalCount = 0;
  page = 1;
  pageSize = 10;
  isLoading = false;

  @ViewChild('modalContent') modalContent: any;

  constructor(
    private modalService: NgbModal,
    private caseService: CaseService,
    private lawyerService: LawyerService,
    private fb: FormBuilder,
    private confirmation: ConfirmationService
  ) {}

  ngOnInit() {
    this.loadCases();
    this.loadLawyers();
  }

  loadCases() {
    this.isLoading = true;
    this.cases$ = this.caseService.getList() as Observable<CaseDto[]>;
    console.log('cases$',this.cases$)
    const x = this.caseService.getList().pipe(
      switchMap(response => {
        console.log('ressss',response)
        this.totalCount = response.length;
        this.isLoading = false;
        return response;
      })
    );
  }

  loadLawyers() {
    this.lawyers$ = this.lawyerService.getList() as Observable<LawyerDto[]>

    console.log('lawyers$',this.lawyers$);
  }

  createCase() {
    this.selectedCase = {} as CaseDto;
    this.buildForm();
    this.isModalOpen = true;
    this.modalService.open(this.modalContent, { size: 'lg' });
  }

  editCase(id: string) {
    this.caseService.get(id).subscribe((caseData) => {
      this.selectedCase = caseData;
      this.buildForm();
      this.isModalOpen = true;
      this.modalService.open(this.modalContent, { size: 'lg' });
    });
  }

  delete(id: string) {
    this.confirmation.warn('Are you sure you want to delete this case?', 'Confirm Deletion').subscribe((status) => {
      if (status === Confirmation.Status.confirm) {
        this.caseService.delete(id).subscribe(() => this.loadCases());
      }
    });
  }

  buildForm() {
    this.form = this.fb.group({
      number: [this.selectedCase.number || '', Validators.required],
      year: [this.selectedCase.year || '', Validators.required],
      litigationDegree: [this.selectedCase.litigationDegree || '', Validators.required],
      finalVerdict: [this.selectedCase.finalVerdict || '', Validators.required],
      lawyerId: [this.selectedCase.lawyerId || '', Validators.required],
    });
  }

  save() {
    if (this.form.invalid) {
      return;
    }

    const request = this.selectedCase.id
      ? this.caseService.update(this.selectedCase.id, this.form.value)
      : this.caseService.create(this.form.value);

    request.subscribe(() => {
      this.isModalOpen = false;
      this.form.reset();
      this.loadCases();
    });
  }

  onPageChange(page: number) {
    this.page = page;
    this.loadCases();
  }
}
