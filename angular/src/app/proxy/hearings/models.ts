import { CaseDto } from "@proxy/cases/models";

// src/app/proxy/hearings/models.ts
export interface HearingDto {
  id: string;
  date: string;
  decision: string;
  caseId: string;
  case?: CaseDto;
}

export interface CreateUpdateHearingDto {
  date: string;
  decision: string;
  caseId: string;
}
