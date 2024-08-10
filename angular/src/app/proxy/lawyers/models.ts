export interface LawyerDto {
  id: string;
  name: string;
  position: string;
  mobile: string;
  address: string;
}

export interface CreateUpdateLawyerDto {
  name: string;
  position: string;
  mobile: string;
  address: string;
}
