import { Component, OnInit, ViewChild } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { Observable } from 'rxjs';
import { switchMap } from 'rxjs/operators';
import { LawyerDto } from '@proxy/lawyers/models';
import { LawyerService } from '@proxy/lawyers/lawyer.service';

@Component({
  selector: 'app-lawyer',
  templateUrl: './lawyers.component.html',
  styleUrls: ['./lawyers.component.scss'],
})
export class LawyerComponent implements OnInit {
  isModalOpen = false;
  selectedLawyer: LawyerDto = {} as LawyerDto;
  form: FormGroup;
  lawyers$: Observable<LawyerDto[]>;
  totalCount = 0;
  page = 1;
  pageSize = 10;
  isLoading = false;

  @ViewChild('modalContent') modalContent: any;

  constructor(
    private modalService: NgbModal,
    private lawyerService: LawyerService,
    private fb: FormBuilder,
    private confirmation: ConfirmationService
  ) {}

  ngOnInit() {
    this.loadLawyers();
  }

  loadLawyers() {
    this.isLoading = true;
    this.lawyers$ = this.lawyerService.getList() as Observable<LawyerDto[]>
     (this.lawyerService.getList() as Observable<LawyerDto[]>)
      .pipe(
        switchMap(response => {
          this.totalCount = (response as LawyerDto[]).length;
          this.isLoading = false;
          console.log('items',response)
          return response as LawyerDto[];
        })
      );
  }

  createLawyer() {
    this.selectedLawyer = {} as LawyerDto;
    this.buildForm();
    this.isModalOpen = true;
    this.modalService.open(this.modalContent, { size: 'lg' });
  }

  editLawyer(id: string) {
    this.lawyerService.get(id).subscribe((lawyer) => {
      this.selectedLawyer = lawyer;
      this.buildForm();
      this.isModalOpen = true;
      this.modalService.open(this.modalContent, { size: 'lg' });
    });
  }

  delete(id: string) {
    this.confirmation.warn('Are you sure you want to delete this lawyer?', 'Confirm Deletion').subscribe((status) => {
      if (status === Confirmation.Status.confirm) {
        this.lawyerService.delete(id).subscribe(() => this.loadLawyers());
      }
    });
  }

  buildForm() {
    this.form = this.fb.group({
      name: [this.selectedLawyer.name || '', Validators.required],
      position: [this.selectedLawyer.position || '', Validators.required],
      mobile: [this.selectedLawyer.mobile || '', Validators.required],
      address: [this.selectedLawyer.address || '', Validators.required],
    });
  }

  save() {
    if (this.form.invalid) {
      return;
    }

    const request = this.selectedLawyer.id
      ? this.lawyerService.update(this.selectedLawyer.id, this.form.value)
      : this.lawyerService.create(this.form.value);

    request.subscribe(() => {
      this.isModalOpen = false;
      this.form.reset();
      this.loadLawyers();
    });
  }

  onPageChange(page: number) {
    this.page = page;
    this.loadLawyers();
  }
}
