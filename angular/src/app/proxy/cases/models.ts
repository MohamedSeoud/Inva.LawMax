import { LawyerDto } from "@proxy/lawyers/models";

export interface CaseDto {
  id: string;
  number: string;
  year: number;
  litigationDegree: string;
  finalVerdict: string;
  lawyerId: string;
  lawyer?: LawyerDto;
}

export interface CreateUpdateCaseDto {
  number: string;
  year: number;
  litigationDegree: string;
  finalVerdict: string;
  lawyerId: string;
}
